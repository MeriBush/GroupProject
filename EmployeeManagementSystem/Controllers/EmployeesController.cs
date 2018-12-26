using EmployeeManagementSystem.DA;
using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                employees = DataAccess.GetEmployees();
                return View(employees);
            }
            catch (Exception)
            {
                return View(employees);
            }            
        }

       
        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                int createdEmployees = DataAccess.AddNewEmployee(employee);   
                if(createdEmployees == 1)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(employee);
                }            
                
            }
            catch(Exception)
            {
                return View(employee);
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                Employee foundEmployee = DataAccess.GetEmployee((int)id);
                return View(foundEmployee);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                int employeesUpdated = DataAccess.EditEmployee(employee);
                if (employeesUpdated == 1)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(employee);
                }
            }
            catch(Exception)
            {
                return View(employee);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id != null)
                {
                    int employesDeleted = DataAccess.DeleteEmployee((int)id);
                }
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
