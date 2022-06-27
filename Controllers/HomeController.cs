using FoodHub.Models;
using Microsoft.AspNetCore.Mvc;
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
        IEnumerable<Recipe> RecipeList= _db.Recipes.ToList();
        return View(RecipeList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}