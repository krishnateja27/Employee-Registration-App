using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Teams.Samples.HelloWorld.Web.Models;

namespace Microsoft.Teams.Samples.HelloWorld.Web.Controllers
{
    public class EmployeeController : Controller
    {
        [Route("employee")]
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        //setemployee
        public ActionResult setEmployee(Employee employee)
        {
            EmployeeList.EmployeesList.Add(employee);
            return View();
        }
    }
}