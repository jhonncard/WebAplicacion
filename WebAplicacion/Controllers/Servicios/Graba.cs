using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using NPOI.OpenXmlFormats.Dml.Diagram;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.SS.Formula.Functions;
using WebAplicacion.Models.entities;
using WebAplicacion.Models.Json;
using WebAplicacion.Models.Json.Grabar;
using WebAplicacion.Models.Operaciones;
using WebAplicacion.util;
namespace WebAplicacion.Controllers.Servicios
{
    public class Grabar
    { /* private readonly  grabasimulacion = new */
         private readonly Operacion ope= new Operacion();
        bool varmen = false;
        private readonly ConsultarDatosComunes3 _cdatos3 = new ConsultarDatosComunes3();
        private readonly ConsultarDatosComunes2 _cdatos2 = new ConsultarDatosComunes2();
        private readonly ConsultarDatosComunes1 _cdatos1 = new ConsultarDatosComunes1();

        //var gope = await operacion.Guardarope(modelo.Opercion);
        //var gdope = await operacion.Guardardeta(modelo.Doperaciones);
        //var gdocrel = await operacion.GrabarDocumentoRelacion(modelo);
        //var gantsimu = await operacion.ActualizarAnticipoSimulacion(modelo);
        //var gpagodoc = await operacion.GrabarPagoDocumentos(modelo);
        //var gactdes = await operacion.ActualizarDescuento(modelo);
        //var gdeusosimu = await GrabarDeudorSimulacion(modelo);
        //var glog = await GrabarLogSimulacion(modelo);

        private readonly OperacionesJson jason = new OperacionesJson();
      
        
        public bool GrabaSimulacion(ListCargaMasivaViewModels modelo)
        {
           
            var validaMoneda = new ConsultarDatosComunes2();
            if (validaMoneda.ValidaMoneda(modelo.Opercion.TipoDocumento, int.Parse(modelo.Opercion.CodigoMoneda))
                    .Result =="" ) return false; 
            if (modelo.Opercion.TotalAcum == modelo.Opercion.MontoRemesa) return false;
            jason.Operacion =  _cdatos1.LeerIncremento().Result;
            foreach (var item in modelo.Doperaciones)
            {
                varmen = varmen && ope.Guardardeta(MapperDoperaciones(item, modelo.Opercion, jason.Operacion.Value)).Result;
            }
            

            varmen = varmen && ope.Guardarope(Mapperoperaciones(modelo.Opercion)).Result;

            














            return true;

































            return true;

        }


        private static DetalleDocJason MapperDoperaciones(DetalleOperacionesViewModel detalle, OperacionViewModel modelo, int remesa)
        {
            var financieros = DatosFinacieros(detalle.RutDeudor, modelo.TipoDocumento, int.Parse(modelo.CodigoMoneda));
            var dias_emision = 0; 

            var dopJson = new DetalleDocJason();

            dopJson.Operacion = remesa;
            dopJson.Contrato = 0;
            dopJson.Correlativo = 333945;
            dopJson.RutDeudor = detalle.RutDeudor;
            dopJson.RutCliente =modelo.RutCliente;
            dopJson.Actividad = 0;
            dopJson.TipoDocto = 1;
            dopJson.Monto = detalle.Monto;
            dopJson.MontoMoneda = 19277132;
            dopJson.FechaE = detalle.FechaEmision.Value.ToString("dd/MM/yyyy");
            dopJson.FechaV =detalle.FechaVencimeinto.Value.ToString("dd/MM/yyyy");
            dopJson.FechaL = "";
            dopJson.plaza = int.Parse(detalle.Plaza);
            dopJson.Nombre =detalle.Nombre;
            dopJson.Direccion = detalle.Direccion;
            dopJson.SaldoDoc = 0;
            dopJson.MonedaDoc = int.Parse(modelo.CodigoMoneda);
            dopJson.DocJunto ="F";
            dopJson.EstadoAct ="";
            dopJson.TipoOpera = modelo.TipoOperacion;
            dopJson.Ncontrato = detalle.Pais;
            dopJson.Cuenta = modelo.TipoDocumento ==3 ?detalle.NroDocumento.ToString(): "";
            dopJson.Remp = 0;
            dopJson.Curse = "S";
            dopJson.NdoctoE = detalle.NroDocumento;
            dopJson.Banco = 1;
            dopJson.Anticipo = modelo.Financiamiento;

     
            dopJson.MontoC = (modelo.ComisionMax != 0 && modelo.ComisionMin !=0 ?
                                     (modelo.Comision > modelo.ComisionMax ? modelo.ComisionMax/Moneda(modelo.CodigoMoneda,modelo.FechaOperacion.Value)
                                    :(modelo.Comision < modelo.ComisionMin ? modelo.ComisionMin:modelo.Comision)):modelo.Comision);
            dopJson.MontoIVA = detalle.Monto * Iva();

            dopJson.Remesada = "F";
            dopJson.FechaPag = fechapago(Retension(detalle.Pais.Value), detalle.FechaVencimeinto.ToString());
            dopJson.MontoI = (modelo.CodigoMoneda != "999" || modelo.CodigoMoneda != "998")?
                    (Math.Round((modelo.Financiamiento.Value /100)*detalle.Monto.Value,2)* ( modelo.TasaOperacion / (modelo.CodigoMoneda == "999"? 3000: 36000)) * Util.Diffechas(modelo.FechaOperacion.Value, DateTime.Parse(dopJson.FechaPag))):
                   ( Math.Round((modelo.Financiamiento.Value / 100) * detalle.Monto.Value, 0) * ((modelo.TasaOperacion / (modelo.CodigoMoneda == "999" ? 3000 : 36000)) * Util.Diffechas(modelo.FechaOperacion.Value, DateTime.Parse(dopJson.FechaPag)))* detalle.Monto);

            var plazo = Util.Diffechas( modelo.FechaOperacion.Value, DateTime.Parse(dopJson.FechaPag));
            var basec = modelo.CodigoMoneda.Equals("999")? 3000:36000;

            var diasEmision = Util.Diffechas( detalle.FechaEmision.Value, modelo.FechaOperacion.Value );
            var porc_envejeci = (diasEmision * 100) / plazo;
            var plazo_emi = financieros.Result.PlazoEmision;
            if (porc_envejeci > plazo_emi)
                  dopJson.NumReempl = plazo_emi == 0 ? 0 : 1;
             else
                dopJson.NumReempl = 0;



            if (financieros.Result.PlazoMin == 0 && financieros.Result.PlazoMin == 0)
                dopJson.RePlazo = "F";
            else
            {
                if (financieros.Result.PlazoMin == 0)
                {
                    dopJson.RePlazo = financieros.Result.PlazoEmision > financieros.Result.PlazoMax ? "T" : "F";
                }
                else if (financieros.Result.PlazoMax == 0)
                {
                    dopJson.RePlazo = financieros.Result.PlazoEmision < financieros.Result.PlazoMin ? "T" : "F";
                }
                else
                {
                    dopJson.RePlazo= (financieros.Result.PlazoEmision < financieros.Result.PlazoMin ||
                        financieros.Result.PlazoEmision > financieros.Result.PlazoMax)? dopJson.RePlazo = "T": dopJson.RePlazo = "F";
                    
                }
               
            }

            decimal plazo_op = 0;
            if (financieros.Result.PlazoEmision > plazo_op)
                plazo_op = financieros.Result.PlazoEmision.Value;

            dopJson.FechaReemp = "";
            //------
            dopJson.Correlativo2 = 0;
            dopJson.NumReempl = 0;
            dopJson.Gastos = 0;
            dopJson.RePlazo = "";
    
    
            
                
            
            return dopJson;
        }









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
                opJson.TotalDoc = modelo.TotalDoc;
                opJson.ValRemesa = 0;
                opJson.ContravPe = 0;
                opJson.TipoDocto = 0;
                opJson.Tasa = modelo.TasaOperacion;
                opJson.Comision = modelo.Comision;
                opJson.MontoMinC = modelo.ComisionMin;
                opJson.MontoMaxc = modelo.ComisionMax;
                opJson.Gastos = 0;
                opJson.GNotario = modelo.Gastosope;
                opJson.GNotifica = int.Parse(modelo.sNotificacion);
                opJson.Anticipo = modelo.Financiamiento;
                opJson.LineaRefe = 1;
                opJson.TipoMoneda = int.Parse(modelo.CodigoMoneda);
                opJson.Actividad = 0;
                opJson.Pagare = 0;
                //decimal montoapes = 0;
                //if (int.Parse(modelo.CodigoMoneda) != 999 && int.Parse(modelo.CodigoMoneda) != 998)
                //    montoapes = (decimal)(modelo.MontoRemesa * modelo.Finaciemientoxc);
                //else
                //    montoapes = (decimal)(modelo.MontoRemesa * modelo.Finaciemientoxc) * valorm, 0);

                opJson.MontoApes = 0;
                opJson.MontoInte = 0;
                opJson.MontoCheq = 0;
                opJson.MontoNota = 0;
                opJson.MontoCom = 0;
                opJson.MontoFran = 0;
                opJson.MontoIva = 0;
                opJson.MontoImp = 0;
                opJson.Notifica = 0;
                opJson.MontoneTot = 0;
                opJson.MontoImpp = 0;
                opJson.Aviso = 0;
                opJson.NDocPagado = 0;
                opJson.MDocPagado = 0;
                opJson.ODocPagado = 0;
                opJson.NDocimpago = 0;
                opJson.MDocImpago = 0;
                opJson.AnticipoOp = 0;
                opJson.Acumulado = 0;
                opJson.PagoMas = 0;
                opJson.PagoMenos = 0;
                opJson.VueltoMenor = 0;
                opJson.SaldoProm = 0;
                opJson.Spread = 0;
                opJson.CostoFondo = 0;
                opJson.NumVoucher = 0;
                opJson.Plazo = 0;
                opJson.Linea = 0;
                opJson.Estado = 0;
                opJson.TPagare = 0;
                opJson.FechaEmp = 0;
                opJson.MontoPaga = 0;
                opJson.FechaVpa = 0;
                opJson.Recunet = 0;
                opJson.IvaRecu = 0;
                opJson.Notario1 = 0;
                opJson.MedioPago = 0;
                //opJson.CurseOp =0;
                //opJson.Facturado =0;
                //opJson.ValMoney =0;
                //opJson.Remesada =0;
                //opJson.ReVctoLinea =0;
                //opJson.ReSaldoLinea =0;
                opJson.TipoResponsabilidad = 0;
                opJson.CodigoAumentoArt84 = 0;
                opJson.Costo_Fondo = modelo.Costo_Fondo;
                opJson.CostoSpread = modelo.CostoSpread;
                opJson.IdCategoriaE = modelo.CategoríaEempresa;

            }







            return opJson;
        }





        private int IncremetarDoc(string rut)
        {
            var consul1 = new ConsultarDatosComunes1();
            var nrodoc = consul1.IncrementaDocumento().Result * 1;
            return nrodoc;
        }
         
        public static async  Task<Finaciero> DatosFinacieros(string rut, int tipodoc, int tipomond)
        {
            var obtener = new DatFinancieros();
            var datfinacieros =await  obtener.DatosFinancieros(rut, tipodoc, tipomond);
            return datfinacieros;
        }

        public static string Esferiado(string fecha)
        {
            var consul2 = new ConsultarDatosComunes2();
            var fech = DateTime.Parse(fecha).ToString("yyyyMMdd");
            var feriado = consul2.Feriado(fech, "00001").Result;
            var fech1 = DateTime.Parse(fech);
            while (feriado.Equals(fecha) && fech1.DayOfWeek.ToString().Equals("Sunday") && fech1.DayOfWeek.ToString().Equals("Saturday"))
            {
                fech1.AddDays(1);
            }
            return fech1.ToString("dd/MM/yyyy");
        }

        public  static decimal Iva()
        {
            decimal iva = 0;
            var consul1 = new ConsultarDatosComunes1();        
            iva = consul1.IvaParametro().Result;
            return iva;
            
        }

        public  static int Retension(int pais )
        {
            var reten = 0;
            var consul1 = new ConsultarDatosComunes1();
            reten = consul1.LeerRetencion(pais).Result;
            return reten;

        }

        public static string fechapago(int reten,string fecha )
       {
            var _fecha = Esferiado(fecha);
            _fecha = DateTime.Parse(_fecha).AddDays(reten).ToString();
            _fecha = Esferiado(_fecha);
            return DateTime.Parse(_fecha).ToString("yyyyMMdd");
        }


        public static int Moneda(string  monedaCod, DateTime fecchaope)
        {
            var const2 = new ConsultarDatosComunes2();
            int moneda = 1;
            if(int.Parse(monedaCod) != 999)
            moneda =  const2.ValorMoneda(int.Parse(monedaCod), fecchaope.ToString("yyyyMMdd")).Result;
            return moneda;
        }

        //public static Finaciero datos_financiero( ListCargaMasivaViewModels modelo)
        //{   var df = new Finaciero();
        //    var datos = new DatFinancieros(modelo , modelo, modelo);
        //}
    }
}