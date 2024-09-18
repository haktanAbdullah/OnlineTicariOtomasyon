using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();

        public ActionResult Index()
        {
            var degerler = c.Kategoris.Where(x=>x.durum==true).ToList();
            return View(degerler);
        }
        
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            if (!ModelState.IsValid)
            {
                // ModelState geçerli değilse, formu tekrar göster
                return RedirectToAction("KategoriEkle");
            }

            // ModelState geçerliyse, departmanı ekleyip başarı mesajı gönder
            k.durum = true;
            c.Kategoris.Add(k);
            c.SaveChanges();

            // TempData'ya başarı mesajını ekleyelim
            TempData["SuccessMessage"] = "Kategori başarıyla eklendi";

            // Index sayfasına yönlendirme yapalım
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var katgr = c.Kategoris.Find(id);
            katgr.durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgr = c.Kategoris.Find(id);
            return View(ktgr);
        }

        [HttpPost]
        public ActionResult KategoriGuncelle(Kategori k,int ktgrId)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("KategoriGetir",ktgrId);
            }

            TempData["SuccessMessage"] = "Kategori basariyla guncellendi";

            var ktgr = c.Kategoris.Find(ktgrId);
            ktgr.ad=k.ad;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Deneme()
        {
            Class3 cs = new Class3();
            cs.Kategoriler = new SelectList(c.Kategoris, "kategoriID", "KategoriAd");
            cs.Urunler = new SelectList(c.Uruns, "urunId", "urunAd");
            return View(cs);
        }
    }
}