namespace WebsiteDuLich.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableNguoidungdangkydangnhap : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CTDonTours", new[] { "Tour_Id" });
            AlterColumn("dbo.CTDonTours", "Tour_Id", c => c.Int());
            CreateIndex("dbo.CTDonTours", "Tour_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CTDonTours", new[] { "Tour_Id" });
            AlterColumn("dbo.CTDonTours", "Tour_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.CTDonTours", "Tour_Id");
        }
    }
}
