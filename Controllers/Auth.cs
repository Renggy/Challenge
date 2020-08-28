using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

using Challenge.App;
using Challenge.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Controllers
{
    public class Auth : Controller
    {
        private readonly ConnectionString _context;
        
        public Auth(ConnectionString context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View("index");
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Index(AuthModel model)
        {
            if (ModelState.IsValid)
            {
                var User = (from table_user in _context.table_user
                            where table_user.username == model.username
                            select table_user).FirstOrDefault();
                if(User == null)
                {
                    ViewBag.Message = "User Tidak Ditemukan";
                }
                else
                {
                    App.Cryptography Classic = new Cryptography();
                    model.password = Classic.EncryptString(model.password);
                    if(User.password == model.password)
                    {
                        HttpContext.Session.SetInt32("ID_User", User.id_user);
                        HttpContext.Session.SetString("User", User.username);
                        HttpContext.Session.SetInt32 ("Role", User.id_role);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Message = "Password Salah";
                    }
                }
                return View("Index");
            }
            else
            {
                return View("index");
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Auth");
        }
    }
}
