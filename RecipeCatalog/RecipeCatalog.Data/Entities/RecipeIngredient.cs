namespace RecipeCatalog.Data.Entities
{
    public class RecipeIngredient
    {
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; } = null!;

        public int IngredientId { get; set; }
        public virtual Ingredient Ingredient { get; set; } = null!;

        public string Quantity { get; set; } = string.Empty; 
    }
}