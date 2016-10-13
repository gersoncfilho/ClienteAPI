namespace ClienteAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_models : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Reference = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Sender_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Senders", t => t.Sender_Id, cascadeDelete: true)
                .Index(t => t.Sender_Id);
            
            CreateTable(
                "dbo.Senders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 320),
                        Email = c.String(nullable: false, maxLength: 320),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "Sender_Id", "dbo.Senders");
            DropIndex("dbo.Payments", new[] { "Sender_Id" });
            DropTable("dbo.Senders");
            DropTable("dbo.Payments");
        }
    }
}
