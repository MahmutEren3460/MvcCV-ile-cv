using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<tbl_SosyalMedya> rep = new GenericRepository<tbl_SosyalMedya>();
        dbCVEntities db = new dbCVEntities();
        public ActionResult Index()
        {
            var veriler = rep.List();
            return View(veriler);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(tbl_SosyalMedya p)
        {
            rep.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Getir(int id)
        {
            var t = rep.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult Getir(tbl_SosyalMedya p)
        {
            var t = rep.Find(x => x.ID == p.ID);
            t.Ad = p.Ad;
            t.Durum = true;
            t.ikon = p.ikon;
            t.Link = p.Link;
            rep.TUpdate(t);
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var t = rep.Find(x => x.ID == id);
            t.Durum = false;
            rep.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}