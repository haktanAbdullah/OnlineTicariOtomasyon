using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Faturalar
    {
        [Key]
        public int id { get; set; }
        
        [Column(TypeName ="Char")]
        [StringLength(1)]
        public string seriNo { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6, ErrorMessage = "En fazla 6 karakter girebilirsiniz...")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz...")]
        public string sıraNo { get; set; }
        public DateTime tarih { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60, ErrorMessage = "En fazla 60 karakter girebilirsiniz...")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz...")]
        public string vergiDairesi { get; set; }

        [Column(TypeName ="char")]
        [StringLength(50)]
        public string saat { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter girebilirsiniz...")]
        public string teslimEden { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter girebilirsiniz...")]
        public string teslimAlan { get; set; }
        public  decimal toplam { get; set; }
        public bool durum { get; set; }

        public ICollection<FaturaKalem> faturaKalems { get; set; }
    }
}