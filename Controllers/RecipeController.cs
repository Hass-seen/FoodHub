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
    public IActionResult Create(Recipe obj)
    {     if(obj.link==null){
            obj.link=".";
        }
        if(obj.Discription==null){
            obj.Discription="";
        }
        if(obj.Ingreadiants==null){
            obj.Ingreadiants="";
        }
        _db.Recipes.Add(obj);
        _db.SaveChanges();
       return RedirectToAction("IndexRecipe");
    }



      public IActionResult Edite(int? id)
    {
        if(id==null || id==0){
            return NotFound();
        }
        var recipefromdb= _db.Recipes.Find(id);
        if(recipefromdb == null){
            return NotFound();
        }
        return View(recipefromdb);
    }


    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edite(Recipe obj)
    {     if(obj.link==null){
            obj.link=".";
        }
        if(obj.Discription==null){
            obj.Discription="";
        }
        if(obj.Ingreadiants==null){
            obj.Ingreadiants="";
        }
        _db.Recipes.Update(obj);
        _db.SaveChanges();
       return RedirectToAction("IndexRecipe");
    }



     public IActionResult Delete(int? id)
    {
        if(id==null || id==0){
            return NotFound();
        }
        var recipefromdb= _db.Recipes.Find(id);
        if(recipefromdb == null){
            return NotFound();
        }
        return View(recipefromdb);
    }


    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(Recipe obj)
    {     if(obj.link==null){
            obj.link=".";
        }
        if(obj.Discription==null){
            obj.Discription="";
        }
        if(obj.Ingreadiants==null){
            obj.Ingreadiants="";
        }
        _db.Recipes.Remove(obj);
        _db.SaveChanges();
       return RedirectToAction("IndexRecipe");
    }
}