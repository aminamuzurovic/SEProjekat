using ProbaProjekat.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProbaProjekat.Controllers
{
    public class MedicinesController : Controller
    {
        string connectionString = @"Data Source=DESKTOP-SHHT07O\SQLEXPRESS;Initial Catalog=MojPregled;Integrated Security=True";
        List<MedicinesModel> Medicines = new List<MedicinesModel>();
        List<string> listMedicine = new List<string>();

        public ActionResult Index()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT * FROM Medicines";
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    try
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            MedicinesModel model = new MedicinesModel();
                            model.medicines_id = (int)reader[0];
                            model.medicines_name = (string)reader[1];
                            model.patient_name = (string)reader[2];
                            model.doctor_name = (string)reader[3];
                            model.quantity = (string)reader[4];                            
                            Medicines.Add(model);
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error");
                    }
                }
                return View(Medicines);
            }
        }

        public ActionResult Edit(int? id)
        {
            MedicinesModel model = new MedicinesModel();
            if (id != null)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string queryString = "SELECT * FROM Medicines WHERE medicines_id = " + id;
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        try
                        {
                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                model.medicines_id = (int)reader[0];
                                model.medicines_name = (string)reader[1];
                                model.patient_name = (string)reader[2];
                                model.doctor_name = (string)reader[3];
                                model.quantity = (string)reader[4];
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
        public ActionResult Edit(MedicinesModel model)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string editString = @"UPDATE Medicines SET medicines_name =  @medicines_name , patient_name =  @patient_name, doctor_name = @doctor_name WHERE medicine_id =  @medicine_id";
                connection.Open();
                using (SqlCommand command = new SqlCommand(editString, connection))
                {
                    command.Parameters.AddWithValue("@medicines_name", model.medicines_name);
                    command.Parameters.AddWithValue("@patient_name", model.patient_name);
                    command.Parameters.AddWithValue("@doctor_name", model.doctor_name);
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
        public ActionResult Add(MedicinesModel model)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string insertString = @"INSERT INTO Medicines(medicines_name,patient_name, doctor_name) VALUES (@medicines_name,@patient_name, @doctor_name)";
                connection.Open();
                using (SqlCommand command = new SqlCommand(insertString, connection))
                {
                    try
                    {                        
                        command.Parameters.AddWithValue("@medicines_name", model.medicines_name);
                        command.Parameters.AddWithValue("@patient_name", model.patient_name);
                        command.Parameters.AddWithValue("@doctor_name", model.doctor_name);
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
                    string deleteString = @"DELETE FROM Medicines WHERE medicines_id = @id";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(deleteString, connection))
                    {
                        try
                        {
                            command.Parameters.AddWithValue("@id", id);
                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                MedicinesModel model = new MedicinesModel();
                                model.medicines_id = (int)reader[0];
                                model.medicines_name = (string)reader[1];
                                model.patient_name = (string)reader[2];
                                model.doctor_name = (string)reader[3];
                                model.quantity = (string)reader[4];
                                Medicines.Remove(model);
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