namespace ClienteAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                        Estado = c.String(nullable: false, maxLength: 100),
                        Cep = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 100),
                        sexo = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.IdCliente);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clientes");
        }
    }
}
