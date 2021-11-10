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
    public class DoctorPersonalDetailController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DoctorPersonalDetailController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Add(int id)
        {
            ViewData["Hospital"] = new SelectList(_context.Hospitals.Where(x => x.IsActive == true), "Id", "Name");
            ViewBag.Message = TempData["Message"];
            if (id > 0)
            {
                var doctorPersonalDetail = _context.DoctorPersonalDetails.FirstOrDefault(x => x.Id == id);
                return View(doctorPersonalDetail);
            }
            return View();
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
