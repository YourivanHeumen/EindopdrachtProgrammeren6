using DomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DomainModel.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeContext context;

        public EmployeeRepository()
        {
            context = new EmployeeContext();
            Database.SetInitializer<EmployeeContext>(null);
        }

        public bool IsValid(Employee employee)
        {
            bool employeeFromDatabase = false;

            if (context.Employees.Any(o => o.Username == employee.Username))
            {
                employeeFromDatabase = true;
            }


            if (!employeeFromDatabase)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}