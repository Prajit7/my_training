using SampleMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvcApp.Controllers
{
    public class FirstExampleController : Controller
    {
        public string HelloWorld() => "Hello from MVC";
        public double GetNumber(string v1, string v2)
        {
            var first = double.Parse(v1);
            var second = double.Parse(v2);
            return first + second;
        }
        public ViewResult DisplayEmployee()
        {
            var employee = new Employee
            {
                EmployeeId = 1,
                EmployeeName = "RamSharma",
                EmployeeEmail = "ram@gmail.com",
                EmployeeSalary = 50000
            };
            return View(employee);

        }
    }
}