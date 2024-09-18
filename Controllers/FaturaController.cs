using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using PagedList;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Faturalars.Where(x => x.durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            if (!ModelState.IsValid)
            {
                return View("FaturaEkle");
            }
            f.durum = true;
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturalars.Find(id);
            return View("FaturaGetir", fatura);
        }
        public ActionResult FaturaGuncelle(Faturalar f)
        {
            if (!ModelState.IsValid)
            {
                return View("FaturaGetir");
            }
            var fatura = c.Faturalars.Find(f.id);
            fatura.seriNo = f.seriNo;
            fatura.sıraNo = f.sıraNo;
            fatura.saat = f.saat;
            fatura.tarih = f.tarih;
            fatura.teslimAlan = f.teslimAlan;
            fatura.teslimEden = f.teslimEden;
            fatura.vergiDairesi = f.vergiDairesi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay()
        {
            var degerler = c.FaturaKalems.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem p)
        {
            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Dinamik()
        {
            Class4 cs = new Class4();
            cs.deger1 = c.Faturalars.ToList();
            cs.deger2 = c.FaturaKalems.ToList();
            return View(cs);
        }
    }
}