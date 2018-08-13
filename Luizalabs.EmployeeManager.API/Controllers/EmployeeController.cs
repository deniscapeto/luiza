using Luizalabs.EmployeeManager.API.DAL;
using Luizalabs.EmployeeManager.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using PagedList;

namespace Luizalabs.EmployeeManager.API.Controllers
{
    public class EmployeeController : ApiController
    {
        [Route("employee")]
        public IHttpActionResult Get(int page_size, int page)
        {
            try
            {
                EmployeeContext context = new EmployeeContext();
                var pagedList =context.employees
                    .OrderBy(e => e.name)
                    .ToPagedList<Employee>(page, page_size);
                List<Employee> employees = pagedList.ToList();

                return Json(employees);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(HttpStatusCode.InternalServerError, Request);
            }
        }

        [Route("employee")]
        public IHttpActionResult Post(Employee employee)
        {
            try
            {
                EmployeeContext context = new EmployeeContext();
                Employee employees = context.employees.Add(employee);
                context.SaveChanges();

                return Created("", employee);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(HttpStatusCode.InternalServerError, Request);
            }
        }

        [Route("employee/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                EmployeeContext context = new EmployeeContext();
                Employee employeeFound = context.employees.Find(id);

                if (employeeFound == null)
                    return NotFound();

                Employee employees = context.employees.Remove(employeeFound );
                context.SaveChanges();

                return new StatusCodeResult(HttpStatusCode.OK, Request);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(HttpStatusCode.InternalServerError, Request);
            }
        }
    }
}