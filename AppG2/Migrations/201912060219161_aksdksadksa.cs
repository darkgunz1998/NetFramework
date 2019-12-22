namespace AppG2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aksdksadksa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Diems", "DiemMonHoc", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Diems", "DiemMonHoc", c => c.Single(nullable: false));
        }
    }
}
