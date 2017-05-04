namespace EventSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeImgAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventModels", "Time", c => c.DateTime(nullable: false));
            AddColumn("dbo.EventModels", "ImgUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EventModels", "ImgUrl");
            DropColumn("dbo.EventModels", "Time");
        }
    }
}
