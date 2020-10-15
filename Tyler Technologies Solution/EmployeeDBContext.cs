using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Tyler_Technologies_Solution
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext() 
            : base("EmployeeConn")
        {
            
        }
        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        
    }
    
    public class Employee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int? ManagerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public virtual ICollection<EmployeeRole> Roles { get; set; }
    }

    // Although we have an enum that could accomplish what this is currently here for, it would help for scalability to
    // create a data model of a Role
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class EmployeeRole
    {
        [Key]
        public int Id { get; set; }
        
        public virtual Employee Employee { get; set; }
        public virtual Role Role { get; set; }
    }

    // In the future, a method to detect that db matches this Enum would be a good idea
    public enum RolesEnum
    {
        Director,
        Support,
        IT,
        Accounting,
        Analyst,
        Sales
    }
}