using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class KargoDetay
    {
        [Key]
        public int kargoDetayId { get; set; }

        [Display(Name = "Açıklama")]
        [Column(TypeName ="Varchar")]
        [StringLength(300,ErrorMessage ="300 karakterden fazla giremezsiniz...")]
        public string aciklama { get; set; }

        [Display(Name ="Takip Kodu")]
        [Column(TypeName = "VarChar")]
        [StringLength(10,ErrorMessage ="10 karakterden fazla giremezsiniz...")]
        public string takipKodu { get; set; }//123123AB


        [Display(Name = "Alıcı")]
        [Column(TypeName="Varchar")]
        [StringLength(25,ErrorMessage ="25 karakterden fazla giremezsiniz")]
        public string alici { get; set; }

        [Display(Name = "Tarih")]
        public DateTime tarih { get; set; }

        [Display(Name = "Personel")]

        public int personel { get; set; }

        [ForeignKey("personel")]
        public virtual Personel Personel { get; set; }
    }
}