namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFeedBacksNumberAndAvgStarsToGS : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GasStations", "AverageStars", c => c.Int(nullable: false));
            AddColumn("dbo.GasStations", "FeedbacksNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GasStations", "FeedbacksNumber");
            DropColumn("dbo.GasStations", "AverageStars");
        }
    }
}
