using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Gider
    {
        [Key]
        public int giderId { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(100,ErrorMessage = "En fazla 100 karakter girmelisin")]
        public string aciklama { get; set; }
        public DateTime tarih { get; set; }
        public decimal tutar { get; set; }
    }
}