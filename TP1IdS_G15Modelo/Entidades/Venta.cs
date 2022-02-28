using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1IdS_G15Modelo.Entidades
{
    public class Venta
    {
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public long NroFacturaAfip { get; set; }
        public int PuntoDeVentaId { get; set; }
        public virtual PuntoDeVenta PuntoDeVenta { get; set; }
        public MedioDePago MedioDePago { get; set; }
        //public virtual Comprobante Comprobante { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        /// <summary>
        /// This property references the Id of the employee's user who made this Sale.
        /// </summary>
        public int EmpleadoId { get; set; }
        public virtual Empleado Vendedor { get; set; }
        public int TipoFacturaId { get; set; }
        public virtual TipoFactura TipoFactura { get; set; }
        public virtual List<LineaDeVenta> LineasDeVentas { get; set; }
    }
}