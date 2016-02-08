using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace egitim.Models
{
    [Table("deneme")]
    public class deneme
    {
       [Key]
        public  string adi { get; set; }
        public string soyadi { get; set; }

    }
}