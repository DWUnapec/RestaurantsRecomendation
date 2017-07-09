namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class identityoff2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserReviews", "UserId", "dbo.Users");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Users", "Id");
            AddForeignKey("dbo.UserReviews", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserReviews", "UserId", "dbo.Users");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "Id");
            AddForeignKey("dbo.UserReviews", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
