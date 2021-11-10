using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SSEcommerceWebApp.Data;
using SSEcommerceWebApp.Models;
using SSEcommerceWebApp.ViewModels;
using System.Diagnostics;
using System.Linq;

namespace SSEcommerceWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Mainpage()
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress;
            var homeViewData = new HomeViewModelForFood
            {
                SliderImages = _context.SliderImages.Where(si => si.IsActive).ToList(),
                Restaurants = _context.ApplicationUser
                    .Where(r => r.RestaurantName != null && r.RestaurantName != null)
                    .Include(r => r.Products)
                    .ThenInclude(p => p.SubCategory)
                    .ThenInclude(sc => sc.Category)
                    .ToList()
            };
            return View(homeViewData);

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SelectLocation()
        {
            return View();
        }

        public IActionResult Restaurant()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult MyAccount()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult AddtoCart()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult BusinessService()
        {
            return View();
        }

        public IActionResult BusinessPartner()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
