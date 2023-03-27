namespace DAeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetDataAnnotationsInUsersTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Store_Id", "dbo.Stores");
            DropIndex("dbo.Users", new[] { "Store_Id" });
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "Phone", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "Store_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "Store_Id");
            AddForeignKey("dbo.Users", "Store_Id", "dbo.Stores", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Store_Id", "dbo.Stores");
            DropIndex("dbo.Users", new[] { "Store_Id" });
            AlterColumn("dbo.Users", "Store_Id", c => c.Int());
            AlterColumn("dbo.Users", "Phone", c => c.String());
            AlterColumn("dbo.Users", "LastName", c => c.String());
            AlterColumn("dbo.Users", "FirstName", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            CreateIndex("dbo.Users", "Store_Id");
            AddForeignKey("dbo.Users", "Store_Id", "dbo.Stores", "Id");
        }
    }
}
