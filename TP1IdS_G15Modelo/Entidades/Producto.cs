using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1IdS_G15Modelo.Entidades
{
    [Table("Productos")]
    public class Producto
    {

        #region members
        private double _porcentajeIVA;
        private double _margenDeGanancia;
        #endregion

        #region Constructors
        public Producto()
        {
        }

        public Producto(int _CodigoDeBarra, string _Descripcion, double _Costo, double _MargenDeGanancia, double _PorcentajeIVA, Marca _Marca, Rubro _Rubro)
        {
            CodigoDeBarra = _CodigoDeBarra;
            Descripcion = _Descripcion;
            Costo = _Costo;
            MargenDeGanancia = _MargenDeGanancia;
            PorcentajeIVA = _PorcentajeIVA;
            Rubro = _Rubro;
            Marca = _Marca;
        }
        #endregion

        #region properties
        [Key]
        public int CodigoDeBarra { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public double MargenDeGanancia
        {
            get
            {
                return _margenDeGanancia * 100;
            }
            set
            {
                _margenDeGanancia = (value / 100);
            }
        }
        public double NetoGravado
        {
            get
            {
                return Costo + (Costo * _margenDeGanancia);
            }
        }
        public double PorcentajeIVA
        {
            get
            {
                return _porcentajeIVA * 100;
            }
            set
            {
                if (value < 0) throw new Exception("El impuesto IVA no puede ser inferior a 0 por ciento");
                _porcentajeIVA = (value / 100);
            }
        }
        public double IVA
        {
            get
            {
                return NetoGravado * _porcentajeIVA;
            }
        }
        public double PrecioVenta
        {
            get
            {
                return NetoGravado + IVA;
            }
        }
        public int MarcaId { get; set; }
        public virtual Marca Marca { get; set; }
        public int RubroId { get; set; }
        public virtual Rubro Rubro { get; set; }
        #endregion
    }
}
