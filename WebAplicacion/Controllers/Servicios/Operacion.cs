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
            var json = await cliente.GetStringAsync("http://10.250.13.245:8080/WS_FactoringCargaMasiva/Helpers/ConsultarValorMoneda/"+codmoneda +"? fecha="+fecha.ToString());
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
            var json = await cliente.GetStringAsync(" http://10.250.13.245:8080/WS_FactoringCargaMasiva/Helpers/ConsultarMedioDePago/"+ nrodcto+"?rut="+rut+"&moneda=" + idmoneda );
            var desjson = JObject.Parse(json);
            mpago.GLosa =(string) desjson["dtoResponseSetResultados"]["Glosa"];
            mpago.Valor = (int)desjson["dtoResponseSetResultados"]["Valor"];
         return mpago;
        }

        #endregion



        public async Task<bool> Guardar(ListCargaMasivaViewModels modelo)
        {
          var gope= await  Guardarope(modelo.Opercion);
          var gdope =await   Guardardeta(modelo.Doperaciones);
          var gdocrel = await GrabarDocumentoRelacion(modelo);
          var gantsimu = await ActualizarAnticipoSimulacion(modelo);
          var gpagodoc = await GrabarPagoDocumentos(modelo);
          var gactdes = await ActualizarDescuento(modelo);
          var gdeusosimu = await GrabarDeudorSimulacion(modelo);
          var glog = await GrabarLogSimulacion(modelo);

            return gdope && gope && gdocrel && gantsimu && gpagodoc && gactdes && gdeusosimu && glog;
        }

        
        #region GrabarOperacion simulacion 

        public   async Task<bool> Guardarope(OperacionViewModel modelo)
        {
          var  resulstado = false;
            try
            {
               
               cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                HttpResponseMessage response = await cliente.PostAsJsonAsync("http://10.250.13.245:8080/WS_FactoringMantenedores/GrabarCondicionesComerciales", Mapperoperaciones(modelo));
                resulstado = true;
            }
            catch (Exception )
            {
                resulstado = false;
            }
                 return resulstado;
        }

        public  async Task<bool> Guardardeta(List<DetalleOperacionesViewModel> modelo)
        {
            var resulstado = false;
            try
            {
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                HttpResponseMessage response = await cliente.PostAsJsonAsync("Url: http://10.250.13.245:8080/GrabarDocumentoSimulacion/", MapperDoperaciones(modelo));
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
                var response = await cliente.PostAsJsonAsync("http://10.250.13.245:8080/WS_FactoringCargaMasiva/GrabarDocumentoRelacion/", MapperDocumentoRelacion(modelo));
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
                var response = await cliente.PostAsJsonAsync("http://10.250.13.245:8080/WS_FactoringCargaMasiva/ActualizarAnticipoSimulacion/", MapperActualizarAnticipo(modelo));
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
                var response = await cliente.PostAsJsonAsync("http://10.250.13.245:8080/WS_FactoringCargaMasiva/GrabarPagoDocumentos/", MapperPagoDocumentos(modelo));
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
                var response = await cliente.PostAsJsonAsync("http://10.250.13.245:8080/WS_FactoringCargaMasiva/ActualizarDescuento/", MapperActualizarDescuento(modelo));
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
                var response = await cliente.PostAsJsonAsync("http://10.250.13.245:8080/WS_FactoringCargaMasiva/GrabarDeudorSimulacion/	", MapperDeudor(modelo));
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
                var response = await cliente.PostAsJsonAsync("http://10.250.13.245:8080/WS_FactoringCargaMasiva/GrabarLogSimulacion/	", MapperLogSimulacion(modelo));
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





        private static OperacionesJson Mapperoperaciones(OperacionViewModel modelo)
        {
             var opJson = new OperacionesJson();
            {
                opJson.CodMoneda = 0;
                opJson.Tabla = 0;
                opJson.Contrato = 0;
                opJson.Operacion = 0;
                opJson.FechaOperacion = modelo.FechaOperacion.ToString();
                opJson.RutCliente = modelo.RutCliente; 
                opJson.TipoOperacion = modelo.TipoOperacion;
                opJson.TotalDoc =modelo.TotalDoc;
                opJson.ValRemesa =0;
                opJson.ContravPe =0;
                opJson.TipoDocto =0;
                opJson.Tasa =modelo.TasaOperacion;
                opJson.Comision =modelo.Comision;
                opJson.MontoMinC =modelo.ComisionMin;
                opJson.MontoMaxc =modelo.ComisionMax;
                opJson.Gastos =0;
                opJson.GNotario =modelo.Gastosope;
                opJson.GNotifica =int.Parse(modelo.sNotificacion);
                opJson.Anticipo =modelo.Finaciemientoxc;
                opJson.LineaRefe =1;
                opJson.TipoMoneda =int.Parse(modelo.CodigoMoneda);
                opJson.Actividad =0;
                opJson.Pagare =0;
                //decimal montoapes = 0;
                // if (int.Parse(modelo.CodigoMoneda) != 999 && int.Parse(modelo.CodigoMoneda) != 998)
                //montoapes = (decimal) (modelo.MontoRemesa * modelo.Finaciemientoxc);
                //else
                //montoapes = (decimal)(modelo.MontoRemesa * modelo.Finaciemientoxc) * valorm, 0);

                opJson.MontoApes =0;
                opJson.MontoInte =0;
                opJson.MontoCheq =0;
                opJson.MontoNota =0;
                opJson.MontoCom =0;
                opJson.MontoFran =0;
                opJson.MontoIva =0;
                opJson.MontoImp =0;
                opJson.Notifica =0;
                opJson.MontoneTot =0;
                opJson.MontoImpp =0;
                opJson.Aviso =0;
                opJson.NDocPagado =0;
                opJson.MDocPagado =0;
                opJson.ODocPagado =0;
                opJson.NDocimpago =0;
                opJson.MDocImpago =0;
                opJson.AnticipoOp =0;
                opJson.Acumulado =0;
                opJson.PagoMas =0;
                opJson.PagoMenos =0;
                opJson.VueltoMenor =0;
                opJson.SaldoProm =0;
                opJson.Spread =0;
                opJson.CostoFondo =0;
                opJson.NumVoucher =0;
                opJson.Plazo =0;
                opJson.Linea =0;
                opJson.Estado =0;
                opJson.TPagare =0;
                opJson.FechaEmp =0;
                opJson.MontoPaga =0;
                opJson.FechaVpa =0;
                opJson.Recunet =0;
                opJson.IvaRecu =0;
                opJson.Notario1 =0;
                opJson.MedioPago =0;
                //opJson.CurseOp =0;
                //opJson.Facturado =0;
                //opJson.ValMoney =0;
                //opJson.Remesada =0;
                //opJson.ReVctoLinea =0;
                //opJson.ReSaldoLinea =0;
                opJson.TipoResponsabilidad =0;
                opJson.CodigoAumentoArt84 =0;
                opJson.Costo_Fondo =modelo.Costo_Fondo;
                opJson.CostoSpread = modelo.CostoSpread;
                opJson.IdCategoriaE = modelo.CategoríaEempresa;

            }







            return opJson;
        }

        private static List<DOperacionJson> MapperDoperaciones(IEnumerable<DetalleOperacionesViewModel> detalles )
        {
            var dopJson = new List<DOperacionJson>();
            foreach (var modelo in detalles)
            {
                var uniJson = new DOperacionJson
                {
                    RutDeudor = modelo.RutDeudor,
               
                    Monto = modelo.Monto,
                    FechaE = modelo.FechaEmision,
                    //FechaV = modelo.FechaVencimeinto,
                   
                    Nombre = modelo.Ciudad,
                    Direccion = modelo.Direccion,
                    RutCliente = modelo.Rutcliente,
                  
                };
                dopJson.Add(uniJson);
            }
            return dopJson;
        }









        private static DocumentoRelacionJson MapperDocumentoRelacion(ListCargaMasivaViewModels modelo)
        {
            var uniJson = new DocumentoRelacionJson
            {
              // RutCliente = detalles.
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