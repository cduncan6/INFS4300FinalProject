namespace Team2FP4300.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeesDepartments",
                c => new
                    {
                        Employees_EmployeeId = c.Int(nullable: false),
                        Department_DepartmentCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employees_EmployeeId, t.Department_DepartmentCode })
                .ForeignKey("dbo.Employees", t => t.Employees_EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentCode, cascadeDelete: true)
                .Index(t => t.Employees_EmployeeId)
                .Index(t => t.Department_DepartmentCode);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeesDepartments", "Department_DepartmentCode", "dbo.Departments");
            DropForeignKey("dbo.EmployeesDepartments", "Employees_EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmployeesDepartments", new[] { "Department_DepartmentCode" });
            DropIndex("dbo.EmployeesDepartments", new[] { "Employees_EmployeeId" });
            DropTable("dbo.EmployeesDepartments");
        }
    }
}
