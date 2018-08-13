using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Luizalabs.EmployeeManager.API.Models
{
    public class Employee
    {
        public long id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string department { get; set; }
    }
}