namespace WebsiteDuLich.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableGioiThieuupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GioiThieux", "NoiDunggt", c => c.String());
            DropColumn("dbo.GioiThieux", "NoiDung");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GioiThieux", "NoiDung", c => c.String());
            DropColumn("dbo.GioiThieux", "NoiDunggt");
        }
    }
}
