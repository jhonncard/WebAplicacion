using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Linq;
using WebAplicacion.Models;
using WebAplicacion.Models.Json;
using System.Text.RegularExpressions;

namespace WebAplicacion.Controllers.Servicios
{
    public class Cliente
    {
        private Mant_ClientesViewModel clienteold = new Mant_ClientesViewModel();

        private readonly HttpClient client = new HttpClient();

        public Cliente()
        {
            
        }

        public async Task<Mant_ClientesViewModel> ConsultaClienteBac(int id, string paramd)
        {
           var   valor = "";
        

        
            var paramid = "0";
            try
            {
                long.Parse(id.ToString());
                paramid = "1";
            }
            catch (Exception)
            {
                paramid = "0";
            }

            IList<Mant_ClientesViewModel> searchResults = new List<Mant_ClientesViewModel>();
            try
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await client.GetStringAsync("http://10.250.13.245:8080/WS_FactoringMantenedores/ConsultarClienteBac/" + paramid + "?" + id);
                JObject desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"]["dtoClienteBAC"].Children().ToList();
                foreach (JToken result in results)
                {
                    Mant_ClientesViewModel searchResult = result.ToObject<Mant_ClientesViewModel>();
                    searchResults.Add(searchResult);
                }

            }
            catch (Exception )
            {
                var searchResult = new Mant_ClientesViewModel();
                searchResults.Add(searchResult);


            }

            return  searchResults.First();
            
        }






         public async Task<List<Mant_ClientesViewModel>> ConsultaClienteFac(string rut)
        {
            
           var searchResults = new List<Mant_ClientesViewModel>();
            try
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await client.GetStringAsync("http://10.250.13.245:8080/WS_FactoringMantenedores/ConsultarClienteFactoring/" + rut);
                JObject desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"]["clientedto"].Children().ToList();
                foreach (JToken result in results)
                {
                    Mant_ClientesViewModel searchResult = result.ToObject<Mant_ClientesViewModel>();
                    searchResults.Add(searchResult);
                }

            }
            catch (Exception ex)
            {

                Mant_ClientesViewModel searchResult =  new Mant_ClientesViewModel();
                searchResults.Add(searchResult);
            }
            
            return searchResults;
        }


        public async Task Guardar(Mant_ClientesViewModel _cliente)
        {

            var reflex = new Reflectiones();
            if (await reflex.Comprar(clienteold, _cliente, "user", "condiciones")) 
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
             await client.PostAsJsonAsync("http://10.250.13.245:8080/WS_FactoringMantenedores/GrabarClienteFactoring/", mapper(_cliente));
        }






        public async Task<List<Mant_ClientesViewModel>> GetClienteNombre(int id, string nombre)
        { 
            List<Mant_ClientesViewModel> searchResults = new List<Mant_ClientesViewModel>();
                try
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await client.GetStringAsync("http://10.250.13.245:8080/WS_FactoringMantenedores/ConsultarClienteBac/"+id+"?param=" + nombre);
                JObject desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"]["dtoClienteBAC"].Children().ToList();
                foreach (JToken result in results)
                {
                    Mant_ClientesViewModel searchResult = result.ToObject<Mant_ClientesViewModel>();
                    searchResults.Add(searchResult);
                }

            }
                catch (Exception ex)
                {
                    Mant_ClientesViewModel searchResult =new Mant_ClientesViewModel();
                    searchResults.Add(searchResult);
             
                }

            return searchResults;
        }



        

        public ClienteJson mapper(Mant_ClientesViewModel cliente)
        {
            ClienteJson _cliente = new ClienteJson();
            _cliente.rut = cliente.Rut;
            _cliente.cliente = cliente.Cliente;
            _cliente.bloqueo = cliente.Bloqueo;
            _cliente.desde = cliente.Desde;
            _cliente.hasta = cliente.Hasta;
            _cliente.clasificacion = cliente.Clasificacion;
            _cliente.retencion = cliente.Retencion;






          //  { "rut":"17394491","cliente":"pablo","bloqueo":0,"desde":1,"hasta":30,"clasificacion": "A1","retencion":600.000}

            return _cliente;
        }







    }
}