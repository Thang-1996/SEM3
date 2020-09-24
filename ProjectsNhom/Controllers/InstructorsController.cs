using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectsNhom.Models;

namespace ProjectsNhom.Controllers
{
    public class InstructorsController : Controller
    {
        private ProjectsNhomEntities db = new ProjectsNhomEntities();

        // GET: Instructors
        public ActionResult Index()
        {
            var instructors = db.Instructors.Include(i => i.Class).Include(i => i.Course).Include(i => i.Department);
            return View(instructors.ToList());
        }

        // GET: Instructors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = db.Instructors.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // GET: Instructors/Create
        public ActionResult Create()
        {
            ViewBag.ClassID = new SelectList(db.Classes, "ID", "ClassName");
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "CourseName");
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "DepartmentName");
            return View();
        }

        // POST: Instructors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CourseID,DepartmentID,InstructorName,Phone,Age,ClassID")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                db.Instructors.Add(instructor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassID = new SelectList(db.Classes, "ID", "ClassName", instructor.ClassID);
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "CourseName", instructor.CourseID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "DepartmentName", instructor.DepartmentID);
            return View(instructor);
        }

        // GET: Instructors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = db.Instructors.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ID", "ClassName", instructor.ClassID);
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "CourseName", instructor.CourseID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "DepartmentName", instructor.DepartmentID);
            return View(instructor);
        }

        // POST: Instructors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CourseID,DepartmentID,InstructorName,Phone,Age,ClassID")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instructor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ID", "ClassName", instructor.ClassID);
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "CourseName", instructor.CourseID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "DepartmentName", instructor.DepartmentID);
            return View(instructor);
        }

        // GET: Instructors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = db.Instructors.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // POST: Instructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instructor instructor = db.Instructors.Find(id);
            db.Instructors.Remove(instructor);
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
