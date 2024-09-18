using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();
        [HttpGet]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = c.mesajlars.Where(x => x.alici == mail).ToList();
            ViewBag.m = mail;

            var mailId = c.Carilers.Where(x => x.mail == mail).Select(y => y.id).FirstOrDefault();
            ViewBag.mid = mailId;

            var toplamSatis = c.SatisHarekets.Where(x => x.cariId == mailId).Count();
            ViewBag.toplamSatis = toplamSatis;

            var toplamTutar = c.SatisHarekets.Where(x => x.cariId == mailId).Sum(y=>y.toplamTutar);
            ViewBag.toplamTutar = toplamTutar;

            var toplamUrunSayisi = c.SatisHarekets.Where(x => x.cariId == mailId).Sum(y => (int?)y.adet) ?? 0;
            ViewBag.toplamUrunSayisi = toplamUrunSayisi;

            var adSoyad = c.Carilers.Where(x => x.mail == mail).Select(y => y.ad + " " + y.soyad).FirstOrDefault();
            ViewBag.adSoyad= adSoyad;

            var gorsel = c.Carilers.Where(x => x.mail == mail).Select(y => y.gorsel).FirstOrDefault();
            ViewBag.gorsel = gorsel;

            var meslek = c.Carilers.Where(x => x.mail == mail).Select(y => y.meslek).FirstOrDefault();
            ViewBag.meslek = meslek;

            var sehir = c.Carilers.Where(x => x.mail == mail).Select(y => y.sehir).FirstOrDefault();
            ViewBag.sehir = sehir;

            var telefonNo = c.Carilers.Where(x => x.mail == mail).Select(y => y.telefonNo).FirstOrDefault();
            ViewBag.telefonNo = telefonNo;

            return View(degerler);
        }

        [HttpPost]
        public ActionResult Index(Cariler p)
        {
            var cari = c.Carilers.Find(p.id);
            cari.ad = p.ad;
            cari.soyad = p.soyad;
            cari.sehir = p.sehir;
            cari.sifre = p.sifre;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.mail == mail.ToString()).Select(y => y.id).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.cariId == id).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.mesajlars.Where(x => x.alici == mail && x.durum == "Gonderildi").ToList();
            var mesajlar1 = c.mesajlars.Where(x => x.gonderici == mail && x.durum == "Gonderildi").ToList();
            var mesajlar2 = c.mesajlars.Where(x => x.durum == "Taslak" && x.gonderici == mail).ToList();
            var mesajlar3 = c.mesajlars.Where(x => x.durum == "Cop" && x.gonderici == mail).ToList();

            var gelenSayisi = mesajlar.Count();
            ViewBag.d1 = gelenSayisi;

            var gidenSayisi = mesajlar1.Count();
            ViewBag.d2 = gidenSayisi;

            var taslakSayisi = mesajlar2.Count();
            ViewBag.d3 = taslakSayisi;

            var copSayisi = mesajlar3.Count();
            ViewBag.d4 = copSayisi;

            return View(mesajlar);
        }

        [HttpGet]
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.mesajlars.Where(x => x.alici == mail && x.durum == "Gonderildi").ToList();
            var mesajlar1 = c.mesajlars.Where(x => x.gonderici == mail && x.durum == "Gonderildi").ToList();
            var mesajlar2 = c.mesajlars.Where(x => x.durum == "Taslak" && x.gonderici == mail).ToList();
            var mesajlar3 = c.mesajlars.Where(x => x.durum == "Cop" && x.gonderici == mail).ToList();

            var gelenSayisi = mesajlar.Count();
            ViewBag.d1 = gelenSayisi;

            var gidenSayisi = mesajlar1.Count();
            ViewBag.d2 = gidenSayisi;

            var taslakSayisi = mesajlar2.Count();
            ViewBag.d3 = taslakSayisi;

            var copSayisi = mesajlar3.Count();
            ViewBag.d4 = copSayisi;

            return View(mesajlar1);
        }

        public ActionResult CopKutusunaTasi(int id)
        {
            var mesaj = c.mesajlars.Find(id);
            mesaj.durum = "Cop";
            c.SaveChanges();
            return RedirectToAction("CopKutusu");
        }

        [HttpGet]
        public ActionResult CopKutusu()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.mesajlars.Where(x => x.alici == mail && x.durum == "Gonderildi").ToList();
            var mesajlar1 = c.mesajlars.Where(x => x.gonderici == mail && x.durum == "Gonderildi").ToList();
            var mesajlar2 = c.mesajlars.Where(x => x.durum == "Taslak" && x.gonderici == mail).ToList();
            var mesajlar3 = c.mesajlars.Where(x => x.durum == "Cop" && x.gonderici == mail).ToList();

            var gelenSayisi = mesajlar.Count();
            ViewBag.d1 = gelenSayisi;

            var gidenSayisi = mesajlar1.Count();
            ViewBag.d2 = gidenSayisi;

            var taslakSayisi = mesajlar2.Count();
            ViewBag.d3 = taslakSayisi;

            var copSayisi = mesajlar3.Count();
            ViewBag.d4 = copSayisi;

            return View(mesajlar3);
        }

        public ActionResult Taslak()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar2 = c.mesajlars.Where(x => x.durum == "Taslak" && x.gonderici==mail).ToList();
            var mesajlar = c.mesajlars.Where(x => x.alici == mail && x.durum=="Gonderildi").ToList();
            var mesajlar1 = c.mesajlars.Where(x => x.gonderici == mail && x.durum == "Gonderildi").ToList();
            var mesajlar3 = c.mesajlars.Where(x => x.durum == "Cop" && x.gonderici == mail).ToList();

            var gelenSayisi = mesajlar.Count();
            ViewBag.d1 = gelenSayisi;

            var gidenSayisi = mesajlar1.Count();
            ViewBag.d2 = gidenSayisi;

            var taslakSayisi = mesajlar2.Count();
            ViewBag.d3 = taslakSayisi;

            var copSayisi = mesajlar3.Count();
            ViewBag.d4 = copSayisi;

            return View(mesajlar2);
        }

        [HttpGet]
        public ActionResult TaslakDetay(int id)
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.mesajlars.Where(x => x.alici == mail && x.durum=="Gonderildi").ToList();
            var mesajlar2 = c.mesajlars.Where(x => x.durum == "Taslak" && x.gonderici == mail).ToList();
            var mesajlar1 = c.mesajlars.Where(x => x.gonderici == mail && x.durum == "Gonderildi").ToList();
            var mesaj = c.mesajlars.Find(id);
            var mesajlar3 = c.mesajlars.Where(x => x.durum == "Cop" && x.gonderici == mail).ToList();

            var gelenSayisi = mesajlar.Count();
            ViewBag.d1 = gelenSayisi;

            var gidenSayisi = mesajlar1.Count();
            ViewBag.d2 = gidenSayisi;

            var taslakSayisi = mesajlar2.Count();
            ViewBag.d3 = taslakSayisi;

            var copSayisi = mesajlar3.Count();
            ViewBag.d4 = copSayisi;

            return View(mesaj);
        }

        [HttpPost]
        public ActionResult TaslakDetay(string durum,mesajlar m)
        {
            var mail = (string)Session["CariMail"];
            if (durum == "gonderici")
            {
                m.durum = "Gonderildi";
            }
            else
            {
                m.durum = "Taslak";
            }
            var mesaj = c.mesajlars.Find(m.mesajId);
            mesaj.konu = m.konu;
            mesaj.icerik = m.icerik;
            mesaj.durum = m.durum;
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult MesajDetay(int id)
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.mesajlars.Where(x => x.alici == mail).ToList();
            var mesajlar1 = c.mesajlars.Where(x => x.gonderici == mail).ToList();
            var mesaj = c.mesajlars.Find(id);

            var gelenSayisi = mesajlar.Count();
            ViewBag.d1 = gelenSayisi;

            var gidenSayisi = mesajlar1.Count();
            ViewBag.d2 = gidenSayisi;

            return View(mesaj);
        }

        [Authorize]
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.mesajlars.Where(x => x.alici == mail).ToList();
            var mesajlar1 = c.mesajlars.Where(x => x.gonderici == mail).ToList();
            var mesajlar2 = c.mesajlars.Where(x => x.durum == "Taslak" && x.gonderici == mail).ToList();

            var gelenSayisi = mesajlar.Count();
            ViewBag.d1 = gelenSayisi;

            var gidenSayisi = mesajlar1.Count();
            ViewBag.d2 = gidenSayisi;

            var taslakSayisi = mesajlar2.Count();
            ViewBag.d3 = taslakSayisi;

            return View();
        }

        public ActionResult MesajSil(int id)
        {
            var mesaj = c.mesajlars.Find(id);
            c.mesajlars.Remove(mesaj);
            c.SaveChanges();

            return RedirectToAction("GelenMesajlar");
        }

        [HttpPost]
        public ActionResult YeniMesaj(mesajlar m ,string durum)
        {
            var mail = (string)Session["CariMail"];
            if (durum == "gonderici")
            {
                m.durum = "Gonderildi";
            }
            else
            {
                m.durum = "Taslak";
            }
            m.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.gonderici = mail;
            c.mesajlars.Add(m);
            c.SaveChanges();
            return RedirectToAction("GidenMesajlar");
        }
        public ActionResult KargoTakip(string p)
        {
            var k = from x in c.KargoDetays select x;
            k = k.Where(y => y.takipKodu.Contains(p));
            return View(k.ToList());
        }
        public ActionResult CariKargoTakip(string id)
        {
            var degerler = c.KargoTakips.Where(x => x.takipKodu == id).ToList();
            return View(degerler);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
        public PartialViewResult Partial1()
        {
            var mail = (string)Session["CariMail"];
            var id=c.Carilers.Where(x=>x.mail==mail).Select(y=>y.id).FirstOrDefault();
            var cariBul = c.Carilers.Find(id);
            return PartialView("Partial1",cariBul);
        }
        public PartialViewResult Partial2()
        {
            var veriler = c.mesajlars.Where(x => x.gonderici == "admin").ToList();
            return PartialView(veriler);
        }
        public ActionResult CariBilgiGuncelle(Cariler p)
        {
            var cari = c.Carilers.Find(p.id);
            cari.ad = p.ad;
            cari.soyad = p.soyad;
            cari.mail = p.mail;
            cari.sifre = p.sifre;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}