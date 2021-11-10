using Microsoft.AspNetCore.Mvc;
using SSEcommerceWebApp.Data;
using SSEcommerceWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace SSEcommerceWebApp.Controllers
{
    public class ItemSubCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ItemSubCategoryController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Add(int id)
        {
            ViewData["Category"] = new SelectList(_context.Categories.Where(x => x.IsActive == true), "Id", "Name");
            ViewBag.Message = TempData["Message"];
            if (id > 0)
            {
                var subcategory = _context.SubCategories.FirstOrDefault(x => x.Id == id);
                return View(subcategory);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Add(SubCategory subcategory)
        {
            ViewData["Category"] = new SelectList(_context.Categories, "Id", "Name");

            if (subcategory.Id > 0)
            {
                var existingSubCategory = _context.SubCategories.FirstOrDefault(x => x.Name == subcategory.Name);
                if (existingSubCategory != null)
                {
                    if (existingSubCategory.IsActive == false)
                    {
                        TempData["Message"] = $"{subcategory.Name} subcategory has been deleted, please contact admin";
                        return RedirectToAction("Add");
                    }
                    else
                    {
                        TempData["Message"] = $"{subcategory.Name} subcategory already exists";
                        return RedirectToAction("Add");
                    }
                }

                else
                {
                    var existingSubCategory1 = _context.SubCategories.FirstOrDefault(x => x.Id == subcategory.Id);
                    if (existingSubCategory1 != null)
                    {
                        existingSubCategory1.Name = subcategory.Name;
                        existingSubCategory1.IsActive = true;
                        existingSubCategory1.UpdatedDate = DateTime.Now;
                        existingSubCategory1.UpdatedBy = _userManager.GetUserId(User);
                        _context.Update(existingSubCategory1);
                    }

                    RedirectToAction("Show");
                }
            }
            else
            {
                var existingSubCategory = _context.SubCategories.FirstOrDefault(x => x.Name == subcategory.Name);
                if (existingSubCategory != null)
                {
                    if (existingSubCategory.IsActive == false)
                    {
                        TempData["Message"] = $"{subcategory.Name} subcategory has been deleted, please contact admin";
                        return RedirectToAction("Add");
                    }
                    else
                    {
                        TempData["Message"] = $"{subcategory.Name} subcategory already exists";
                        return RedirectToAction("Add");
                    }
                }
                else
                {
                    subcategory.IsActive = true;
                    subcategory.CreatedDate = DateTime.Now;
                    subcategory.CreatedBy = _userManager.GetUserId(User);
                    _context.SubCategories.Add(subcategory);
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
                return View(subcategory);
            }

        }



        [HttpGet]
        public IActionResult Show()
        {
            ViewBag.Message = TempData["Message"];
            var Categories = _context.SubCategories.Where(x=> x.IsActive).Include("Category").ToList();
            if (Categories.Any())
            {
                return View(Categories);

            }
            else
            {
                return View(Categories);
            }
        }

        public IActionResult Delete(int id)
        {
            _context.SubCategories.Remove(_context.SubCategories.Find(id));
            var existingCategory = _context.SubCategories.FirstOrDefault(x => x.Id == id);
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
