using DomainModel;
using DomainModel.Interfaces;
using DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EindopdrachtProg6.Controllers
{
    public class StartController : Controller
    {
        IEmployeeRepository employeeRepository = new EmployeeRepository();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection f)
        {
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            var employee = new Employee();
            return View(employee);
        }

        [HttpPost]
        public ActionResult Login(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employeeRepository.IsValid(employee))
                {
                    FormsAuthentication.SetAuthCookie(employee.Username, false);
                    return RedirectToAction("Index", "Start");
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        public ActionResult GuestMenu()
        {
            return View();
        }

        public ActionResult EmployeeMenu()
        {
            return View();
        }
    }
}
