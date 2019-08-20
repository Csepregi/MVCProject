using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace MVCProject.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeBusinessLayer employeeBusiness = new EmployeeBusinessLayer();
            List<Employee> employees = employeeBusiness.Employees.ToList();
            return View(employees);
        }

        [HttpGet]
        public ActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
                employeeBusinessLayer.AddEmmployee(employee);
                return RedirectToAction("Index");
            }
            return View();
            
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            Employee employee = employeeBusinessLayer.Employees.Single(emp => emp.id == id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
                employeeBusinessLayer.SaveEmmployee(employee);
                return RedirectToAction("Index");
            }
            return View();
           
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
                employeeBusinessLayer.DeleteEmployee(id);
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}