using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace egitim.Models
{
    public class database
    {

        public deneme egitimTablosu { get; set; }
        public IEnumerable<deneme> egitimTablosuE { get; set; }
    }


    public class databaseContext:DbContext
    {


        public DbSet <deneme> egitimTablosuContext { get; set; }


    }

}