using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Yapilacak
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100,ErrorMessage ="100 karakterden fazla giremezsiniz")]
        public string baslik { get; set; }
        [Column(TypeName = "bit")]
        public bool durum { get; set; }
    }
}