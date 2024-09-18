using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class FaturaKalem
    {
        [Key]
        public int faturaKalemid { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(200, ErrorMessage = "En fazla 200 karakter girebilirsiniz...")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz...")]
        public string aciklama { get; set; }
        public int miktar { get; set; }
        public decimal birimFiyat { get; set; }
        public decimal tutar { get; set; }

        public int faturaId { get; set; }


        [ForeignKey("faturaId")]
        public virtual Faturalar Faturalar { get; set; }
    }
}