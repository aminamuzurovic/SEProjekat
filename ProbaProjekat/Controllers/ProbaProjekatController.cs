using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProbaProjekat.Controllers
{
    public class ProbaProjekatController : Controller
    {
        public ActionResult Index()
        {
            string connectionString = @"Data Source=DESKTOP-SHHT07O\SQLEXPRESS;Initial Catalog=MojPregled;Integrated Security=True";
            string queryString = "SELECT * FROM Patient";
            List<string> listPatient = new List<string>(); 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listPatient.Add(String.Format("\t{0}\t{1}\t{2}",
                            reader[0], reader[1], reader[2]));
                    }
                    reader.Close();
                }
                catch (Exception)
                {
                    throw new Exception("Error");
                }
                return Json(listPatient, JsonRequestBehavior.AllowGet);
            }
        }
    }
}