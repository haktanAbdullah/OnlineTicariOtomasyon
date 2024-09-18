using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Carilers.Count().ToString();
            ViewBag.d1=deger1;

            var deger2 = c.Uruns.Count().ToString();
            ViewBag.d2=deger2; 
            
            var deger3 = c.Personels.Count().ToString();
            ViewBag.d3=deger3;

            var deger4 = c.Kategoris.Count().ToString();
            ViewBag.d4 = deger4;

            var deger5 = c.Uruns.Sum(x => x.stok).ToString();
            ViewBag.d5 = deger4;

            var deger6 = (from x in c.Uruns select x.marka).Distinct().Count().ToString();
            ViewBag.d6 = deger4;

            var deger7 = c.Uruns.Count(x => x.stok<=20).ToString();
            ViewBag.d7 = deger7;

            var deger8 = (from x in c.Uruns orderby x.satisFiyat descending select x.ad).FirstOrDefault();
            ViewBag.d8 = deger8;

            var deger9 = (from x in c.Uruns orderby x.satisFiyat descending select x.ad).FirstOrDefault();
            ViewBag.d9 = deger9;

            var deger10 = c.Uruns.Count(x => x.ad == "Buzdolabı").ToString();
            ViewBag.d10 = deger10;

            var deger11 = c.Uruns.Where(x => x.ad == "Laptop").Count().ToString();
            ViewBag.d11 = deger11;

            var deger12 = c.Uruns.GroupBy(x => x.marka).OrderByDescending(z => z.Count()).Select(x => x.Key).FirstOrDefault();
            ViewBag.d12 = deger12;

            var deger13 = c.SatisHarekets.GroupBy(x => x.urunId).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            var dgr13 = c.Uruns.Find(deger13);
            ViewBag.d13 = dgr13.ad;

            var deger14 = c.SatisHarekets.Sum(x => x.toplamTutar).ToString();
            ViewBag.d14 = deger14;

            DateTime bugun = DateTime.Today;
            var deger15 = c.SatisHarekets.Count(x => x.tarih == bugun).ToString();
            ViewBag.d15 = deger15;

            var deger16 = c.SatisHarekets.Where(x => x.tarih == bugun).Sum(y => y.toplamTutar).ToString();
            ViewBag.d16 = deger16;

            return View();
        }
        public ActionResult KolayTablolar()
        {
            var sorgu = from x in c.Carilers
                        group x by x.sehir into g
                        select new SinifGrup
                        {
                            sehir = g.Key,
                            sayi = g.Count()
                        };
            return View(sorgu.ToList());
        }
        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.Personels
                         group x by x.Departman.ad into g
                         select new SinifGrup2
                         {
                             departman=g.Key,
                             sayi=g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }
        public PartialViewResult Partial2()
        {
            var sorgu = c.Carilers.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial3()
        {
            var sorgu = c.Uruns.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial4()
        {
            var sorgu = from x in c.Uruns
                         group x by x.marka into g
                         select new SinifGrup3
                         {
                             marka=g.Key,
                             sayi=g.Count(),
                         };
            return PartialView(sorgu.ToList());
        }
        public ActionResult Partial5()
        {
            var sorgu = from x in c.Uruns
                        group x by x.Kategori.ad into g
                        select new SinifGrup4
                        {
                            kategori=g.Key,
                            sayi=g.Count(),
                        };
            return PartialView(sorgu.ToList());
        }
    }
}