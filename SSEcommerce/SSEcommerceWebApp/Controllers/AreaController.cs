using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SSEcommerceWebApp.Data;
using SSEcommerceWebApp.Models;
using System;
using System.Linq;

namespace SSEcommerceWebApp.Controllers
{
    public class AreaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AreaController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Add(int id)
        {
            ViewData["Country"] = new SelectList(_context.Countries.Where(x => x.IsActive == true), "Id", "Name");
            ViewData["Division"] = new SelectList(_context.Divisions.Where(x => x.IsActive == true), "Id", "Name");
            ViewData["District"] = new SelectList(_context.Districts.Where(x => x.IsActive == true), "Id", "Name");
            ViewBag.Message = TempData["Message"];
            if (id > 0)
            {
                var area = _context.Areas.FirstOrDefault(x => x.Id == id);
                return View(area);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Add(Area area)
        {
            ViewData["Country"] = new SelectList(_context.Countries, "Id", "Name");
            ViewData["Division"] = new SelectList(_context.Divisions, "Id", "Name");
            ViewData["District"] = new SelectList(_context.Districts, "Id", "Name");
            if (area.Id > 0)
            {
                var existingDivision1 = _context.Areas.FirstOrDefault(x => x.Name == area.Name);
                if (existingDivision1 != null)
                {
                    if (existingDivision1.IsActive == false)
                    {
                        TempData["Message"] = $"{area.Name} division has been deleted, please contact admin";
                        return RedirectToAction("Add");
                    }
                    else
                    {
                        TempData["Message"] = $"{area.Name} division already exists";
                        return RedirectToAction("Add");
                    }
                }


                else
                {
                    var existingDivision = _context.Areas.FirstOrDefault(x => x.Id == area.Id);
                    if (existingDivision != null)
                    {
                        existingDivision.Name = area.Name;
                        existingDivision.IsActive = true;
                        existingDivision.UpdatedDate = DateTime.Now;
                        existingDivision.UpdatedBy = _userManager.GetUserId(User);
                        _context.Update(existingDivision);
                    }

                    RedirectToAction("Show");
                }
            }
            else
            {
                var existingDivision1 = _context.Areas.FirstOrDefault(x => x.Name == area.Name);
                if (existingDivision1 != null)
                {
                    if (existingDivision1.IsActive == false)
                    {
                        TempData["Message"] = $"{area.Name} division has been deleted, please contact admin";
                        return RedirectToAction("Add");
                    }
                    else
                    {
                        TempData["Message"] = $"{area.Name} division already exists";
                        return RedirectToAction("Add");
                    }
                }

                else
                {
                    area.IsActive = true;
                    area.CreatedDate = DateTime.Now;
                    area.CreatedBy = _userManager.GetUserId(User);
                    _context.Areas.Add(area);
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
                return View(area);
            }

        }



        [HttpGet]
        public IActionResult Show()
        {
            ViewBag.Message = TempData["Message"];
            var Areas = _context.Areas.Where(x => x.IsActive).Include("Country").Include("Division").Include("District").ToList();
            if (Areas.Any())
            {
                return View(Areas);

            }
            else
            {
                return View(Areas);
            }
        }

        public IActionResult Delete(int id)
        {
            _context.Areas.Remove(_context.Areas.Find(id));
            var existingDivision = _context.Areas.FirstOrDefault(x => x.Id == id);
            if (existingDivision != null)
            {
                existingDivision.IsActive = false;
                existingDivision.UpdatedDate = DateTime.Now;
                _context.Update(existingDivision);
            }

            _context.SaveChanges();
            return RedirectToAction("Show");
        }
        public IActionResult LoadDivisionByCountry(int countryId)
        {
            var Country = _context.Divisions.Where(sc => sc.CountryId == countryId);
            return Json(Country);
        }
        public IActionResult LoadDistrictByDivision(int divisionId)
        {
            var Division = _context.Districts.Where(sc => sc.DivisionId == divisionId);
            return Json(Division);
        }
    }
}
