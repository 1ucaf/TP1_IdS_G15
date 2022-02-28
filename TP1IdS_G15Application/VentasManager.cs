using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1IdS_G15AccesoADatos;
using TP1IdS_G15Modelo.Entidades;

namespace TP1IdS_G15Application
{
    public class VentasManager : IDisposable
    {
        private DataContext db = new DataContext();

        //public Venta Save(Venta venta)
        //{
            //Venta Venta;
            //if (venta.Id == 0)
            //{
            //    Venta = new Venta();
            //    Venta.Id = 0;

            //    db.Marcas.Add(Venta);
            //}
            //else
            //{
            //    Venta = db.Ventas.Find(venta.Id);
            //    db.Entry(Venta).State = EntityState.Modified;
            //}
            //db.SaveChanges();
            //return Venta;
        //}

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
