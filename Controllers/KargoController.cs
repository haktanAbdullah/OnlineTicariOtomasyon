using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class KargoController : Controller
    {
        // GET: Kargo
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var k = from x in c.KargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                k = k.Where(y => y.takipKodu.Contains(p));
            }
            return View(k.ToList());
        }

        [HttpGet]
        public ActionResult YeniKargo()
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            Random rnd = new Random();
            string[] karakterler = { "A", "B", "C", "D", "E", "F", "G", "H", "K" };
            int k1, k2, k3;
            k1 = rnd.Next(0, karakterler.Length);
            k2 = rnd.Next(0, karakterler.Length);
            k3 = rnd.Next(0, karakterler.Length);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);//10 --> 3 1 2 1
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);

            string kod = s1 + karakterler[k1] + s2 + karakterler[k2] + s3 + karakterler[k3];
            ViewBag.takipKod = kod;

            List<SelectListItem> deger1 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ad,
                                               Value = x.id.ToString()
                                           }).ToList();

            ViewBag.deger1 = deger1;

            return View();
        }

        [HttpPost]
        public ActionResult YeniKargo(KargoDetay d)
        {
            c.KargoDetays.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KargoTakip(string id)
        {
            var degerler = c.KargoTakips.Where(x => x.takipKodu == id).ToList();
            var kargoDetayId = c.KargoDetays.Where(x => x.takipKodu == id).Select(x => x.kargoDetayId).FirstOrDefault();
            var tarihZaman = c.KargoDetays.Where(x => x.takipKodu == id).Select(x => x.tarih).FirstOrDefault();
            ViewBag.id = kargoDetayId;
            ViewBag.tarihZaman = tarihZaman;
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KargoDetayGir(int id,DateTime tarihZaman)
        {
            ViewBag.tarihZaman = tarihZaman;
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public ActionResult KargoDetayGir(KargoTakip k)
        {   
            c.KargoTakips.Add(k);
            c.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}