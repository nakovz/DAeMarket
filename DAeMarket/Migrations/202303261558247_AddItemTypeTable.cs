namespace DAeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddItemTypeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO ItemTypes (Id, Name) VALUES (1, 'Virtual')");
            Sql("INSERT INTO ItemTypes (Id, Name) VALUES (2, 'Physical')");

        }

        public override void Down()
        {
            DropTable("dbo.ItemTypes");
        }
    }
}
