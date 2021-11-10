using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SSEcommerceWebApp.Data;
using SSEcommerceWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSEcommerceWebApp.Controllers
{
    public class DistrictController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DistrictController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Add(int id)
        {
            ViewData["Country"] = new SelectList(_context.Countries.Where(x => x.IsActive == true), "Id", "Name");
            ViewData["Division"] = new SelectList(_context.Divisions.Where(x => x.IsActive == true), "Id", "Name");
            ViewBag.Message = TempData["Message"];
            if (id > 0)
            {
                var district = _context.Districts.FirstOrDefault(x => x.Id == id);
                return View(district);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Add(District district)
        {
            ViewData["Country"] = new SelectList(_context.Countries, "Id", "Name");
            ViewData["Division"] = new SelectList(_context.Divisions, "Id", "Name");
            if (district.Id > 0)
            {
                var existingDivision1 = _context.Districts.FirstOrDefault(x => x.Name == district.Name);
                if (existingDivision1 != null)
                {
                    if (existingDivision1.IsActive == false)
                    {
                        TempData["Message"] = $"{district.Name} division has been deleted, please contact admin";
                        return RedirectToAction("Add");
                    }
                    else
                    {
                        TempData["Message"] = $"{district.Name} division already exists";
                        return RedirectToAction("Add");
                    }
                }


                else
                {
                    var existingDivision = _context.Districts.FirstOrDefault(x => x.Id == district.Id);
                    if (existingDivision != null)
                    {
                        existingDivision.Name = district.Name;
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
                var existingDivision1 = _context.Districts.FirstOrDefault(x => x.Name == district.Name);
                if (existingDivision1 != null)
                {
                    if (existingDivision1.IsActive == false)
                    {
                        TempData["Message"] = $"{district.Name} division has been deleted, please contact admin";
                        return RedirectToAction("Add");
                    }
                    else
                    {
                        TempData["Message"] = $"{district.Name} division already exists";
                        return RedirectToAction("Add");
                    }
                }

                else
                {
                    district.IsActive = true;
                    district.CreatedDate = DateTime.Now;
                    district.CreatedBy = _userManager.GetUserId(User);
                    _context.Districts.Add(district);
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
                return View(district);
            }

        }



        [HttpGet]
        public IActionResult Show()
        {
            ViewBag.Message = TempData["Message"];
            var Divisions = _context.Districts.Where(x => x.IsActive).Include("Country").Include("Division").ToList();
            if (Divisions.Any())
            {
                return View(Divisions);

            }
            else
            {
                return View(Divisions);
            }
        }

        public IActionResult Delete(int id)
        {
            _context.Districts.Remove(_context.Districts.Find(id));
            var existingDivision = _context.Districts.FirstOrDefault(x => x.Id == id);
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
    }
}
