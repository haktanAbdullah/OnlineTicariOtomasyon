using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Admin
    {
        public int id { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(10)]
        public string kullaniciAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string sifre { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(1)]
        public string yetki { get; set; }

    }
}