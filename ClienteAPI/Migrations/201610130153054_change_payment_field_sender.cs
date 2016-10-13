namespace ClienteAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_payment_field_sender : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payments", "Sender_Id", "dbo.Senders");
            DropIndex("dbo.Payments", new[] { "Sender_Id" });
            AddColumn("dbo.Payments", "Sender", c => c.String(nullable: false));
            DropColumn("dbo.Payments", "Sender_Id");
            DropTable("dbo.Senders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Senders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 320),
                        Email = c.String(nullable: false, maxLength: 320),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Payments", "Sender_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Payments", "Sender");
            CreateIndex("dbo.Payments", "Sender_Id");
            AddForeignKey("dbo.Payments", "Sender_Id", "dbo.Senders", "Id", cascadeDelete: true);
        }
    }
}
