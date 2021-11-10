using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using SSEcommerceWebApp.Data;
using SSEcommerceWebApp.Models;

namespace SSEcommerceWebApp.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IServiceProvider _serviceProvider;

        public RegistrationController(ApplicationDbContext context, IWebHostEnvironment environment,
            UserManager<ApplicationUser> userManager, IServiceProvider serviceProvider)
        {
            _context = context;
            _environment = environment;
            _userManager = userManager;
            _serviceProvider = serviceProvider;
        }


        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AdminList()
        {
            var admins = _context.ApplicationUser.Where(r => r.FirstName != null);
            return View(admins);
        } 
        
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> VendorList()
        {
            var vendors =_context.ApplicationUser.Where(r => r.RestaurantName != null);
            return View(vendors);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AdminSignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminSignUp(ApplicationUser user)
        {
            var roleManager = _serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var userId = _userManager.GetUserId(User);
            var nidImagePath = SaveNidImage(user.NidImage);
            var userImagePath = SaveUserImage(user.UserImage);

            user.NidImagePath = nidImagePath;
            user.UserImagePath = userImagePath;
            user.UserName = user.PhoneNumber;
            user.PhoneNumber = user.PhoneNumber;
            user.PhoneNumberConfirmed = true;
            user.EmailConfirmed = true;
            user.IsActive = true;
            user.CreatedDate = DateTime.Now;
            user.CreatedBy = userId;
            //Default Password
                
            var result =  await _userManager.CreateAsync(user, "Dc$1234");
            
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Administrator");
                ViewBag.SuccessMessaage = "Successfully Added";
                return View();
            } 
            else if (result.Errors.Any())
            {
                ViewBag.ErrorMessage = result.Errors.FirstOrDefault()?.Description;
                return View();
            }
            else
            {
                ViewBag.ErrorMessage = "Failed to save";
                return View(user);
            }
            
        }
        
        public async Task<IActionResult> DoctorSignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DoctorSignUp(ApplicationUser user)
        {
            var userId = _userManager.GetUserId(User);
            var userImagePath = SaveUserImage(user.UserImage);
            user.UserImagePath = userImagePath;
            user.FirstName = user.FirstName;
            user.LastName = user.LastName;
            user.UserName = user.PhoneNumber;
            user.PhoneNumber = user.PhoneNumber;
            user.PhoneNumberConfirmed = true;
            user.IsActive = true;
            user.CreatedDate = DateTime.Now;
            user.CreatedBy = userId;
            //Default Password
            var result = await _userManager.CreateAsync(user, "Dc$1234");

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Doctor");
                ViewBag.SuccessMessaage = "Successfully Added";
                return View();
            }
            else if (result.Errors.Any())
            {
                ViewBag.ErrorMessage = result.Errors.FirstOrDefault()?.Description;
                return View();
            }
            else
            {
                ViewBag.ErrorMessage = "Failed to save";
                return View(user);
            }

        }




        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> VendorSignUpForAdmin()
        {
            ViewData["Vendors"] = new SelectList(_context.ApplicationUser
                .Where(au => au.RestaurantName != null), "Id", "RestaurantName"); 
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VendorSignUpForAdmin(ApplicationUser user)
        {
            ViewData["Vendors"] = new SelectList(_context.ApplicationUser
                    .Where(au => au.RestaurantName != null), "Id", "RestaurantName");
            var userId = _userManager.GetUserId(User);
            var nidImagePath = SaveNidImage(user.NidImage);
            var menuImagePath = SaveMenuImage(user.MenuImage);
            var restaurantImagePath = SaveRestaurantImage(user.RestaurantImage);
            var logoPath = SaveLogoImage(user.RestaurantLogo);
           
                user.NidImagePath = nidImagePath;
                user.MenuImagePath = menuImagePath;
                user.RestaurantImagePath = restaurantImagePath;
                user.LogoPath = logoPath;
                user.PhoneNumber = user.PhoneNumber;
                user.UserName = user.PhoneNumber;
                user.PhoneNumberConfirmed = true;
                user.EmailConfirmed = true;
                user.IsApproved = true;
                user.IsActive = true;
                user.CreatedDate = DateTime.Now;
                user.CreatedBy = userId;
                //Default Password
                
                var result =  await _userManager.CreateAsync(user, "Dc$1234");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Vendor");
                    ViewBag.SuccessMessaage = "Successfully Added";
                    return View();
                } 
                else if (result.Errors.Any())
                {
                    ViewBag.ErrorMessage = result.Errors.FirstOrDefault()?.Description;
                    return View(user);
                }
                else
                {
                    ViewBag.ErrorMessage = "Failed to save";
                    return View(user);
                }
            
        }



        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateVendorForAdmin(string id)
        {
            var users = _context.ApplicationUser.ToList();
            foreach (var u in users)
            {
                u.PhoneNumber = u.UserName;
            }
            _context.UpdateRange(users);
            var user = _context.ApplicationUser.FirstOrDefault(u => u.Id == id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVendorForAdmin(ApplicationUser user)
        {
            ViewData["Vendors"] = new SelectList(_context.ApplicationUser
                .Where(au => au.RestaurantName != null), "Id", "RestaurantName");

            var userId = _userManager.GetUserId(User);
            var existingUser = _context.ApplicationUser.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                
                if (user.NidImage != null)
                {
                    var nidImagePath = UpdateNidImage(user.NidImage, existingUser.NidImagePath);
                    existingUser.NidImagePath = nidImagePath;
                }

                if (user.MenuImage !=null)
                {
                    var menuImagePath = UpdateMenuImage(user.MenuImage, existingUser.MenuImagePath);
                    existingUser.MenuImagePath = menuImagePath;

                }

                if (user.RestaurantImage != null)
                {
                    var restaurantImagePath = UpdateRestaurantImage(user.RestaurantImage, existingUser.RestaurantImagePath);
                    existingUser.RestaurantImagePath = restaurantImagePath;
                }

                if (user.RestaurantLogo !=null)
                {
                    var logoPath = UpdateLogoImage(user.RestaurantLogo, existingUser.RestaurantImagePath);
                    existingUser.LogoPath = logoPath;
                }
                existingUser.UserName = user.PhoneNumber;
                existingUser.PhoneNumberConfirmed = true;
                existingUser.EmailConfirmed = true;
                existingUser.IsApproved = true;
                existingUser.IsActive = true;
                existingUser.UpdatedDate = DateTime.Now;
                existingUser.UpdatedBy = userId;
                _context.Update(existingUser);
            }
            
            if (await _context.SaveChangesAsync() > 0)
            {
                ViewBag.SuccessMessaage = "Successfully Updated";
                return View();
            }
            else
            {
                ViewBag.ErrorMessage = "Failed to update";
                return View(user);
            }
            
        }


        [Authorize(Roles = "Vendor")]
        public async Task<IActionResult> VendorSignUpForFood()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VendorSignUpForFood(ApplicationUser user)
        {
            var userId = _userManager.GetUserId(User);
            var nidImagePath = SaveNidImage(user.NidImage);
            var menuImagePath = SaveMenuImage(user.MenuImage);
            var restaurantImagePath = SaveRestaurantImage(user.RestaurantImage);
            var logoPath = SaveLogoImage(user.RestaurantLogo);
           
                user.NidImagePath = nidImagePath;
                user.MenuImagePath = menuImagePath;
                user.RestaurantImagePath = restaurantImagePath;
                user.LogoPath = logoPath;
                user.UserName = user.PhoneNumber;
                user.PhoneNumberConfirmed = true;
                user.EmailConfirmed = true;
                user.IsActive = true;
                user.CreatedDate = DateTime.Now;
                user.CreatedBy = userId;
                //Default Password
                
                var result =  await _userManager.CreateAsync(user, "Dc$1234");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Vendor");
                    ViewBag.SuccessMessaage = "Successfully Added";
                    return View();
                } 
                else if (result.Errors.Any())
                {
                    ViewBag.ErrorMessage = result.Errors.FirstOrDefault()?.Description;
                    return View();
                }
                else
                {
                    ViewBag.ErrorMessage = "Failed to save";
                    return View(user);
                }
            
        }


  
        public async Task<IActionResult> UpdateVendorForFood(ApplicationUser user)
        {
            ApplicationUser vendor = new ApplicationUser();
            if (user.Id != null)
            {
                vendor = await _userManager.GetUserAsync(User);
            }

            return View(vendor);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVendorForFood(ApplicationUser user, string btnValue)
        {
                var userId = _userManager.GetUserId(User);
                var nidImagePath = SaveNidImage(user.NidImage);
                var menuImagePath = SaveMenuImage(user.MenuImage);
                var oldUser = _context.ApplicationUser.FirstOrDefault(si => si.Id == user.Id);
                if (oldUser != null)
                {
                    oldUser.RestaurantName = user.RestaurantName;
                    oldUser.RestaurantTypeId = user.RestaurantTypeId;
                    oldUser.ContactPersonName = user.ContactPersonName;
                    oldUser.NidImagePath = nidImagePath;
                    oldUser.MenuImagePath = menuImagePath;
                    oldUser.FacebookPageLink = user.FacebookPageLink;
                    oldUser.IsActive = oldUser.IsActive;
                    oldUser.UpdatedBy = userId;
                    oldUser.UpdatedDate = DateTime.Now;

                    _context.ApplicationUser.Update(oldUser);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        ViewBag.SuccessMessaage = "Successfully Added";
                        return View();
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Failed to save";
                        return View(user);
                    }
                }

                ViewBag.ErrorMessage = "Invalid User";
                return View(user);
            
        }

        public string SaveUserImage(IFormFile itemFile)
        {
            if (itemFile != null)
            {

                var filePath = Path.Combine(_environment.WebRootPath, "Image/admin/");

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
                return "/Image/admin/" + uniqueFileName;
            }

            return null;
        }
        public string SaveNidImage(IFormFile itemFile)
        {
            if (itemFile != null)
            {

                var filePath = Path.Combine(_environment.WebRootPath, "Image/nid/");

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
                return "/Image/nid/" + uniqueFileName;
            }

            return null;
        }

        public string SaveMenuImage(IFormFile itemFile)
        {
            if (itemFile != null)
            {

                var filePath = Path.Combine(_environment.WebRootPath, "Image/foodmenu/");

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
                return "/Image/foodmenu/" + uniqueFileName;
            }

            return null;
        }
     public string SaveRestaurantImage(IFormFile itemFile)
        {
            if (itemFile != null)
            {

                var filePath = Path.Combine(_environment.WebRootPath, "Image/restaurant/");

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
                return "/Image/restaurant/" + uniqueFileName;
            }

            return null;
        }

        public string SaveLogoImage(IFormFile itemFile)
        {
            if (itemFile != null)
            {

                var filePath = Path.Combine(_environment.WebRootPath, "Image/restaurant_logo/");

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
                return "/Image/restaurant_logo/" + uniqueFileName;
            }

            return null;
        }


        public string UpdateNidImage(IFormFile itemFile, string existingFilePath)
        {
            if (existingFilePath != null)
            {
                if (System.IO.File.Exists(existingFilePath.Split('/').Last()))
                {
                    System.IO.File.Delete(existingFilePath.Split('/').Last());
                }
            }

            if (itemFile != null)
            {
                var filePath = Path.Combine(_environment.WebRootPath, "Image/nid/");

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
                return "/Image/nid/" + uniqueFileName;
            }

            return null;
        }  
        public string UpdateMenuImage(IFormFile itemFile, string existingFilePath)
        {
            if (existingFilePath != null)
            {
                if (System.IO.File.Exists(existingFilePath.Split('/').Last()))
                {
                    System.IO.File.Delete(existingFilePath.Split('/').Last());
                }
            }

            if (itemFile != null)
            {

                var filePath = Path.Combine(_environment.WebRootPath, "Image/foodmenu/");

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
                return "/Image/foodmenu/" + uniqueFileName;
            }

            return null;
        }  
        public string UpdateRestaurantImage(IFormFile itemFile, string existingFilePath)
        {
            var fileName = existingFilePath.Split('/').Last();

            if (existingFilePath != null)
            {
                var filePath = Path.Combine(_environment.WebRootPath, "Image/restaurant/"+fileName);

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            if (itemFile != null)
            {
                var filePath = Path.Combine(_environment.WebRootPath, "Image/restaurant/");

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
                return "/Image/restaurant/" + uniqueFileName;
            }

            return null;
        }
        
        public string UpdateLogoImage(IFormFile itemFile, string existingFilePath)
        {   
            if (existingFilePath != null)
            {
                if (System.IO.File.Exists(existingFilePath.Split('/').Last()))
                {
                    System.IO.File.Delete(existingFilePath.Split('/').Last());
                }
            }

            if (itemFile != null)
            {

                var filePath = Path.Combine(_environment.WebRootPath, "Image/restaurant_logo/");

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
                return "/Image/restaurant_logo/" + uniqueFileName;
            }

            return null;
        }
    }
}
