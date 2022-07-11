using FoodHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodHub.Controllers;

public class IngreadiantController : Controller
{

    private readonly ApplicationDBContext _db;

    public IngreadiantController(ApplicationDBContext db)
    {
        _db=db;
    }

        public IActionResult IndexIng()
    {
        IEnumerable<Ingreadiant> List= _db.Ingreadiants.ToList();
       IEnumerable<Ingreadiant> IngList=List.Reverse();
        return View(IngList);
    }



}