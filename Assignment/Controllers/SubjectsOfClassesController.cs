using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment.DB;

namespace Assignment.Controllers
{
    public class SubjectsOfClassesController : Controller
    {
        private AttendanceDBEntities db = new AttendanceDBEntities();

        // GET: SubjectsOfClasses
        public ActionResult Index()
        {
            var subjectsOfClasses = db.SubjectsOfClasses.Include(s => s.Class).Include(s => s.Lecturer).Include(s => s.Subject);
            return View(subjectsOfClasses.ToList());
        }

        // GET: SubjectsOfClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectsOfClass subjectsOfClass = db.SubjectsOfClasses.Find(id);
            if (subjectsOfClass == null)
            {
                return HttpNotFound();
            }
            return View(subjectsOfClass);
        }

        // GET: SubjectsOfClasses/Create
        public ActionResult Create()
        {
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName");
            ViewBag.LecID = new SelectList(db.Lecturers, "LecID", "Fullname");
            ViewBag.SubID = new SelectList(db.Subjects, "SubID", "SubName");
            return View();
        }

        // POST: SubjectsOfClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubOfClaID,SubID,ClassID,LecID,StartDate,EndDate,Hours,SlotTime,Status")] SubjectsOfClass subjectsOfClass)
        {
            if (ModelState.IsValid)
            {
                db.SubjectsOfClasses.Add(subjectsOfClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", subjectsOfClass.ClassID);
            ViewBag.LecID = new SelectList(db.Lecturers, "LecID", "Fullname", subjectsOfClass.LecID);
            ViewBag.SubID = new SelectList(db.Subjects, "SubID", "SubName", subjectsOfClass.SubID);
            return View(subjectsOfClass);
        }

        // GET: SubjectsOfClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectsOfClass subjectsOfClass = db.SubjectsOfClasses.Find(id);
            if (subjectsOfClass == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", subjectsOfClass.ClassID);
            ViewBag.LecID = new SelectList(db.Lecturers, "LecID", "Fullname", subjectsOfClass.LecID);
            ViewBag.SubID = new SelectList(db.Subjects, "SubID", "SubName", subjectsOfClass.SubID);
            return View(subjectsOfClass);
        }

        // POST: SubjectsOfClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubOfClaID,SubID,ClassID,LecID,StartDate,EndDate,Hours,SlotTime,Status")] SubjectsOfClass subjectsOfClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjectsOfClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", subjectsOfClass.ClassID);
            ViewBag.LecID = new SelectList(db.Lecturers, "LecID", "Fullname", subjectsOfClass.LecID);
            ViewBag.SubID = new SelectList(db.Subjects, "SubID", "SubName", subjectsOfClass.SubID);
            return View(subjectsOfClass);
        }

        // GET: SubjectsOfClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectsOfClass subjectsOfClass = db.SubjectsOfClasses.Find(id);
            if (subjectsOfClass == null)
            {
                return HttpNotFound();
            }
            return View(subjectsOfClass);
        }

        // POST: SubjectsOfClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubjectsOfClass subjectsOfClass = db.SubjectsOfClasses.Find(id);
            db.SubjectsOfClasses.Remove(subjectsOfClass);
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
