using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1IdS_G15AccesoADatos
{
    public class AFIPController
    {
        private static WrapperAutorizacion.Autorizacion _Ticket;
        public static void GetTicket()
        {
            var webReference = new WrapperAutorizacion.LoginServiceClient();
            _Ticket = webReference.SolicitarAutorizacion("40CA85E4-283F-4C8B-BD07-2E60FE5354ED");
        }

        public static void FE()
        {
            var webReference = new AFIPWebService.ServiceSoapClient();
            var Auth = new AFIPWebService.FEAuthRequest();
            Auth.Cuit = _Ticket.Cuit;
            Auth.Token = _Ticket.Token;
            Auth.Sign = _Ticket.Sign;

            var FECAERequest = new AFIPWebService.FECAERequest();

            var Cabecera = new AFIPWebService.FECAECabRequest();
            Cabecera.CantReg = 1;
            Cabecera.PtoVta = 15;
            Cabecera.CbteTipo = 1;
            FECAERequest.FeCabReq = Cabecera;

            var Det = new AFIPWebService.FECAEDetRequest();
            Det.Concepto = 1;
            Det.DocTipo = 80;
            Det.DocNro = 20418167093;
            Det.CbteDesde = 1;
            Det.CbteHasta = 1;
            Det.CbteFch = "20220107";
            Det.ImpTotal = 0;
            Det.ImpTotConc = 0;
            Det.ImpNeto = 0;
            Det.ImpOpEx = 0;
            Det.ImpTrib = 0;
            Det.ImpIVA = 0;
            Det.MonId = "PES";
            Det.MonCotiz = 1;

            FECAERequest.FeDetReq = new AFIPWebService.FECAEDetRequest[] { Det };

            var Response = webReference.FECAESolicitar(Auth, FECAERequest);

            //MessageBox.Show(Response.FeDetResp[0].Resultado);
        }
    }
}
