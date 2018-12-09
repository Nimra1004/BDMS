using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Net;
using WebApplication6.Models;
using WebApplication6;

namespace WebApplication6.Controllers
{
    [Authorize]
    public class DonorsController : Controller
    {
        
        public static int GetMonthDifference(DateTime startDate, System.DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }
        SELABEntities db = new SELABEntities();
        // GET: Donor
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            var donors = from s in db.RegisteredUsers
                         select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                donors = donors.Where(s => s.R_BloodGroup.Contains(searchString)
                                       || s.R_Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    donors = donors.OrderByDescending(s => s.R_BloodGroup);
                    break;
                case "Date":
                    donors = donors.OrderBy(s => s.R_Gender);
                    break;
                case "date_desc":
                    donors = donors.OrderByDescending(s => s.R_City);
                    break;
                default:
                    donors = donors.OrderBy(s => s.R_Name);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(donors.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult Details(int id = 0)
        {
            RegisteredUser user1 = db.RegisteredUsers.Find(id);
            using (var context = new SELABEntities())
            {
                var regUser = context.RegisteredUsers.Where(x => x.R_ID == id).SingleOrDefault();
                RegisteredUser DOB = new RegisteredUser();
                System.DateTime user = regUser.R_Dateofbirth;
                // System.DateTime date1 = System.DateTime.Now;
                DateTime now = DateTime.UtcNow;
                System.DateTime past = user;
                int monthDiff = GetMonthDifference(now, past);
                if (monthDiff >= 3)
                {
                    ViewBag.Message = "Yes";
                }
                else
                {
                    ViewBag.Message = "No";
                }
            }
            return View(user1);
            //using (var context = new DonorsDataDbEntities1())
            //{
            //    List<RegisteredUser> list = new List<RegisteredUser>();
            //    var regUsers = context.RegisteredUsers.Where(x => x.R_ID == id).SingleOrDefault();
            //    RegisteredUser result = new RegisteredUser();
            //    result.R_ID = regUsers.R_ID;
            //    result.R_Email = regUsers.R_Email;
            //    result.R_Email = regUsers.R_Email;
            //    result.R_Name = regUsers.R_Name;
            //    result.R_Gender = regUsers.R_Gender;
            //    result.R_BloodGroup = regUsers.R_BloodGroup;
            //    result.R_Contact = regUsers.R_Contact;
            //    result.R_Dateofbirth = regUsers.R_Dateofbirth;
            //    result.R_Address = regUsers.R_Address;
            //    list.Add(result);
            //    return View(list);
            //}
            //return View();
        }
        

    }
}