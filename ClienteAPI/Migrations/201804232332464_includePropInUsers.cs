namespace ClienteAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class includePropInUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "BirthDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "BirthDate");
        }
    }
}
