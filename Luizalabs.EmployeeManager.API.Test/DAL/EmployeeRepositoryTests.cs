using Microsoft.VisualStudio.TestTools.UnitTesting;
using Luizalabs.EmployeeManager.API.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Luizalabs.EmployeeManager.API.Models;
using Moq;
using System.Data.Entity;
using Luizalabs.EmployeeManager.API.Test.Helper;

namespace Luizalabs.EmployeeManager.API.DAL.Tests
{
    [TestClass()]
    public class EmployeeRepositoryTests
    {
        [TestMethod()]
        public void List_ShouldHaveIdEquals3OnSecondPageWithPageSize2()
        {
            var context = new Mock<EmployeeContext>().Object;
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee() {
                id = 1,
                name = "Rodrigo Carvalho",
                department = "IntegraCommerce",
                email = "rodrigo@luizalabs.com" });
            employees.Add(new Employee()
            {
                id = 2,
                name = "Renato Pedigoni",
                department = "Digital Platform",
                email = "renato@luizalabs.com"
            });
            employees.Add(new Employee()
            {
                id = 3,
                name = "Thiago Catoto",
                department = "Mobile",
                email = "catoto@luizalabs.com"
            });

            context.Employees = MockHelper.GetQueryableMockDbSet(employees);

            var repo = new EmployeeRepository(context);
            var list = repo.List(2, 2);
            Assert.AreEqual(3,list.First().id);
        }


        [TestMethod()]
        public void Add_ShouldNotReturnNullOnInsertingNewEmployee()
        {
            var context = new Mock<EmployeeContext>().Object;
            var employee = new Employee()
            {
                name = "Rodrigo Carvalho",
                department = "IntegraCommerce",
                email = "rodrigo@luizalabs.com"
            };
            context.Employees = MockHelper.GetQueryableMockDbSet(new List<Employee>());

            var repo = new EmployeeRepository(context);
            var inserted = repo.Add(employee);

            Assert.IsNotNull(inserted);
        }

        [TestMethod()]
        public void Delete_ShouldDecrementCountNumberOfEmployees()
        {
            var context = new Mock<EmployeeContext>().Object;
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee()
            {
                id = 1,
                name = "Rodrigo Carvalho",
                department = "IntegraCommerce",
                email = "rodrigo@luizalabs.com"
            });
            employees.Add(new Employee()
            {
                id = 2,
                name = "Renato Pedigoni",
                department = "Digital Platform",
                email = "renato@luizalabs.com"
            });
            employees.Add(new Employee()
            {
                id = 3,
                name = "Thiago Catoto",
                department = "Mobile",
                email = "catoto@luizalabs.com"
            });

            context.Employees = MockHelper.GetQueryableMockDbSet(employees);

            var repo = new EmployeeRepository(context);
            repo.Delete(3);
            Assert.AreEqual(2, context.Employees.Count());
        }

    }
}