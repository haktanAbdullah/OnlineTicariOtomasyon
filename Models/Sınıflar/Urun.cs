using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Urun
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Ürünün Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "30 karakterden fazla giremezsiniz...")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz...")]

        public string ad { get; set; }

        [Display(Name = "Ürünün Marka")]
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "30 Karakterden fazla giremezsiniz...")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz...")]
        public string marka { get; set; }

        [Display(Name = "Ürünün Stok")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz...")]
        public short stok{ get; set; }

        [Display(Name = "Ürünün alış fiaytı")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz...")]
        public decimal alisFiyat { get; set; }

        [Display(Name = "Ürünün Satış fiaytı")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz...")]
        public decimal satisFiyat { get; set; }
        public bool durum { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250,ErrorMessage ="250 karakterden fazla giremezsiniz...")]
        public string gorsel { get; set; }

        public int kategoriid { get; set; }
        public virtual Kategori Kategori { get; set; }
        public ICollection<SatisHareket> satisHarekets { get; set; }
    }
}