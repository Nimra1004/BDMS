using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using WebApplication6;
namespace WebApplication6.Models
{
    public class RegisteredUserViewModel
    {

        [Display(Name = "Email")]
        public string R_Email { get; set; }
        [Display(Name = "Name")]
        public string R_Name { get; set; }
        [Display(Name = "Gender")]
        public string R_Gender { get; set; }
        [Display(Name = "Blood Group")]
        public string R_BloodGroup { get; set; }
        [Display(Name = "Contact")]
        public string R_Contact { get; set; }
        [Display(Name = "Date of Birth")]
        public System.DateTime R_Dateofbirth { get; set; }
        [Display(Name = "City")]
        public string R_City { get; set; }
        [Display(Name = "Address")]
        public string R_Address { get; set; }


        public virtual AspNetUser AspNetUser { get; set; }
    }
}