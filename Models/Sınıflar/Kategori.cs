using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Kategori
    {
         [Key]
         public int id { get; set; }

         [Display(Name ="Kategori Adı:")]
         [Column(TypeName ="Varchar")]
         [StringLength(30,ErrorMessage ="30 Karakterden fazla giremezsiniz...")]
         [Required(ErrorMessage ="Bu alanı boş geçemezsiniz...")]
         public string ad { get; set; }
         public bool durum { get; set; }
         public ICollection<Urun> uruns { get; set; }
    }
}