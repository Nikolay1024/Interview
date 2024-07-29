namespace PriceListEditor2.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldPriceList : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PriceLists", "CreatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PriceLists", "CreatedAt");
        }
    }
}
