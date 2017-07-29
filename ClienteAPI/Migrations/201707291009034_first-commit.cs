namespace ClienteAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstcommit : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserASP", newName: "UsersASP");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.UsersASP", newName: "UserASP");
        }
    }
}
