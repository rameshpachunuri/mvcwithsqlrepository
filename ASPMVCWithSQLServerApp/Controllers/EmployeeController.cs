using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPMVCWithSQLServerApp.Repository;
using ASPMVCWithSQLServerApp.Models;

namespace ASPMVCWithSQLServerApp.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult GetAllEmployees()
        {
            EmployeeRepository repository = new EmployeeRepository();
            ModelState.Clear();
            return View(repository.getEmployees());
        }

        // GET: Employee/Details/5
        public ActionResult AddEmployee()
        {
            return View();
        }
        // Post: Employee/Details/5
        [HttpPost]
        public ActionResult AddEmployee(EmployeeModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeRepository repository = new EmployeeRepository();
                    if (repository.addNewEmployee(model))
                    {
                        ViewBag.Message = "Employee added successfully";
                    }
                }
                return View();
            }
            catch { return View(); }
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("GetAllEmployees");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult EditEmployee(int id)
        {
            EmployeeRepository repository = new EmployeeRepository();
            return View(repository.getEmployees().Find(emp => emp.EmpID == id));
        }

        // POST: Employee/Edit/5 update employee details
        [HttpPost]
        public ActionResult EditEmployee(int
            id, EmployeeModel model)
        {
            try
            {
                EmployeeRepository employee = new EmployeeRepository();
                employee.updateEmployee(model);
                ViewBag.Message = "Employee updated successfully";
                return RedirectToAction("GetAllEmployees");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult DeleteEmployee(int id)
        {
            try
            {
                EmployeeRepository repository = new EmployeeRepository();
                if (repository.deleteEmployee(id))
                {
                    ViewBag.Message = "Employee deleted successfully";
                }

                return RedirectToAction("GetAllEmployees");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult employeeDetails(int id)
        {
            try
            {
                EmployeeRepository repository = new EmployeeRepository();
                return View(repository.getEmployees().Find(emp => emp.EmpID == id));
            }
            catch { return View(); }
        }
    }
}
