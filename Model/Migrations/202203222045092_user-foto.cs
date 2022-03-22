namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userfoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Foto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Foto");
        }
    }
}
