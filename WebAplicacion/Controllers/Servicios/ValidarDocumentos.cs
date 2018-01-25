using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using NPOI.HPSF;
using Remotion.Logging;
using WebAplicacion.Models.Dto;
using WebAplicacion.Models.entities;
using WebAplicacion.Models.Json;
using WebAplicacion.Models.Operaciones;
using Util = WebAplicacion.util.Util;

namespace WebAplicacion.Controllers.Servicios
{
    public class ValidarDocumentos
    {
        private readonly HttpClient _cliente = new HttpClient();


        public ListCargaMasivaViewModels Validar(ListCargaMasivaViewModels model)
        {
            var detalle = model.Doperaciones;
            var marca = "@class = classalerta";
            var servcliente = new ConsultaOtrosDatos();
            var servalidargravacm = new ConsultaOtrosDatos();
            var codigos = new List<Codigos>();
            var varGraba = new List<ValidaGrabacion>();
            var varia = 450;
            codigos =  servcliente.ConsultarMtdCodigos(450).Result;
           foreach (var item  in detalle)
           {
               var valGraba = new VIngresoSimulacion
               {
                   RutDeudor = item.RutDeudor,
                   RutCliente = model.Opercion.RutCliente,
                   Nombre =item.Nombre,
                   CodPais =  item.Pais.Value,
                   CodCiudad = int.Parse(item.Plaza),
                   NroDcto = item.NroDocumento.Value,
                   TipoDcto = model.Opercion .TipoDocumento
               };
                
               varGraba = servalidargravacm.ValidarGrabadoSimulacion(valGraba).Result;
              // validar que ningun campo este vacio
              // validar el rut 
              // validar que el rut cliente no sea deudor 
                int num = 0;
               if (int.TryParse(item.RutDeudor.Substring(0, item.RutDeudor.Length - 1), out num))
                    continue;
               else 
                  {
                   item.RutDeudorNoti = "Rut no valido";
                    if (!Util.ObtenerValidezRut(item.RutDeudor.Substring(0, item.RutDeudor.Length - 1),
                       item.RutDeudor.Substring(item.RutDeudor.Length - 1)))
                    {
                        item.RutDeudorClass = marca;
                       item.RutDeudorNoti = "Rut no valido";
                   }
                  }

                 // validar verificar que el numero de documento sea un numero y que no este repetido * por validar 
                 // verificar que el documento no exista en la base de datos y que sea menor o igual a 99999999999999999999 
               if (item.NroDocumento.Value > 99999999999999999999)
               {
                   item.RutDeudorClass = marca;
                   item.RutDeudorNoti = "Nro de Documnto invalido debe ser menor a 21 digitos";
                }
            










































               //        // verificar que el monto no este en blanco y sea un valor numerico 
                //        // verifica fecha emision que no este en blanco, que sea una fecha valida que no sea mayor a la fecha de la operacion   
                //        // verificarfecha vencimiento  que no este en blanco, que sea una fecha valida que sea menor a la fecha de emision y mayor a la fecha de operacion  
                //        // verificar pais que no este en blanco y que exista dentro del la base de datos de paises 
                //        // verificar plaza que no este en blanco que sea un valor numerico que este asociada a un pais y 
                //        // 
            }




            return model;
        }







        private async Task<List<SelectListItem>> LlamarServicios(string hijo)
        {
            var searchResultscf = new List<datoscofigJson>();
            var searchResults = new List<SelectListItem>();

            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-AuthorizationOPE"]);
                var json = await _cliente.GetStringAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/ConsultarConfigFinanciera/");
                var desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"][hijo].Children().ToList();
                if (hijo == "FechaProceso")
                {
                    var items = new datoscofigJson();
                    items.FechaProceso = (string)desjson["dtoResponseSetResultados"]["FechaProceso"];
                    items.Id = "1";
                    searchResultscf.Add(items);
                }
                foreach (var result in results)
                {
                    var searchResult = result.ToObject<datoscofigJson>();
                    searchResultscf.Add(searchResult);
                }

            }
            catch (Exception)
            {
                var searchResult = new datoscofigJson();
                searchResultscf.Add(searchResult);

            }

            foreach (var item in searchResultscf)
            {
                var items = new SelectListItem();
                switch (hijo)
                {
                    case "dtoDocumentos":
                        items.Text = item.GlosaDocumento.Trim();
                        items.Value = item.CodigoDocumento;

                        break;
                    case "dtoMonedas":
                        items.Text = item.GlosaMoneda.Trim();
                        items.Value = item.CodigoMoneda;

                        break;
                    case "dtoEmpresas":

                        items.Text = item.GlosaEmpresa.Trim();
                        items.Value = item.Id;

                        break;
                    case "FechaProceso":

                        items.Text = item.FechaProceso.Trim();
                        items.Value = item.Id.Trim();
                        break;

                }
                searchResults.Add(items);

            }

            return searchResults;
        }
    }




}