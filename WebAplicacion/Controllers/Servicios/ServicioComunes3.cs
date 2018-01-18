using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;
using Newtonsoft.Json.Linq;
using WebAplicacion.Models.Json;

namespace WebAplicacion.Controllers.Servicios
{
    public class ServicioComunes3
    {
        private readonly HttpClient _cliente = new HttpClient();
        

        
       
        public async Task<Finaciero> LlamarServicios(int tipo, string para1, string para2, string para3)
        {
            var json ="";
            var Financie = new Finaciero(); 
            var searchResults = new List<SelectListItem>();
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-AuthorizationOPE"]);

                switch (tipo)
                {
                    case 1:
                        http://localhost:8080/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes3/6?param1=1&param2=ADMINISTRA&param3=BTR
                        break;
                      
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                }
              

                var desjson = JObject.Parse(json);

                Financie.Comision = (decimal)desjson["dtoResponseSetResultados"]["Comision"];
                Financie.ComisionMin = (decimal)desjson["dtoResponseSetResultados"]["ComisionMin"];
                Financie.ComisionMax = (decimal)desjson["dtoResponseSetResultados"]["ComisionMax"];
                Financie.Tasa = (decimal)desjson["dtoResponseSetResultados"]["Tasa"];
                Financie.Anticipo = (decimal)desjson["dtoResponseSetResultados"]["Anticipo"];
                Financie.GastoOper = (decimal)desjson["dtoResponseSetResultados"]["GastoOper"];
                Financie.PlazoMin = (int)desjson["dtoResponseSetResultados"]["PlazoMin"];
                Financie.PlazoMax = (int)desjson["dtoResponseSetResultados"]["PlazoMax"];
                Financie.DiasLinea = (int)desjson["dtoResponseSetResultados"]["DiasLinea"];
                Financie.PlazoEmision = (decimal)desjson["dtoResponseSetResultados"]["PlazoEmision"];
                Financie.Notificacion = (decimal)desjson["dtoResponseSetResultados"]["Notificacion"];
                Financie.NotificacionDocto = (decimal)desjson["dtoResponseSetResultados"]["NotificacionDocto"];
            }
            catch (Exception)
            {

                Financie.Comision = 0;
                Financie.ComisionMin = 0;
                Financie.ComisionMax = 0;
                Financie.Tasa = 0;
                Financie.Anticipo = 0;
                Financie.GastoOper = 0;
                Financie.PlazoMin = 0;
                Financie.PlazoMax = 0;
                Financie.DiasLinea = 0;
                Financie.PlazoEmision = 0;
                Financie.Notificacion = 0;
                Financie.NotificacionDocto = 0;

            }
            return Financie;
        }
    }
}