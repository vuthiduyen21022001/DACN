namespace WebsiteDuLich.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableGioiThieu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GioiThieux",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NgayDang = c.DateTime(nullable: false),
                        NoiDung = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GioiThieux");
        }
    }
}
