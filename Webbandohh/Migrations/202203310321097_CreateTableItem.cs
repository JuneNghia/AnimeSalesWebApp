namespace Webbandohh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CateId = c.Int(nullable: false, identity: true),
                        CateName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.CateId);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        CateId = c.Int(),
                        CreatorId = c.Int(),
                        ProId = c.Int(),
                        Summary = c.String(),
                        ImgUrl = c.String(maxLength: 250),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        ModifierDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Category", t => t.CateId)
                .ForeignKey("dbo.Creator", t => t.CreatorId)
                .ForeignKey("dbo.Producer", t => t.ProId)
                .Index(t => t.CateId)
                .Index(t => t.CreatorId)
                .Index(t => t.ProId);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(),
                        Content = c.String(maxLength: 200),
                        CreateDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Item", t => t.ItemId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Creator",
                c => new
                    {
                        CreatorId = c.Int(nullable: false, identity: true),
                        CreatorName = c.String(maxLength: 50),
                        History = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.CreatorId);
            
            CreateTable(
                "dbo.Producer",
                c => new
                    {
                        ProId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ProId);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ItemId })
                .ForeignKey("dbo.Item", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        OrderDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String(maxLength: 256));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrderDetail", "OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderDetail", "ItemId", "dbo.Item");
            DropForeignKey("dbo.Item", "ProId", "dbo.Producer");
            DropForeignKey("dbo.Item", "CreatorId", "dbo.Creator");
            DropForeignKey("dbo.Comment", "ItemId", "dbo.Item");
            DropForeignKey("dbo.Item", "CateId", "dbo.Category");
            DropIndex("dbo.Order", new[] { "UserId" });
            DropIndex("dbo.OrderDetail", new[] { "ItemId" });
            DropIndex("dbo.OrderDetail", new[] { "OrderId" });
            DropIndex("dbo.Comment", new[] { "ItemId" });
            DropIndex("dbo.Item", new[] { "ProId" });
            DropIndex("dbo.Item", new[] { "CreatorId" });
            DropIndex("dbo.Item", new[] { "CateId" });
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "FullName");
            DropTable("dbo.Order");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.Producer");
            DropTable("dbo.Creator");
            DropTable("dbo.Comment");
            DropTable("dbo.Item");
            DropTable("dbo.Category");
        }
    }
}
