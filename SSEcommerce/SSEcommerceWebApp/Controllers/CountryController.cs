using Microsoft.AspNetCore.Mvc;
using SSEcommerceWebApp.Data;
using SSEcommerceWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSEcommerceWebApp.Controllers
{
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CountryController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Add(int id)
        {
            ViewBag.Message = TempData["Message"];
            if (id != null)
            {
                var country = _context.Countries.FirstOrDefault(x => x.Id == id);
                return View(country);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Add(Country country)
        {
            if (country.Id > 0)
            {
                var existingCountry1 = _context.Countries.FirstOrDefault(x => x.Name == country.Name);
                if (existingCountry1 != null)
                {
                    if (existingCountry1.IsActive == false)
                    {
                        TempData["Message"] = $"{country.Name} country has been deleted, please contact admin";
                        return RedirectToAction("Add");
                    }
                    else
                    {
                        TempData["Message"] = $"{country.Name} country already exists";
                        return RedirectToAction("Add");
                    }
                }

                else
                {
                    var existingCountry = _context.Countries.FirstOrDefault(x => x.Id == country.Id);
                    if (existingCountry != null)
                    {
                        existingCountry.Name = country.Name;
                        existingCountry.IsActive = true;
                        existingCountry.UpdatedDate = DateTime.Now;
                        _context.Update(existingCountry);
                        RedirectToAction("Show");
                    }
                    return RedirectToAction("Add");
                }
            }
            else
            {
                var existingCategory = _context.Countries.FirstOrDefault(x => x.Name == country.Name);
                if (existingCategory != null)
                {
                    if (existingCategory.IsActive == false)
                    {
                        TempData["Message"] = $"{country.Name} country has been deleted, please contact admin";
                        return RedirectToAction("Add");
                    }
                    else
                    {
                        TempData["Message"] = $"{country.Name} country already exists";
                        return RedirectToAction("Add");
                    }
                }
                else
                {
                    country.IsActive = true;
                    country.CreatedDate = DateTime.Now;
                    _context.Countries.Add(country);
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
                return View(country);
            }

        }



        [HttpGet]
        public IActionResult Show()
        {
            ViewBag.Message = TempData["Message"];
            var dataList = _context.Countries.Where(x => x.IsActive == true);
            return View(dataList);
        }


        public IActionResult Delete(int id)
        {
            _context.Countries.Remove(_context.Countries.Find(id));
            var existingCountry = _context.Countries.FirstOrDefault(x => x.Id == id);
            if (existingCountry != null)
            {
                existingCountry.IsActive = false;
                existingCountry.UpdatedDate = DateTime.Now;
                _context.Update(existingCountry);
            }

            _context.SaveChanges();
            return RedirectToAction("Show");
        }
    }
}
