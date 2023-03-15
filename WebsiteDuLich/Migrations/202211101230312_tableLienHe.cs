namespace WebsiteDuLich.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableLienHe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LienHes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HoTenLH = c.String(),
                        EmailLH = c.String(),
                        ChuDeLH = c.String(),
                        NoiDungLH = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LienHes");
        }
    }
}
