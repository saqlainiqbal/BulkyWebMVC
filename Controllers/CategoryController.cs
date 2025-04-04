using BulkyWebMVC.Data;
using BulkyWebMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWebMVC.Controllers
{
   public class CategoryController(ApplicationDbContext dbContext) : Controller
   {
      private readonly ApplicationDbContext _dbContext = dbContext;
      public IActionResult Index()
      {
         List<Catagory> categoryList = _dbContext.Catagories.ToList();
         return View(categoryList);
      }
      public IActionResult Create()
      {
         return View();
      }
      [HttpPost]
      public IActionResult Create(Catagory catagory)
      {
         if (ModelState.IsValid)
         {
            _dbContext.Add(catagory);
            _dbContext.SaveChanges();
         }
         return RedirectToAction("Index");
      }
   }
}
