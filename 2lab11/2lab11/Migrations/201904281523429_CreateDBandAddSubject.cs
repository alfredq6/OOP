namespace _2lab11.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDBandAddSubject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        HoursNumber = c.Int(nullable: false),
                        LectorName = c.String(),
                        StudentsNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Subjects");
        }
    }
}
