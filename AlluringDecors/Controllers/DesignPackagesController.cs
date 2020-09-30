using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlluringDecors.Models;

namespace AlluringDecors.Controllers
{
    public class DesignPackagesController : Controller
    {
        private AlluringDecorsEntities db = new AlluringDecorsEntities();

        // GET: DesignPackages
        public ActionResult Index()
        {
            var designPackages = db.DesignPackages.Include(d => d.Project);
            return View(designPackages.ToList());
        }

        // GET: DesignPackages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignPackage designPackage = db.DesignPackages.Find(id);
            if (designPackage == null)
            {
                return HttpNotFound();
            }
            return View(designPackage);
        }

        // GET: DesignPackages/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "id", "ProjectName");
            return View();
        }

        // POST: DesignPackages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PackageName,Price,ProjectID")] DesignPackage designPackage)
        {
            if (ModelState.IsValid)
            {
                db.DesignPackages.Add(designPackage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "id", "ProjectName", designPackage.ProjectID);
            return View(designPackage);
        }

        // GET: DesignPackages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignPackage designPackage = db.DesignPackages.Find(id);
            if (designPackage == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "id", "ProjectName", designPackage.ProjectID);
            return View(designPackage);
        }

        // POST: DesignPackages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PackageName,Price,ProjectID")] DesignPackage designPackage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(designPackage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "id", "ProjectName", designPackage.ProjectID);
            return View(designPackage);
        }

        // GET: DesignPackages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignPackage designPackage = db.DesignPackages.Find(id);
            if (designPackage == null)
            {
                return HttpNotFound();
            }
            return View(designPackage);
        }

        // POST: DesignPackages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DesignPackage designPackage = db.DesignPackages.Find(id);
            db.DesignPackages.Remove(designPackage);
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
