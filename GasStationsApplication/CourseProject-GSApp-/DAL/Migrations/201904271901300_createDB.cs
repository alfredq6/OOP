namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FuelTypes",
                c => new
                    {
                        FuelTypeName = c.String(nullable: false, maxLength: 128),
                        MapLink = c.String(),
                    })
                .PrimaryKey(t => t.FuelTypeName);
            
            CreateTable(
                "dbo.GasStations",
                c => new
                    {
                        StationNumber = c.String(nullable: false, maxLength: 128),
                        CompanyName = c.String(),
                        Adress = c.String(),
                        Lat = c.Double(nullable: false),
                        Lng = c.Double(nullable: false),
                        AI92_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AI95_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AI98_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DT_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GAS_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.StationNumber);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GasStations");
            DropTable("dbo.FuelTypes");
        }
    }
}
