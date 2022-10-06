using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokk.Models.Entitiy;
using PagedList;
using PagedList.Mvc;
namespace MvcStokk.Controllers
{
    public class KategoriController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();


        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.Kategori.ToList();
            var degerler = db.Kategori.ToList().ToPagedList(sayfa, 4);
            return View(degerler);//degerler geri döndürülüyor

        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]

        public ActionResult YeniKategori(Kategori p1)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.Kategori.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var kategori = db.Kategori.Find(id);
            db.Kategori.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.Kategori.Find(id);
            return View("KategoriGetir", kategori);
        }
        public ActionResult GUNCELLE(Kategori p1)
        {
            var ktgr = db.Kategori.Find(p1.KategoriID);
            ktgr.KategoriAdi = p1.KategoriAdi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
