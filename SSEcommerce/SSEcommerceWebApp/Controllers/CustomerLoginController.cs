using Microsoft.AspNetCore.Mvc;

namespace SSEcommerceWebApp.Controllers
{
    public class CustomerLoginController : Controller
    {
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
    }
}
