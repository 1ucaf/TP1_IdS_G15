using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1IdS_G15AccesoADatos;
using TP1IdS_G15Application.Model;
using TP1IdS_G15Application.TokenHandlers;
using TP1IdS_G15Modelo.Entidades;

namespace TP1IdS_G15Application
{
    public class VentasManager : IDisposable
    {
        private DataContext db = new DataContext();

        public Venta Save(VentaDTO venta, string token)
        {
            Venta Venta;
            try
            {
                Cliente c = db.Clientes.Find(venta.ClienteId);
                string userName = TokenManager.ValidateToken(token);
                Sesion s = db.Sesiones.Where(se => (se.UserName == userName && se.IsActive)).FirstOrDefault();
                PuntoDeVenta pdv = s.PuntoDeVenta;
                Empleado e = db.Empleados.Where(em => em.UserName == userName).FirstOrDefault();
                TipoFactura tf = db.TiposDeFactura.Find(venta.TipoFacturaId);
                List<LineaDeVenta> LineasDeVenta = new List<LineaDeVenta>();
                decimal MontoTotal = 0;
                foreach(LineaDeVentaDTO LdVdto in venta.LineasDeVenta)
                {
                    var p = db.Productos.Find(LdVdto.ProductoId);
                    LineaDeVenta ldv = new LineaDeVenta()
                    {
                        ProductoId = LdVdto.ProductoId,
                        Producto = p,
                        MontoUnitario = p.PrecioVenta,
                        Cantidad = LdVdto.Cantidad,
                    };
                    MontoTotal += ldv.SubTotal;
                    LineasDeVenta.Add(ldv);
                }

                Venta = new Venta()
                {
                    Id = 0,
                    ClienteId = venta.ClienteId,
                    Cliente = c,
                    PuntoDeVenta = pdv,
                    PuntoDeVentaId = pdv.Id,
                    Vendedor = e,
                    EmpleadoId = e.Legajo,
                    Fecha = DateTime.Now,
                    MedioDePago = venta.MedioDePago,
                    TipoFactura = tf,
                    TipoFacturaId = venta.TipoFacturaId,
                    Monto = (decimal)MontoTotal,
                    LineasDeVentas = LineasDeVenta,
                    NroFacturaAfip = 0,
                };
                db.Ventas.Add(Venta);
                db.SaveChanges();
                return Venta;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Marca DeleteMarca(int id)
        {
            Marca Marca = db.Marcas.Find(id);
            if (Marca == null)
            {
                return null;
            }

            db.Marcas.Remove(Marca);
            db.SaveChanges();
            return Marca;
        }

        public Marca FindMarca(int id)
        {
            Marca Marca = db.Marcas.Find(id);
            return Marca;
        }
        public List<Marca> GetMarcas()
        {
            return db.Marcas.ToList();
        }

        public bool MarcaExists(int id)
        {
            return db.Marcas.Count(e => e.Id == id) > 0;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
