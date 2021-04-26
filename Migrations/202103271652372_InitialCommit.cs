namespace GameShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCommit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 100),
                        CategoryDescription = c.String(nullable: false),
                        IconFileName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        GameTitle = c.String(nullable: false, maxLength: 100),
                        Publisher = c.String(nullable: false, maxLength: 100),
                        DateAdded = c.DateTime(nullable: false),
                        AgeClassification = c.Int(nullable: false),
                        Premiere = c.DateTime(nullable: false),
                        ImageFileName = c.String(maxLength: 100),
                        GameDescryption = c.String(),
                        Type = c.String(),
                        GamePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bestseller = c.Boolean(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                        DigitalVersion = c.Boolean(nullable: false),
                        Rating = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.GameId)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.HardwareRequirements",
                c => new
                    {
                        HardwareRequirementsId = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        System = c.String(),
                        Processor = c.String(),
                        Memory = c.String(),
                        GraphicsCard = c.String(),
                        DirectX = c.String(),
                        HardDrive = c.String(),
                    })
                .PrimaryKey(t => t.HardwareRequirementsId);
            
            CreateTable(
                "dbo.OrderItem",
                c => new
                    {
                        OrderItemId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderItemId)
                .ForeignKey("dbo.Game", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        Street = c.String(nullable: false, maxLength: 100),
                        City = c.String(nullable: false, maxLength: 100),
                        PostCode = c.String(nullable: false, maxLength: 6),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Comment = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        OrderStatus = c.Int(nullable: false),
                        OrderValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItem", "OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderItem", "GameId", "dbo.Game");
            DropForeignKey("dbo.Game", "CategoryId", "dbo.Category");
            DropIndex("dbo.OrderItem", new[] { "GameId" });
            DropIndex("dbo.OrderItem", new[] { "OrderId" });
            DropIndex("dbo.Game", new[] { "CategoryId" });
            DropTable("dbo.Order");
            DropTable("dbo.OrderItem");
            DropTable("dbo.HardwareRequirements");
            DropTable("dbo.Game");
            DropTable("dbo.Category");
        }
    }
}
