using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Luizalabs.EmployeeManager.API.DAL
{
    public static class EmployeeContextFactory
    {
        private static EmployeeContext _context;
        public static EmployeeContext GetInstance()
        {
            if (_context == null)
                _context = new EmployeeContext();

            return _context;
        }
    }
}