using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication6.Models
{
    public class PostRequestModel
    {

        [Required(ErrorMessage = "Please enter city name")]
        [Display(Name = "City Name")]
        public string CityName { get; set; }

        [Required(ErrorMessage = "Please enter city latitude")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "Please enter city longitude ")]
        public double Longitude { get; set; }

        public string Message { get; set; }

        public static IEnumerable<SelectListItem> BloodGroupList()
        {
            IList<SelectListItem> items = new List<SelectListItem>
            {
                new  SelectListItem{Text = "A+", Value = "A+" },
                new  SelectListItem{Text = "A-", Value = "A-" },
                new  SelectListItem{Text = "B+", Value = "B+" },
                new  SelectListItem{Text = "B-", Value = "B-" },
                new  SelectListItem{Text = "AB+", Value = "AB+" },
                new  SelectListItem{Text = "AB-", Value = "AB-" },
                new  SelectListItem{Text = "O+", Value = "O+" },
                new  SelectListItem{Text = "O-", Value = "O-" },
            };
            return items;
        }
    }
}