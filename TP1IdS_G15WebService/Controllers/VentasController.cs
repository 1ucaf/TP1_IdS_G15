using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TP1IdS_G15Application;
using TP1IdS_G15Application.Model;

namespace TP1IdS_G15WebService.Controllers
{
    public class VentasController : ApiController
    {
        VentasManager AppLayer = new VentasManager();
        // GET: api/Ventas
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Ventas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Ventas
        public void Post([FromBody]VentaDTO venta)
        {
            string token = "";
            try
            {
                token = Request.Headers.GetValues("Authorization").First();
                AppLayer.Save(venta, token);
            }
            catch(Exception e)
            {

            }
        }

        // PUT: api/Ventas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Ventas/5
        public void Delete(int id)
        {
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                AppLayer.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
