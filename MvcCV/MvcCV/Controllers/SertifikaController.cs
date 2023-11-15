using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Repositories;
using MvcCV.Models.Entity;
namespace MvcCV.Controllers
{
    public class SertifikaController : Controller
    {
        GenericRepository<Tbl_Sertifika> rep = new GenericRepository<Tbl_Sertifika>();
        // GET: Sertifika
        public ActionResult Index()
        {
            var sertifika = rep.List();
            return View(sertifika);
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = rep.Find(x => x.ID == id);
            ViewBag.d = id;
            return View(sertifika);
        }
        [HttpPost]
        public ActionResult SertifikaGetir(Tbl_Sertifika t)
        {
            var sertifika = rep.Find(x => x.ID == t.ID);
            sertifika.Aciklama = t.Aciklama;
            sertifika.Tarih = t.Tarih;
            rep.TUpdate(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSertifika(Tbl_Sertifika t)
        {
            rep.TAdd(t);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id)
        {
            var sertifika = rep.Find(x => x.ID == id);
            rep.TDelete(sertifika);
            return RedirectToAction("Index");
        }
    }
}