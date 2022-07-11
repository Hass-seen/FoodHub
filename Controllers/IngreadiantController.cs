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
           obj.path= serverfolder;
        }
        _db.Ingreadiants.Add(obj);

        return RedirectToAction("IndexIng");
    }



}