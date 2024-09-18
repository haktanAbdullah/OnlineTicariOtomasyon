using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Cariler
    {
        [Key]
        public int id { get; set; }

        [Display(Name ="Cari Adı:")]
        [Column(TypeName ="Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter girebilirsiniz...")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz...")]
        public string ad { get; set; }

        [Display(Name = "Soyadı:")]
        [Column(TypeName ="Varchar")]
        [StringLength (30,ErrorMessage ="En fazla 30 karakter girebilirsiniz...")]
        [Required(ErrorMessage ="Bu alanı boş geçemezsiniz...")]
        public string soyad { get; set; }

        [Display(Name = "Şehir:")]
        [Column(TypeName ="Varchar")]
        [StringLength(13, ErrorMessage = "En fazla 13 karakter girebilirsiniz...")]
        public string sehir { get; set; }

        [Display(Name = "Mail:")]
        [Column(TypeName ="Varchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz...")]
        [Required(ErrorMessage = "Email alanı gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string mail { get; set; }

        [Display(Name = "Cari Şifre:")]
        [Column(TypeName ="Varchar")]
        [StringLength(20, ErrorMessage = "En fazla 20 karakter girebilirsiniz...")]
        //[Required(ErrorMessage = "Şifre alanı gereklidir.")]
        public string sifre { get; set; }

        [Display(Name ="Cari Görseli")]
        [Column(TypeName = "Varchar")]
        public string gorsel { get; set; }

        [Display(Name ="Meslek")]
        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage = "En fazla 30 karakter uzunluğunda girebilirsiniz...")]
        public string meslek { get; set; }

        [Display(Name="Telefon no")]
        [Column(TypeName ="Char")]
        [StringLength(11,ErrorMessage ="11 Karakter girmelisiniz...")]
        public string telefonNo { get; set; }

        public bool durum { get; set;}
        public ICollection<SatisHareket> satisHarekets { get; set; }
    }
}