using FacturaConverter.Model;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FacturaConverter
{
    public class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Comprobante));
            StringReader rdr;
            int registro = 1;
            Comprobante response;
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                Console.WriteLine("Excel is not properly installed!!");
                return;
            }


            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            xlWorkSheet.Cells[registro, 1] = "Version";
            xlWorkSheet.Cells[registro, 1].Interior.Color = XlRgbColor.rgbSkyBlue;
            xlWorkSheet.Cells[registro, 1].Font.Color = XlRgbColor.rgbWhite;
            xlWorkSheet.Cells[registro, 2] = "Tipo";
            xlWorkSheet.Cells[registro, 3] = "Fecha Emision";
            xlWorkSheet.Cells[registro, 3].EntireColumn.NumberFormat = "MM/DD/YYYY";
            xlWorkSheet.Cells[registro, 4] = "Fecha Timbrado";
            xlWorkSheet.Cells[registro, 4].EntireColumn.NumberFormat = "MM/DD/YYYY";
            xlWorkSheet.Cells[registro, 5] = "Folio";
            xlWorkSheet.Cells[registro, 6] = "UUID";
            xlWorkSheet.Cells[registro, 7] = "RFC Emisor";
            xlWorkSheet.Cells[registro, 8] = "Nombre Emisor";
            xlWorkSheet.Cells[registro, 9] = "LugarDeExpedicion";
            xlWorkSheet.Cells[registro, 10] = "RFC Receptor";
            xlWorkSheet.Cells[registro, 11] = "Nombre Receptor";
            xlWorkSheet.Cells[registro, 12] = "Subtotal";
            xlWorkSheet.Cells[registro, 13] = "Total IEPS";
            xlWorkSheet.Cells[registro, 14] = "IVA 16%";
            xlWorkSheet.Cells[registro, 15] = "Total";
            xlWorkSheet.Cells[registro, 16] = "Total traslados";
            xlWorkSheet.Cells[registro, 17] = "Moneda";
            xlWorkSheet.Cells[registro, 18] = "Forma De Pago";
            xlWorkSheet.Cells[registro, 19] = "Metodo de Pago";
            xlWorkSheet.Cells[registro, 20] = "Condicion de Pago";
            xlWorkSheet.Cells[registro, 21] = "Conceptos";
            xlWorkSheet.Cells[registro, 22] = "Combustible";
            xlWorkSheet.Cells[registro, 23] = "IEPS 3%";
            xlWorkSheet.Cells[registro, 24] = "IEPS 6%";
            xlWorkSheet.Cells[registro, 25] = "IEPS 7%";
            xlWorkSheet.Cells[registro, 26] = "IEPS 8%";
            xlWorkSheet.Cells[registro, 27] = "IEPS 9%";
            xlWorkSheet.Cells[registro, 28] = "IEPS 26.5%";
            xlWorkSheet.Cells[registro, 29] = "IEPS 30%";
            xlWorkSheet.Cells[registro, 30] = "IEPS 53%";
            xlWorkSheet.Cells[registro, 31] = "IEPS 160%";
            xlWorkSheet.Cells[registro, 32] = "Direccion Emisor";
            xlWorkSheet.Cells[registro, 33] = "Localidad Emisor";

            var columnHeadingsRange = xlWorkSheet.Range[
            xlWorkSheet.Cells[registro, 1],
            xlWorkSheet.Cells[registro, 33]];
            columnHeadingsRange.Interior.Color = XlRgbColor.rgbSkyBlue;
            columnHeadingsRange.Font.Color = XlRgbColor.rgbWhite;

            Console.WriteLine("Leyendo documentos...");
            string[] files = Directory.GetFiles(@"C:\XMLFacturas", "*.xml");
            Console.WriteLine(files.Count() + " documentos encontrados...");
            Console.WriteLine("Iniciando migracion a excel...");

            foreach (string file in files)
            {
                registro++;
                try
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    string contents = File.ReadAllText(file);
                    rdr = new StringReader(contents);
                    response = (Comprobante)serializer.Deserialize(rdr);

                }
                catch (Exception ex)
                {
                    Console.ReadKey();
                    return;
                }               
                xlWorkSheet.Cells[registro, 1] = response.version;
                xlWorkSheet.Cells[registro, 2] = response.tipoDeComprobante;
                xlWorkSheet.Cells[registro, 3] = response.fecha.Replace("T"," ");
                xlWorkSheet.Cells[registro, 4] = response.Complemento.TimbreFiscalDigital != null ? response.Complemento.TimbreFiscalDigital.FechaTimbrado.Replace("T"," ") : "";
                xlWorkSheet.Cells[registro, 5] = response.folio;
                xlWorkSheet.Cells[registro, 6] = response.Complemento.TimbreFiscalDigital.UUID;
                xlWorkSheet.Cells[registro, 7] = response.Emisor.rfc;
                xlWorkSheet.Cells[registro, 8] = response.Emisor.nombre;
                xlWorkSheet.Cells[registro, 9] = response.LugarExpedicion;
                xlWorkSheet.Cells[registro, 10] = response.Receptor.rfc;
                xlWorkSheet.Cells[registro, 11] = response.Receptor.nombre;
                xlWorkSheet.Cells[registro, 12] = response.subTotal;
                //xlWorkSheet.Cells[registro, 13] = "Total IEPS";
                //xlWorkSheet.Cells[registro, 14] = "IVA 16%";
                //xlWorkSheet.Cells[registro, 15] = "Total";
                //xlWorkSheet.Cells[registro, 16] = "Total traslados";
                //xlWorkSheet.Cells[registro, 17] = "Moneda";
                //xlWorkSheet.Cells[registro, 18] = "Forma De Pago";
                //xlWorkSheet.Cells[registro, 19] = "Metodo de Pago";
                //xlWorkSheet.Cells[registro, 20] = "Condicion de Pago";
                //xlWorkSheet.Cells[registro, 21] = "Conceptos";
                //xlWorkSheet.Cells[registro, 22] = "Combustible";
                //xlWorkSheet.Cells[registro, 23] = "IEPS 3%";
                //xlWorkSheet.Cells[registro, 24] = "IEPS 6%";
                //xlWorkSheet.Cells[registro, 25] = "IEPS 7%";
                //xlWorkSheet.Cells[registro, 26] = "IEPS 8%";
                //xlWorkSheet.Cells[registro, 27] = "IEPS 9%";
                //xlWorkSheet.Cells[registro, 28] = "IEPS 26.5%";
                //xlWorkSheet.Cells[registro, 29] = "IEPS 30%";
                //xlWorkSheet.Cells[registro, 30] = "IEPS 53%";
                //xlWorkSheet.Cells[registro, 31] = "IEPS 160%";
                //xlWorkSheet.Cells[registro, 32] = "Direccion Emisor";
                //xlWorkSheet.Cells[registro, 33] = "Localidad Emisor";





                //Console.ForegroundColor = ConsoleColor.Yellow;
                //Console.WriteLine("UUID: " + response.Complemento.TimbreFiscalDigital.UUID);

            }
            xlWorkBook.SaveAs("C:\\XMLFacturas\\facturas.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine((registro - 1) + " registros migrados exitosamente.");
            Console.WriteLine("Archivo de excel creado, se ecuentra en C:\\XMLFacturas\\facturas.xls");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Presione cualquier tecla para continuar.");
            Console.ReadKey();
        }
    }
}
