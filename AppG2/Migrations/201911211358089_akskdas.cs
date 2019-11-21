namespace AppG2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class akskdas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        NameContact = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contacts");
        }
    }
}
