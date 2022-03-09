namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Configuraciones",
                c => new
                    {
                        Relacion = c.String(nullable: false, maxLength: 20),
                        Valor = c.String(nullable: false, maxLength: 20),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                        Orden = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Relacion, t.Valor });
            
            CreateTable(
                "dbo.Experiencias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        Tipo = c.Byte(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Titulo = c.String(nullable: false, maxLength: 50),
                        Desde = c.String(nullable: false, maxLength: 10),
                        Hasta = c.String(nullable: false, maxLength: 10),
                        Descripcion = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 50),
                        Apellidos = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                        Direccion = c.String(nullable: false, maxLength: 100),
                        Ciudad = c.String(nullable: false, maxLength: 50),
                        Pais = c.String(nullable: false, maxLength: 50),
                        Telefono = c.String(maxLength: 50),
                        Linkedin = c.String(maxLength: 100),
                        Github = c.String(maxLength: 100),
                        Youtube = c.String(maxLength: 100),
                        Twitter = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Habilidades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Dominio = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Testimonios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        Ip = c.String(nullable: false, maxLength: 50),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Comentario = c.String(nullable: false, unicode: false, storeType: "text"),
                        Fecha = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Testimonios", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Habilidades", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Experiencias", "UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.Testimonios", new[] { "UsuarioId" });
            DropIndex("dbo.Habilidades", new[] { "UsuarioId" });
            DropIndex("dbo.Experiencias", new[] { "UsuarioId" });
            DropTable("dbo.Testimonios");
            DropTable("dbo.Habilidades");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Experiencias");
            DropTable("dbo.Configuraciones");
        }
    }
}
