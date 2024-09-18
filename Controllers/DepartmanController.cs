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
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departmans.Where(x => x.durum == true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            if (!ModelState.IsValid)
            {
                return View("DepartmanEkle");
            }

            // ModelState geçerliyse, departmanı ekleyip başarı mesajı gönder
            d.durum = true;
            c.Departmans.Add(d);
            c.SaveChanges();

            // TempData'ya başarı mesajını ekleyelim
            TempData["SuccessMessage"] = "Departman basarıyla eklendi";

            // Index sayfasına yönlendirme yapalım
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var dep = c.Departmans.Find(id);
            dep.durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var dpt = c.Departmans.Find(id);
            return View("DepartmanGetir", dpt);
        }
        public ActionResult DepartmanGuncelle(Departman p)
        {
            if (!ModelState.IsValid)
            {
                return View("DepartmanGetir");
            }

            // TempData'ya başarı mesajını ekleyelim
            TempData["SuccessMessage"] = "Departman başarıyla Guncellendi";


            var dept = c.Departmans.Find(p.id);
            dept.ad = p.ad;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.departmanId == id).ToList();
            var dpt = c.Departmans.Where(x => x.id == id).Select
                (y => y.ad).FirstOrDefault();
            ViewBag.d = dpt;
            return View(degerler);
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x=>x.personelId== id).ToList();
            var pers = c.Personels.Where(x => x.id == id).Select(y => y.ad + " " + y.soyad).FirstOrDefault();
            ViewBag.dpers = pers;
            return View(degerler);
        }
    }
}