namespace Tyler_Technologies_Solution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TurnOffAutoIncrementEmpId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeRoles", "Employee_Id", "dbo.Employees");
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.Employees", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Employees", "Id");
            AddForeignKey("dbo.EmployeeRoles", "Employee_Id", "dbo.Employees", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeRoles", "Employee_Id", "dbo.Employees");
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.Employees", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Employees", "Id");
            AddForeignKey("dbo.EmployeeRoles", "Employee_Id", "dbo.Employees", "Id");
        }
    }
}
