using System.ComponentModel.DataAnnotations;

namespace RecipeCatalog.Data.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty; 

        public string? Unit { get; set; } 

        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
    }
}