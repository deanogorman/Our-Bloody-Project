namespace MupadoodleAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class markets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        longitude = c.Double(nullable: false),
                        latitude = c.Double(nullable: false),
                        lname = c.String(maxLength: 4000),
                        MuseumID = c.Int(),
                        cityStr = c.String(maxLength: 4000),
                        shape = c.String(maxLength: 4000),
                        tel = c.String(maxLength: 4000),
                        url = c.String(maxLength: 4000),
                        adress1 = c.String(maxLength: 4000),
                        address2 = c.String(maxLength: 4000),
                        zip = c.String(maxLength: 4000),
                        MarketID = c.Int(),
                        cityStr1 = c.String(maxLength: 4000),
                        shape1 = c.String(maxLength: 4000),
                        name = c.String(maxLength: 4000),
                        location = c.String(maxLength: 4000),
                        ParkID = c.Int(),
                        cityStr2 = c.String(maxLength: 4000),
                        shape2 = c.String(maxLength: 4000),
                        acres = c.Double(),
                        place = c.String(maxLength: 4000),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        City_LocationID = c.Int(),
                        City_LocationID1 = c.Int(),
                        City_LocationID2 = c.Int(),
                        City_LocationID3 = c.Int(),
                        City_LocationID4 = c.Int(),
                        City_LocationID5 = c.Int(),
                        City_LocationID6 = c.Int(),
                    })
                .PrimaryKey(t => t.LocationID)
                .ForeignKey("dbo.Locations", t => t.City_LocationID)
                .ForeignKey("dbo.Locations", t => t.City_LocationID1)
                .ForeignKey("dbo.Locations", t => t.City_LocationID2)
                .ForeignKey("dbo.Locations", t => t.City_LocationID3)
                .ForeignKey("dbo.Locations", t => t.City_LocationID4)
                .ForeignKey("dbo.Locations", t => t.City_LocationID5)
                .ForeignKey("dbo.Locations", t => t.City_LocationID6)
                .Index(t => t.City_LocationID)
                .Index(t => t.City_LocationID1)
                .Index(t => t.City_LocationID2)
                .Index(t => t.City_LocationID3)
                .Index(t => t.City_LocationID4)
                .Index(t => t.City_LocationID5)
                .Index(t => t.City_LocationID6);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Locations", new[] { "City_LocationID6" });
            DropIndex("dbo.Locations", new[] { "City_LocationID5" });
            DropIndex("dbo.Locations", new[] { "City_LocationID4" });
            DropIndex("dbo.Locations", new[] { "City_LocationID3" });
            DropIndex("dbo.Locations", new[] { "City_LocationID2" });
            DropIndex("dbo.Locations", new[] { "City_LocationID1" });
            DropIndex("dbo.Locations", new[] { "City_LocationID" });
            DropForeignKey("dbo.Locations", "City_LocationID6", "dbo.Locations");
            DropForeignKey("dbo.Locations", "City_LocationID5", "dbo.Locations");
            DropForeignKey("dbo.Locations", "City_LocationID4", "dbo.Locations");
            DropForeignKey("dbo.Locations", "City_LocationID3", "dbo.Locations");
            DropForeignKey("dbo.Locations", "City_LocationID2", "dbo.Locations");
            DropForeignKey("dbo.Locations", "City_LocationID1", "dbo.Locations");
            DropForeignKey("dbo.Locations", "City_LocationID", "dbo.Locations");
            DropTable("dbo.Locations");
        }
    }
}
