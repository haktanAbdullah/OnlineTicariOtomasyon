using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using PagedList;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class UrunController : Controller
    {
        List<SelectListItem> kategoriFunk()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.Where(x=>x.durum==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ad,
                                               Value = x.id.ToString()
                                           }).ToList();
            return deger1;
        }
        // GET: Urun
        Context c = new Context();

        public ActionResult Index(string p)
        {
            var urunler = from x in c.Uruns.Where(x=>x.durum==true) select x;

            // Filtreleme işlemi
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.ad.Contains(p));
            }

            // Sayfalama işlemi
            var siraliUrunler = urunler.OrderBy(x => x.id).ToList();

            return View(siraliUrunler);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            ViewBag.dgr1 = kategoriFunk();
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Urun p)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.dgr1 = kategoriFunk();
                // ModelState geçerli değilse, formu tekrar göster
                return View("YeniUrun");
            }

            // ModelState geçerliyse, departmanı ekleyip başarı mesajı gönder
            p.durum = true;
            c.Uruns.Add(p);
            c.SaveChanges();

            // TempData'ya başarı mesajını ekleyelim
            TempData["SuccessMessage"] = "Ürün başarıyla eklendi";

            // Index sayfasına yönlendirme yapalım
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var deger = c.Uruns.Find(id);
            deger.durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            ViewBag.dgr1 = kategoriFunk();

            var urunDeger = c.Uruns.Find(id);
            return View("UrunGetir", urunDeger);
        }

        [HttpPost]
        public ActionResult UrunGuncelle(Urun p,int urunId)
        {
            if (!ModelState.IsValid)
            {
                return View("UrunGetir", urunId);
            }

            TempData["SuccessMessage"] = "Urun basariyla guncellendi";

            var deger = c.Uruns.Find(urunId);
            deger.ad = p.ad;
            deger.stok = p.stok;
            deger.alisFiyat = p.alisFiyat;
            deger.satisFiyat = p.satisFiyat;
            deger.gorsel = p.gorsel;
            deger.marka = p.marka;
            deger.kategoriid = p.kategoriid;

            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunListesi()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ad + " " + x.soyad,
                                               Value = x.id.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            var deger1 = c.Uruns.Find(id);
            ViewBag.dgr1 = deger1.id;
            ViewBag.dgr2 = deger1.satisFiyat;

            return View();
        }

        [HttpPost]
        public ActionResult SatisYap(SatisHareket p)
        {
            p.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index","Satis");
        }
    } 
}