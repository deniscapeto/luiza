using Luizalabs.EmployeeManager.API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Luizalabs.EmployeeManager.API.DAL
{
    public interface IEmployeeContext
    {
        DbSet<Employee> Employees { get; set; }
        int SaveChanges();

    }
    public class EmployeeContext : DbContext , IEmployeeContext
    {
        public EmployeeContext() : base("EmployeeContext")
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //manter o mesmo noma da entidade na tabela
           modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}