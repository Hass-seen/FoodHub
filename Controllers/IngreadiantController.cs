using FoodHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodHub.Controllers;

public class IngreadiantController : Controller
{

    private readonly ApplicationDBContext _db;
    private readonly IWebHostEnvironment _IWebHostEnvironment;
    public IngreadiantController(ApplicationDBContext db, IWebHostEnvironment IWebHostEnvironment)
    {
        _db=db;
        _IWebHostEnvironment=IWebHostEnvironment;
    }

        public IActionResult IndexIng()
    {
        IEnumerable<Ingreadiant> List= _db.Ingreadiants.ToList();
       IEnumerable<Ingreadiant> IngList=List.Reverse();
        return View(IngList);
    }

     public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Ingreadiant obj)
    {
        if(obj.Image!=null){
            string folder= "Images/";
            folder += Guid.NewGuid().ToString()+(obj.Image.FileName) ;
            string serverfolder= Path.Combine( _IWebHostEnvironment.WebRootPath,folder);
           await obj.Image.CopyToAsync(new FileStream(serverfolder,FileMode.Create));
           
           obj.path="/"+ folder;
        }else{
            obj.path="/images/default.jpg";
        }
        _db.Ingreadiants.Add(obj);
        _db.SaveChanges();

        return RedirectToAction("IndexIng");
    }



         public IActionResult Edite(String? name)
    {   
        
        var ing =_db.Ingreadiants.Find(name);
        return View(ing);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edite(Ingreadiant obj)
    {
        if(obj.Image!=null){
            string folder= "Images/";
            folder += Guid.NewGuid().ToString()+(obj.Image.FileName) ;
            string serverfolder= Path.Combine( _IWebHostEnvironment.WebRootPath,folder);
           await obj.Image.CopyToAsync(new FileStream(serverfolder,FileMode.Create));
           
           obj.path="/"+ folder;
        }
        _db.Ingreadiants.Update(obj);
        _db.SaveChanges();

        return RedirectToAction("IndexIng");
    }


         public IActionResult Delete(String? name)
    {   
        
        var ing =_db.Ingreadiants.Find(name);
        return View(ing);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Ingreadiant obj)
    {
        _db.Ingreadiants.Remove(obj);
        _db.SaveChanges();

        return RedirectToAction("IndexIng");
    }



}