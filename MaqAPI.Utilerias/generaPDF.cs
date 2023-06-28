using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

using SpreadsheetLight;

namespace MaqAPI.Utilerias
{
    public class generaPDF
    {
        public string createPDFtoBASE64(string pHTML) {
            // string _html = "<div style='border-bottom: 1px solid black;'>BITACORA DE SUPERVISOR DE SEGURIDAD</div><h1>Hola </h1><h4>Test</h4>";
            string inputAsString = "";

            using (MemoryStream ms = new MemoryStream())
            {
                StringReader sr = new StringReader(pHTML.ToString());

                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, ms);
                document.Open();
                // document.Add(new Paragraph("Hello World"));
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, sr);
                document.Close();
                writer.Close();

                inputAsString = Convert.ToBase64String(ms.ToArray());
            }


            return inputAsString;
        }

        public string createXLSXtoBase64(DataTable pDataTable)
        {
            string inputAsString = "";
            int ctdColumnas = pDataTable.Columns.Count;

            using (MemoryStream ms = new MemoryStream())
            {
                
                SLDocument sl = new SLDocument();
                sl.ImportDataTable(1, 1, pDataTable, true);

                sl.AutoFitColumn(1, ctdColumnas);
                
                sl.SaveAs(ms);

                inputAsString = Convert.ToBase64String(ms.ToArray());
            }

            return inputAsString;
        }
    }
}
