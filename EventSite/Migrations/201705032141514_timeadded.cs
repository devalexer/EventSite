namespace EventSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class timeadded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EventModels", "Time", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EventModels", "Time", c => c.DateTime(nullable: false));
        }
    }
}
