namespace TP1IdS_G15AccesoADatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sessions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PuntosDeVenta", "SesionId", "dbo.Sesiones");
            DropIndex("dbo.PuntosDeVenta", new[] { "SesionId" });
            AddColumn("dbo.Sesiones", "PuntoDeVentaId", c => c.Int(nullable: false));
            AddColumn("dbo.LineaDeVentas", "Cantidad", c => c.Int(nullable: false));
            CreateIndex("dbo.Sesiones", "PuntoDeVentaId");
            AddForeignKey("dbo.Sesiones", "PuntoDeVentaId", "dbo.PuntosDeVenta", "Id", cascadeDelete: true);
            DropColumn("dbo.PuntosDeVenta", "SesionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PuntosDeVenta", "SesionId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Sesiones", "PuntoDeVentaId", "dbo.PuntosDeVenta");
            DropIndex("dbo.Sesiones", new[] { "PuntoDeVentaId" });
            DropColumn("dbo.LineaDeVentas", "Cantidad");
            DropColumn("dbo.Sesiones", "PuntoDeVentaId");
            CreateIndex("dbo.PuntosDeVenta", "SesionId");
            AddForeignKey("dbo.PuntosDeVenta", "SesionId", "dbo.Sesiones", "Id", cascadeDelete: true);
        }
    }
}
