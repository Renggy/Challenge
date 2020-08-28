using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Challenge.App;
using Challenge.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Controllers
{
    public class Request : Controller
    {
        private readonly ConnectionString _context;

        public Request(ConnectionString context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Logout", "Auth");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Tambah(RequestModel Permintaan, AuthModel Asem)
        {
            RequestModel Req = new RequestModel()
            {
                id_user = Permintaan.id_user,
                nama_barang = Permintaan.nama_barang,
                jumlah = Permintaan.jumlah,
                spesifikasi = Permintaan.spesifikasi
            };
            _context.table_transaksi_request.Add(Req);
            if(_context.SaveChanges() > 0)
            {
                TempData["Request"] = "Good Job,success,Berhasil Diinputkan";
            }
            else
            {
                TempData["Request"] = "Sorry,error,Gagal Diinputkan";
            }
            return RedirectToAction("Index", "Request");
        }
    }
}
