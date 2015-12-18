using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCRepository.Repository;
using MVCRepository.Models;

namespace MVCRepository.Controllers
{
    public class EmployeeController : Controller
    {

        private IEmployeeRepository _employeeRepository;

        public EmployeeController()
        {
            _employeeRepository = new EmployeeRepository(new Models.EmployeeContext());
        }

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public ActionResult Index()
        {
            var getallemp = _employeeRepository.GetAllEmployee();
            return View(getallemp);
        }

        public ActionResult AddEmployee()
        {
            if (TempData["Failed"] != null)
            {
                ViewBag.Failed = "Failed to add employee";
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                int result = _employeeRepository.AddEmployee(employee);
                if (result > 0)
                {
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    TempData["Failed"] = "Failed";
                    return RedirectToAction("AddEmployee", "Employee");
                }
            }
            return View();
        }

        public ActionResult EditEmployee(int EmpId)
        {
            if (TempData["Failed"] != null)
            {
                ViewBag.failed = "Failed to edit the employee details";
            }
            Employee employee = _employeeRepository.GetEmployeeById(EmpId);
            return View(employee);
        }

        [HttpPost]
        public ActionResult EditEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                int result = _employeeRepository.UpdateEmployee(employee);
                if (result > 0)
                {
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    return RedirectToAction("Index", "Employee");
                }
            }
            return View();
        }

        public ActionResult DeleteEmployee(int EmpId)
        {
            Employee employee = _employeeRepository.GetEmployeeById(EmpId);
            return View(employee);
        }

        [HttpPost]
        public ActionResult DeleteEmployee(Employee employee)
        {
            if (TempData["Failed"] != null)
            {
                ViewBag.Failed = "Failed to delete employee data";
            }
            _employeeRepository.DeleteEmployee(employee.EmployeeId);
            return RedirectToAction("Index", "Employee");
        }
    }
}
