namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCompanies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        WebSiteLink = c.String(),
                    })
                .PrimaryKey(t => t.Name);
            
            AlterColumn("dbo.GasStations", "CompanyName", c => c.String(maxLength: 128));
            CreateIndex("dbo.GasStations", "CompanyName");
            AddForeignKey("dbo.GasStations", "CompanyName", "dbo.Company", "Name");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GasStations", "CompanyName", "dbo.Company");
            DropIndex("dbo.GasStations", new[] { "CompanyName" });
            AlterColumn("dbo.GasStations", "CompanyName", c => c.String());
            DropTable("dbo.Company");
        }
    }
}
