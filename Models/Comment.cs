using System.ComponentModel.DataAnnotations;

namespace GroupProject.Models;

// comments for recipes - gotta let people share their thoughts
public class Comment
{
    public int Id { get; set; }

    public int RecipeId { get; set; }

    public string UserId { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "you can't post an empty comment")]
    [StringLength(1000, ErrorMessage = "keep it under 1000 characters")]
    public string Content { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? EditedAt { get; set; }

    // optional rating with the comment
    [Range(1, 5)]
    public int? Rating { get; set; }
}
