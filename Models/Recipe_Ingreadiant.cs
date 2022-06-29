using System.ComponentModel.DataAnnotations;

namespace FoodHub.Models
{
    public class Recipe_Ingreadiant
    {
        public int RecipeID { get; set; }
        public Recipe recipe { get; set; }

        public string IngreadiantName { get; set; }
        public Ingreadiant ingreadiant { get; set; }

        public string amount { get; set; }
    }
}
