namespace PriceListEditor2.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PriceListCells",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        PriceListProductId = c.Int(nullable: false),
                        PriceListColumnId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PriceListProducts", t => t.PriceListProductId, cascadeDelete: true)
                .ForeignKey("dbo.PriceListColumns", t => t.PriceListColumnId, cascadeDelete: true)
                .Index(t => t.PriceListProductId)
                .Index(t => t.PriceListColumnId);
            
            CreateTable(
                "dbo.PriceListColumns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        PriceListId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PriceLists", t => t.PriceListId, cascadeDelete: true)
                .Index(t => t.PriceListId);
            
            CreateTable(
                "dbo.PriceLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PriceListProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.Int(nullable: false),
                        PriceListId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PriceLists", t => t.PriceListId)
                .Index(t => t.PriceListId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PriceListCells", "PriceListColumnId", "dbo.PriceListColumns");
            DropForeignKey("dbo.PriceListProducts", "PriceListId", "dbo.PriceLists");
            DropForeignKey("dbo.PriceListCells", "PriceListProductId", "dbo.PriceListProducts");
            DropForeignKey("dbo.PriceListColumns", "PriceListId", "dbo.PriceLists");
            DropIndex("dbo.PriceListProducts", new[] { "PriceListId" });
            DropIndex("dbo.PriceListColumns", new[] { "PriceListId" });
            DropIndex("dbo.PriceListCells", new[] { "PriceListColumnId" });
            DropIndex("dbo.PriceListCells", new[] { "PriceListProductId" });
            DropTable("dbo.PriceListProducts");
            DropTable("dbo.PriceLists");
            DropTable("dbo.PriceListColumns");
            DropTable("dbo.PriceListCells");
        }
    }
}
