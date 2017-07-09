namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class identityoff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "Id", "dbo.Restaurants");
            DropForeignKey("dbo.UserReviews", "RestaurantId", "dbo.Restaurants");
            DropPrimaryKey("dbo.Restaurants");
            AlterColumn("dbo.Restaurants", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Restaurants", "Id");
            AddForeignKey("dbo.Addresses", "Id", "dbo.Restaurants", "Id");
            AddForeignKey("dbo.UserReviews", "RestaurantId", "dbo.Restaurants", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserReviews", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.Addresses", "Id", "dbo.Restaurants");
            DropPrimaryKey("dbo.Restaurants");
            AlterColumn("dbo.Restaurants", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Restaurants", "Id");
            AddForeignKey("dbo.UserReviews", "RestaurantId", "dbo.Restaurants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Addresses", "Id", "dbo.Restaurants", "Id");
        }
    }
}
