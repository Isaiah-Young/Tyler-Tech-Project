namespace Tyler_Technologies_Solution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeAndRoleAndEmployeeRole : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Employee_Id = c.Int(),
                        Role_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Roles", t => t.Role_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ManagerId = c.Int(),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeRoles", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.EmployeeRoles", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.EmployeeRoles", new[] { "Role_Id" });
            DropIndex("dbo.EmployeeRoles", new[] { "Employee_Id" });
            DropTable("dbo.Roles");
            DropTable("dbo.Employees");
            DropTable("dbo.EmployeeRoles");
        }
    }
}
