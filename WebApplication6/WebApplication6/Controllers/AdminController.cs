using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication6;
using WebApplication6.Models;
namespace WebApplication6.Controllers
{
    public class AdminController : Controller
    {
        private LABEntities db = new LABEntities();

        public ActionResult Home()
        {
            return View("Home");
        }
            // GET: Admin
            public ActionResult Index()
        {
            //onlineEntities2 db = new onlineEntities2();
            //List<AspNetUser> lists = new List<AspNetUser>();
            //lists = db.AspNetUsers.ToList();
            return View();
            //List<AspNetUser> lists = new List<AspNetUser>();
            //List<RegisterViewModel> finalData=new List<RegisterViewModel>(); 
            //lists = db.AspNetUsers.ToList();
            //foreach (AspNetUser a in lists) {
            //    RegisterViewModel temp = new RegisterViewModel();
            //    temp.Username = a.UserName;
            //    temp.Email = a.Email;
            //    temp.Cnic = a.Cnic;
            //    temp.Adress = a.Adress;
            //    finalData.Add(temp);
            //    }
            //ViewBag.data = finalData;
            //return View(finalData);
            //return View(db.AspNetUsers.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisteredUser product = db.RegisteredUsers.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "R_Email, R_Name, R_Gender, R_BloodGroup,  R_Dateofbirth, R_Contact, R_City, R_AddedOn")] RegisteredUser donor)
        {
            if (ModelState.IsValid)
            {
                db.RegisteredUsers.Add(donor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donor);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisteredUser donor = db.RegisteredUsers.Find(id);
            if (donor == null)
            {
                return HttpNotFound();
            }
            return View(donor);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "R_Email, R_Name, R_Gender, R_BloodGroup,  R_Dateofbirth, R_Contact, R_City, R_AddedOn")] RegisteredUser donor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donor);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisteredUser donor = db.RegisteredUsers.Find(id);
            if (donor == null)
            {
                return HttpNotFound();
            }
            return View(donor);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegisteredUser product = db.RegisteredUsers.Find(id);
            db.RegisteredUsers.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
