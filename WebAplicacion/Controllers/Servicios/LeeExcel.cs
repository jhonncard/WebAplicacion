using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Web;
using LinqToExcel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using WebAplicacion.Models.Operaciones;



namespace WebAplicacion.Controllers.Servicios
{
    public class LeeExcel
    {
        public List<DetalleOperacionesViewModel> Excelnpoi(string  archivo)
        {
            var list = new List<DetalleOperacionesViewModel>();
            HSSFWorkbook hssfwb;
            //using (var fs = File.Open(HttpContext.Current.Server.MapPath("~/Files/entrada/" + archivo), FileMode.Open, FileAccess.Read))
            using (var fs = File.Open(archivo, FileMode.Open, FileAccess.Read))
            {
                hssfwb = new HSSFWorkbook(fs);
            }

            var i = 0;
                var sheet = hssfwb.GetSheet("Carga Masiva");
                for (var row = 11; row <= sheet.LastRowNum; row++)
                {
                    try
                    {
                        
                        if (sheet.GetRow(row) == null)
                        {
                           break;
                        }

                        if (sheet.GetRow(row).GetCell(0).StringCellValue== null)
                        {
                            i++;
                            if (i==2)break;
                        }
                    var detalle =

                            new DetalleOperacionesViewModel
                            {

                                RutDeudor = sheet.GetRow(row).GetCell(0).StringCellValue,
                                NroDocumento = int.Parse(sheet.GetRow(row).GetCell(1).NumericCellValue.ToString()),
                                Monto =decimal.Parse( sheet.GetRow(row).GetCell(2).NumericCellValue.ToString()),
                                FechaEmision = Convert.ToDateTime(sheet.GetRow(row).GetCell(3).DateCellValue.ToString()),
                                FechaVencimeinto = Convert.ToDateTime(sheet.GetRow(row).GetCell(4).DateCellValue.ToString()),
                                Pais = sheet.GetRow(row).GetCell(5).NumericCellValue.ToString(),
                                Plaza = sheet.GetRow(row).GetCell(6).NumericCellValue.ToString(),
                                Nombre = sheet.GetRow(row).GetCell(7).StringCellValue,
                             

                            };

                        list.Add(detalle);

                }
                    catch (Exception )
                    {
                       ;
                    }

                   
                }
            
            
              return list;

           
        }
    }
}