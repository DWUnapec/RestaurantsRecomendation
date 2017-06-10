namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_location_datatype_in_address : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Addresses", "Longitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "Longitude", c => c.Double(nullable: false));
            AlterColumn("dbo.Addresses", "Latitude", c => c.Double(nullable: false));
        }
    }
}
