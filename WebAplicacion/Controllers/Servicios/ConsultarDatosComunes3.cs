using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using WebAplicacion.Models;
using WebAplicacion.Models.entities;

namespace WebAplicacion.Controllers.Servicios
{
    public class ConsultarDatosComunes3
    {
        private readonly HttpClient _cliente = new HttpClient();

         public async Task<DatosImpreson> DatosDeImpresion(string paramd0, int paramd1, int  paramd2)
        {

            var  searchResult = new DatosImpreson();
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync("http://localhost:8080/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes3/1?param1 = " + paramd0+"&param2="+paramd1+"&param3="+paramd2 );
                var desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"]["DatosDeImpresion"].Children().ToList();
                foreach (var result in results)
                {
                     searchResult = result.ToObject<DatosImpreson>();
                   
                }

            }
            catch (Exception)
            {
                 searchResult = new DatosImpreson();
               


            }

            return searchResult;

        }
        public async Task<string> VerificaFactura(string paramd0, int paramd1, int paramd2)
        {

           var searchResult = "" ;
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync("http://localhost:8080/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes3/2?param1=" + paramd0 + "&param2=" + paramd1 + "&param3=" + paramd2);
                var desjson = JObject.Parse(json);
                //falta buscar valor del string 
                searchResult = (string)desjson["VerificaFactura"];
           }
            catch (Exception)
            {
               ;
            }

            return searchResult;

        }

        public async Task<string> VerificaDocumento( string paramd0, int paramd1, int paramd2)
        {

            var searchResult = "";
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync("http://localhost:8080/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes3/3?param1 = " + paramd0 + "&param2=" + paramd1 + "&param3=" + paramd2);
                var desjson = JObject.Parse(json);

                searchResult = (string)desjson["VerificaDcto"];

            }
            catch (Exception)
            {
               ;
          }
            return searchResult;
         }

        public async Task<VerificaLineaCredito> LineaDeCredito(int paramd0, int  paramd1 ,int paramd2)
        {
          var searchResult = new VerificaLineaCredito();
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync("http://localhost:8080/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes3/4?param1 = " + paramd0 + "&param2=" + paramd1 + "&param3=" + paramd2);
               var desjson = JObject.Parse(json);
                searchResult.Linea = (int)desjson["dtoResponseSetResultados"]["LineaDeCredito"]["Linea"];
                searchResult.Fecha = (DateTime)desjson["dtoResponseSetResultados"]["LineaDeCredito"]["fecha"];

            }
            catch (Exception)
            {
                ;
            }

            return searchResult;

        }

        public async Task<List<DeudoresOperacion>> DeudoresOperacion(int paramd0, int paramd1, string paramd2)
        {

            var searchResults = new List<DeudoresOperacion>();
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync("http://localhost:8080/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes3/5?param1 = " + paramd0 + "&param2=" + paramd1 + "&param3=" + paramd2);
                var desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"]["DeudoresOperacion"].Children().ToList();
                searchResults.AddRange(results.Select(result => result.ToObject<DeudoresOperacion>()));
            }
            catch (Exception)
            {
                var searchResult = new DeudoresOperacion();
                searchResults.Add(searchResult);
            }

            return searchResults;

        }

        public async Task<string> ActTmpGe(int paramd0, string paramd1, string paramd2)
        {
                var searchResult ="";
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync("http://localhost:8080/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes3/6?param1 = " + paramd0 + "&param2=" + paramd1 + "&param3=" + paramd2);
                var desjson = JObject.Parse(json);

                searchResult = (string)desjson["dtoResponseSetResultados"]["Comision"];


            }
            catch (Exception)
            {
               ;
            }

            return searchResult;

        }
        public async Task<List<Articulo84>> AumentoArt84(int paramd0, int paramd1, int paramd2)
        {

            List<Articulo84> searchResults = new List<Articulo84>();
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync("http://localhost:8080/WS_FactoringCargaMasiva/Helpers/ConsultarDatosComunes3/7?param1 = " + paramd0 + "&param2=" + paramd1 + "&param3=" + paramd2);
                var desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"]["AumentoArt84"].Children().ToList();
                searchResults.AddRange(results.Select(result => result.ToObject<Articulo84>()));
            }
            catch (Exception)
            {
                var searchResult = new Articulo84();
                searchResults.Add(searchResult);


            }

            return searchResults;

        }


    }
}