using ProbaProjekat.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProbaProjekat.Controllers
{
    public class DoctorController : Controller
    {
        string connectionString = @"Data Source=DESKTOP-SHHT07O\SQLEXPRESS;Initial Catalog=MojPregled;Integrated Security=True";
        List<DoctorModel> Doctors = new List<DoctorModel>();
        List<string> listDoctor = new List<string>();

        public ActionResult Index()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT * FROM Doctor";
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    try
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            DoctorModel model = new DoctorModel();
                            model.doctor_id = (int)reader[0];
                            model.doctor_name = (string)reader[1];
                            model.doctor_surname = (string)reader[2];
                            //model.patient_dateofbirth = (DateTime)reader[3];
                            //model.patient_address = (string)reader[4];
                            //model.patient_phonenumber = (string)reader[5];
                            //model.patient_city = (string)reader[6];
                            Doctors.Add(model);
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error");
                    }
                }
                return View(Doctors);
            }
        }

        public ActionResult Edit(int? id)
        {
            DoctorModel model = new DoctorModel();
            if (id != null)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string queryString = "SELECT * FROM Doctor WHERE doctor_id = " + id;
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        try
                        {
                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                model.doctor_id = (int)reader[0];
                                model.doctor_name = (string)reader[1];
                                model.doctor_surname = (string)reader[2];
                                //model.patient_dateofbirth = (DateTime)reader[3];
                                //model.patient_address = (string)reader[4];
                                //model.patient_phonenumber = (string)reader[5];
                                //model.patient_city = (string)reader[6];
                            }
                            reader.Close();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Error");
                        }
                    }
                }
            }
            TempData["message"] = "Edited";
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(DoctorModel model)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string editString = @"UPDATE Doctor SET doctor_name =  @doctor_name , doctor_surname =  @doctor_surname WHERE doctor_id =  @doctor_id";
                connection.Open();
                using (SqlCommand command = new SqlCommand(editString, connection))
                {
                    command.Parameters.AddWithValue("@id", model.doctor_id);
                    command.Parameters.AddWithValue("@name", model.doctor_name);
                    command.Parameters.AddWithValue("@surname", model.doctor_surname);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error");
                    }
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Add(DoctorModel model)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string insertString = @"INSERT INTO Doctor(doctor_name, doctor_surname) VALUES (@doctor_name, @doctor_surname)";
                connection.Open();
                using (SqlCommand command = new SqlCommand(insertString, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@name", model.doctor_name);
                        command.Parameters.AddWithValue("@surname", model.doctor_surname);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error");
                    }
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Add()
        {
            TempData["message"] = "Added";
            return View();
        }

        [HttpGet]
        public ActionResult Delete()
        {
            TempData["message"] = "Deleted";
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string deleteString = @"DELETE FROM Doctor WHERE doctor_id = @id";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(deleteString, connection))
                    {
                        try
                        {
                            command.Parameters.AddWithValue("@id", id);
                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                DoctorModel model = new DoctorModel();
                                model.doctor_id = (int)reader[0];
                                model.doctor_name = (string)reader[1];
                                model.doctor_surname = (string)reader[2];
                                Doctors.Remove(model);
                            }
                            reader.Close();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Error");
                        }
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}