using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodHub.Models
{
    public class Recipe
    {
        [Key]
        public string Name { get; set; }
        //public string Ingreadiants { get; set; } = " ";
        public string Discription { get; set; } = " ";
        public string link { get; set; } = ".";

        public DateTime DateOfCreation { get; set; } = DateTime.Now;

        public List<Recipe_Ingreadiant> Recipe_Ingreadiants { get; set; }

    [NotMapped]
     public List<Ingreadiant> AllIngs { get; set; }

    }
}
