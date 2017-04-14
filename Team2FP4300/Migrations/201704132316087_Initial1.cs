namespace Team2FP4300.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "DepartmentCode", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "DeptCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "DeptCode", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "DepartmentCode");
        }
    }
}
