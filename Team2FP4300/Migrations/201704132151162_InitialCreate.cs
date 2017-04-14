namespace Team2FP4300.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentCode = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false),
                        DepartmentHead = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentCode);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        DeptCode = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Title = c.String(),
                        HireDate = c.DateTime(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImgFileName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
