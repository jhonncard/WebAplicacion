using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting; 
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using NPOI.Util;

using WebAplicacion.Models.Deudores;
using WebAplicacion.Models.Dto;
using WebAplicacion.Models.Json;
using WebAplicacion.Models.Json.Grabar;
using WebAplicacion.Models.Operaciones;

namespace WebAplicacion.Controllers.Servicios
{
    public class Operacion
    {
        private readonly TipoOperacion _tipoOpe = new TipoOperacion();
        private readonly ConfFinanciera _conffina = new ConfFinanciera();
       
        private readonly Cliente _cliente = new Cliente();
        private readonly HttpClient cliente = new HttpClient();

        public Operacion()
        {
                
        }

        public List<SelectListItem> LIstaSiNo()
        {
           

            return new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Si", 
                    Value = "1"
                },
                new SelectListItem()
                {
                Text = "No",
                Value = "2"
            }
            };
        }

        #region consultar  datos guardado

        public  async Task<decimal>  ConsultarValorModenda(int codmoneda, DateTime fecha )
        {
            cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization",
                ConfigurationManager.AppSettings["Token-Authorization"]);
            var json = await cliente.GetStringAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarValorMoneda/"+codmoneda +"? fecha="+fecha.ToString());
            var desjson = JObject.Parse(json);
          return (decimal)desjson["Valor"] ;
        }
        
    public  async Task<MedioPago> MedioDePago(int nrodcto,string  rut, int idmoneda)
        {
           var mpago = new MedioPago();
            var searchResults = new List<MantDuedoresViewModel>();
            var valor = 0;
            cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization",
                ConfigurationManager.AppSettings["Token-Authorization"]);
            var json = await cliente.GetStringAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/Helpers/ConsultarMedioDePago/"+ nrodcto+"?rut="+rut+"&moneda=" + idmoneda );
            var desjson = JObject.Parse(json);
            mpago.GLosa =(string) desjson["dtoResponseSetResultados"]["Glosa"];
            mpago.Valor = (int)desjson["dtoResponseSetResultados"]["Valor"];
         return mpago;
        }

        #endregion



        public async Task<bool> Guardar(ListCargaMasivaViewModels modelo)
        {
          //var gope= await  Guardarope(modelo.Opercion);
          //var gdope =await   Guardardeta(modelo.Doperaciones);
          //var gdocrel = await GrabarDocumentoRelacion(modelo);
          //var gantsimu = await ActualizarAnticipoSimulacion(modelo);
          //var gpagodoc = await GrabarPagoDocumentos(modelo);
          //var gactdes = await ActualizarDescuento(modelo);
          //var gdeusosimu = await GrabarDeudorSimulacion(modelo);
          //var glog = await GrabarLogSimulacion(modelo);

            return false; //gdope && gope && gdocrel && gantsimu && gpagodoc && gactdes && gdeusosimu && glog;
        }

        
        #region GrabarOperacion simulacion 

        public   async Task<bool> Guardarope(OperacionesJson modelo)
        {
          var  resulstado = false;
            try
            {
               
               cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var response = await cliente.PostAsJsonAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringMantenedores/GrabarCondicionesComerciales", (modelo));
                resulstado = true;
            }
            catch (Exception )
            {
                resulstado = false;
            }
                 return resulstado;
        }

        public  async Task<bool> Guardardeta(DetalleDocJason modelo)
        {
            var resulstado = false;
            try
            {
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                HttpResponseMessage response = await cliente.PostAsJsonAsync("Url: http://10.250.13.245:8080/GrabarDocumentoSimulacion/", modelo);
                resulstado = true;
            }
            catch (Exception)
            {
                resulstado = false;
            }
            return resulstado;
        }

        public async Task<bool> GrabarDocumentoRelacion(ListCargaMasivaViewModels modelo)
        {
            var resulstado = false;
            try
            {
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var response = await cliente.PostAsJsonAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/GrabarDocumentoRelacion/", MapperDocumentoRelacion(modelo));
                resulstado = true;
            }
            catch (Exception)
            {
                resulstado = false;
            }
            return resulstado;
        }


        public async Task<bool> ActualizarAnticipoSimulacion(ListCargaMasivaViewModels modelo)
        {
            var resulstado = false;
            try
            {
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var response = await cliente.PostAsJsonAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/ActualizarAnticipoSimulacion/", MapperActualizarAnticipo(modelo));
                resulstado = true;
            }
            catch (Exception)
            {
                resulstado = false;
            }
            return resulstado;
        }


        public async Task<bool> GrabarPagoDocumentos(ListCargaMasivaViewModels modelo)
        {
            var resulstado = false;
            try
            {
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var response = await cliente.PostAsJsonAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/GrabarPagoDocumentos/", MapperPagoDocumentos(modelo));
                resulstado = true;
            }
            catch (Exception)
            {
                resulstado = false;
            }
            return resulstado;
        }


        public async Task<bool> ActualizarDescuento(ListCargaMasivaViewModels modelo)
        {
            var resulstado = false;
            try
            {
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var response = await cliente.PostAsJsonAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/ActualizarDescuento/", MapperActualizarDescuento(modelo));
                resulstado = true;
            }
            catch (Exception)
            {
                resulstado = false;
            }
            return resulstado;
        }

        public async Task<bool> GrabarDeudorSimulacion(ListCargaMasivaViewModels modelo)
        {
            var resulstado = false;
            try
            {
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var response = await cliente.PostAsJsonAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/GrabarDeudorSimulacion/	", MapperDeudor(modelo));
                resulstado = true;
            }
            catch (Exception)
            {
                resulstado = false;
            }
            return resulstado;
        }


        public async Task<bool> GrabarLogSimulacion(ListCargaMasivaViewModels modelo)
        {   
            var resulstado = false;
            try
            {
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var response = await cliente.PostAsJsonAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/GrabarLogSimulacion/	", MapperLogSimulacion(modelo));
                resulstado = true;
            }
            catch (Exception)
            {
                resulstado = false;
            }
            return resulstado;
        }

        #endregion

        #region Mapper






      









        private static DocumentoRelacionJson MapperDocumentoRelacion(ListCargaMasivaViewModels modelo)
        {
            var uniJson = new DocumentoRelacionJson
            {
                //RutCliente = modelo.Opercion.RutCliente
                // NroOperRemesa = 
                // CodTipoOperacion =
                // CodCobranza =
                // CodResponsabilidad =
                // CodSeguro =
                // Flag =
            };
            
        
        return uniJson;
        }



        private static ActualizarAnticipoJson MapperActualizarAnticipo(ListCargaMasivaViewModels modelo)
        {
            var uniJson = new ActualizarAnticipoJson
            {
                //RutCliente=
                //NroAnticipo=
                //Estado=
                //Cesion=
           
            };
            
        
            return uniJson;
        }

        private static PagoDocumentosJosn  MapperPagoDocumentos(ListCargaMasivaViewModels modelo)
        {
            
                var uniJson = new PagoDocumentosJosn
                {
                    //Operacion = 
                    //MontoC= 
                    //Correlativo = 
                    //Mora =
                    //Devolucion =
                    //Liquido = 
                    //GastosProt = 
                    //IntProrro = 
                    //RutCliente = 

                };


                return uniJson;
          
        }

       

        private static ActualizarDecuentoJson MapperActualizarDescuento(ListCargaMasivaViewModels modelo)
        {

            var uniJson = new ActualizarDecuentoJson
            {
                //Operacion = 
                //MontoC= 
                //Correlativo = 
                //Mora =
                //Devolucion =
                //Liquido = 
                //GastosProt = 
                //IntProrro = 
                //RutCliente = 

            };


            return uniJson;

        }

        
        private static DeudorJson MapperDeudor(ListCargaMasivaViewModels modelo)
        {

            var uniJson = new DeudorJson()
            {
                //RutDeudor = 
                //NombreDeudor= 


            };


            return uniJson;

        }



        private static LogSimulacionJson MapperLogSimulacion(ListCargaMasivaViewModels modelo)
        {

            var uniJson = new LogSimulacionJson()
            {
                //Sistema=
                //Usuario=
                //Fecha=
                //Evento=
                //Name=

            };


            return uniJson;

        }


        #endregion




        public ListCargaMasivaViewModels Mapper(ListCargaMasivaViewModels modelo,
         List< DetalleOperacionesViewModel> doperaciones)
        {
            foreach (var item in doperaciones)
            {
                modelo.Doperaciones.Add(item);
                
            }
            return modelo;
        }


    }

}