using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication6.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            SELABEntities db = new SELABEntities();
            Feedback fb = new Feedback();
            List<Feedback> list1 = db.Feedbacks.ToList();
            int z = list1.Count();
            int i = 5;
            if (z > i)
            {
                Feedback fb1 = new Feedback();
                fb =list1.ElementAt(i);
                string v = fb.Message;
                string g2 = fb.Name;
                ViewBag.Message = v;
                ViewBag.Message0 = g2;

                fb = list1.ElementAt(i-1);
                string v1 = fb.Message;
                string g3 = fb.Name;
                ViewBag.Message = v;
                ViewBag.Message11 = g2;
                ViewBag.Message1 = v1;

                fb = list1.ElementAt(i-2);
                string g4 = fb.Name;
                string v2 = fb.Message;
                ViewBag.Message2 = v2;
                ViewBag.Message33 = g4;
                
               
                fb = list1.ElementAt(i-3);
                string v3 = fb.Message;
                string g5 = fb.Name;
                ViewBag.Message3 = v3;
                ViewBag.Message33 = g5;
               
                ViewBag.Message = v3;
                fb = list1.ElementAt(i-4);
                string g6 = fb.Name;
                ViewBag.Message44 = g6;
                string v4 = fb.Message;
                ViewBag.Message = v4;

            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}