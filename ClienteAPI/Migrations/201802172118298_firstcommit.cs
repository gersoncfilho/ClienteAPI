namespace ClienteAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstcommit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        IdCliente = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 300),
                        Endereco = c.String(nullable: false, maxLength: 300),
                        Bairro = c.String(nullable: false, maxLength: 100),
                        Municipio = c.String(nullable: false, maxLength: 255),
                        Estado = c.String(nullable: false, maxLength: 100),
                        Cep = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false, maxLength: 255),
                        sexo = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.IdCliente);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sender = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Reference = c.String(nullable: false),
                        Date = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProfileASP",
                c => new
                    {
                        IdProfile = c.Int(nullable: false, identity: true),
                        ProfileName = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdProfile);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 300),
                        FirstName = c.String(nullable: false, maxLength: 300),
                        LastName = c.String(nullable: false, maxLength: 300),
                        Email = c.String(nullable: false, maxLength: 300),
                        Password = c.String(nullable: false, maxLength: 300),
                        Phone = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsersASP",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        ProfileId = c.Int(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdUser);
            
            CreateTable(
                "dbo.VideosASP",
                c => new
                    {
                        IdVideo = c.Int(nullable: false, identity: true),
                        VideoTitle = c.String(nullable: false, maxLength: 50),
                        VideoDescription = c.String(nullable: false, maxLength: 100),
                        IsActive = c.Boolean(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdVideo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VideosASP");
            DropTable("dbo.UsersASP");
            DropTable("dbo.Users");
            DropTable("dbo.ProfileASP");
            DropTable("dbo.Payments");
            DropTable("dbo.Clientes");
        }
    }
}
