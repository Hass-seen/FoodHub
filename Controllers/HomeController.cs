using FoodHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FoodHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDBContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDBContext db)
        {
            _logger = logger;
            _db=db;
        }

        public IActionResult Index()
        {
        IEnumerable<Recipe> List= _db.Recipes.ToList();
       IEnumerable<Recipe> RecipeList=List.Reverse();
        return View(RecipeList);
        }

        public IActionResult Privacy()
        {
            return View();
        }


         public IActionResult Visit(string? name)
        {
        var recipefromdb= _db.Recipes.Find(name);
        var recipe_Ingreadiantsfromdb= _db.Recipes_Ingreadiants.Include(i=> i.ingreadiant).Where(recing=> recing.RecipeName== recipefromdb.Name);
        recipefromdb.Recipe_Ingreadiants= recipe_Ingreadiantsfromdb.ToList();

            return View(recipefromdb);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}