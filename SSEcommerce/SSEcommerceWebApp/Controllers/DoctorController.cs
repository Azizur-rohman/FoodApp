using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSEcommerceWebApp.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult DoctorMainPage()
        {
            return View();
        }

        public IActionResult DoctorService()
        {
            return View();
        }

        public IActionResult DoctorDetails()
        {
            return View();
        }

        
        public IActionResult DoctorDashboard()
        {
            return View();
        }

        public IActionResult PersonalDetails()
        {
            return View();
        }

        public IActionResult WorkingDetails()
        {
            return View();
        }

        public IActionResult DoctorNotification()
        {
            return View();
        }
    }
}
