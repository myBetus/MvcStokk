using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokk.Models.Entitiy;
namespace MvcStokk.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(Satis p)
        {
            db.Satis.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}