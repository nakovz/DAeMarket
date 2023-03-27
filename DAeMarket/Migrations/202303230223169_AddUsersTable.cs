namespace DAeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        phone = c.String(),
                        DateOfBirth = c.DateTime(),
                        Credit = c.Int(),
                        Store_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stores", t => t.Store_Id)
                .Index(t => t.Store_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Store_Id", "dbo.Stores");
            DropIndex("dbo.Users", new[] { "Store_Id" });
            DropTable("dbo.Users");
        }
    }
}
