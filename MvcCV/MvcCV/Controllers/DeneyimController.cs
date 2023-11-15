using MvcCV.Models.Entity;
using MvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository rep = new DeneyimRepository();
        public ActionResult Index()
        {
            var degerler = rep.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult deneyimekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult deneyimekle(Tbl_Deneyimler p)
        {
            rep.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult deneyimsil(int id)
        {
            Tbl_Deneyimler t = rep.Find(x => x.ID == id);
            rep.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult deneyimgetir(int id)
        {
            Tbl_Deneyimler t = rep.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult deneyimgetir(Tbl_Deneyimler p)
        {
            Tbl_Deneyimler t = rep.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.Altbaslik = p.Altbaslik;
            t.Tarih = p.Tarih;
            t.Aciklama = p.Aciklama;
            rep.TUpdate(t);

            return RedirectToAction("Index");
        }
    }
}