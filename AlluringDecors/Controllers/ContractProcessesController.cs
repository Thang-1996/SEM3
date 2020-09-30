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
    public class ContractProcessesController : Controller
    {
        private AlluringDecorsEntities db = new AlluringDecorsEntities();

        // GET: ContractProcesses
        public ActionResult Index()
        {
            var contractProcesses = db.ContractProcesses.Include(c => c.Contract);
            return View(contractProcesses.ToList());
        }

        // GET: ContractProcesses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContractProcess contractProcess = db.ContractProcesses.Find(id);
            if (contractProcess == null)
            {
                return HttpNotFound();
            }
            return View(contractProcess);
        }

        // GET: ContractProcesses/Create
        public ActionResult Create()
        {
            ViewBag.ContractID = new SelectList(db.Contracts, "ID", "ContractName");
            return View();
        }

        // POST: ContractProcesses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ContractID,TotalProcess,Status")] ContractProcess contractProcess)
        {
            if (ModelState.IsValid)
            {
                db.ContractProcesses.Add(contractProcess);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContractID = new SelectList(db.Contracts, "ID", "ContractName", contractProcess.ContractID);
            return View(contractProcess);
        }

        // GET: ContractProcesses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContractProcess contractProcess = db.ContractProcesses.Find(id);
            if (contractProcess == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContractID = new SelectList(db.Contracts, "ID", "ContractName", contractProcess.ContractID);
            return View(contractProcess);
        }

        // POST: ContractProcesses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ContractID,TotalProcess,Status")] ContractProcess contractProcess)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contractProcess).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContractID = new SelectList(db.Contracts, "ID", "ContractName", contractProcess.ContractID);
            return View(contractProcess);
        }

        // GET: ContractProcesses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContractProcess contractProcess = db.ContractProcesses.Find(id);
            if (contractProcess == null)
            {
                return HttpNotFound();
            }
            return View(contractProcess);
        }

        // POST: ContractProcesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContractProcess contractProcess = db.ContractProcesses.Find(id);
            db.ContractProcesses.Remove(contractProcess);
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
