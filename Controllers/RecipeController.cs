using FoodHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
        var obj= new Recipe();
        obj.AllIngs=_db.Ingreadiants.ToList();
        return View(obj);
    }

    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Recipe obj)
      {   
         if(obj.Discription==null){
            obj.Discription="";
        }
         
        if(obj.link==null){
            obj.link=".=.";
        }
        var temp= obj.link.Split("=");
        obj.link= "https://www.youtube.com/embed/"+temp[1];



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
            x.amount=null;
            x.IngreadiantName=recipefromdb.Name;
            x.IngreadiantName=null;
            recipefromdb.Recipe_Ingreadiants.Add(x);
        }

        if(recipefromdb == null){
            return NotFound();
        }
                recipefromdb.AllIngs=_db.Ingreadiants.ToList();
        return View(recipefromdb);
    }


    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edite(Recipe obj)
    {            if(obj.link==null){
            obj.link=".=.";
        }
        var temp= obj.link.Split("=");
        try{
        obj.link= "https://www.youtube.com/embed/"+temp[1];
        } catch(Exception ex){

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
               // _db.Recipes_Ingreadiants.Update(obj.Recipe_Ingreadiants[i]);
            }
        }

        var recings = _db.Recipes_Ingreadiants.Where(recing => recing.RecipeName==obj.Name).ToList();
        foreach(Recipe_Ingreadiant recing in recings){
            _db.Recipes_Ingreadiants.Remove(recing);
        }

        var rec= _db.Recipes.Find(obj.Name);
 try{
        _db.Recipes.Remove(rec);
        _db.SaveChanges();
        _db.Recipes.Add(obj);
        _db.SaveChanges();
        }
        catch(SqlException exception){
        
        }

       return RedirectToAction("IndexRecipe");
    }



     public IActionResult Delete(string? name)
    {
        if(name==null){
            return NotFound();
        }
        var recipefromdb= _db.Recipes.Find(name);
        var recipe_Ingreadiantsfromdb= _db.Recipes_Ingreadiants.Where(recing=> recing.RecipeName== recipefromdb.Name);
        recipefromdb.Recipe_Ingreadiants= recipe_Ingreadiantsfromdb.ToList();

        for(int i=0; i<31;i++){
            var x= new Recipe_Ingreadiant();
            x.amount=null;
            x.IngreadiantName=recipefromdb.Name;
            x.IngreadiantName=null;
            recipefromdb.Recipe_Ingreadiants.Add(x);
        }

        if(recipefromdb == null){
            return NotFound();
        }
        return View(recipefromdb);
    }


    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(Recipe obj)
    {       
        var recipefromdb= _db.Recipes.Find(obj.Name);
        _db.Recipes.Remove(recipefromdb);
        _db.SaveChanges();
       return RedirectToAction("IndexRecipe");
    }



    
 public IActionResult Login()
    {

        return View();
    }


    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(User admin)
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