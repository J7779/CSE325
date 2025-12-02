using GroupProject.Models;
using GroupProject.Data;
using System.Security.Cryptography;
using System.Text;

namespace GroupProject.Services;

// handles all the auth stuff - login, register, session management
public class AuthService
{
    private readonly List<User> _users;
    private User? _currentUser;
    private int _nextId;

    public AuthService()
    {
        // load sample users - also adding a simple password for demo
        _users = SeedData.GetSampleUsers();
        // update the demo users with proper password hashes
        foreach (var user in _users)
        {
            user.PasswordHash = HashPassword("password123");
        }
        _nextId = _users.Max(u => u.Id) + 1;
    }

    public User? CurrentUser => _currentUser;

    public bool IsAuthenticated => _currentUser != null;

    // register a new user
    public Task<(bool Success, string Message)> RegisterAsync(RegisterRequest request)
    {
        // check if email already exists
        if (_users.Any(u => u.Email.Equals(request.Email, StringComparison.OrdinalIgnoreCase)))
        {
            return Task.FromResult((false, "that email is already taken"));
        }

        // check if username already exists
        if (_users.Any(u => u.Username.Equals(request.Username, StringComparison.OrdinalIgnoreCase)))
        {
            return Task.FromResult((false, "that username is already taken"));
        }

        var user = new User
        {
            Id = _nextId++,
            Username = request.Username,
            Email = request.Email,
            PasswordHash = HashPassword(request.Password),
            DisplayName = request.Username,
            CreatedAt = DateTime.UtcNow
        };

        _users.Add(user);
        _currentUser = user;
        _currentUser.LastLoginAt = DateTime.UtcNow;

        return Task.FromResult((true, "welcome aboard! you're all set"));
    }

    // login with email and password
    public Task<(bool Success, string Message)> LoginAsync(LoginRequest request)
    {
        var user = _users.FirstOrDefault(u => 
            u.Email.Equals(request.Email, StringComparison.OrdinalIgnoreCase));

        if (user == null)
        {
            return Task.FromResult((false, "couldn't find an account with that email"));
        }

        if (user.PasswordHash != HashPassword(request.Password))
        {
            return Task.FromResult((false, "password doesn't match"));
        }

        _currentUser = user;
        _currentUser.LastLoginAt = DateTime.UtcNow;

        return Task.FromResult((true, $"welcome back, {user.DisplayName ?? user.Username}!"));
    }

    // log out the current user
    public Task LogoutAsync()
    {
        _currentUser = null;
        return Task.CompletedTask;
    }

    // get a user by their id
    public Task<User?> GetUserByIdAsync(int id)
    {
        return Task.FromResult(_users.FirstOrDefault(u => u.Id == id));
    }

    // update user profile
    public Task<(bool Success, string Message)> UpdateProfileAsync(User updatedUser)
    {
        var user = _users.FirstOrDefault(u => u.Id == updatedUser.Id);
        if (user == null)
        {
            return Task.FromResult((false, "user not found"));
        }

        user.DisplayName = updatedUser.DisplayName;
        user.Bio = updatedUser.Bio;
        user.ProfileImageUrl = updatedUser.ProfileImageUrl;

        if (_currentUser?.Id == user.Id)
        {
            _currentUser = user;
        }

        return Task.FromResult((true, "profile updated successfully"));
    }

    // simple password hashing - in production you'd use bcrypt or similar
    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + "recipe_salt_2025"));
        return Convert.ToBase64String(bytes);
    }

    // check if a username is available
    public Task<bool> IsUsernameAvailableAsync(string username)
    {
        return Task.FromResult(!_users.Any(u => 
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)));
    }

    // check if an email is available
    public Task<bool> IsEmailAvailableAsync(string email)
    {
        return Task.FromResult(!_users.Any(u => 
            u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)));
    }
}
