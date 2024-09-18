using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class PersonelController : Controller
    {
        List<SelectListItem> departmanFunk()
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                           Text = x.ad,
                                           Value = x.id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return deger1;
        }
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {

            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ad,
                                               Value = x.id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }

            if (Request.Files.Count > 0 && Request.Files[0] != null && Request.Files[0].ContentLength > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "/Image/" + dosyaAdi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.gorsel = "/Image/" + dosyaAdi;
            }
            else
            {
                return RedirectToAction("Index");
            }

            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            //Select-option yapısı


            List<SelectListItem> deger1 = (from x in c.Departmans.Where(x=>x.durum==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ad,
                                               Value = x.id.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            var prs = c.Personels.Find(id);
            return View(prs);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelGetir");
            }

            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "/Image/" + dosyaAdi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.gorsel = "/Image/" + dosyaAdi;
            }

            var prsn = c.Personels.Find(p.id);
            prsn.ad = p.ad;
            prsn.soyad = p.soyad;
            prsn.gorsel = p.gorsel;
            prsn.departmanId = p.departmanId;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult PersonelListe()
        {
            var sorgu = c.Personels.ToList();
            return View(sorgu);
;       }
    }
}