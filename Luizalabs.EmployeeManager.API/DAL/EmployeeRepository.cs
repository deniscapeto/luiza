using System.Collections.Generic;
using System.Linq;
using Luizalabs.EmployeeManager.API.Models;
using PagedList;

namespace Luizalabs.EmployeeManager.API.DAL
{
    public interface IEmployeeRepository
    {
        List<Employee> List(int page_size, int page);
        Employee Add(Employee employee);
        void Delete(int id);
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        IEmployeeContext context;
        public EmployeeRepository(IEmployeeContext employeeContext)
        {
            this.context = employeeContext;
        }
        public List<Employee> List(int page_size, int page)
        {
              var pagedList = context.Employees
                .OrderBy(e => e.name)
                .ToPagedList<Employee>(page, page_size);

            return pagedList.ToList();
        }

        public Employee Add(Employee employee)
        {
            Employee employees = context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public void Delete(int id)
        {
            Employee employeeFound = context.Employees.Find(id);

            if (employeeFound == null)
                throw new KeyNotFoundException("Employee not found");

            Employee employees = context.Employees.Remove(employeeFound);
            context.SaveChanges();
        }

    }
}