using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Personel
    {
        [Key]
        public int id { get; set; }


        [Display(Name ="Personel Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="30 karakterden fazla giremezsiniz...")]
        public string ad { get; set; }


        [Display(Name = "Personel Soyadı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "30 karakterden fazla giremezsiniz...")]
        public string soyad { get; set; }


        [Display(Name = "Personel Görsel")]
        [Column(TypeName ="Varchar")]
        [StringLength(250)]
        [Required(ErrorMessage = "Görsel kaydetmeniz gerek !!!")]
        public string gorsel { get; set; }

        public ICollection<SatisHareket> satisHarekets { get; set; }

        [Display(Name ="Departman adı")]
        public int departmanId { get; set; }

        [Display(Name = "Departman adı")]
        public virtual Departman Departman { get; set; }

        public ICollection<KargoDetay> kargoDetays { get; set; }

    }
}