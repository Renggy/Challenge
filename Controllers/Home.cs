using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Controllers
{
    public class Home : Controller
    {
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Logout", "Auth");
            }
            return View();
        }
    }
}
