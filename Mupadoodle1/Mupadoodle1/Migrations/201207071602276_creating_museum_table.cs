namespace Mupadoodle1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creating_museum_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Museums",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Museums");
        }
    }
}
