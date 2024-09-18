using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class SatisController : Controller
    {
        // GET: Satış
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.SatisHarekets.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1=(from x in c.Uruns.ToList()
                                         select new SelectListItem
                                         {
                                             Text=x.ad,
                                             Value=x.id.ToString()
                            }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ad + " " + x.soyad,
                                               Value = x.id.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ad + " " + x.soyad,
                                               Value = x.id.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            s.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetir(int id)
        {
            var deger = c.SatisHarekets.Find(id);
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ad,
                                               Value = x.id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ad + " " + x.soyad,
                                               Value = x.id.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ad + " " + x.soyad,
                                               Value = x.id.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;

            return View(deger);
        }
        public ActionResult SatisGuncelle(SatisHareket s)
        {
            if (!ModelState.IsValid)
            {
                return View("SatisGetir");
            }
            var deger = c.SatisHarekets.Find(s.satisId);
            
            deger.tarih=s.tarih;
            deger.adet = s.adet;
            deger.fiyat = s.fiyat;
            deger.toplamTutar = s.toplamTutar;
            deger.satisId = s.satisId;
            deger.cariId = s.cariId;
            deger.personelId = s.personelId;
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult SatisDetay(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.satisId == id).ToList();
            return View(degerler);
        }
    }
}