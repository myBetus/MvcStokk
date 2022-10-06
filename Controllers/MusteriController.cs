using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokk.Models.Entitiy;
namespace MvcStokk.Controllers
{
    public class MusteriController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.Musteri select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MusteriAd.Contains(p));
            //var degerler = db.Musteri.ToList();
            //return View(degerler);
            }
            return View(degerler.ToList());
        }
        [HttpGet]
        public ActionResult YeniMusteriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteriEkle(Musteri p1)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniMusteriEkle");
            }
            db.Musteri.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var deger = db.Musteri.Find(id);
            db.Musteri.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.Musteri.Find(id);
            return View("MusteriGetir", mus);
        }
        public ActionResult GUNCELLE(Musteri p1)
        {
            var mus = db.Musteri.Find(p1.MusteriID);
            mus.MusteriAd = p1.MusteriAd;
            mus.MusteriSoyad = p1.MusteriSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}