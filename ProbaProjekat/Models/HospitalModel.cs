using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProbaProjekat.Models
{
    public class HospitalModel
    {
        public int hospital_id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Hospital Name")]
        public string hospital_name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Hospital Address")]
        public string hospital_address { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Hospital City")]
        public string hospital_city { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Number Of Doctors")]
        public int number_of_doctors { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Number Of Patients")]
        public int number_of_patients { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Capacity")]
        public int capacity { get; set; }
    }
}