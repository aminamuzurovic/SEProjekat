using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProbaProjekat.Models
{
    public class PatientModel
    {
        public int patient_id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Patient Name")]
        public string patient_name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Patient Surname")]
        public string patient_surname { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Patient Date Of Birth")]
        public DateTime patient_dateofbirth { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Patient Address")]
        public string patient_address { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Patient Number")]
        public string patient_phonenumber { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Patient City")]
        public string patient_city { get; set; }
    }
}