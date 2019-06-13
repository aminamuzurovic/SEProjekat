/*using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProbaProjekat.Models;

namespace ProbaProjekat.Controllers
{
    public class HospitalController : Controller
    {
        string connectionString = @"Data Source=DESKTOP-SHHT07O\SQLEXPRESS;Initial Catalog=MojPregled;Integrated Security=True";
        List<HospitalModel> Hospitals = new List<HospitalModel>();
        List<string> listPatient = new List<string>();

        public ActionResult Index()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT * FROM Hospital";
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    try
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            HospitalModel model = new HospitalModel();
                            model.hospital_id = (int)reader[0];
                            model.hospital_name = (string)reader[1];
                            model.hospital_address = (string)reader[2];
                            model.number_of_doctors = (int)reader[3];
                            model.number_of_patients = (int)reader[4];
                            model.capacity = (int)reader[5];
                            Hospitals.Add(model);
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error");
                    }
                }
                return View(Hospitals);
            }
        }
    }
}*/

using ProbaProjekat.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProbaProjekat.Controllers
{
    public class HospitalController : Controller
    {
        string connectionString = @"Data Source=DESKTOP-SHHT07O\SQLEXPRESS;Initial Catalog=MojPregled;Integrated Security=True";
        List<HospitalModel> Hospitals = new List<HospitalModel>();
        List<string> listHospital = new List<string>();

        public ActionResult Index()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT * FROM Hospital";
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    try
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            HospitalModel model = new HospitalModel();
                            model.hospital_id = (int)reader[0];
                            model.hospital_name = (string)reader[1];
                            model.hospital_address = (string)reader[2];
                            Hospitals.Add(model);
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error");
                    }
                }
                return View(Hospitals);
            }
        }
    }
}