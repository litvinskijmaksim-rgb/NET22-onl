using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations; 

namespace RecipeCatalog.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty; 

        public string? Description { get; set; }

        
        public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}