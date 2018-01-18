using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        private string marcar = "@Class='classalerta'";
        public bool CargaMasiva(ListCargaMasivaViewModels modelo)
        {
            var repuesta = false;

           
            if (modelo.Doperaciones == null) return repuesta;
            if (!modelo.Doperaciones.Any()) return repuesta;
            foreach (var item in modelo.Doperaciones)
            {
                if (modelo.Opercion.TipoDocumento == 1 || modelo.Opercion.TipoDocumento == 4)
                {
                    if (!condat3
                        .VerificaFactura(item.RutDeudor, item.NroDocumento.GetValueOrDefault(),
                            modelo.Opercion.TipoDocumento).Result
                        .Equals(item.NroDocumento.GetValueOrDefault().ToString()))
                        item.NroDocumentoClass = marcar;
                }
                else
                {
                    if (!condat3
                        .VerificaDocumento(item.RutDeudor, item.NroDocumento.GetValueOrDefault(),
                            modelo.Opercion.TipoDocumento).Result
                        .Equals(item.NroDocumento.GetValueOrDefault().ToString()))
                        item.NroDocumentoClass = marcar;
                }

            //if ( item.RutDeudor.IsNullOrWhiteSpace() ) 
                if (condat3.VerificaFactura(item.RutDeudor, item.NroDocumento.GetValueOrDefault(),modelo.Opercion.TipoDocumento).Result ==
                    "") return repuesta;
                
                












            }

            repuesta = true;


            return repuesta;
        }





    }
}