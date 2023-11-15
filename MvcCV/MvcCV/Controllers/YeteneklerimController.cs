using MvcCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class YeteneklerimController : Controller
    {
        GenericRepository<Tbl_Yetenek> rep = new GenericRepository<Tbl_Yetenek>();
        public ActionResult Index()
        {
            var yetenek = rep.List();
            return View(yetenek);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(Tbl_Yetenek p)
        {
            rep.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var yetenek = rep.Find(x => x.ID == id);
            rep.TDelete(yetenek);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult duzenle(int id)
        {
            var yetenek = rep.Find(x => x.ID == id);
            return View(yetenek);
        }
        [HttpPost]
        public ActionResult duzenle(Tbl_Yetenek t)
        {
            var y = rep.Find(x => x.ID == t.ID);
            y.Yetenek = t.Yetenek;
            y.Oran = t.Oran;
            rep.TUpdate(y);
            return RedirectToAction("Index");
        }
    }
}