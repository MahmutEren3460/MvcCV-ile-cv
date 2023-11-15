using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<tbl_Hobi> rep = new GenericRepository<tbl_Hobi>();
        public ActionResult Index()
        {
            var hobiler = rep.List();
            return View(hobiler);
        }
        [HttpGet]
        public ActionResult HobiEkle()
        {
            return View();
        } 
        [HttpPost]
        public ActionResult HobiEkle(tbl_Hobi t)
        {
            rep.TAdd(t);
            return RedirectToAction("Index");
        }
        public ActionResult HobiSil(int id)
        {
            var hobi = rep.Find(x => x.ID == id);
            rep.TDelete(hobi);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult HobiGetir(int id)
        {
            tbl_Hobi t = rep.Find(x => x.ID == id);
            return View();
        }
        [HttpPost]
        public ActionResult HobiGetir(tbl_Hobi p)
        {
            tbl_Hobi t = rep.Find(x => x.ID == p.ID);
            t.Aciklama = p.Aciklama;
            rep.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}