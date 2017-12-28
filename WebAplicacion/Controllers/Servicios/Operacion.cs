using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Factoring.Negocios;
using Newtonsoft.Json.Linq;
using WebAplicacion.Models.Json;
using WebAplicacion.Models.Operaciones;

namespace WebAplicacion.Controllers.Servicios
{
    public class Operacion
    {
        private readonly TipoOperacion _tipoOpe = new TipoOperacion();
        private readonly ConfFinanciera _conffina = new ConfFinanciera();
        private readonly DatFinancieros _dtfinan = new DatFinancieros();
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

       public async Task<List<SelectListItem>> Datosfinancieros (string hijo, object tipo )
        {
           
                var searchResults = new List<SelectListItem>();
                var searchResultsdatos = new List<Datos>();
                try
                {
                    cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                    cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-AuthorizationOPE"]);
                    var json = await cliente.GetStringAsync("http://10.250.13.245:8080/WS_FactoringCargaMasiva/ConsultarConfigFinanciera/");
                    var desjson = JObject.Parse(json);
                    IList<JToken> results = desjson["dtoResponseSetResultados"][hijo].Children().ToList();
                    foreach (var result in results)
                    {
                        var searchResult = result.ToObject<Datos>();
                        searchResultsdatos.Add(searchResult);
                    }

                }
                catch (Exception ex)
                {

                    var searchResult = new Datos();
                    searchResultsdatos.Add(searchResult);
                }

                foreach (var item in searchResultsdatos)
                {
                    var items = new SelectListItem();

                    items.Text = item.Glosa.Trim();
                    items.Value = item.Id.ToString();
                    searchResults.Add(items);
                }

                return searchResults;
            




    }
















        public async void  Guardar(OperacionViewModel modelo)
        {
            
            


                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var response = await cliente.PostAsJsonAsync("http://10.250.13.245:8080/WS_FactoringMantenedores/GrabarCondicionesComerciales", Mapperoperaciones(modelo));     
           
       }


        private OperacionesJson Mapperoperaciones(OperacionViewModel modelo)
        {
             var opJson = new OperacionesJson();
            {
                opJson.CodMoneda = 0;
                opJson.Tabla = 0;
                opJson.Contrato = 0;
                opJson.Operacion = 0;
                opJson.FechaOperacion = modelo.FechaOperacion.ToString();
                opJson.RutCliente = modelo.RutCliente; 
                opJson.TipoOperacion = int.Parse(modelo.TipoOperacion);
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
                opJson.IdCategoriaE = int.Parse(modelo.CategoríaEempresa);

            }







            return opJson;
        }


















    }




}