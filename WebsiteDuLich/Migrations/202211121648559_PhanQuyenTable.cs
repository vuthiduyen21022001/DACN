namespace WebsiteDuLich.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhanQuyenTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhanQuyens",
                c => new
                    {
                        IDQuyen = c.Int(nullable: false, identity: true),
                        TenQuyen = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.IDQuyen);
            
            CreateIndex("dbo.Nguoidungs", "IDQuyen");
            AddForeignKey("dbo.Nguoidungs", "IDQuyen", "dbo.PhanQuyens", "IDQuyen");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Nguoidungs", "IDQuyen", "dbo.PhanQuyens");
            DropIndex("dbo.Nguoidungs", new[] { "IDQuyen" });
            DropTable("dbo.PhanQuyens");
        }
    }
}
