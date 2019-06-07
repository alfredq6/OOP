namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCompaniesIcons : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Company", "Icon", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Company", "Icon");
        }
    }
}
