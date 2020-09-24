using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeFirst_WebApplication.DAL;
using CodeFirst_WebApplication.Models;
using PagedList;

namespace CodeFirst_WebApplication.Controllers
{
    public class StudentsController : Controller
    {
        private FptAptechEduContext db = new FptAptechEduContext();

        // GET: Students
        // sử dụng viewResult cho action result để render view engine

        public ViewResult Index(string sortOrder, string search,
            string currentFilter,int? page) // tạo biến để sort và search // current filter là lưu lại thông tin lọc của page hiện tại còn int?page là đang xem ở page bao nhiêu

        {
            ViewBag.CurrentSort = sortOrder; // gán sort hiện tại bằng sortOrder
            /* List<Student> students = db.Students.ToList();
             // sử dụng querry
             String query = "SELECT * FROM student";
             return View(students);*/
            // sử dụng viewbag là 1 đối tượng có sẵn để giao tiếp với view
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            // querry
            if(search != null)
            {
                page = 1; // nếu search có giá trị trả về page = 1
            }
            else
            {
                search = currentFilter;
            }
            ViewBag.CurrentFilter = search;
            var students = from s in db.Students select s;
            if(!String.IsNullOrEmpty(search)) // nếu search string có thì in ra hoặc không thì không in ra
            {
                students = students.Where(s => s.LastName.Contains(search) || s.FirstMidName.Contains(search) || s.Address.Contains(search)); // contains là để check xem lastname hoặc firstName có chứa search string ở trên 

            }

            switch (sortOrder)
            {
                case  "name desc" :
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case  "date_desc" :
                    students = students.OrderByDescending(s => s.EnrollmentDate);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.EnrollmentDate);
                    break;
                default:
                    students = students.OrderBy(s => s.LastName);
                    break;
            }
            int pageSize = 3; //  khai báo số lượng record trên 1 page
            int pageNumber = ( page ?? 1 ); // page number là page đang chọn nếu không chọn sẽ = 1
            return View(students.ToPagedList(pageNumber,pageSize)); // sử dụng topagedlist() để sử dụng phân trang 
         
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LastName,FirstMidName,EnrollmentDate,Address")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LastName,FirstMidName,EnrollmentDate,Address")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
