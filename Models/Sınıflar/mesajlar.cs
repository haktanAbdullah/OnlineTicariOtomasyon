using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class mesajlar
    {
        [Key]
        public int mesajId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz...")]
        public string gonderici { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz...")]
        public string alici { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50,ErrorMessage ="En fazla 50 karakter girebilirsiniz")]
        public string konu { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(2000,ErrorMessage ="En fazla 2000 karakter girebilirsiniz")]
        public string icerik { get; set; }

        [Column(TypeName = "Smalldatetime")]
        public DateTime tarih { get; set; }

        [Column(TypeName ="Varchar")]
        public string durum { get; set; }
    }
}