namespace _2lab9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Name", "dbo.Companies");
            DropIndex("dbo.Employees", new[] { "Name" });
            AddColumn("dbo.Employees", "CompanyName", c => c.String(maxLength: 128));
            AlterColumn("dbo.Employees", "Name", c => c.String());
            CreateIndex("dbo.Employees", "CompanyName");
            AddForeignKey("dbo.Employees", "CompanyName", "dbo.Companies", "Name");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "CompanyName", "dbo.Companies");
            DropIndex("dbo.Employees", new[] { "CompanyName" });
            AlterColumn("dbo.Employees", "Name", c => c.String(maxLength: 128));
            DropColumn("dbo.Employees", "CompanyName");
            CreateIndex("dbo.Employees", "Name");
            AddForeignKey("dbo.Employees", "Name", "dbo.Companies", "Name");
        }
    }
}
