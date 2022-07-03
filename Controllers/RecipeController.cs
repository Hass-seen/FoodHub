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
        IEnumerable<Recipe> List= _db.Recipes.ToList();
       IEnumerable<Recipe> RecipeList=List.Reverse();
        return View(RecipeList);
    }

        public IActionResult Create()
    {
        return View();
    }


    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(string? obj)
    {   var recipe=new Recipe(); 
        string[] rec=  obj.Split(",");
        recipe.Name=rec[0];
        recipe.Discription=rec[1];
        recipe.link=rec[2];

        string[] Ingstodb= rec[3].Split(";");
        for(var i=0; i<Ingstodb.Length;i++){
            string[] Data= Ingstodb[i].Split("*");
            var ing= new Ingreadiant();
                ing.Name=Data[0];
            _db.Ingreadiants.Add(ing);
            _db.SaveChanges();
            var rec_Ing= new Recipe_Ingreadiant();
            rec_Ing.RecipeName=recipe.Name;
            rec_Ing.amount=Data[1];
            rec_Ing.IngreadiantName=Data[0];
            _db.Recipes_Ingreadiants.Add(rec_Ing);
            _db.SaveChanges();
        }
        _db.Recipes.Add(recipe);
        _db.SaveChanges();
       return RedirectToAction("IndexRecipe");
    }



      public IActionResult Edite(string? id)
    {
        if(id==null){
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

        _db.Recipes.Update(obj);
        _db.SaveChanges();
       return RedirectToAction("IndexRecipe");
    }



     public IActionResult Delete(string? id)
    {
        if(id==null){
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
    {
        _db.Recipes.Remove(obj);
        _db.SaveChanges();
       return RedirectToAction("IndexRecipe");
    }



    
 public IActionResult Login()
    {

        return View();
    }


    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(Admin admin)
    {   if(admin.account!= "BobTheBuilder"){
        ModelState.AddModelError("account", "Wrong Username");
        }else if(admin.password!= "BobTheBuilder123"){
            ModelState.AddModelError("password", "Wrong Password");
        }else{
         return RedirectToAction("IndexRecipe");
        }

         return View(admin);

    }

}