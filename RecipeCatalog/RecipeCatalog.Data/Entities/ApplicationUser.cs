using Microsoft.AspNetCore.Identity;

namespace RecipeCatalog.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        
        public string? FullName { get; set; }
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

        
        public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
        public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
        public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    }
}