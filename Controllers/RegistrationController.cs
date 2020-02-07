using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ManagementStudent.Models;

namespace ManagementStudent.Controllers
{
    public class RegistrationController : Controller
    {
        private ManagementEntities db = new ManagementEntities();

        // GET: /Registration/
        public ActionResult Index()
        {
            var registrations = db.registrations.Include(r => r.batch).Include(r => r.course);
            return View(registrations.ToList());
        }

        // GET: /Registration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registration registration = db.registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // GET: /Registration/Create
        public ActionResult Create()
        {
            ViewBag.Batch_id = new SelectList(db.batches, "Id", "Batch1");
            ViewBag.Course_id = new SelectList(db.courses, "Id", "Course1");
            return View();
        }

        // POST: /Registration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Firstname,Lastname,Nic,Course_id,Batch_id,Telno")] registration registration)
        {
            if (ModelState.IsValid)
            {
                db.registrations.Add(registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Batch_id = new SelectList(db.batches, "Id", "Batch1", registration.Batch_id);
            ViewBag.Course_id = new SelectList(db.courses, "Id", "Course1", registration.Course_id);
            return View(registration);
        }

        // GET: /Registration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registration registration = db.registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            ViewBag.Batch_id = new SelectList(db.batches, "Id", "Batch1", registration.Batch_id);
            ViewBag.Course_id = new SelectList(db.courses, "Id", "Course1", registration.Course_id);
            return View(registration);
        }

        // POST: /Registration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Firstname,Lastname,Nic,Course_id,Batch_id,Telno")] registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Batch_id = new SelectList(db.batches, "Id", "Batch1", registration.Batch_id);
            ViewBag.Course_id = new SelectList(db.courses, "Id", "Course1", registration.Course_id);
            return View(registration);
        }

        // GET: /Registration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registration registration = db.registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // POST: /Registration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            registration registration = db.registrations.Find(id);
            db.registrations.Remove(registration);
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
