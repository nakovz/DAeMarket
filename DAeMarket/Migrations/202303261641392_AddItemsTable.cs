namespace DAeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddItemsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Price = c.Single(nullable: false),
                        SalePrice = c.Single(nullable: false),
                        Rating = c.Single(nullable: false),
                        ImageUrl = c.String(),
                        Quantity = c.Int(nullable: false),
                        ItemTypeId = c.Byte(nullable: false),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemTypes", t => t.ItemTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.ItemTypeId)
                .Index(t => t.StoreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Items", "ItemTypeId", "dbo.ItemTypes");
            DropIndex("dbo.Items", new[] { "StoreId" });
            DropIndex("dbo.Items", new[] { "ItemTypeId" });
            DropTable("dbo.Items");
        }
    }
}
