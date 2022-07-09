using System.ComponentModel.DataAnnotations;

namespace FoodHub.Models
{
    public class User
    {   [Key]
        public string account { get; set; }
        public string password { get; set; }

    }
}