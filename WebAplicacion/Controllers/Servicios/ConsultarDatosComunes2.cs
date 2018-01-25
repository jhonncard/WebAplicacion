using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using iTextSharp.text;
using Newtonsoft.Json.Linq;
using WebAplicacion.Models.entities;

namespace WebAplicacion.Controllers.Servicios
{
    public class ConsultarDatosComunes2
    {
        private readonly HttpClient _cliente = new HttpClient();

        public async Task<string> LeerCiudad(int paramd0, int paramd1)
        {

            var searchResult = "";
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization",
                    ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync(
                    ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes2/1?param1 = " +
                    paramd0 + "&param2=" + paramd1);
                var desjson = JObject.Parse(json);
                searchResult = (string) desjson["dtoResponseSetResultados"]["DatosDeImpresion"];


            }
            catch (Exception)
            {
                ;
            }

            return searchResult;

        }

        public async Task<List<DatosClientes>> LeerClientes(string paramd0, int paramd1)
        {

            var searchResults = new List<DatosClientes>();
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization",
                    ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync(
                    ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes2/2?param1 = " +
                    paramd0 + "&param2=" + paramd1);
                var desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"]["dtoDatosClientes"].Children().ToList();

                searchResults.AddRange(results.Select(result => result.ToObject<DatosClientes>()));
            }
            catch (Exception)
            {
                var searchResult = new DatosClientes();
                searchResults.Add(searchResult);
            }

            return searchResults;

        }
        
        public async Task<int> ConvierteMonedaXDolar(int paramd0, int paramd1)
        {

            var searchResult = 0;
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization",
                    ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync(
                    ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes2/3?param1 = " +
                    paramd0 + "&param2=" + paramd1);
                var desjson = JObject.Parse(json);

                searchResult = (int) desjson["dtoResponseSetResultados"]["Comision"];

            }
            catch (Exception)
            {
                ;
            }
            return searchResult;
        }
        
        public async Task<string> BuscaValoresMoneda(int paramd0, string paramd1)
        {
            var searchResult = "";
            try
            {

                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization",
                    ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync(
                    ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes2/4?param1 = " +
                    paramd0 + "&param2=" + paramd1);
                var desjson = JObject.Parse(json);

                searchResult = (string) desjson["dtoResponseSetResultados"]["Comision"];

            }
            catch (Exception)
            {
                ;
            }

            return searchResult;

        }
        
        public async Task<int> ValorMoneda(int paramd0, string paramd1)
        {

            var searchResults = 0;
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization",
                    ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync(
                    ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes2/5?param1 = " +
                    paramd0 + "&param2=" + paramd1);
                var desjson = JObject.Parse(json);

                searchResults = (int) desjson["dtoResponseSetResultados"]["DeudoresOperacion"];
            }
            catch (Exception)
            {
                ;
            }
            return searchResults;

        }

        public async Task<string> ValidaMoneda(int paramd0, int paramd1)
        {
            var searchResult = "";
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization",
                    ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync(
                    ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes2/6?param1 = " +
                    paramd0 + "&param2=" + paramd1);
                var desjson = JObject.Parse(json);

                searchResult = (string) desjson["ValidaMoneda"];


            }
            catch (Exception)
            {
                ;
            }

            return searchResult;

        }

        public async Task<List<DocumentosContratados>> AumentoArt84(int paramd0, string paramd1)
        {

            List<DocumentosContratados> searchResults = new List<DocumentosContratados>();
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization",
                    ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync(
                    ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes2/7?param1 = " +
                    paramd0 + "&param2=" + paramd1);
                var desjson = JObject.Parse(json);
                IList<JToken> results = desjson["DocumentosContratados"]["dtoDocumentosContratatos"].Children()
                    .ToList();
                searchResults.AddRange(results.Select(result => result.ToObject<DocumentosContratados>()));
            }
            catch (Exception)
            {
                var searchResult = new DocumentosContratados();
                searchResults.Add(searchResult);


            }

            return searchResults;

        }
        
        public async Task<SaldosCliente> SaldosCliente(int paramd0, string paramd1)
        {
            var searchResults = new List<SaldosCliente>();
            var searchResult = new SaldosCliente();
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization",
                    ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync(
                    ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes2/8?param1 = " +
                    paramd0 + "&param2=" + paramd1);
                var desjson = JObject.Parse(json);
                IList<JToken> results = desjson["SaldosCliente"]["dtoConsultarSaldosCliente"].Children().ToList();

                searchResults.AddRange(results.Select(result => result.ToObject<SaldosCliente>()));
            }
            catch (Exception)
            {
                searchResult = new SaldosCliente();
                searchResults.Add(searchResult);
            }
            return searchResults.First();

        }

        public async Task<string> Feriado(string paramd0, string paramd1)
        {
            var searchResult = "";
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization",
                    ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes2/9?param1 = "+paramd0 + "&param2=" + paramd1);
                var desjson = JObject.Parse(json);
                searchResult = (string) desjson["SaldosCliente"]["dtoConsultarSaldosCliente"];
            }
            catch (Exception)
            {
                ;
            }
            return searchResult;
        }

    }
}