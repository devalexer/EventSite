namespace EventSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restarted : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeCreated = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                        MyProperty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TicketModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BarCode = c.Guid(nullable: false),
                        DatePurchased = c.DateTime(nullable: false),
                        PurchasedPrice = c.Double(nullable: false),
                        WasUsed = c.Boolean(nullable: false),
                        EventId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventModels", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.OrderModels", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderModels", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TicketModels", "OrderId", "dbo.OrderModels");
            DropForeignKey("dbo.TicketModels", "EventId", "dbo.EventModels");
            DropIndex("dbo.TicketModels", new[] { "OrderId" });
            DropIndex("dbo.TicketModels", new[] { "EventId" });
            DropIndex("dbo.OrderModels", new[] { "UserId" });
            DropTable("dbo.TicketModels");
            DropTable("dbo.OrderModels");
        }
    }
}
