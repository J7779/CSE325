using System.ComponentModel.DataAnnotations;

namespace GroupProject.Models;

// the main recipe model - this is where the magic happens
public class Recipe
{
    public int Id { get; set; }

    [Required(ErrorMessage = "yo you need a title for this recipe")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "title should be between 3 and 100 chars")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "gotta describe what you're making")]
    [StringLength(2000, ErrorMessage = "keep the description under 2000 chars")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "we need the ingredients list")]
    public string Ingredients { get; set; } = string.Empty;

    [Required(ErrorMessage = "how are people supposed to make this without instructions?")]
    public string Instructions { get; set; } = string.Empty;

    [Range(1, 480, ErrorMessage = "prep time should be between 1 and 480 minutes")]
    public int PrepTimeMinutes { get; set; }

    [Range(0, 1440, ErrorMessage = "cook time should be between 0 and 1440 minutes")]
    public int CookTimeMinutes { get; set; }

    [Range(1, 50, ErrorMessage = "servings should be between 1 and 50")]
    public int Servings { get; set; } = 4;

    public string? ImageUrl { get; set; }

    [Required(ErrorMessage = "pick a category")]
    public string Category { get; set; } = string.Empty;

    public string? Cuisine { get; set; }

    public DifficultyLevel Difficulty { get; set; } = DifficultyLevel.Medium;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    // who made this masterpiece
    public string AuthorId { get; set; } = string.Empty;
    public string AuthorName { get; set; } = string.Empty;

    // keeping track of the likes
    public int LikeCount { get; set; } = 0;

    public bool IsFeatured { get; set; } = false;

    // tags for easy searching
    public string? Tags { get; set; }

    // helper prop to get total time
    public int TotalTimeMinutes => PrepTimeMinutes + CookTimeMinutes;
}

public enum DifficultyLevel
{
    Easy,
    Medium,
    Hard,
    Expert
}
