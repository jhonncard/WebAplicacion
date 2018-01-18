using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;


namespace WebAplicacion.util
{
    public class UtilDocumentos
    {
        public static byte[] GetPdf(string pHtml)
        {
            byte[] bPDF = null;

            MemoryStream ms = new MemoryStream();
            TextReader txtReader = new StringReader(pHtml);

            // 1: create object of a itextsharp document class
            Document doc = new Document(PageSize.A4, 25, 25, 25, 25);

            // 2: we create a itextsharp pdfwriter that listens to the document and directs a XML-stream to a file
            PdfWriter oPdfWriter = PdfWriter.GetInstance(doc, ms);

            // 3: we create a worker parse the document
            var htmlWorker = new HTMLWorker(doc);

            // 4: we open document and start the worker on the document
            doc.Open();
            htmlWorker.StartDocument();

            // 5: parse the html into the document
            htmlWorker.Parse(txtReader);

            // 6: close the document and the worker
            htmlWorker.EndDocument();
            htmlWorker.Close();
            doc.Close();

            bPDF = ms.ToArray();

            return bPDF;
        }

        public static byte[] GetPdf(string pHtml, string titulo)
        {

            byte[] bPDF = null;

            MemoryStream ms = new MemoryStream();
            TextReader txtReader = new StringReader(pHtml);

            // 1: create object of a itextsharp document class
            //Document doc = new Document(PageSize.LETTER, 25, 25, 25, 25);
            Document doc = new Document(PageSize.LETTER, 25, 25, 120, 60);

            // 2: we create a itextsharp pdfwriter that listens to the document and directs a XML-stream to a file
            PdfWriter oPdfWriter = PdfWriter.GetInstance(doc, ms);

            // 3: we create a worker parse the document
            var htmlWorker = new HTMLWorker(doc);

            // 4: we open document and start the worker on the document
            doc.Open();

            oPdfWriter.PageEvent = new ClsHeaderFooterPdf.Footer()
            {
                pTitulo = titulo,
                pLeftMargin = 360,
                pAlturaTitulo = 730,
                pAnchoTitulo = 250
            };

            htmlWorker.StartDocument();

            // 5: parse the html into the document
            htmlWorker.Parse(txtReader);

            // 6: close the document and the worker
            htmlWorker.EndDocument();
            htmlWorker.Close();
            doc.Close();

            bPDF = ms.ToArray();

            return bPDF;
        }
    }
}