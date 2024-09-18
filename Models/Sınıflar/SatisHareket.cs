using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class SatisHareket
    {
        [Key]
        public int satisId { get; set; }

        [Display(Name = "Satış Tarihi")]
        public DateTime tarih { get; set; }

        [Display(Name = "Adet")]
        public int adet { get; set; }

        [Display(Name = "Fiyat")]
        public decimal fiyat { get; set; }

        [Display(Name = "Satış Toplam Tutar")]
        public decimal? toplamTutar { get; set; }

        [Display(Name = "Ürün")]
        public int urunId { get; set; }

        [Display(Name = "Cari")]
        public int cariId { get; set; }

        [Display(Name = "Personel")]
        public int personelId { get; set; }
        public virtual Cariler cari { get; set; }
        public virtual Urun urun { get; set; }
        public virtual Personel personel { get; set; }
    }
}