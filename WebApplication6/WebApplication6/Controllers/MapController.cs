using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class MapController : Controller
    {
        // GET: Map
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Location()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Location(PostRequestModel location)
        {
            if (!ModelState.IsValid)
            {
                return View("Register");
            }
            else
            {
                try
                {
                    using (SELABEntities model = new SELABEntities())
                    {
                        return View();
                    }
                }
                catch (Exception ex)
                {

                    return View();

                }
            }
                        
        }
    }
}