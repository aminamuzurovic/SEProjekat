using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbaProjekat.Models
{
    public class DoctorModel
    {
        
        public int doctor_id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Doctor's Name")]
        public string doctor_name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Doctor Surname")]
        public string doctor_surname { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Doctor Date Of Birth")]
        public DateTime doctor_dateofbirth { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Doctor City")]
        public string doctor_city { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Doctor Phone")]
        public string doctor_phonenumber { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Doctor Speciality")]
        public string doctor_speciality { get; set; }
    }
}