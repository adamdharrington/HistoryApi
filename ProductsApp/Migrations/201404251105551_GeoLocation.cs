namespace HistoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    
    public partial class GeoLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.APIEvents", "Geolocation", c => c.Geography());
        }
        
        public override void Down()
        {
            DropColumn("dbo.APIEvents", "Geolocation");
        }
    }
}
