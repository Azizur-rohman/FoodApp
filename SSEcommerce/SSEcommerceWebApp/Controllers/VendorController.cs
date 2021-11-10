using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SSEcommerceWebApp.Controllers
{
    public class VendorController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
