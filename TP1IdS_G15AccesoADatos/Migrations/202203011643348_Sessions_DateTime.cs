namespace TP1IdS_G15AccesoADatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sessions_DateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sesiones", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sesiones", "DateTime");
        }
    }
}
