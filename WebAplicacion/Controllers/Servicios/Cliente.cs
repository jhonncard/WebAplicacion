using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using WebAplicacion.Models;
using WebAplicacion.Models.Json;
using WebAplicacion.Models.Clientes;
using WebAplicacion.Models.entities;

namespace WebAplicacion.Controllers.Servicios
{
    public class Cliente
    {
        private MantClientesViewModel clienteold = new MantClientesViewModel();
        private readonly HttpClient client = new HttpClient();

        public Cliente()
        {
            
        }

        public async Task<MantClientesViewModel> ConsultaClienteBac(int id, string paramd)
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

            IList<MantClientesViewModel> searchResults = new List<MantClientesViewModel>();
            try
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await client.GetStringAsync("http://10.250.13.245:8080/WS_FactoringMantenedores/ConsultarClienteBac/" + paramid + "?param=" + id);
                var desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"]["dtoClienteBAC"].Children().ToList();
                foreach (var result in results)
                {
                    MantClientesViewModel searchResult = result.ToObject<MantClientesViewModel>();
                    searchResults.Add(searchResult);
                }

            }
            catch (Exception )
            {
                var searchResult = new MantClientesViewModel();
                searchResults.Add(searchResult);


            }

            return  searchResults.First();
            
        }






         public async Task<List<MantClientesViewModel>> ConsultaClienteFac(string rut)
        {
            
           var searchResults = new List<MantClientesViewModel>();
            try
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await client.GetStringAsync("http://10.250.13.245:8080/WS_FactoringMantenedores/ConsultarClienteFactoring/" + rut);
                JObject desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"]["clientedto"].Children().ToList();
                foreach (JToken result in results)
                {
                    MantClientesViewModel searchResult = result.ToObject<MantClientesViewModel>();
                    searchResults.Add(searchResult);
                }

            }
            catch (Exception ex)
            {

                MantClientesViewModel searchResult =  new MantClientesViewModel();
                searchResults.Add(searchResult);
            }
            
            return searchResults;
        }


        public async Task Guardar(MantClientesViewModel _cliente)
        {

            var reflex = new Reflectiones();
            if (await reflex.Comprar(clienteold, _cliente, "user", "condiciones")) 
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
             await client.PostAsJsonAsync("http://10.250.13.245:8080/WS_FactoringMantenedores/GrabarClienteFactoring/", mapper(_cliente));
        }






        public async Task<List<MantClientesViewModel>> GetClienteNombre(int id, string nombre)
        { 
            List<MantClientesViewModel> searchResults = new List<MantClientesViewModel>();
                try
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await client.GetStringAsync("http://10.250.13.245:8080/WS_FactoringMantenedores/ConsultarClienteBac/"+id+"?param=" + nombre);
                JObject desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"]["dtoClienteBAC"].Children().ToList();
                foreach (JToken result in results)
                {
                    MantClientesViewModel searchResult = result.ToObject<MantClientesViewModel>();
                    searchResults.Add(searchResult);
                }

            }
                catch (Exception ex)
                {
                    MantClientesViewModel searchResult =new MantClientesViewModel();
                    searchResults.Add(searchResult);
             
                }

            return searchResults;
        }



        

        public ClienteJson mapper(MantClientesViewModel cliente)
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


        public async Task<List<Politicas>> DefPoliticas()
       {
           var searchResults = new List<Politicas>();
           try
           {
               client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
               client.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
               var json = await client.GetStringAsync("http://10.250.13.245:8080/WS_FactoringMantenedores/ConsultarLimitesDeudor");
               var desjson = JObject.Parse(json);
               IList<JToken> results = desjson["dtoResponseSetResultados"]["dtoConsultarLimitesDeudor"].Children().ToList();
               searchResults.AddRange(results.Select(result => result.ToObject<Politicas>()));
           }
           catch (Exception ex)
           {
               var searchResult = new Politicas();
               searchResults.Add(searchResult);

           }

           return searchResults;
        }


    }
}