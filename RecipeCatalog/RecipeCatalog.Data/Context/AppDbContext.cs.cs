using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeCatalog.Data.Entities;

namespace RecipeCatalog.Data.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser> // Наследуемся от Identity + наш User
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet для наших сущностей
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // Обязательно вызываем для Identity

            // Настройка составного ключа для RecipeIngredient
            builder.Entity<RecipeIngredient>()
                .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

            // Уникальность: один пользователь может оценить рецепт только раз
            builder.Entity<Rating>()
                .HasIndex(r => new { r.RecipeId, r.UserId })
                .IsUnique();

            // Уникальность: один пользователь может добавить рецепт в избранное один раз
            builder.Entity<Favorite>()
                .HasIndex(f => new { f.RecipeId, f.UserId })
                .IsUnique();
        }
    }
}