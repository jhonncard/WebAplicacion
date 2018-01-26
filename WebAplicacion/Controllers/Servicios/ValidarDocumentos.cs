using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using iTextSharp.text.pdf.crypto;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Linq;
using NPOI.HPSF;
using NPOI.HSSF.Record;
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
                   NroDcto = item.NroDocumento,
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
               if (item.NroDocumento.Length > 20)
               {
                   item.RutDeudorClass = marca;
                   item.RutDeudorNoti = "Nro de Documnto invalido debe ser menor a 21 digitos";
               }
               if (item.NroDocumento == "")
               {
                   item.RutDeudorClass = marca;
                   item.RutDeudorNoti = "Nro de DocumntoNo puede estar en blanco ";
               }
               else
               {
                   ulong i = 0;
                   if (ulong.TryParse(item.NroDocumento, out i))
                   {
                       item.NroDocumentoClass = marca;
                       item.NroDocumentoNoti = $"Nro de DocumntoNo{item.NroDocumento} Invalido ";
                   }
               }
               var p = 0;
               if (int.TryParse(item.Pais.ToString(), out p))
               {
                   item.PaisClass = marca;
                   item.PaisNoti = $"El pais debe ser numerico y no puede ser 0";
                }
               else if (item.Pais.ToString().IsNullOrWhiteSpace())
                   {
                       item.PaisClass =  marca;
                       item.PaisNoti += $" El pais no puede estar en blanco";
                   }
               if (item.Plaza.IsNullOrWhiteSpace())
               {
                   item.PlazaClass = marca;
                   item.PlazaNoti += $" La ciudad no puede estar en blanco";
                }
              else if (item.plaza)
                foreach (var ivg in varGraba)
               {

                   switch (ivg.Id)
                   {
                        case 1:
                            if (ivg.Valor1=="S")
                        {
                            item.RutDeudorClass = marca;
                           item.RutDeudorNoti = $"Rut {item.RutDeudor} Bloqueadov para el cliente";
                        }
                            break;
                        case 2:
                             if (ivg.Valor1 == "S")
                            {
                                item.RutDeudorClass = marca;
                                item.RutDeudorNoti = item.RutDeudorNoti + " " + $"Rut {item.RutDeudor} Bloqueadov";
                            }


                              break;
                            
                        case 3:
                           
                           if (ivg.Valor1 == "S")
                            {
                                item.NombreClass = marca;
                                item.NombreNoti = $" El nombre {item.Nombre} no corresponde al rut";
                            }
                            break;


                        case 4:

                            if (ivg.Valor1 == "S")
                                {
                                    item.NroDocumento = marca;
                                    item.NroDocumento = $" Docto. {item.NroDocumento} existe en Base de Datos";
                                }

                            break;

                        case 5:
                            if (ivg.Valor1 == "0")
                            {
                                item.NombreClass = marca;
                                item.NombreNoti = $"Pa�s {item.Pais} No Existe";
                            }

                            break;
                        case 6:



















                            break;
                       case 7:

                           if (!ivg.Valor1.Equals("0"))
                               
                               {
                                   item.NroDocumento = marca;
                                   item.NroDocumento = $" Docto. {item.NroDocumento} existe en Base de Datos";
                               }

                           break;
                    }








                   
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
            var searchResultscf = new List<DatoscofigJson>();
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
                    var items = new DatoscofigJson();
                    items.FechaProceso = (string)desjson["dtoResponseSetResultados"]["FechaProceso"];
                    items.Id = "1";
                    searchResultscf.Add(items);
                }
                foreach (var result in results)
                {
                    var searchResult = result.ToObject<DatoscofigJson>();
                    searchResultscf.Add(searchResult);
                }

            }
            catch (Exception)
            {
                var searchResult = new DatoscofigJson();
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