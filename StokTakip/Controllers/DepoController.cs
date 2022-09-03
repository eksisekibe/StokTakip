using StokTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StokTakip.Controllers
{
    public class DepoController : Controller
    {
        stoktakipEntities db = new stoktakipEntities();
        // GET: Depo
        
        public ActionResult Index()
        {
            var bilgiler = db.DepoGirisCikis.ToList();
            return View(bilgiler);
        }

        [HttpGet]
        public ActionResult DepoEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepoEkle(DepoGirisCikis dp)
        {
            db.DepoGirisCikis.Add(dp);
            db.SaveChanges();
            return View();
        }

        public ActionResult SİL(int id)
        {
            var depo = db.DepoGirisCikis.Find(id);
            db.DepoGirisCikis.Remove(depo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepoGetir(int id)
        {
            var depo = db.DepoGirisCikis.Find(id);
            return View("DepoGetir", depo);
        }

        public ActionResult GÜNCELLE(DepoGirisCikis dp)
        {
            var depo = db.DepoGirisCikis.Find(dp.Id);
            depo.Id = dp.Id;
            depo.FisNo = dp.FisNo;
            depo.DepoKodu = dp.DepoKodu;
            depo.GCMiktarı = dp.GCMiktarı;
            depo.KayitTarihi = dp.KayitTarihi;
            depo.KullaniciAdi = dp.KullaniciAdi;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}