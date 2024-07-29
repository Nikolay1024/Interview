namespace PriceListEditor2.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProductCodeType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PriceListProducts", "Code", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PriceListProducts", "Code", c => c.String());
        }
    }
}
