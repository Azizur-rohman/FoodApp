using Microsoft.AspNetCore.Mvc;
using SSEcommerceWebApp.Data;
using SSEcommerceWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSEcommerceWebApp.Controllers
{
    public class ItemCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ItemCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            ViewBag.Message = TempData["Message"];
            if (id != null)
            {
                var category = _context.Categories.FirstOrDefault(x => x.Id == id);
                return View(category);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        { 
            if(category.Id > 0)
            {
                var existingCategory = _context.Categories.FirstOrDefault(x => x.Name == category.Name);
                if (existingCategory != null)
                {
                    if (existingCategory.IsActive == false)
                    {
                        TempData["Message"] = $"{category.Name} category has been deleted, please contact admin";
                        return RedirectToAction("Add");
                    }
                    else
                    {
                        TempData["Message"] = $"{category.Name} category already exists";
                        return RedirectToAction("Add");
                    }
                }
                else
                {
                    var existingCategory1 = _context.Categories.FirstOrDefault(x => x.Id == category.Id);
                    if (existingCategory1 != null)
                    {
                        existingCategory1.Name = category.Name;
                        existingCategory1.IsActive = true;
                        existingCategory1.UpdatedDate = DateTime.Now;
                        _context.Update(existingCategory1);
                        RedirectToAction("Show");
                    }
                    return RedirectToAction("Add");
                }
            }
            else
            {
                var existingCategory = _context.Categories.FirstOrDefault(x => x.Name == category.Name);
                if (existingCategory != null)
                {
                    if (existingCategory.IsActive == false)
                    {
                        TempData["Message"] = $"{category.Name} category has been deleted, please contact admin";
                        return RedirectToAction("Add");
                    }
                    else
                    {
                        TempData["Message"] = $"{category.Name} category already exists";
                        return RedirectToAction("Add");
                    }
                }
                else
                {
                    category.IsActive = true;
                    category.CreatedDate = DateTime.Now;
                    _context.Categories.Add(category);
                }
           
            }

            if (_context.SaveChanges() > 0)
            {
                TempData["Message"] = "Save Successfully";

                return RedirectToAction("Show");
            }
            else
            {
                TempData["Message"] = "Failed";
                return View(category);
            }
            
        }

        

        [HttpGet]
        public IActionResult Show()
        {
            ViewBag.Message = TempData["Message"];
            var dataList = _context.Categories.Where(x => x.IsActive == true);
            return View(dataList);
        }

        
        public IActionResult Delete(int id)
        {
            _context.Categories.Remove(_context.Categories.Find(id));
            var existingCategory = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (existingCategory != null)
            {
                existingCategory.IsActive = false;
                existingCategory.UpdatedDate = DateTime.Now;
                _context.Update(existingCategory);
            }

            _context.SaveChanges();
            return RedirectToAction("Show");
        }

    }
}
