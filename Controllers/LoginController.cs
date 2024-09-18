using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                if (message == "notauthorized")
                {
                    ViewBag.ErrorMessage = "Lütfen giriş yapınız";
                }
            }
            return View();
        }

        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Partial1(Cariler p)
        {
            c.Carilers.Add(p);
            c.SaveChanges();
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult Partial2()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Partial2(string eskiSifre,string yeniSifre,string yeniSifre1)
        {
            if(yeniSifre==yeniSifre1)
            {
                var cari = c.Carilers.Where(x => x.sifre == eskiSifre).FirstOrDefault();
                cari.sifre = yeniSifre;

                TempData["SessionMessage"] = "şifreniz başarıyla değiştirildi...";
                return PartialView("Partial2");
            }

            else
            {
                TempData["SessionMessage"] = "yeni şifreniz uyuşmuyor...";
                return PartialView("Partial2");
            }
        }

        [HttpGet]
        public ActionResult CariLogin1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariLogin1(Cariler p)
        {
            var bilgiler = c.Carilers.FirstOrDefault(x => x.mail == p.mail && x.sifre == p.sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.mail, false);
                Session["CariMail"] = bilgiler.mail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.kullaniciAd==
            p.kullaniciAd && x.sifre==p.sifre);
            if(bilgiler !=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullaniciAd, false);
                Session["KulaniciAd"]=bilgiler.kullaniciAd.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

    }
}