using GroupProject.Models;
using GroupProject.Data;

namespace GroupProject.Services;

// service to handle recipe comments
public class CommentService
{
    private readonly List<Comment> _comments = new();
    private int _nextId = 1;

    // get all comments for a recipe
    public Task<List<Comment>> GetCommentsForRecipeAsync(int recipeId)
    {
        return Task.FromResult(_comments
            .Where(c => c.RecipeId == recipeId)
            .OrderByDescending(c => c.CreatedAt)
            .ToList());
    }

    // add a new comment
    public Task<Comment> AddCommentAsync(Comment comment)
    {
        comment.Id = _nextId++;
        comment.CreatedAt = DateTime.UtcNow;
        _comments.Add(comment);
        return Task.FromResult(comment);
    }

    // update an existing comment
    public Task<Comment?> UpdateCommentAsync(int commentId, string newContent)
    {
        var comment = _comments.FirstOrDefault(c => c.Id == commentId);
        if (comment == null)
            return Task.FromResult<Comment?>(null);

        comment.Content = newContent;
        comment.EditedAt = DateTime.UtcNow;
        return Task.FromResult<Comment?>(comment);
    }

    // delete a comment
    public Task<bool> DeleteCommentAsync(int commentId)
    {
        var comment = _comments.FirstOrDefault(c => c.Id == commentId);
        if (comment == null)
            return Task.FromResult(false);

        _comments.Remove(comment);
        return Task.FromResult(true);
    }

    // get average rating for a recipe
    public Task<double?> GetAverageRatingAsync(int recipeId)
    {
        var ratings = _comments
            .Where(c => c.RecipeId == recipeId && c.Rating.HasValue)
            .Select(c => c.Rating!.Value)
            .ToList();

        if (ratings.Count == 0)
            return Task.FromResult<double?>(null);

        return Task.FromResult<double?>(ratings.Average());
    }

    // get comment count for a recipe
    public Task<int> GetCommentCountAsync(int recipeId)
    {
        return Task.FromResult(_comments.Count(c => c.RecipeId == recipeId));
    }
}
