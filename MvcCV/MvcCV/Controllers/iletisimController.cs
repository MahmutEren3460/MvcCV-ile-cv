using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;


namespace MvcCV.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
        GenericRepository<Tbl_İletişim> rep = new GenericRepository<Tbl_İletişim>();
        public ActionResult Index()
        {
            var mesajlar = rep.List();
            return View(mesajlar);
        }
    }
}