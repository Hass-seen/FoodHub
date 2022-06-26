using Microsoft.AspNetCore.Mvc;

namespace FoodHub.Controllers;

public class RecipeController : Controller
{
    public IActionResult IndexRecipe()
    {
        return View();
    }
}