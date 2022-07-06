using FoodHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public IActionResult Create(Recipe obj)
      {   //var recipe=new Recipe(); 
    //     recipe.Name=obj.name;
    //     recipe.Discription=obj.discription;
    //     recipe.link=obj.link;

    //     string[] ings=obj.RecIngr;
    //     if(ings.Length!=null){
    //     for(var i=0; i<ings.Length-1;i=i+2){
    //         if(ings[i]==null){
    //             continue;
    //         }
    //         if(ings[i+1]==null){
    //            ings[i+1]="..."; 
    //         }
    //         var ing= new Ingreadiant();
    //         ing.Name=ings[i];
    //         _db.Ingreadiants.Add(ing);
    //         _db.SaveChanges();
            
    //         var recIng= new Recipe_Ingreadiant();
    //         recIng.amount=ings[i+1];
    //         recIng.IngreadiantName=ings[i];
    //         recIng.RecipeName=recipe.Name;
    //         _db.Recipes_Ingreadiants.Add(recIng);
    //         _db.SaveChanges();


    //      }}
    foreach(Recipe_Ingreadiant x in obj.Recipe_Ingreadiants){
        x.RecipeName=obj.Name;
    }  
    //List<Recipe_Ingreadiant> temp=;

    for(int i=obj.Recipe_Ingreadiants.Count -1; i>=0; i--){
        if(obj.Recipe_Ingreadiants[i].IngreadiantName==null){
            obj.Recipe_Ingreadiants.Remove(obj.Recipe_Ingreadiants[i]);
        }else
            {
                if (_db.Ingreadiants.Any(s => s.Name == obj.Recipe_Ingreadiants[i].IngreadiantName))
                {
                    continue;
                }
                var ing = new Ingreadiant();
                ing.Name = obj.Recipe_Ingreadiants[i].IngreadiantName;

                obj.Recipe_Ingreadiants[i].ingreadiant = ing;
            }
        }
     try{
        _db.Recipes.Add(obj);
        _db.SaveChanges();
        }
        catch(DbUpdateException ex){
        
        }
       return RedirectToAction("IndexRecipe");
    }



      public  IActionResult Edite(string? name)
    {
        if(name==null){
            return NotFound();
        }
        var recipefromdb= _db.Recipes.Find(name);
        var recipe_Ingreadiantsfromdb= _db.Recipes_Ingreadiants.Where(recing=> recing.RecipeName== recipefromdb.Name);
        recipefromdb.Recipe_Ingreadiants= recipe_Ingreadiantsfromdb.ToList();

        for(int i=0; i<31;i++){
            var x= new Recipe_Ingreadiant();
            x.amount="";
            x.IngreadiantName=recipefromdb.Name;
            x.IngreadiantName="";
            recipefromdb.Recipe_Ingreadiants.Add(x);
        }

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
            foreach(Recipe_Ingreadiant x in obj.Recipe_Ingreadiants){
            x.RecipeName=obj.Name;
                } 

           for(int i=obj.Recipe_Ingreadiants.Count -1; i>=0; i--){
        if(obj.Recipe_Ingreadiants[i].IngreadiantName==null|| obj.Recipe_Ingreadiants[i].IngreadiantName==""){
            obj.Recipe_Ingreadiants.Remove(obj.Recipe_Ingreadiants[i]);
        }else
            {
                if (_db.Ingreadiants.Any(s => s.Name == obj.Recipe_Ingreadiants[i].IngreadiantName))
                {
                    continue;
                }
                var ing = new Ingreadiant();
                ing.Name = obj.Recipe_Ingreadiants[i].IngreadiantName;

                obj.Recipe_Ingreadiants[i].ingreadiant = ing;
                _db.Recipes_Ingreadiants.Update(obj.Recipe_Ingreadiants[i]);
            }
        }
 try{
        _db.Recipes.Update(obj);
        _db.SaveChanges();
        }
        catch(DbUpdateException ex){
        
        }

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