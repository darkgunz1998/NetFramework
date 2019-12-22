namespace AppG2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kaskdsak : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diems",
                c => new
                    {
                        IDMonHoc = c.String(nullable: false, maxLength: 128),
                        IDStudent = c.String(nullable: false, maxLength: 128),
                        DiemMonHoc = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.IDMonHoc, t.IDStudent })
                .ForeignKey("dbo.Students", t => t.IDStudent, cascadeDelete: true)
                .ForeignKey("dbo.MonHocs", t => t.IDMonHoc, cascadeDelete: true)
                .Index(t => t.IDMonHoc)
                .Index(t => t.IDStudent);
            
            CreateTable(
                "dbo.MonHocs",
                c => new
                    {
                        IDMonHoc = c.String(nullable: false, maxLength: 128),
                        TenMonHoc = c.String(),
                        IDKhoa = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IDMonHoc)
                .ForeignKey("dbo.Khoas", t => t.IDKhoa)
                .Index(t => t.IDKhoa);
            
            CreateTable(
                "dbo.Khoas",
                c => new
                    {
                        IDKhoa = c.String(nullable: false, maxLength: 128),
                        TenKhoa = c.String(),
                    })
                .PrimaryKey(t => t.IDKhoa);
            
            AddColumn("dbo.Students", "IDKhoa", c => c.String(maxLength: 128));
            CreateIndex("dbo.Students", "IDKhoa");
            AddForeignKey("dbo.Students", "IDKhoa", "dbo.Khoas", "IDKhoa");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Diems", "IDMonHoc", "dbo.MonHocs");
            DropForeignKey("dbo.Diems", "IDStudent", "dbo.Students");
            DropForeignKey("dbo.Students", "IDKhoa", "dbo.Khoas");
            DropForeignKey("dbo.MonHocs", "IDKhoa", "dbo.Khoas");
            DropIndex("dbo.Students", new[] { "IDKhoa" });
            DropIndex("dbo.MonHocs", new[] { "IDKhoa" });
            DropIndex("dbo.Diems", new[] { "IDStudent" });
            DropIndex("dbo.Diems", new[] { "IDMonHoc" });
            DropColumn("dbo.Students", "IDKhoa");
            DropTable("dbo.Khoas");
            DropTable("dbo.MonHocs");
            DropTable("dbo.Diems");
        }
    }
}
