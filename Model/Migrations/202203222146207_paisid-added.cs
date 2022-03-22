namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paisidadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "PaisId", c => c.Int(nullable: false));
            DropColumn("dbo.Usuarios", "Pais");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "Pais", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Usuarios", "PaisId");
        }
    }
}
