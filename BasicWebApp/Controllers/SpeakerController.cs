using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BasicWebApp.Models;
using EntityState = System.Data.Entity.EntityState;

namespace BasicWebApp.Controllers
{
    public class SpeakerController : Controller
    {
        private ConferenceContext db = new ConferenceContext();

        // GET: /Speaker/
        public ActionResult Index()
        {
            return View(db.Speakers.ToList());
        }

        // GET: /Speaker/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Speaker speaker = db.Speakers.Find(id);
            if (speaker == null)
            {
                return HttpNotFound();
            }
            return View(speaker);
        }

        // GET: /Speaker/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Speaker/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SpeakerID,Name,EmailAddress")] Speaker speaker)
        {
            if (ModelState.IsValid)
            {
                db.Speakers.Add(speaker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(speaker);
        }

        // GET: /Speaker/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Speaker speaker = db.Speakers.Find(id);
            if (speaker == null)
            {
                return HttpNotFound();
            }
            return View(speaker);
        }

        // POST: /Speaker/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SpeakerID,Name,EmailAddress")] Speaker speaker)
        {
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(speaker);
        }

        // GET: /Speaker/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Speaker speaker = db.Speakers.Find(id);
            if (speaker == null)
            {
                return HttpNotFound();
            }
            return View(speaker);
        }

        // POST: /Speaker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Speaker speaker = db.Speakers.Find(id);
            db.Speakers.Remove(speaker);
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
