namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserAndFeedBack : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Content = c.String(nullable: false),
                        Stars = c.Int(nullable: false),
                        GasStationName = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.Users", t => t.UserName, cascadeDelete: true)
                .ForeignKey("dbo.GasStations", t => t.GasStationName, cascadeDelete: true)
                .Index(t => t.GasStationName)
                .Index(t => t.UserName);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "GasStationName", "dbo.GasStations");
            DropForeignKey("dbo.Feedbacks", "UserName", "dbo.Users");
            DropIndex("dbo.Feedbacks", new[] { "UserName" });
            DropIndex("dbo.Feedbacks", new[] { "GasStationName" });
            DropTable("dbo.Users");
            DropTable("dbo.Feedbacks");
        }
    }
}
