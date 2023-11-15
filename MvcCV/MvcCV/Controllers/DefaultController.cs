using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;

namespace MvcCV.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {

        // GET: Default
        dbCVEntities db = new dbCVEntities();
        public ActionResult Index()
        {
            var degerler = db.tblhakkında.ToList();
            return View(degerler);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler = db.Tbl_Deneyimler.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.tbl_SosyalMedya.Where(x=>x.Durum==true).ToList();
            return PartialView(sosyalmedya);
        }
        public PartialViewResult egitimlerim()
        {
            var egitim = db.Tbl_Egitim.ToList();
            return PartialView(egitim);
        }
        public PartialViewResult yeteneklerim()
        {
            var yetenek = db.Tbl_Yetenek.ToList();
            return PartialView(yetenek);
        }
        public PartialViewResult hobilerim()
        {
            var hobi = db.tbl_Hobi.ToList();
            return PartialView(hobi);
        }
        public PartialViewResult sertifikalarım()
        {
            var sertifika = db.Tbl_Sertifika.ToList();
            return PartialView(sertifika);
        }
        [HttpGet]
        public PartialViewResult iletişimim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult iletişimim(Tbl_İletişim t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbl_İletişim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}