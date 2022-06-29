using System.ComponentModel.DataAnnotations;

namespace FoodHub.Models
{
    public class Ingreadiant
    {
        [Key]
        public string Name { get; set; }

     public List<Recipe_Ingreadiant> Recipe_Ingreadiants { get; set; }

    }
}