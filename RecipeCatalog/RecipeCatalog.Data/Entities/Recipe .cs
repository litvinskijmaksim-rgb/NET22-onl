using System.ComponentModel.DataAnnotations;

namespace RecipeCatalog.Data.Entities
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название рецепта")]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required(ErrorMessage = "Введите способ приготовления")]
        public string Instructions { get; set; } = string.Empty;

        [Range(1, 600, ErrorMessage = "Время от 1 до 600 минут")]
        public int CookingTimeMinutes { get; set; }

        public string? ImageUrl { get; set; }
        public double AverageRating { get; set; }

        [Required(ErrorMessage = "Выберите категорию")]
        public int CategoryId { get; set; }

        
        public bool IsUserCreated { get; set; } = false;

        public virtual Category? Category { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
        public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
        public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
    }
}