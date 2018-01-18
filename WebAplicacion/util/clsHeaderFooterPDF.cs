using System;
using System.Web;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace WebAplicacion.util
{

    public class ClsHeaderFooterPdf
    {
        public partial class Footer : PdfPageEventHelper
        {
            public string pTitulo { get; set; }
            public int pLeftMargin { get; set; }
            public int pAlturaTitulo { get; set; }
            public int pAnchoTitulo { get; set; }

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                // Registro de fuente usada en el título.
                string fontpath = HttpContext.Current.Server.MapPath("~/Content/fonts/");
                BaseFont customfont = BaseFont.CreateFont(fontpath + "DIN Bold.ttf", BaseFont.CP1252, BaseFont.EMBEDDED);
                Font fontDinBold = new Font(customfont, 26);

                // Posicionamiento de Título.
                Paragraph titulo = new Paragraph(pTitulo, fontDinBold);
                titulo.Font.SetColor(0, 44, 92);
                PdfPTable tituloTbl = new PdfPTable(1);
                tituloTbl.TotalWidth = pAnchoTitulo;
                PdfPCell cellTitulo = new PdfPCell(titulo);
                cellTitulo.Border = 0;
                tituloTbl.AddCell(cellTitulo);
                tituloTbl.WriteSelectedRows(0, -1, pLeftMargin, pAlturaTitulo, writer.DirectContent);

                // Posicionamiento de Logo Consorcio.
                var cabezaLogo = Image.GetInstance(HttpContext.Current.Server.MapPath("~/Content/img/") + "logoPdf.jpg");
                cabezaLogo.Alignment = Image.ALIGN_CENTER;
                cabezaLogo.SetDpi(300, 300);
                cabezaLogo.ScalePercent(13.5f);
                //Margen Izquierdo / Alto
                cabezaLogo.SetAbsolutePosition(28, 680);
                document.Add(cabezaLogo);

                // Posicionamiento de Footer.
                var pie = Image.GetInstance(HttpContext.Current.Server.MapPath("~/Content/img/") + "footerPdf.jpg");
                pie.Alignment = Element.ALIGN_CENTER;
                pie.ScalePercent(23f);
                //Margen Izquierdo / Alto
                pie.SetAbsolutePosition(20, 1);
                document.Add(pie);
            }
        }
    }
}
