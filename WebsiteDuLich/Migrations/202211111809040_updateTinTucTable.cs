namespace WebsiteDuLich.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTinTucTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TinTucs", "MoTa", c => c.String());
            AlterColumn("dbo.TinTucs", "TgDang", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TinTucs", "TgDang", c => c.DateTime());
            DropColumn("dbo.TinTucs", "MoTa");
        }
    }
}
