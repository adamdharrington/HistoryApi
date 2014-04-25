namespace HistoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.APIEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EndDate = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        Category = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        ImageName = c.String(),
                        ImageUrl = c.String(),
                        Excerpt = c.String(),
                        Description = c.String(),
                        SourceUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.APIEvents");
        }
    }
}
