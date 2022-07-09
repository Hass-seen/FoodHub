using FoodHub.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodHub.Controllers
{
    public class UserController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(RoleManager<IdentityRole> roleManager){
            this.roleManager= roleManager;
        }


        public IActionResult Create(){
            return View();
        }


        [HttpPost]
       public async Task<IActionResult> Create(Role role){
            
            var roleExist = await roleManager.RoleExistsAsync(role.Name);
            if(!roleExist){
                var result = await roleManager.CreateAsync(new IdentityRole(role.Name));
            }  
            return View();
        }
    }
    }