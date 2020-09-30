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
    public class DesignTypesController : Controller
    {
        private AlluringDecorsEntities db = new AlluringDecorsEntities();

        // GET: DesignTypes
        public ActionResult Index()
        {
            var designTypes = db.DesignTypes.Include(d => d.ProjectCategory);
            return View(designTypes.ToList());
        }

        // GET: DesignTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignType designType = db.DesignTypes.Find(id);
            if (designType == null)
            {
                return HttpNotFound();
            }
            return View(designType);
        }

        // GET: DesignTypes/Create
        public ActionResult Create()
        {
            ViewBag.ProjectCategoryID = new SelectList(db.ProjectCategories, "id", "CategoryName");
            return View();
        }

        // POST: DesignTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DesignTypeName,ProjectCategoryID,Price")] DesignType designType)
        {
            if (ModelState.IsValid)
            {
                db.DesignTypes.Add(designType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectCategoryID = new SelectList(db.ProjectCategories, "id", "CategoryName", designType.ProjectCategoryID);
            return View(designType);
        }

        // GET: DesignTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignType designType = db.DesignTypes.Find(id);
            if (designType == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectCategoryID = new SelectList(db.ProjectCategories, "id", "CategoryName", designType.ProjectCategoryID);
            return View(designType);
        }

        // POST: DesignTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DesignTypeName,ProjectCategoryID,Price")] DesignType designType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(designType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectCategoryID = new SelectList(db.ProjectCategories, "id", "CategoryName", designType.ProjectCategoryID);
            return View(designType);
        }

        // GET: DesignTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignType designType = db.DesignTypes.Find(id);
            if (designType == null)
            {
                return HttpNotFound();
            }
            return View(designType);
        }

        // POST: DesignTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DesignType designType = db.DesignTypes.Find(id);
            db.DesignTypes.Remove(designType);
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
