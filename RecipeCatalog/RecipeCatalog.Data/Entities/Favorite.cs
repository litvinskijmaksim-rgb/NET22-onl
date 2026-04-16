namespace RecipeCatalog.Data.Entities
{
    public class Favorite
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int RecipeId { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;
        public virtual Recipe Recipe { get; set; } = null!;
    }
}