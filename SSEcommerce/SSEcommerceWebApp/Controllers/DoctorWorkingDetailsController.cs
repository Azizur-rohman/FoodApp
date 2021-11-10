using Microsoft.AspNetCore.Mvc;
using SSEcommerceWebApp.Data;
using SSEcommerceWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSEcommerceWebApp.Controllers
{
    public class DoctorWorkingDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DoctorWorkingDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Add(int id)
        {
            ViewBag.Message = TempData["Message"];
            if (id != null)
            {
                var doctorWorkingDetail = _context.DoctorWorkingDetails.FirstOrDefault(x => x.Id == id);
                return View(doctorWorkingDetail);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Add(DoctorWorkingDetail doctorWorkingDetails)
        {
            if (doctorWorkingDetails.Id > 0)
            {
                var existingDoctorWorkingDetail1 = _context.DoctorWorkingDetails.FirstOrDefault(x => x.HospitalName == doctorWorkingDetails.HospitalName);
                if (existingDoctorWorkingDetail1 != null)
                {
                    if (existingDoctorWorkingDetail1.IsActive == false)
                    {
                        TempData["Message"] = $"{doctorWorkingDetails.HospitalName} country has been deleted, please contact admin";
                        return RedirectToAction("Add");
                    }
                    else
                    {
                        TempData["Message"] = $"{doctorWorkingDetails.HospitalName} country already exists";
                        return RedirectToAction("Add");
                    }
                }

                else
                {
                    var existingCountry = _context.DoctorWorkingDetails.FirstOrDefault(x => x.Id == doctorWorkingDetails.Id);
                    if (existingCountry != null)
                    {
                        existingCountry.HospitalName = doctorWorkingDetails.HospitalName;
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
                var existingCategory = _context.DoctorWorkingDetails.FirstOrDefault(x => x.HospitalName == doctorWorkingDetails.HospitalName);
                if (existingCategory != null)
                {
                    if (existingCategory.IsActive == false)
                    {
                        TempData["Message"] = $"{doctorWorkingDetails.HospitalName} country has been deleted, please contact admin";
                        return RedirectToAction("Add");
                    }
                    else
                    {
                        TempData["Message"] = $"{doctorWorkingDetails.HospitalName} country already exists";
                        return RedirectToAction("Add");
                    }
                }
                else
                {
                    doctorWorkingDetails.IsActive = true;
                    doctorWorkingDetails.CreatedDate = DateTime.Now;
                    _context.DoctorWorkingDetails.Add(doctorWorkingDetails);
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
                return View(doctorWorkingDetails);
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
