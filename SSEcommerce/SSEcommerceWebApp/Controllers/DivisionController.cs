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
    public class DivisionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DivisionController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Add(int id)
        {
            ViewData["Country"] = new SelectList(_context.Countries.Where(x => x.IsActive == true), "Id", "Name");
            ViewBag.Message = TempData["Message"];
            if (id > 0)
            {
                var division = _context.Divisions.FirstOrDefault(x => x.Id == id);
                return View(division);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Add(Division division)
        {
            ViewData["Country"] = new SelectList(_context.Countries, "Id", "Name");

            if (division.Id > 0)
            {
                var existingDivision1 = _context.Divisions.FirstOrDefault(x => x.Name == division.Name);
                if (existingDivision1 != null)
                {
                    if (existingDivision1.IsActive == false)
                    {
                        TempData["Message"] = $"{division.Name} division has been deleted, please contact admin";
                        return RedirectToAction("Add");
                    }
                    else
                    {
                        TempData["Message"] = $"{division.Name} division already exists";
                        return RedirectToAction("Add");
                    }
                }


                else
                {
                    var existingDivision = _context.Divisions.FirstOrDefault(x => x.Id == division.Id);
                    if (existingDivision != null)
                    {
                        existingDivision.Name = division.Name;
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
                var existingDivision1 = _context.Divisions.FirstOrDefault(x => x.Name == division.Name);
                if (existingDivision1 != null)
                {
                    if (existingDivision1.IsActive == false)
                    {
                        TempData["Message"] = $"{division.Name} division has been deleted, please contact admin";
                        return RedirectToAction("Add");
                    }
                    else
                    {
                        TempData["Message"] = $"{division.Name} division already exists";
                        return RedirectToAction("Add");
                    }
                }

                else
                {
                    division.IsActive = true;
                    division.CreatedDate = DateTime.Now;
                    division.CreatedBy = _userManager.GetUserId(User);
                    _context.Divisions.Add(division);
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
                return View(division);
            }

        }



        [HttpGet]
        public IActionResult Show()
        {
            ViewBag.Message = TempData["Message"];
            var Divisions = _context.Divisions.Where(x => x.IsActive).Include("Country").ToList();
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
            _context.Divisions.Remove(_context.Divisions.Find(id));
            var existingDivision = _context.Divisions.FirstOrDefault(x => x.Id == id);
            if (existingDivision != null)
            {
                existingDivision.IsActive = false;
                existingDivision.UpdatedDate = DateTime.Now;
                _context.Update(existingDivision);
            }

            _context.SaveChanges();
            return RedirectToAction("Show");
        }
    }
}
