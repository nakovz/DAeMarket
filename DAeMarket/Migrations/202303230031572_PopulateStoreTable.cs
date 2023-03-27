namespace DAeMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateStoreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Stores (Name, Slogan, SuperUser, SuperPassword) VALUES ('Different Academy eMarket', 'Buy. Think. Grow.', 'admin', 'admin')");
            Sql("INSERT INTO Stores (Name, Slogan, SuperUser, SuperPassword) VALUES ('Another eMarket', 'Experts with vision.', 'admin', 'admin')");
        }
        
        public override void Down()
        {
        }
    }
}
