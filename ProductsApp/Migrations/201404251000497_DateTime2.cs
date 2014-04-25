namespace HistoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.APIEvents", "EndDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.APIEvents", "StartDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.APIEvents", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.APIEvents", "EndDate", c => c.DateTime(nullable: false));
        }
    }
}
