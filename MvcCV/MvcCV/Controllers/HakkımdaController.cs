using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class HakkımdaController : Controller
    {
        // GET: Hakkımda
        dbCVEntities db = new dbCVEntities();
        GenericRepository<tblhakkında> rep = new GenericRepository<tblhakkında>();
        [HttpGet]
        public ActionResult Index()
        {
            var hakkında = rep.List();
            return View(hakkında);
        }
        [HttpPost]
        public ActionResult Index(tblhakkında p)
        {
            var t = rep.Find(x => x.ID == 1);
            t.Ad = p.Ad;
            t.Soyad = p.Soyad;
            t.Adres = p.Adres;
            t.Mail = p.Mail;
            t.Resim = p.Resim;
            t.Telefon = p.Telefon;
            t.Acıklama = p.Acıklama;
            rep.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}