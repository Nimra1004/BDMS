using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace WebApplication6.Controllers
{
    
    public class ApprovalController : Controller
    {

        // GET: Approval
        [Authorize]
        public ActionResult Index()
        {
            LABEntities db = new LABEntities();
            List<ApprovalViewModel> viewlist = new List<ApprovalViewModel>();
            ApprovalViewModel obj = new ApprovalViewModel();
            List<PostRequest> list1 = db.PostRequests.ToList();
            List<GoogleMap> list2 = db.GoogleMaps.ToList();
            string loginUserId = User.Identity.GetUserId();
            var regUser = db.RegisteredUsers.Where(x => x.FK_R_ID == loginUserId).SingleOrDefault();
            string LoginUserBg = regUser.R_BloodGroup;
            obj.num = 0;
            for (int i = 0; i < list1.Count; i++)
            {
                PostRequest req = list1.ElementAt(i);
                obj.num = obj.num + 1;
                if ((req.BloodGroup == LoginUserBg) && (req.Status == "Decline"))
                {
                    obj.BloodGroup = req.BloodGroup;
                    GoogleMap g = list2.ElementAt(req.Address - 1);
                    obj.CityName = g.CityName;
                    obj.Message = g.Description;
                    viewlist.Add(obj);
                }                
            }
            return View(viewlist);
        }


        public ActionResult IndexAdmin()
        {
            LABEntities db = new LABEntities();
            List<ApprovalViewModel> viewlist = new List<ApprovalViewModel>();
            ApprovalViewModel obj = new ApprovalViewModel();
            List<PostRequest> list1 = db.PostRequests.ToList();
            List<GoogleMap> list2 = db.GoogleMaps.ToList();
            
            obj.num = 0;
            for (int i = 0; i < list1.Count; i++)
            {
                PostRequest req = list1.ElementAt(i);
                obj.num = obj.num + 1;
                obj.BloodGroup = req.BloodGroup;
                GoogleMap g = list2.ElementAt(req.Address - 1);
                obj.CityName = g.CityName;
                obj.Message = g.Description;
                viewlist.Add(obj);
            }
            return View(viewlist);
        }


        [Authorize]
        public ActionResult Decline(int id)
        {
            LABEntities db = new LABEntities();
            List<ApprovalViewModel> viewlist = new List<ApprovalViewModel>();
            ApprovalViewModel obj = new ApprovalViewModel();
            List<PostRequest> list1 = db.PostRequests.ToList();
            List<GoogleMap> list2 = db.GoogleMaps.ToList();
            string loginUserId = User.Identity.GetUserId();
            var regUser = db.RegisteredUsers.Where(x => x.FK_R_ID == loginUserId).SingleOrDefault();
            string LoginUserBg = regUser.R_BloodGroup;
            obj.num = 0;
            for (int i = 0; i < list1.Count; i++)
            {
                PostRequest req = list1.ElementAt(i);
                obj.num = obj.num + 1;
                if ((req.BloodGroup == LoginUserBg) && (req.Status == "Decline"))
                {
                    obj.BloodGroup = req.BloodGroup;
                    GoogleMap g = list2.ElementAt(req.Address - 1);
                    obj.CityName = g.CityName;
                    obj.Message = g.Description;
                    if (obj.num != id)
                    {
                        viewlist.Add(obj);
                    }
                }
            }
            if (viewlist.Count == 0)
            {
                ViewBag.Message = "No More Request Found";
            }
            return View(viewlist);
        }
        [Authorize]
        public ActionResult Approve(int id)
        {
            LABEntities db = new LABEntities();
            
            if (ModelState.IsValid)
            {

                var req = db.PostRequests.Where(x => x.Request_ID == id).SingleOrDefault();
                req.Status = "Approve";
                db.Entry(req).State = EntityState.Modified;
                db.SaveChanges();
                Donation d = new Donation();
                d.Donatdate = DateTime.Now;
                d.Place = req.Address;
                d.FK_Donation_ID = User.Identity.GetUserId();
                db.Donations.Add(d);
                db.SaveChanges();
            }

            return View();
        }
        [Authorize]
        public ActionResult MyReq()
        {
            string LoginId = User.Identity.GetUserId();
            List<ApprovalViewModel> mylist = new List<ApprovalViewModel>();
            ApprovalViewModel obj = new ApprovalViewModel();
            LABEntities db = new LABEntities();
            List<PostRequest> list1 = db.PostRequests.ToList();
            List<GoogleMap> list2 = db.GoogleMaps.ToList();
            obj.num = 0;
            for ( int i = 0; i < list1.Count;i++)
            {
                PostRequest req = list1.ElementAt(i);
                obj.num = obj.num + 1;
                if (req.FK_ID == LoginId)
                {
                    obj.BloodGroup = req.BloodGroup;
                    GoogleMap g = list2.ElementAt(req.Address - 1);
                    obj.CityName = g.CityName;
                    obj.Message = g.Description;
                    obj.Status = req.Status;
                    mylist.Add(obj);
                }

            }
            return View(mylist);
        }
    }
}
