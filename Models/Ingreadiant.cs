using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace FoodHub.Models
{
    public class Ingreadiant
    {
        [Key]
        public string Name { get; set; }

     public List<Recipe_Ingreadiant> Recipe_Ingreadiants { get; set; }

     
    [NotMapped]
     public IFormFile Image { get; set; }

     public string path { get; set; }

    }
}