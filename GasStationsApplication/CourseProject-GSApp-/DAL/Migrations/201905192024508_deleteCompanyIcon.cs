namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteCompanyIcon : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Company", "Icon");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Company", "Icon", c => c.Binary());
        }
    }
}
