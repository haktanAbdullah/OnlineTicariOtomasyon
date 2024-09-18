using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class KargoTakip
    {
        [Key]
        public int kargoTakipId { get; set; }

        [Column(TypeName ="VarChar")]
        [StringLength(10,ErrorMessage ="10 karakterden fazla giremezsiniz...")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz...")]
        public string takipKodu { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(100, ErrorMessage = "100 karakterden fazla giremezsiniz...")]
        public string aciklama { get; set; }
        public DateTime tarihZaman { get; set; }
    }
}