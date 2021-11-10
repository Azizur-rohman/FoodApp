using Microsoft.AspNetCore.Mvc;
using SSEcommerceWebApp.Data;
using SSEcommerceWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSEcommerceWebApp.Controllers
{
    public class HospitalController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HospitalController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Add(int id)
        {
            ViewBag.Message = TempData["Message"];
            if (id != null)
            {
                var hospital = _context.Hospitals.FirstOrDefault(x => x.Id == id);
                return View(hospital);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Add(Hospital hospital)
        {
            if (hospital.Id > 0)
            {
                var existingHospital1 = _context.Hospitals.FirstOrDefault(x => x.Name == hospital.Name);
                if (existingHospital1 != null)
                {
                    if (existingHospital1.IsActive == false)
                    {
                        TempData["Message"] = $"{hospital.Name} hospital has been deleted, please contact admin";
                        return RedirectToAction("Add");
                    }
                    else
                    {
                        TempData["Message"] = $"{hospital.Name} hospital already exists";
                        return RedirectToAction("Add");
                    }
                }

                else
                {
                    var existingHospital = _context.Hospitals.FirstOrDefault(x => x.Id == hospital.Id);
                    if (existingHospital != null)
                    {
                        existingHospital.Name = hospital.Name;
                        existingHospital.IsActive = true;
                        existingHospital.UpdatedDate = DateTime.Now;
                        _context.Update(existingHospital);
                        RedirectToAction("Show");
                    }
                    return RedirectToAction("Add");
                }
            }
            else
            {
                var existingHospital = _context.Hospitals.FirstOrDefault(x => x.Name == hospital.Name);
                if (existingHospital != null)
                {
                    if (existingHospital.IsActive == false)
                    {
                        TempData["Message"] = $"{hospital.Name} hospital has been deleted, please contact admin";
                        return RedirectToAction("Add");
                    }
                    else
                    {
                        TempData["Message"] = $"{hospital.Name} hospital already exists";
                        return RedirectToAction("Add");
                    }
                }
                else
                {
                    hospital.IsActive = true;
                    hospital.CreatedDate = DateTime.Now;
                    _context.Hospitals.Add(hospital);
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
                return View(hospital);
            }

        }



        [HttpGet]
        public IActionResult Show()
        {
            ViewBag.Message = TempData["Message"];
            var dataList = _context.Hospitals.Where(x => x.IsActive == true);
            return View(dataList);
        }


        public IActionResult Delete(int id)
        {
            _context.Hospitals.Remove(_context.Hospitals.Find(id));
            var existingHospital = _context.Hospitals.FirstOrDefault(x => x.Id == id);
            if (existingHospital != null)
            {
                existingHospital.IsActive = false;
                existingHospital.UpdatedDate = DateTime.Now;
                _context.Update(existingHospital);
            }

            _context.SaveChanges();
            return RedirectToAction("Show");
        }
    }
}
