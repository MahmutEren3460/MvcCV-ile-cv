using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<Tbl_Login> rep = new GenericRepository<Tbl_Login>();

        public ActionResult Index()
        {
            var list = rep.List();
            return View(list);
        }
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminEkle(Tbl_Login p)
        {
            rep.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult AdminSil(int id)
        {
            Tbl_Login t = rep.Find(x => x.ID == id);
            rep.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminGetir(int id)
        {
            Tbl_Login t = rep.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult AdminGetir(Tbl_Login p)
        {
            Tbl_Login t = rep.Find(x => x.ID == p.ID);
            t.KullaniciAdi = p.KullaniciAdi;
            t.Sifre = p.Sifre;
            rep.TUpdate(t);

            return RedirectToAction("Index");
        }
    }
}