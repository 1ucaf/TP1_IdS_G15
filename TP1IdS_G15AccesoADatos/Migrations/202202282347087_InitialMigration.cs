namespace TP1IdS_G15AccesoADatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Cuit = c.String(nullable: false, maxLength: 128),
                        RazonSocial = c.String(),
                        Domicilio = c.String(),
                        Condicion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Cuit);
            
            CreateTable(
                "dbo.Colores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        Legajo = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        UserId = c.Int(nullable: false),
                        SucursalId = c.Int(nullable: false),
                        User_UserName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Legajo)
                .ForeignKey("dbo.Sucursales", t => t.SucursalId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserName)
                .Index(t => t.SucursalId)
                .Index(t => t.User_UserName);
            
            CreateTable(
                "dbo.Sucursales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Ubicacion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PuntosDeVenta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumeroPDV = c.Long(nullable: false),
                        SesionId = c.Int(nullable: false),
                        SucursalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sesiones", t => t.SesionId, cascadeDelete: true)
                .ForeignKey("dbo.Sucursales", t => t.SucursalId, cascadeDelete: true)
                .Index(t => t.SesionId)
                .Index(t => t.SucursalId);
            
            CreateTable(
                "dbo.Sesiones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsActive = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                        User_UserName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_UserName)
                .Index(t => t.User_UserName);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        TipoUsuario = c.Int(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserName);
            
            CreateTable(
                "dbo.ProductosEnStock",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        SucursalId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        ColorId = c.Int(nullable: false),
                        TalleId = c.Int(nullable: false),
                        Producto_CodigoDeBarra = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colores", t => t.ColorId, cascadeDelete: true)
                .ForeignKey("dbo.Productos", t => t.Producto_CodigoDeBarra)
                .ForeignKey("dbo.Sucursales", t => t.SucursalId, cascadeDelete: true)
                .ForeignKey("dbo.Talles", t => t.TalleId, cascadeDelete: true)
                .Index(t => t.SucursalId)
                .Index(t => t.ColorId)
                .Index(t => t.TalleId)
                .Index(t => t.Producto_CodigoDeBarra);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        CodigoDeBarra = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Costo = c.Double(nullable: false),
                        MargenDeGanancia = c.Double(nullable: false),
                        PorcentajeIVA = c.Double(nullable: false),
                        MarcaId = c.Int(nullable: false),
                        RubroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CodigoDeBarra)
                .ForeignKey("dbo.Marcas", t => t.MarcaId, cascadeDelete: true)
                .ForeignKey("dbo.Rubros", t => t.RubroId, cascadeDelete: true)
                .Index(t => t.MarcaId)
                .Index(t => t.RubroId);
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rubros",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Talles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fecha = c.DateTime(nullable: false),
                        NroFacturaAfip = c.Long(nullable: false),
                        PuntoDeVentaId = c.Int(nullable: false),
                        MedioDePago = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        EmpleadoId = c.Int(nullable: false),
                        TipoFacturaId = c.Int(nullable: false),
                        Cliente_Cuit = c.String(maxLength: 128),
                        Vendedor_Legajo = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Cuit)
                .ForeignKey("dbo.PuntosDeVenta", t => t.PuntoDeVentaId, cascadeDelete: true)
                .ForeignKey("dbo.TiposDeFactura", t => t.TipoFacturaId, cascadeDelete: true)
                .ForeignKey("dbo.Empleados", t => t.Vendedor_Legajo)
                .Index(t => t.PuntoDeVentaId)
                .Index(t => t.TipoFacturaId)
                .Index(t => t.Cliente_Cuit)
                .Index(t => t.Vendedor_Legajo);
            
            CreateTable(
                "dbo.LineaDeVentas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Monto = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Producto_CodigoDeBarra = c.Int(),
                        Venta_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Productos", t => t.Producto_CodigoDeBarra)
                .ForeignKey("dbo.Ventas", t => t.Venta_Id)
                .Index(t => t.Producto_CodigoDeBarra)
                .Index(t => t.Venta_Id);
            
            CreateTable(
                "dbo.TiposDeFactura",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ventas", "Vendedor_Legajo", "dbo.Empleados");
            DropForeignKey("dbo.Ventas", "TipoFacturaId", "dbo.TiposDeFactura");
            DropForeignKey("dbo.Ventas", "PuntoDeVentaId", "dbo.PuntosDeVenta");
            DropForeignKey("dbo.LineaDeVentas", "Venta_Id", "dbo.Ventas");
            DropForeignKey("dbo.LineaDeVentas", "Producto_CodigoDeBarra", "dbo.Productos");
            DropForeignKey("dbo.Ventas", "Cliente_Cuit", "dbo.Clientes");
            DropForeignKey("dbo.Empleados", "User_UserName", "dbo.Users");
            DropForeignKey("dbo.ProductosEnStock", "TalleId", "dbo.Talles");
            DropForeignKey("dbo.ProductosEnStock", "SucursalId", "dbo.Sucursales");
            DropForeignKey("dbo.ProductosEnStock", "Producto_CodigoDeBarra", "dbo.Productos");
            DropForeignKey("dbo.Productos", "RubroId", "dbo.Rubros");
            DropForeignKey("dbo.Productos", "MarcaId", "dbo.Marcas");
            DropForeignKey("dbo.ProductosEnStock", "ColorId", "dbo.Colores");
            DropForeignKey("dbo.PuntosDeVenta", "SucursalId", "dbo.Sucursales");
            DropForeignKey("dbo.PuntosDeVenta", "SesionId", "dbo.Sesiones");
            DropForeignKey("dbo.Sesiones", "User_UserName", "dbo.Users");
            DropForeignKey("dbo.Empleados", "SucursalId", "dbo.Sucursales");
            DropIndex("dbo.LineaDeVentas", new[] { "Venta_Id" });
            DropIndex("dbo.LineaDeVentas", new[] { "Producto_CodigoDeBarra" });
            DropIndex("dbo.Ventas", new[] { "Vendedor_Legajo" });
            DropIndex("dbo.Ventas", new[] { "Cliente_Cuit" });
            DropIndex("dbo.Ventas", new[] { "TipoFacturaId" });
            DropIndex("dbo.Ventas", new[] { "PuntoDeVentaId" });
            DropIndex("dbo.Productos", new[] { "RubroId" });
            DropIndex("dbo.Productos", new[] { "MarcaId" });
            DropIndex("dbo.ProductosEnStock", new[] { "Producto_CodigoDeBarra" });
            DropIndex("dbo.ProductosEnStock", new[] { "TalleId" });
            DropIndex("dbo.ProductosEnStock", new[] { "ColorId" });
            DropIndex("dbo.ProductosEnStock", new[] { "SucursalId" });
            DropIndex("dbo.Sesiones", new[] { "User_UserName" });
            DropIndex("dbo.PuntosDeVenta", new[] { "SucursalId" });
            DropIndex("dbo.PuntosDeVenta", new[] { "SesionId" });
            DropIndex("dbo.Empleados", new[] { "User_UserName" });
            DropIndex("dbo.Empleados", new[] { "SucursalId" });
            DropTable("dbo.TiposDeFactura");
            DropTable("dbo.LineaDeVentas");
            DropTable("dbo.Ventas");
            DropTable("dbo.Talles");
            DropTable("dbo.Rubros");
            DropTable("dbo.Marcas");
            DropTable("dbo.Productos");
            DropTable("dbo.ProductosEnStock");
            DropTable("dbo.Users");
            DropTable("dbo.Sesiones");
            DropTable("dbo.PuntosDeVenta");
            DropTable("dbo.Sucursales");
            DropTable("dbo.Empleados");
            DropTable("dbo.Colores");
            DropTable("dbo.Clientes");
        }
    }
}
