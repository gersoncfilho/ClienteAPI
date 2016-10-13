namespace ClienteAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_field_payment_date : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Payments", "Date", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Payments", "Date", c => c.DateTime(nullable: false));
        }
    }
}
