namespace AppG2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ksaklla : DbMigration
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
                        UserName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserName)
                .Index(t => t.UserName);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        PassWord = c.String(),
                    })
                .PrimaryKey(t => t.UserName);
            
            CreateTable(
                "dbo.HistoryLearnings",
                c => new
                    {
                        IDHistoryLearning = c.String(nullable: false, maxLength: 128),
                        YearFrom = c.Int(nullable: false),
                        YearEnd = c.Int(nullable: false),
                        Address = c.String(),
                        IDStudent = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IDHistoryLearning)
                .ForeignKey("dbo.Students", t => t.IDStudent)
                .Index(t => t.IDStudent);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        IDStudent = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        POB = c.String(),
                    })
                .PrimaryKey(t => t.IDStudent);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HistoryLearnings", "IDStudent", "dbo.Students");
            DropForeignKey("dbo.Contacts", "UserName", "dbo.Users");
            DropIndex("dbo.HistoryLearnings", new[] { "IDStudent" });
            DropIndex("dbo.Contacts", new[] { "UserName" });
            DropTable("dbo.Students");
            DropTable("dbo.HistoryLearnings");
            DropTable("dbo.Users");
            DropTable("dbo.Contacts");
        }
    }
}
