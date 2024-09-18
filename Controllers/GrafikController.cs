using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grafikciz = new Chart(600, 600);
            grafikciz.AddTitle("Kategori - Ürün Stok Sayısı")
                .AddLegend("Stok")
                .AddSeries
                (chartType:"Pie" ,
                name:"Değerler", 
                xValue: new[] { "Mobilya", "Ofis Eşyaları","Bilgisayar" }, 
                yValues:new[] { 85,66,98})
            .Write();

            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }
        Context c = new Context();
        public ActionResult Index3()
        {
            //ArrayList xValue = new ArrayList();
            //ArrayList yValue = new ArrayList();
            //var sonuclar = c.Uruns.ToList();
            //sonuclar.ToList().ForEach(x => xValue.Add(x.ad));
            //sonuclar.ToList().ForEach(y => yValue.Add(y.stok));
            //var grafik = new Chart(width: 500, height: 500)
            //    .AddTitle("Stoklar")
            //    .AddSeries(chartType: "Column", name: "Stok", xValue: xValue, yValues: yValue);
            //return File(grafik.ToWebImage().GetBytes(),"image/jpeg");

            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();
            var sonuclar = c.Uruns.ToList();
            sonuclar.ToList().ForEach(x=>xValue.Add(x));
            sonuclar.ToList().ForEach(y => yValue.Add(y));
            var grafik = new Chart(width: 500, height: 500);
            grafik.AddTitle("Kategori - ürün stok sayısı");
            grafik.AddSeries(chartType: "Column", name: "Stok", xValue: xValue, yValues:yValue);

            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");

        }
        
        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult()
        {
            return Json(urunListesi(), JsonRequestBehavior.AllowGet);
        }
        public List<sinif1> urunListesi()
        {
            List<sinif1> snf = new List<sinif1>();

            snf.Add(new sinif1()
            {
                urunAd="Bilgisayar",
                stok=120
            });
            snf.Add(new sinif1()
            {
                urunAd = "Beyaz Eşya",
                stok = 150
            });
            snf.Add(new sinif1()
            {
                urunAd = "Mobilya",
                stok = 150
            });
            snf.Add(new sinif1()
            {
                urunAd = "Küçük Ev Aletleri",
                stok = 150
            });
            snf.Add(new sinif1()
            {
                urunAd = "Mobil Cihazlar",
                stok = 150
            });
            return snf;

        }

        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult2()
        {
            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);
        }
        public List<sinif2> UrunListesi2()
        {
            List<sinif2> snf = new List<sinif2>();
            using(var c=new Context())
            {
                snf = c.Uruns.Select(x => new sinif2
                {
                    urn = x.ad,
                    stk = x.stok
                }).ToList();
            }
            return snf;
        }
        public ActionResult Index6()
        {
            return View();
        }
        public ActionResult Index7()
        {
            return View();
        }
    }
}