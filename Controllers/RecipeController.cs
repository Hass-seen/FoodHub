using FoodHub.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodHub.Controllers;

public class RecipeController : Controller
{

    private readonly ApplicationDBContext _db;

    public RecipeController(ApplicationDBContext db)
    {
        _db=db;
    }
    public IActionResult IndexRecipe()
    {
        IEnumerable<Recipe> RecipeList= _db.Recipes.ToList();
        return View(RecipeList);
    }

        public IActionResult Create()
    {
        return View();
    }


    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Post(Recipe obj)
    {
        _db.Recipes.Add(obj);
        _db.SaveChanges();
        return RedirectToAction("IndexRecipe");
    }
}