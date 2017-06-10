namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        City = c.String(),
                        Street = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Rating = c.Double(nullable: false),
                        MinPrice = c.Double(nullable: false),
                        MaxPrice = c.Double(nullable: false),
                        PhoneNumber = c.String(),
                        RestaurantTypeId = c.Int(nullable: false),
                        FoodTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FoodTypes", t => t.FoodTypeId, cascadeDelete: true)
                .ForeignKey("dbo.RestaurantTypes", t => t.RestaurantTypeId, cascadeDelete: true)
                .Index(t => t.RestaurantTypeId)
                .Index(t => t.FoodTypeId);
            
            CreateTable(
                "dbo.FoodTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RestaurantTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Comment = c.String(),
                        UserId = c.Int(nullable: false),
                        RestaurantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RestaurantId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserReviews", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserReviews", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.Addresses", "Id", "dbo.Restaurants");
            DropForeignKey("dbo.Restaurants", "RestaurantTypeId", "dbo.RestaurantTypes");
            DropForeignKey("dbo.Restaurants", "FoodTypeId", "dbo.FoodTypes");
            DropIndex("dbo.UserReviews", new[] { "RestaurantId" });
            DropIndex("dbo.UserReviews", new[] { "UserId" });
            DropIndex("dbo.Restaurants", new[] { "FoodTypeId" });
            DropIndex("dbo.Restaurants", new[] { "RestaurantTypeId" });
            DropIndex("dbo.Addresses", new[] { "Id" });
            DropTable("dbo.Users");
            DropTable("dbo.UserReviews");
            DropTable("dbo.RestaurantTypes");
            DropTable("dbo.FoodTypes");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Addresses");
        }
    }
}
