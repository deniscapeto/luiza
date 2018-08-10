using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Luizalabs.EmployeeManager.API.Controllers
{
    public class EmployeeController : ApiController
    {
        [Route("employee")]
        public JsonResult<List<Employee>> Get(int page_size, int page)
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee(){ name = "Denis", email  = "deniscapeto@gmail.com",  department ="TI"  },
                new Employee(){ name = "Renato", email  = "renato@gmail.com",  department ="TI"  },
                new Employee(){ name = "Rogerio", email  = "rogerio@gmail.com",  department ="TI"  }
            };

            return Json(employees);
        }

        [Route("employee")]
        public StatusCodeResult Post(Employee employee)
        {
            return new StatusCodeResult(HttpStatusCode.Created, Request);
        }

        public StatusCodeResult Delete(int id)
        {
            return new StatusCodeResult(HttpStatusCode.OK, Request);
        }
    }

    public class Employee
    {
        public string name { get; set; }
        public string email { get; set; }
        public string department { get; set; }
    }
}