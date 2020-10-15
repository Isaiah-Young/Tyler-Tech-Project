using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Tyler_Technologies_Solution
{
    public class EmployeeDbHandle
    {
        private readonly EmployeeDBContext _db = new EmployeeDBContext();

        public bool AddEmployee(int employeeId, int managerId, string firstName, string lastName, List<Role> roles)
        {
            // employee id isn't being added correctly in the db
            Employee employee = new Employee()
            {
                Id = employeeId,
                FirstName = firstName,
                LastName = lastName,
                ManagerId = managerId,
            };

            ICollection<EmployeeRole> empRoles = MakeEmployeeRoles(employee, roles);
            employee.Roles = empRoles;

            if (EmployeeCanBeAdded(employee))
            {
                // Necessary to add explicit ID
                using (var transaction = _db.Database.BeginTransaction())
                {
                    _db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Employees] ON");
                    _db.Employees.Add(employee);
                    _db.SaveChanges();
                    _db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Employees] OFF");
                    transaction.Commit();
                }

                return true;
            }

            return false;
        }

        // Check that data is correct format and won't inject unwanted SQL
        // If this were an MVC Web app, this method would be called in the controller (and made public)
        // Need to unit test this
        private bool EmployeeCanBeAdded(Employee employee)
        {
            int employeeId = employee.Id;
            int? managerId = employee.ManagerId;
            string firsName = employee.FirstName;
            string lastName = employee.LastName;

            if (employeeId < 0) return false;
            if (managerId < 0) return false;
            // add sql sanitization of first and last name (no drop table, etc.)
            return true;
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