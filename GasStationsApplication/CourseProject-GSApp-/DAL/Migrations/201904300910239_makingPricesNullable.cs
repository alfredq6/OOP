namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makingPricesNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GasStations", "AI92_Price", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.GasStations", "AI95_Price", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.GasStations", "AI98_Price", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.GasStations", "DT_Price", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.GasStations", "GAS_Price", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GasStations", "GAS_Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.GasStations", "DT_Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.GasStations", "AI98_Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.GasStations", "AI95_Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.GasStations", "AI92_Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
