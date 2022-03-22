using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TP1IdS_G15Application;
using TP1IdS_G15Application.Model;
using TP1IdS_G15Modelo.Entidades;

namespace TP1IdS_G15WebService.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("ventas")]
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
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post([FromBody]VentaDTO venta)
        {
            try
            {
                string token = Request.Headers.GetValues("Authorization").First();
                VentaDTO Venta = AppLayer.Save(venta, token);
                return Request.CreateResponse(HttpStatusCode.OK, Venta);
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
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
