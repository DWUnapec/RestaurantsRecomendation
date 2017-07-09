namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_food_service_rating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserReviews", "FoodRating", c => c.Double(nullable: false));
            AddColumn("dbo.UserReviews", "ServiceRating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserReviews", "ServiceRating");
            DropColumn("dbo.UserReviews", "FoodRating");
        }
    }
}
