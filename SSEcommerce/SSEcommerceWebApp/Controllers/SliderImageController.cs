using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SSEcommerceWebApp.Data;
using SSEcommerceWebApp.Models;

namespace SSEcommerceWebApp.Controllers
{
    public class SliderImageController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        private readonly UserManager<ApplicationUser> _userManager;

        public SliderImageController(ApplicationDbContext context, IWebHostEnvironment environment, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _environment = environment;
            _userManager = userManager;
        }

        [Authorize(Roles="Administrator")]
        public IActionResult Add(int? id)
        {

            SliderImage image = new SliderImage();

            if (id != null)
            {
                image = _context.SliderImages.FirstOrDefault(si=>si.Id == id);
            }

            return View(image);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(SliderImage sliderImage, string btnValue)
        {
            var userId = _userManager.GetUserId(User);
            var filePath = SaveImage(sliderImage.Image);
            if (btnValue == "Save")
            {
                sliderImage.ImagePath = filePath;
                sliderImage.IsActive = true;
                sliderImage.CreatedDate = DateTime.Now;
                _context.SliderImages.Add(sliderImage);
                if (_context.SaveChanges()>0)
                {
                    TempData["Success"] = "Successfully Added";
                }
                else
                {
                    TempData["Error"] = "Failed to save";
                }
            }
            else
            {
                var oldSliderImage = _context.SliderImages.FirstOrDefault(si=>si.Id == sliderImage.Id);
                if (oldSliderImage != null)
                {
                    sliderImage.ImagePath = filePath;
                    oldSliderImage.ActionUrl = sliderImage.ActionUrl;
                    oldSliderImage.IsActive = sliderImage.IsActive;
                    oldSliderImage.UpdatedBy = userId;
                    oldSliderImage.UpdatedDate = DateTime.Now;
                    _context.SliderImages.Update(oldSliderImage);
                    if (_context.SaveChanges()>0)
                    {
                        TempData["Success"] = "Successfully Updated";
                    }
                    else
                    {
                        TempData["Error"] = "Failed to update";
                    }
                }
            }

            return RedirectToAction("List");
        }

        [Authorize(Roles="Administrator")]
        public IActionResult List()
        {
            ViewBag.SuccessMessage = TempData["Success"];
            ViewBag.ErrorMessage = TempData["Error"];
            return View();
        }

        public IActionResult LoadData()
        {
            var images = _context.SliderImages;
            return PartialView("_LoadData", images);
        }


        public string SaveImage(IFormFile itemFile)
        {
            if (itemFile != null)
            {

                var filePath = Path.Combine(_environment.WebRootPath, "Image/home_slider/");

                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);

                var fileExt = Path.GetExtension(itemFile.FileName);
                string uniqueFileName = Guid.NewGuid() + fileExt;
                filePath = Path.Combine(filePath, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    itemFile.CopyTo(stream);
                }

                //Utility.CompressImage(filePath);
                return "/Image/home_slider/" + uniqueFileName;
            }

            return null;
        }


        public string UpdateImage(IFormFile itemFile)
        {
            if (itemFile != null)
            {

                var filePath = Path.Combine(_environment.WebRootPath, "Image/home_slider/");

                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);

                var fileExt = Path.GetExtension(itemFile.FileName);
                string uniqueFileName = Guid.NewGuid() + fileExt;
                filePath = Path.Combine(filePath, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    itemFile.CopyTo(stream);
                }

                //Utility.CompressImage(filePath);
                return "/Image/home_slider/" + uniqueFileName;
            }

            return null;
        }
    }
}
    
