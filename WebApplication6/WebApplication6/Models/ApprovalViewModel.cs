using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class ApprovalViewModel
    {
        public int num { get; set; }

        [Required(ErrorMessage = "Please enter city name")]
        [Display(Name = "City Name")]
        public string CityName { get; set; }

        public string Message { get; set; }

        public string BloodGroup { get; set; }

        public string Status { get; set; }
    }
}