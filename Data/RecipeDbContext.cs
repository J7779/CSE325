using Microsoft.EntityFrameworkCore;
using GroupProject.Models;

namespace GroupProject.Data;

// my database context - where all the data magic happens
public class RecipeDbContext : DbContext
{
    public RecipeDbContext(DbContextOptions<RecipeDbContext> options) : base(options)
    {
    }

    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // setting up the recipe entity
        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(r => r.Id);
            entity.Property(r => r.Title).IsRequired().HasMaxLength(100);
            entity.Property(r => r.Description).IsRequired().HasMaxLength(2000);
            entity.Property(r => r.Category).IsRequired().HasMaxLength(50);
            entity.HasIndex(r => r.Category);
            entity.HasIndex(r => r.AuthorId);
        });

        // user entity config
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Username).IsRequired().HasMaxLength(50);
            entity.Property(u => u.Email).IsRequired().HasMaxLength(255);
            entity.HasIndex(u => u.Email).IsUnique();
            entity.HasIndex(u => u.Username).IsUnique();
        });

        // comment entity setup
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Content).IsRequired().HasMaxLength(1000);
            entity.HasIndex(c => c.RecipeId);
        });
    }
}
