using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace FoodHub.Models
{
    public class Ingreadiant
    {
        [Key]
        public string Name { get; set; }

     public List<Recipe_Ingreadiant> Recipe_Ingreadiants { get; set; }

     public IFormFile Image { get; set; }

    }
}