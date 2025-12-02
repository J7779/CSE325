using System.ComponentModel.DataAnnotations;

namespace GroupProject.Models;

// user model for auth and profile stuff
public class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "username is required")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "username should be 3-50 characters")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "email is required")]
    [EmailAddress(ErrorMessage = "that doesn't look like a valid email")]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    public string? DisplayName { get; set; }

    public string? Bio { get; set; }

    public string? ProfileImageUrl { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? LastLoginAt { get; set; }

    // tracking how many recipes they've shared
    public int RecipeCount { get; set; } = 0;

    // how many followers they got
    public int FollowerCount { get; set; } = 0;
}

// for login requests
public class LoginRequest
{
    [Required(ErrorMessage = "need your email to log in")]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "password can't be empty")]
    public string Password { get; set; } = string.Empty;
}

// for new user registration
public class RegisterRequest
{
    [Required(ErrorMessage = "pick a username")]
    [StringLength(50, MinimumLength = 3)]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "we need your email")]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "gotta have a password")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "password needs to be at least 6 characters")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "confirm your password")]
    [Compare("Password", ErrorMessage = "passwords don't match")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
