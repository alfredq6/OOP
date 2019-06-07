using System;
using System.Data.Entity.Migrations;

namespace DAL.Migrations
{
    
    public partial class editcompnay : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Company", newName: "Company");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Company", newName: "Company");
        }
    }
}
