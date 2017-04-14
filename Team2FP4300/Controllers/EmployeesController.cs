using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Team2FP4300.DAL;
using Team2FP4300.Models;
using PagedList.Mvc;
using PagedList;

namespace Team2FP4300.Controllers
{
    public class EmployeesController : Controller
    {
        private DBCtx db = new DBCtx();

        // GET: Employees
        public ActionResult Index(string pSortOrder, int page = 1, int pageSize=5)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(pSortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = pSortOrder == "date_asc" ? "date_desc" : "date_asc";
            if (pSortOrder == "empid_asc")
            {
                ViewBag.empidSortParm = "empid_desc";
            }
            else
            {
                ViewBag.empidSortParm = "empid_asc";
            }

            List<Employees> MyEmployees = db.Employees.ToList();

            switch (pSortOrder)
            {
                case "name_asc":
                    MyEmployees = MyEmployees.OrderBy(e => e.LastName).ToList();
                    break;
                case "name_desc":
                    MyEmployees = MyEmployees.OrderByDescending(e => e.LastName).ToList();
                    break;
                case "empid_asc":
                    MyEmployees = MyEmployees.OrderBy(e => e.EmployeeId).ToList();
                    break;
                case "empid_desc":
                    MyEmployees = MyEmployees.OrderByDescending(e => e.EmployeeId).ToList();
                    break;
                case "date_asc":
                    MyEmployees = MyEmployees.OrderBy(e => e.HireDate).ToList();
                    break;
                case "date_desc":
                    MyEmployees = MyEmployees.OrderByDescending(e => e.HireDate).ToList();
                    break;
                default: // display in the ascending order of last name
                    MyEmployees = MyEmployees.OrderBy(e => e.LastName).ToList();
                    break;
            }
            PagedList<Employees> myEmps =
                          new PagedList<Employees>(MyEmployees, page, pageSize);
            return View(myEmps);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,DeptCode,FirstName,LastName,Title,HireDate,Salary,ImgFileName")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employees);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employees);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,DeptCode,FirstName,LastName,Title,HireDate,Salary,ImgFileName")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employees).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employees);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employees employees = db.Employees.Find(id);
            db.Employees.Remove(employees);
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

        public ActionResult SearchEmp(string SearchString)
        {
            var employees = db.Employees.Include(e => e.Departments);
            if (!String.IsNullOrEmpty(SearchString))
            {
                employees = db.Employees
                         .Where(e => e.LastName.Contains(SearchString) || e.FirstName.Contains(SearchString));
            }
            return View(employees);
        }
        public ActionResult ShowEmpsByDept(int id =1)
        {
            int theDeptCode = id;
            List<Employees> myEmployees = db.Employees.Where(e => e.DepartmentCode == theDeptCode).ToList();
            // Find department name
            Department myDept = db.Department.Find(theDeptCode);
            string theDeptName = myDept.DepartmentName;
            ViewBag.theDeptName = theDeptName;
            return View(myEmployees);
        }


    }

}
