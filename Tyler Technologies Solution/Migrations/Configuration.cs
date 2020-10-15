
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Tyler_Technologies_Solution.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Tyler_Technologies_Solution.EmployeeDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    } 
}