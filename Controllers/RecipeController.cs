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
    public IActionResult Create(TransportRecipe obj)
    {   var recipe=new Recipe(); 
        recipe.Name=obj.name;
        recipe.Discription=obj.discription;
        recipe.link=obj.link;

        string[] ings=obj.RecIngr;
        if(ings.Length!=null){
        for(var i=0; i<ings.Length-1;i=i+2){
            if(ings[i]==null){
                break;
            }
            if(ings[i+1]==null){
               ings[i+1]="..."; 
            }
            var ing= new Ingreadiant();
            ing.Name=ings[i];
            _db.Ingreadiants.Add(ing);
            _db.SaveChanges();
            
            var recIng= new Recipe_Ingreadiant();
            recIng.amount=ings[i+1];
            recIng.IngreadiantName=ings[i];
            recIng.RecipeName=recipe.Name;
            _db.Recipes_Ingreadiants.Add(recIng);
            _db.SaveChanges();


         }}
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