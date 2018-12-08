using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;
using Microsoft.AspNet.Identity;

namespace WebApplication6.Controllers
{
    public class PostRequestController : Controller
    {
        // GET: PostRequest
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Request()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Request(PostRequestModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SEProjectEntities db = new SEProjectEntities();
                    GoogleMap Map = new GoogleMap();
                    PostRequest req = new PostRequest();
                    Map.CityName = model.CityName;
                    Map.Latitude = model.Latitude;
                    Map.Longitude = model.Longitude;
                    Map.Description = model.Message;
                    db.GoogleMaps.Add(Map);
                    var val = db.SaveChanges();

                    req.BloodGroup = model.BloodGroup;
                    req.Address = val;
                    req.FK_ID = User.Identity.GetUserId();
                    req.Status = "Decline";
                    db.PostRequests.Add(req);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
               catch(DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }
            }
            return View();
        }
    }
}