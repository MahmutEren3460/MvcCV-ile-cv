using MvcCV.Models.Entity;
using MvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    [Authorize]
    public class EgitimController : Controller
    {
        GenericRepository<Tbl_Egitim> rep = new GenericRepository<Tbl_Egitim>();
        // GET: Egitim
        public ActionResult Index()
        {
            var egitim = rep.List();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult egitimekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult egitimekle(Tbl_Egitim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            rep.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            var egitim = rep.Find(x => x.ID == id);
            rep.TDelete(egitim);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimDuz(int id)
        {
            var duzenle = rep.Find(x => x.ID == id);
            return View(duzenle);
        }
        [HttpPost]
        public ActionResult EgitimDuz(Tbl_Egitim t)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimDuz");
            }
            var duzenle = rep.Find(x => x.ID == t.ID);
            duzenle.Baslik = t.Baslik;
            duzenle.AltBaslik = t.AltBaslik;
            duzenle.AltBaslik2 = t.AltBaslik2;
            duzenle.Tarih = t.Tarih;
            duzenle.GNO = t.GNO;
            rep.TUpdate(duzenle);
            return RedirectToAction("Index");
        }
    }
}