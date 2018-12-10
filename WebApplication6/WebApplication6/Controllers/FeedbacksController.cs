using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using WebApplication6;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    
    public class FeedbacksController : Controller
    {
        private SELABEntities db = new SELABEntities();

        // GET: Feedbacks
        
        public ActionResult Index()
        {
            var feedbacks = db.Feedbacks.Include(f => f.AspNetUser);
            return View(feedbacks.ToList());
        }
        
        public ActionResult IndexUser()
        {
            var feedbacks = db.Feedbacks.Include(f => f.AspNetUser);
            return View(feedbacks.ToList());
        }

        // GET: Feedbacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // GET: Feedbacks/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.FK_ID = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Feedbacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,Message,FK_ID")] FeedBackViewModel feedback)
        {
            SELABEntities db = new SELABEntities();
            Feedback fb = new Feedback();
            if (ModelState.IsValid)
            {
                fb.Name = feedback.Name;
                fb.Email = feedback.Email;
                fb.Message = feedback.Message;
                fb.FK_ID = User.Identity.GetUserId();

                db.Feedbacks.Add(fb);
                db.SaveChanges();
                return RedirectToAction("Index", "Home"); ;
            }

            ViewBag.FK_ID = new SelectList(db.AspNetUsers, "Id", "Email", fb.FK_ID);
            return View(feedback);
        }

        // GET: Feedbacks/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_ID = new SelectList(db.AspNetUsers, "Id", "Email", feedback.FK_ID);
            feedback.FK_ID = User.Identity.GetUserId();
            return View(feedback);
        }

        // POST: Feedbacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,Message,FK_ID")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedback.FK_ID = User.Identity.GetUserId();
                db.Entry(feedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.FK_ID = new SelectList(db.AspNetUsers, "Id", "Email", feedback.FK_ID);
            return View(feedback);
        }

        // GET: Feedbacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // POST: Feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feedback feedback = db.Feedbacks.Find(id);
            db.Feedbacks.Remove(feedback);
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
