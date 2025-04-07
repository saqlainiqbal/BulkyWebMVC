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
         if (catagory.Name == catagory.DisplayOrder.ToString())
         {
            ModelState.AddModelError("name", "The Display Order cannot exactly match the Name.");
         }
         if (catagory.Name.ToLower() == "test")
         {
            ModelState.AddModelError("", "Test is inavalid Value.");
         }
         if (ModelState.IsValid)
         {
            _dbContext.Add(catagory);
            _dbContext.SaveChanges();
         }
         return RedirectToAction("Index");
      }
      public IActionResult Edit(int? id)
      {
         if (id == null || id == 0)
         {
            return NotFound();
         }
         Catagory catagory = _dbContext.Catagories.Find(id)!;
         if (catagory == null)
         {
            return NotFound();
         }
         return View(catagory);
      }
      [HttpPost]
      public IActionResult Edit(Catagory catagory)
      {
         //if (catagory.Name == catagory.DisplayOrder.ToString())
         //{
         //   ModelState.AddModelError("name", "The Display Order cannot exactly match the Name.");
         //}
         //if (catagory.Name.ToLower() == "test")
         //{
         //   ModelState.AddModelError("", "Test is inavalid Value.");
         //}
         if (ModelState.IsValid)
         {
            _dbContext.Update(catagory);
            _dbContext.SaveChanges();
         }
         return RedirectToAction("Index");
      }
      public IActionResult Delete(int? id)
      {
         if (id == null || id == 0)
         {
            return NotFound();
         }
         Catagory catagory = _dbContext.Catagories.Find(id)!;
         if (catagory == null)
         {
            return NotFound();
         }
         return View(catagory);
      }
      [HttpPost, ActionName("Delete")]
      public IActionResult DeletePost(int id)
      {
         Catagory? catagory = _dbContext.Catagories.Find(id);
         if (catagory == null)
         {
            return NotFound();
         }
         if (ModelState.IsValid)
         {
            _dbContext.Catagories.Remove(catagory);
            _dbContext.SaveChanges();
         }
         return RedirectToAction("Index");
      }
   }
}
