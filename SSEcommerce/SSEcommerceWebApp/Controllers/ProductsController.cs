using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SSEcommerceWebApp.Data;
using SSEcommerceWebApp.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SSEcommerceWebApp.Controllers
{
    [Authorize(Roles = "Administrator, Vendor")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductsController(ApplicationDbContext context, IWebHostEnvironment environment,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _environment = environment;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var s = _context.SubCategories.Include(s => s.Products);
            var pd = _context.Products.Include(s => s.SubCategory);
            var products = _context.Products
                .Include(p => p.SubCategory)
                .ThenInclude(p => p.Category);
            return View(await products.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                    .Include(p => p.SubCategory)
                    .ThenInclude(p => p.Category)
                    .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Create()
        {
            ViewData["Vendor"] = new SelectList(_context.ApplicationUser.Where(au => au.RestaurantName != null), "Id", "RestaurantName");
            ViewData["Category"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["SubCategory"] = new SelectList(_context.SubCategories, "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                product.ImagePath = SaveImage(product.Image);
                product.CreatedBy = _userManager.GetUserId(User); ;
                product.CreatedDate = DateTime.Now;
                product.IsActive = true;
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "Id", "Name");
            return View(product);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _context.Products
                .Include(p => p.SubCategory)
                .ThenInclude(sc => sc.Category)
                .ToList()
                .FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.SubCategory.CategoryId);
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "Id", "Name", product.SubCategoryId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", product.CategoryId);
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "Id", "Id", product.SubCategoryId);
            return View(product);
        }


        public async Task<IActionResult> UpdateQuantity(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateQuantity(int productId, int quantity)
        {
            var product = await _context.Products.FindAsync(productId);
            product.Quantity += quantity;
            _context.Update(product);
            if (await _context.SaveChangesAsync() > 0)
            {
                TempData["UpdateQtySuccessMessage"] = "Quantity updated successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["UpdateQtyFailedMessage"] = "Quantity failed to update";
            }

            return View(product);
        }
        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                    .Include(p => p.SubCategory)
                    .ThenInclude(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        public string SaveImage(IFormFile itemFile)
        {
            if (itemFile != null)
            {

                var filePath = Path.Combine(_environment.WebRootPath, "Image/products/");

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
                return "/Image/products/" + uniqueFileName;
            }

            return null;
        }

        public IActionResult LoadSubCategoryByCategory(int categoryId)
        {
            var subCategory = _context.SubCategories.Where(sc => sc.CategoryId == categoryId);
            return Json(subCategory);
        }

        [AllowAnonymous]
        public IActionResult RestaurantWiseProduct(string id)
        {
            var products = _context.Products
                .Where(p => p.ApplicationUserId == id)
                .Include(p => p.ApplicationUser)
                .Include(P => P.SubCategory)
                .ThenInclude(p=> p.Category);
            return View(products);
        }
    }
}
