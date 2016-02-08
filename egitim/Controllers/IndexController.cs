using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace egitim.Controllers
{
    public class IndexController : Controller
    {

        Models.deneme dbDeneme = new Models.deneme();
        Models.databaseContext dbContext = new Models.databaseContext();

        string con_string() { return ConfigurationManager.ConnectionStrings["databaseContext"].ToString(); }

        public ActionResult Index(string adi,string soyadi)
        {
           if(adi!=null && soyadi != null)
            {

                dbDeneme.adi = adi;
                dbDeneme.soyadi = soyadi;
                dbContext.egitimTablosuContext.Add(dbDeneme);
                dbContext.SaveChanges();
                return RedirectToAction("Delete");

            }
            ViewBag.deneme = "burak";
            ViewData["Key"] = "secer";
           


            return View();
        }

        public ActionResult Ornek()
        {

            return View();

        }

        public ActionResult Delete(string adi)
        {

            if(adi!= null && adi!= " ")
            {
                dbDeneme = dbContext.egitimTablosuContext.Find(adi);
                dbContext.egitimTablosuContext.Remove(dbDeneme);
                dbContext.SaveChanges();

            }

            var modelim = new Models.database
            {
                egitimTablosuE = dbContext.egitimTablosuContext.ToList()
            };
            
            return View(modelim);
        }

        public ActionResult Update(string id,string adi,string soyadi)
        {
            SqlConnection con = new SqlConnection(con_string());
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            if(id!=null && id!=" " && adi!=null && adi!=" " && soyadi!= null && soyadi!=" ")
            {

              

                string query = "update deneme set adi='"+adi+"', soyadi='"+soyadi+"' where adi='"+id+"'";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                con.Close();
                return RedirectToAction("Delete");
            }

            if(id!=null && id!= " ")
            {
                var modelim = new Models.database
                {
                    egitimTablosu = dbContext.egitimTablosuContext.Find(id)
                };

                return View(modelim);

            }

            return RedirectToAction("Delete");
        }


        

    }
}