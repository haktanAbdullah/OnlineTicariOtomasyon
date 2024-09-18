using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using PagedList;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class CariController : Controller
    {
        Context c = new Context();

        Cariler cariGetir1(int id)
        {
            var cari = c.Carilers.Find(id);

            return cari;
        }
        
        // GET: Cari
        public ActionResult Index()
        {
            var degerler = c.Carilers.Where(x => x.durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult CariEkle()
        {
            List<string> sehirler = GetSehirlerFromFile();
            ViewBag.sehirler = sehirler;
            return View();
        }
        private List<string> GetSehirlerFromFile()
        {
            List<string> sehirler = new List<string>();
            string filePath = Server.MapPath("~/sehirler.txt");

             if(System.IO.File.Exists(filePath))
             {
                string[] lines = System.IO.File.ReadAllLines(filePath);
                foreach(var line in lines)
                {
                    sehirler.Add(line.Trim());
                }
             }

            return sehirler;
        }

        [HttpPost]
        public ActionResult CariEkle(Cariler p)
        {
            if (!ModelState.IsValid)
            {
                return View("CariEkle");
            }

            TempData["SuccessMessage"] = "Cari başarıyla eklendi";

            p.durum = true;
            c.Carilers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var cari = c.Carilers.Find(id);
            cari.durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {
            List<string> sehirler = GetSehirlerFromFile();
            ViewBag.sehirler = sehirler;
            var cari = c.Carilers.Find(id);
            return View("CariGetir",cari);
        }

        [HttpPost]
        public ActionResult CariGuncelle(Cariler p,int urunId)
        {
            if(!ModelState.IsValid)
            {
                return View("CariGetir");
            }

            TempData["SuccessMessage"] = "Cari basariyla guncellendi";

            var cari = c.Carilers.Find(urunId);
            cari.ad = p.ad;
            cari.soyad = p.soyad;
            cari.sehir = p.sehir;
            cari.mail = p.mail;
            cari.telefonNo = p.telefonNo;
            cari.meslek = p.meslek;

            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.cariId == id).ToList();
            var cr = c.Carilers.Where(x => x.id == id).Select(y => y.ad + " " + y.soyad).FirstOrDefault();
            ViewBag.cari = cr;
            return View(degerler);
        }
    }
}