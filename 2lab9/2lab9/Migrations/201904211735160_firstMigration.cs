namespace _2lab9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 128),
                        Age = c.Int(nullable: false),
                        Wage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Post = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Name)
                .Index(t => t.Name);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Adress = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Name", "dbo.Companies");
            DropIndex("dbo.Employees", new[] { "Name" });
            DropTable("dbo.Companies");
            DropTable("dbo.Employees");
        }
    }
}
