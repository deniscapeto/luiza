using Luizalabs.EmployeeManager.API.DAL;
using Luizalabs.EmployeeManager.API.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;

namespace Luizalabs.EmployeeManager.API.Controllers
{
    public class EmployeeController : ApiController
    {
        private IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        [Route("employee")]
        public IHttpActionResult Get(int page_size, int page)
        {
            try
            {
                var employees =_repository.List(page_size, page);
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
                 Employee employees = _repository.Add(employee);
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
                _repository.Delete(id);

                return Ok();
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(HttpStatusCode.InternalServerError, Request);
            }
        }
    }
}