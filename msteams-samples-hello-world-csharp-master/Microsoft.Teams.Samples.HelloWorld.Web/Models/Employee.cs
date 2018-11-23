using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.Teams.Samples.HelloWorld.Web.Models
{
    public static class EmployeeList
    {
        public static List<Employee> EmployeesList { get; set; } = new List<Employee>()
        {
            new Employee() {  Address = "KPHB",
                ID = 1,
                Gender = "Male",
                Name = "Krishna",
                PhoneNumber = 7032258248
            },
            new Employee() {  Address = "Koti",
                ID = 2,
                Gender = "Female",
                Name = "Ramya",
                PhoneNumber = 12345678
            },
            new Employee() {  Address = "Ramnagar",
                ID = 3,
                Gender = "Male",
                Name = "Pavan",
                PhoneNumber = 2345678
            }
        };
    }
    public class Employee
    {
        public int ID;

        public string Name;

        public string Gender;

        public string Address;

        public Int64 PhoneNumber;

    }
}