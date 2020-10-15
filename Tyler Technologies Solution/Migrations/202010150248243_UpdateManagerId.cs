namespace Tyler_Technologies_Solution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateManagerId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "ManagerId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "ManagerId", c => c.Int());
        }
    }
}
