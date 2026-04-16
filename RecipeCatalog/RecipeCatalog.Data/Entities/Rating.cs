using System.ComponentModel.DataAnnotations;

namespace RecipeCatalog.Data.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string UserId { get; set; } = string.Empty;

        [Range(1, 5)]
        public int Score { get; set; } 

        public DateTime RatedAt { get; set; } = DateTime.UtcNow;

        public virtual Recipe Recipe { get; set; } = null!;
        public virtual ApplicationUser User { get; set; } = null!;
    }
}