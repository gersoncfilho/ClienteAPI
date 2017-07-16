namespace ClienteAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtablesASP : DbMigration
    {
        public override void Up()
        {
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
                "dbo.UserASP",
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
            
            DropTable("dbo.ClienteTheBank");
            DropTable("dbo.Destaques");
            DropTable("dbo.TransacaoTheBank");
            DropTable("dbo.UsuariosASP");
            DropTable("dbo.Carteirinha");
            DropTable("dbo.Videos");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        IdVideoDestaque = c.Int(nullable: false, identity: true),
                        TituloVideo = c.String(),
                        DescricaoVideo = c.String(),
                        Video = c.Byte(nullable: false),
                        EstaAtivo = c.Boolean(nullable: false),
                        VideoDataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdVideoDestaque);
            
            CreateTable(
                "dbo.Carteirinha",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeUsuario = c.String(nullable: false, maxLength: 255),
                        SenhaUsuario = c.String(nullable: false, maxLength: 12),
                        DataCadastro = c.DateTime(nullable: false),
                        EstaAtivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsuariosASP",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserPassword = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdUser);
            
            CreateTable(
                "dbo.TransacaoTheBank",
                c => new
                    {
                        IdTransacao = c.Int(nullable: false, identity: true),
                        TipoTransacao = c.String(),
                        ValorTransacao = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataTransacao = c.DateTime(nullable: false),
                        ContaCorrenteOrigem = c.String(),
                        ContaCorrenteDestino = c.String(),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTransacao);
            
            CreateTable(
                "dbo.Destaques",
                c => new
                    {
                        IdDestaque = c.Int(nullable: false, identity: true),
                        TituloDestaque = c.String(),
                        DescricaoDestaque = c.String(),
                        DestaqueImagem = c.Byte(nullable: false),
                        DestaqueDataCadastro = c.DateTime(nullable: false),
                        DestaqueAtivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdDestaque);
            
            CreateTable(
                "dbo.ClienteTheBank",
                c => new
                    {
                        IdCliente = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Senha = c.String(),
                        Perfil = c.String(),
                        NumeroConta = c.String(),
                        Cpf = c.String(),
                        NumeroAgencia = c.String(),
                        Saldo = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IdCliente);
            
            DropTable("dbo.VideosASP");
            DropTable("dbo.UserASP");
            DropTable("dbo.ProfileASP");
        }
    }
}
