using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokk.Models.Entitiy;
namespace MvcStokk.Controllers
{
    public class UrunController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.Urun.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniUrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.Kategori.ToList()//KATEGORİLERİ DROPDOWN OLARAK GETİRDİ
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAdi,
                                                 Value = i.KategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrunEkle(Urun p1)
        {
            var ktgr = db.Kategori.Where(m => m.KategoriID == p1.Kategori.KategoriID).FirstOrDefault();
            p1.Kategori = ktgr;
            db.Urun.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var urun = db.Urun.Find(id);
            db.Urun.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.Urun.Find(id);
            List<SelectListItem> degerler = (from i in db.Kategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAdi,
                                                 Value = i.KategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir", urun);
        }
        public ActionResult GUNCELLE(Urun p1)
        {
            var urun = db.Urun.Find(p1.UrunID);
            urun.UrunAdi = p1.UrunAdi;
            //urun.UrunKategori = p1.UrunKategori;
            var ktgr = db.Kategori.Where(m => m.KategoriID == p1.Kategori.KategoriID).FirstOrDefault();
            urun.UrunKategori = ktgr.KategoriID;
            urun.Marka = p1.Marka;
            urun.Stok = p1.Stok;
            urun.Fiyat = p1.Fiyat;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}