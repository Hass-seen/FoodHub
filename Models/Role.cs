using System.ComponentModel.DataAnnotations;
namespace FoodHub.Models
{
    public class Role
    {
        [Key]
        public string Name { get; set; }
    }
}