using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Tyler_Technologies_Solution
{
    public class EmployeeDbHandle
    {
        private readonly EmployeeDBContext _db = new EmployeeDBContext();

        public string AddEmployee(int employeeId, int managerId, string firstName, string lastName, List<Role> roles)
        {
            try
            {
                Employee employee = new Employee()
                {
                    Id = employeeId,
                    FirstName = firstName,
                    LastName = lastName,
                    ManagerId = managerId,
                };

                employee.Roles = MakeEmployeeRoles(employee, roles);

                // Necessary to add explicit ID
                using (var transaction = _db.Database.BeginTransaction())
                {
                    _db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Employees] ON");
                    _db.Employees.Add(employee);
                    _db.SaveChanges();
                    _db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Employees] OFF");
                    transaction.Commit();
                }

                return "Employee Added";
            }
            catch (Exception e)
            {
                return "Employee could not be added: The server threw the following exception: " + e.Message;
            }
        }

        private ICollection<EmployeeRole> MakeEmployeeRoles(Employee employee, List<Role> roles)
        {
            ICollection<EmployeeRole> empRoles = new List<EmployeeRole>();
            foreach (Role role in roles)
            {
                empRoles.Add(new EmployeeRole(){Employee = employee, Role = role});
            }

            return empRoles;
        }
        
        public List<Employee> GetAllManagers()
        {
            List<Employee> allManagers = new List<Employee>();
            List<EmployeeRole> empRoles = _db.EmployeeRoles.ToList();

            foreach (EmployeeRole empRole in empRoles)
            {
                if (empRole.Role.Id == (int)RolesEnum.Director)
                {
                    allManagers.Add(_db.Employees.Single(e => e.Id == empRole.Employee.Id));
                }
            }

            return allManagers;
        }

        public List<Role> GetPossibleRoles()
        {
            return _db.Roles.ToList();
        }

        public List<Employee> GetAllEmployees()
        {
            return _db.Employees.ToList();
        }
    }
}