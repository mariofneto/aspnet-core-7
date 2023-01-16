using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using S01_Introduction.Data;
using Microsoft.AspNetCore.Mvc;
using S01_Introduction.Models;

namespace S01_Introduction.Controllers
{
    public class CategoryController : Controller
    {
        readonly private ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The DisplayOrder cannot exactly match the Name.");
            }

            var search = _db.Categories.FirstOrDefault(x => x.Name == obj.Name);
            if (obj.Name == search.Name.ToString())
            {
                ModelState.AddModelError("CustomError", "The Name is exists");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
                return NotFound();
                
            return View(categoryFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The DisplayOrder cannot exactly match the Name.");
            }

            var search = _db.Categories.FirstOrDefault(x => x.Name == obj.Name);
            if (obj.Name == search.Name.ToString())
            {
                ModelState.AddModelError("CustomError", "The Name is exists");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }
    }
}