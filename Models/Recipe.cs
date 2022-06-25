using System.ComponentModel.DataAnnotations;

namespace FoodHub.Models
{
    public class Recipe
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Ingreadiants { get; set; }
        public string Discription { get; set; }

        public DateTime DateOfCreation { get; set; } = DateTime.Now;

    }
}
