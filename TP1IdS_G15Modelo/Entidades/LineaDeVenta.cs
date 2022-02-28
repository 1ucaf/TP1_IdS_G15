using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1IdS_G15Modelo.Entidades
{
    public class LineaDeVenta
    {
        [Key]
        public int Id { get; set; }
        public int Monto { get; set; }
        public int ProductoId { get; set; }
        public virtual Producto Producto { get; set; }

    }
}
