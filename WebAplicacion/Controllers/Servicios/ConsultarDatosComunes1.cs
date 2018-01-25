using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using WebAplicacion.Models.entities;


namespace WebAplicacion.Controllers.Servicios
{
    public class ConsultarDatosComunes1
    {
        private readonly HttpClient _cliente = new HttpClient();

        public async Task<string> LeerBancoCliente(int paramd0)
        {

            var searchResult = "";
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes1/1?param1 = " + paramd0 );
                var desjson = JObject.Parse(json);
                //falta buscar valor del string 
                searchResult = (string)desjson["GlosaBancoCliente"];
            }
            catch (Exception)
            {
                ;
            }

            return searchResult;

        }
        public async Task<string> LeerBanco(int paramd0)
        {

            var searchResult = "";
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes1/2?param1 = " + paramd0 );
                var desjson = JObject.Parse(json);
                //falta buscar valor del string 
                searchResult = (string)desjson["GlosaBanco"];
            }
            catch (Exception)
            {
                ;
            }

            return searchResult;

        }
        public async Task<string> LeerPais(int paramd0)
        {

            var searchResult = "";
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes1/3?param1 = " + paramd0 );
                var desjson = JObject.Parse(json);
                //falta buscar valor del string 
                searchResult = (string)desjson["GlosaPais"];
            }
            catch (Exception)
            {
                ;
            }

            return searchResult;

        }
        public async Task<string> RescataFormaPpago(int paramd0)
        {

            var searchResult = "";
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes1/4?param1 = " + paramd0 );
                var desjson = JObject.Parse(json);
                //falta buscar valor del string 
                searchResult = (string)desjson["GlosaFormaPago"];
            }
            catch (Exception)
            {
                ;
            }

            return searchResult;

        }
        public async Task<string> LeerPlaza(int paramd0)
        {

            var searchResult = "";
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes1/5?param1 = " + paramd0 );
                var desjson = JObject.Parse(json);
                //falta buscar valor del string 
                searchResult = (string) desjson["GlosaPlaza"];
            }
            catch (Exception)
            {
                ;
            }

            return searchResult;

        }
        public async Task<int> LeerIncremento()
        {

            var searchResult = 0;
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes1/6?");
                var desjson = JObject.Parse(json);
                //falta buscar valor del string 
                searchResult = (int)desjson["Incremento"];
            }
            catch (Exception)
            {
                ;
            }

            return searchResult;

        }
        public async Task<int> LeerRetencion(int paramd0)
        {
            var searchResult =0;
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes1/7?param1 = " + paramd0);
                var desjson = JObject.Parse(json);
                //falta buscar valor del string 
                searchResult = (int)desjson["Retencion"];
            }
            catch (Exception)
            {
                ;
            }

            return searchResult;

        }
        public async Task<List<Deudor>> LeerDeudor(string  paramd0)
        {
            var searchResults = new List<Deudor>();
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes1/8?param1=" + paramd0 );
                var desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"]["DeudoresOperacion"].Children().ToList();
                searchResults.AddRange(results.Select(result => result.ToObject<Deudor>()));
            }
            catch (Exception)
            {
                var searchResult = new Deudor();
                searchResults.Add(searchResult);
            }
            return searchResults;

        }
        public async Task<List<ClienteEntidad>> LeerManCliente(string paramd0)
        {

            var searchResults = new List<ClienteEntidad>();
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes1/9?param1 = " + paramd0 );
                var desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"]["DeudoresOperacion"].Children().ToList();
                searchResults.AddRange(results.Select(result => result.ToObject<ClienteEntidad>()));
            }
            catch (Exception)
            {
                var searchResult = new ClienteEntidad();
                searchResults.Add(searchResult);
            }

            return searchResults;

        }
        public async Task<List<OperacionCliente>> UltimasOpClinte(string  paramd0)
        {

            var searchResults = new List<OperacionCliente>();
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes1/10?param1 = " + paramd0 );
                var desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"]["DeudoresOperacion"].Children().ToList();
                searchResults.AddRange(results.Select(result => result.ToObject<OperacionCliente>()));
            }
            catch (Exception)
            {
                var searchResult = new OperacionCliente();
                searchResults.Add(searchResult);
            }

            return searchResults;

        }
        public async Task<int> IncrementaDocumento()
        {

            var searchResult = 0;
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes1/11?param1 = ");
                var desjson = JObject.Parse(json);
                //falta buscar valor del string 
                searchResult = (int)desjson["IncrementoDocumento"];
            }
            catch (Exception)
            {
                ;
            }

            return searchResult;

        }
        public async Task<DatosMdac> DeudoresOperacion()
        {

            var searchResults = new DatosMdac();
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization",
                    ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes1/12?param1 = ");
                var desjson = JObject.Parse(json);
                searchResults.RutMonex = (string) desjson["dtoDatosMdac"]["dtoConsultaDatosMdac"]["RutMonex"];
                searchResults.Dv = (string)desjson["dtoDatosMdac"]["dtoConsultaDatosMdac"]["Dv"];
                searchResults.NombreMonex = (string)desjson["dtoDatosMdac"]["dtoConsultaDatosMdac"]["NombreMonex"];
                searchResults.DireccionMonex = (string)desjson["dtoDatosMdac"]["dtoConsultaDatosMdac"]["DireccionMonex"];
                searchResults.FechaOper = (DateTime)desjson["dtoDatosMdac"]["dtoConsultaDatosMdac"]["FechaOper"];
            }
            catch (Exception)
            {
                ;
            }
            return searchResults;
      }
        public async Task<List<DatosRepresentantes>> ReImpresionrepResentantes(string paramd0)
        {

            var searchResults = new List<DatosRepresentantes>();
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes1/13?param1 = " + paramd0 );
                var desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"]["DeudoresOperacion"].Children().ToList();
                searchResults.AddRange(results.Select(result => result.ToObject<DatosRepresentantes>()));
            }
            catch (Exception)
            {
                var searchResult = new DatosRepresentantes();
                searchResults.Add(searchResult);
            }

            return searchResults;

        }
        public async Task<List<DatosRepresentantes>> IngresoRepresentatesSimulacion(string paramd0)
        {

            var searchResults = new List<DatosRepresentantes>();
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes1/14?param1 = " + paramd0);
                var desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"]["DeudoresOperacion"].Children().ToList();
                searchResults.AddRange(results.Select(result => result.ToObject<DatosRepresentantes>()));
            }
            catch (Exception)
            {
                var searchResult = new DatosRepresentantes();
                searchResults.Add(searchResult);
            }

            return searchResults;

        }
        public async Task<List<DatosRepresentantes>> CargaRepresentateContratoMonex(string paramd0)
        {

            var searchResults = new List<DatosRepresentantes>();
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes1/15?param1 = " + paramd0);
                var desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"]["DeudoresOperacion"].Children().ToList();
                searchResults.AddRange(results.Select(result => result.ToObject<DatosRepresentantes>()));
            }
            catch (Exception)
            {
                var searchResult = new DatosRepresentantes();
                searchResults.Add(searchResult);
            }

            return searchResults;

        }
        public async Task<string> VerificaProcesoLimites(string paramd0 )
        {

            var searchResult = "";
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes1/16?param1 = " + paramd0 );
                var desjson = JObject.Parse(json);
                //falta buscar valor del string 
                searchResult = (string)desjson["VerificaProceso"];
            }
            catch (Exception)
            {
                ;
            }

            return searchResult;

        }
        public async Task<string> VerificaFactura(int paramd0)
        {

            var searchResult = "";
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes1/17?param1 = " + paramd0 );
                var desjson = JObject.Parse(json);
                //falta buscar valor del string 
                searchResult = (string)desjson["VerificaBanco"];
            }
            catch (Exception)
            {
                ;
            }

            return searchResult;

        }

        public async Task<string> ValorResposabilidad(int paramd0)
        {

            var searchResult = "";
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes1/18?param1 = " + paramd0);
                var desjson = JObject.Parse(json);
                
                searchResult = (string)desjson["VerificaResponsabilidad"];
            }
            catch (Exception)
            {
                ;
            }

            return searchResult;

        }

        public async Task<decimal> IvaParametro()
        {

            decimal searchResult = 0;
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes1/19");
                var desjson = JObject.Parse(json);

                searchResult = (decimal)desjson["Iva_Parametro"];
            }
            catch (Exception)
            {
                ;
            }

            return searchResult;

        }
    }
}