namespace ClienteAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "Email", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "Email", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
