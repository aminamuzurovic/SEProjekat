using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProbaProjekat.Models
{
    public class MedicinesModel
    {
        public int medicines_id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Patient Name")]
        public string patient_name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Doctor Name")]
        public string doctor_name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Quantity")]
        public string quantity { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Medicines Name")]
        public string medicines_name { get; set; }
    }
}