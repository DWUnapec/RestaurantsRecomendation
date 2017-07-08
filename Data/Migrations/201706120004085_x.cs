namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class x : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 9));
            AlterColumn("dbo.Addresses", "Longitude", c => c.Decimal(nullable: false, precision: 18, scale: 9));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "Longitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Addresses", "Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
