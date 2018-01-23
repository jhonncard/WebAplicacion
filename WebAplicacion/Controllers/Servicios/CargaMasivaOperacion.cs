using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text.pdf;
using Microsoft.Ajax.Utilities;
using WebAplicacion.Models.Operaciones;
using WebAplicacion.util;

namespace WebAplicacion.Controllers.Servicios
{
    public class CargaMasivaOperacion
    {
        private readonly Operacion condat = new Operacion();
        private readonly ConsultarDatosComunes1 condat1 = new ConsultarDatosComunes1();
        private readonly ConsultarDatosComunes2 condat2 = new ConsultarDatosComunes2();
        private readonly ConsultarDatosComunes3 condat3 = new ConsultarDatosComunes3();
        private const string marcar = "@Class='classalerta'";

        public bool CargaMasiva(ListCargaMasivaViewModels modelo)
        {
            var repuesta = false;

           
            if (modelo.Doperaciones == null) return repuesta;
            if (!modelo.Doperaciones.Any()) return repuesta;
            foreach (var item in modelo.Doperaciones)
            {
                if (modelo.Opercion.TipoDocumento == 1 || modelo.Opercion.TipoDocumento == 4)
                {
                    if (int.Parse(condat3.VerificaFactura(item.RutDeudor, item.NroDocumento.GetValueOrDefault(),
                            modelo.Opercion.TipoDocumento).Result)
                        != 0)
                        item.NroDocumentoClass = marcar;
                    item.MensajeNotificaciones += (" Nro.Documento ya registrado en la base de datos " +
                                                  item.NroDocumento + ",");
                  
                }
                else
                {
                    if (!condat3.VerificaDocumento(item.RutDeudor, item.NroDocumento.GetValueOrDefault(),
                        modelo.Opercion.TipoDocumento).Result.Equals("s"))
                        item.NroDocumentoClass = marcar;
                    item.MensajeNotificaciones += (" Nro.Documento ya registrado en la base de datos " +
                                                  item.NroDocumento + ",");
                  
                }
            }
          //  Util.RegistrosRepetidos(modelo.Doperaciones);

            if (int.Parse(modelo.Opercion.Responsabilidad) != 0)
            {
            //    var valor de => 
            //    if ( valor == "C")
            //    {
            //          GrabarSimilacion(modelo)

            //    }
            //    else
            //    {
            //        ValidaLimiteduedores(modelo)
            //    }

            }



//           











            repuesta = true;


            return repuesta;
        }





    }
}