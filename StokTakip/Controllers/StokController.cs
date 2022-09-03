using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakip.Models;

namespace StokTakip.Controllers
{
    public class StokController : Controller
    {
        stoktakipEntities db = new stoktakipEntities();

        // GET: Stok
        public ActionResult Index()
        {
            var bilgiler = db.StokKarti.ToList();
            return View(bilgiler);
        }

        [HttpGet]

        public ActionResult StokEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StokEkle(StokKarti st)
        {
            db.StokKarti.Add(st);
            db.SaveChanges();
            return View();
        }

        public ActionResult SİL(int id)
        {
            var stok = db.StokKarti.Find(id);
            db.StokKarti.Remove(stok);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult StokGetir(int id)
        {
            var stok = db.StokKarti.Find(id);
            return View("StokGetir", stok);
        }

        public ActionResult GÜNCELLE(StokKarti st)
        {
            var stok = db.StokKarti.Find(st.Id);
            stok.Id = st.Id;
            stok.StokKodu = st.StokKodu;
            stok.StokAdi = st.StokAdi;
            stok.Kdv = st.Kdv;
            stok.Fiyat = st.Fiyat;
            stok.Aciklama = st.Aciklama;
            stok.DepoKodu = st.DepoKodu;
            stok.KayitTarihi = st.KayitTarihi;
            stok.KullaniciAdi = st.KullaniciAdi;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}