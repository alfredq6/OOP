namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBaseModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GasStations", "CompanyName", "dbo.Company");
            DropIndex("dbo.GasStations", new[] { "CompanyName" });
            DropPrimaryKey("dbo.FuelTypes");
            DropPrimaryKey("dbo.GasStations");
            AddColumn("dbo.FuelTypes", "Name", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.GasStations", "Name", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.GasStations", "CompanyName", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.FuelTypes", "Name");
            AddPrimaryKey("dbo.GasStations", "Name");
            CreateIndex("dbo.GasStations", "CompanyName");
            AddForeignKey("dbo.GasStations", "CompanyName", "dbo.Company", "Name", cascadeDelete: true);
            DropColumn("dbo.FuelTypes", "FuelTypeName");
            DropColumn("dbo.GasStations", "StationNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GasStations", "StationNumber", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.FuelTypes", "FuelTypeName", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.GasStations", "CompanyName", "dbo.Company");
            DropIndex("dbo.GasStations", new[] { "CompanyName" });
            DropPrimaryKey("dbo.GasStations");
            DropPrimaryKey("dbo.FuelTypes");
            AlterColumn("dbo.GasStations", "CompanyName", c => c.String(maxLength: 128));
            DropColumn("dbo.GasStations", "Name");
            DropColumn("dbo.FuelTypes", "Name");
            AddPrimaryKey("dbo.GasStations", "StationNumber");
            AddPrimaryKey("dbo.FuelTypes", "FuelTypeName");
            CreateIndex("dbo.GasStations", "CompanyName");
            AddForeignKey("dbo.GasStations", "CompanyName", "dbo.Company", "Name");
        }
    }
}
