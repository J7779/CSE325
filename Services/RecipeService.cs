using GroupProject.Models;
using GroupProject.Data;

namespace GroupProject.Services;

// service to handle all the recipe CRUD operations
public class RecipeService
{
    private List<Recipe> _recipes;
    private int _nextId;

    public RecipeService()
    {
        // load up the sample recipes
        _recipes = SeedData.GetSampleRecipes();
        _nextId = _recipes.Max(r => r.Id) + 1;
    }

    // get all the recipes
    public Task<List<Recipe>> GetAllRecipesAsync()
    {
        return Task.FromResult(_recipes.OrderByDescending(r => r.CreatedAt).ToList());
    }

    // grab a single recipe by id
    public Task<Recipe?> GetRecipeByIdAsync(int id)
    {
        return Task.FromResult(_recipes.FirstOrDefault(r => r.Id == id));
    }

    // get the featured recipes for the homepage
    public Task<List<Recipe>> GetFeaturedRecipesAsync(int count = 6)
    {
        return Task.FromResult(_recipes
            .Where(r => r.IsFeatured)
            .OrderByDescending(r => r.LikeCount)
            .Take(count)
            .ToList());
    }

    // search recipes by title, description, or tags
    public Task<List<Recipe>> SearchRecipesAsync(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return GetAllRecipesAsync();

        var term = searchTerm.ToLower();
        return Task.FromResult(_recipes
            .Where(r => r.Title.ToLower().Contains(term) ||
                       r.Description.ToLower().Contains(term) ||
                       (r.Tags?.ToLower().Contains(term) ?? false) ||
                       r.Category.ToLower().Contains(term) ||
                       (r.Cuisine?.ToLower().Contains(term) ?? false))
            .ToList());
    }

    // filter recipes by category
    public Task<List<Recipe>> GetRecipesByCategoryAsync(string category)
    {
        if (string.IsNullOrWhiteSpace(category) || category == "All")
            return GetAllRecipesAsync();

        return Task.FromResult(_recipes
            .Where(r => r.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
            .ToList());
    }

    // get all unique categories
    public Task<List<string>> GetCategoriesAsync()
    {
        return Task.FromResult(_recipes
            .Select(r => r.Category)
            .Distinct()
            .OrderBy(c => c)
            .ToList());
    }

    // create a new recipe
    public Task<Recipe> CreateRecipeAsync(Recipe recipe)
    {
        recipe.Id = _nextId++;
        recipe.CreatedAt = DateTime.UtcNow;
        _recipes.Add(recipe);
        return Task.FromResult(recipe);
    }

    // update an existing recipe
    public Task<Recipe?> UpdateRecipeAsync(Recipe recipe)
    {
        var existing = _recipes.FirstOrDefault(r => r.Id == recipe.Id);
        if (existing == null)
            return Task.FromResult<Recipe?>(null);

        // update all the fields
        existing.Title = recipe.Title;
        existing.Description = recipe.Description;
        existing.Ingredients = recipe.Ingredients;
        existing.Instructions = recipe.Instructions;
        existing.PrepTimeMinutes = recipe.PrepTimeMinutes;
        existing.CookTimeMinutes = recipe.CookTimeMinutes;
        existing.Servings = recipe.Servings;
        existing.ImageUrl = recipe.ImageUrl;
        existing.Category = recipe.Category;
        existing.Cuisine = recipe.Cuisine;
        existing.Difficulty = recipe.Difficulty;
        existing.Tags = recipe.Tags;
        existing.UpdatedAt = DateTime.UtcNow;

        return Task.FromResult<Recipe?>(existing);
    }

    // delete a recipe
    public Task<bool> DeleteRecipeAsync(int id)
    {
        var recipe = _recipes.FirstOrDefault(r => r.Id == id);
        if (recipe == null)
            return Task.FromResult(false);

        _recipes.Remove(recipe);
        return Task.FromResult(true);
    }

    // toggle the like on a recipe
    public Task<int> ToggleLikeAsync(int recipeId)
    {
        var recipe = _recipes.FirstOrDefault(r => r.Id == recipeId);
        if (recipe != null)
        {
            recipe.LikeCount++;
        }
        return Task.FromResult(recipe?.LikeCount ?? 0);
    }

    // get recipes by a specific author
    public Task<List<Recipe>> GetRecipesByAuthorAsync(string authorId)
    {
        return Task.FromResult(_recipes
            .Where(r => r.AuthorId == authorId)
            .OrderByDescending(r => r.CreatedAt)
            .ToList());
    }

    // get popular recipes sorted by likes
    public Task<List<Recipe>> GetPopularRecipesAsync(int count = 10)
    {
        return Task.FromResult(_recipes
            .OrderByDescending(r => r.LikeCount)
            .Take(count)
            .ToList());
    }

    // filter by difficulty
    public Task<List<Recipe>> GetRecipesByDifficultyAsync(DifficultyLevel difficulty)
    {
        return Task.FromResult(_recipes
            .Where(r => r.Difficulty == difficulty)
            .ToList());
    }

    // get quick recipes (under 30 min total)
    public Task<List<Recipe>> GetQuickRecipesAsync()
    {
        return Task.FromResult(_recipes
            .Where(r => r.TotalTimeMinutes <= 30)
            .OrderBy(r => r.TotalTimeMinutes)
            .ToList());
    }
}
