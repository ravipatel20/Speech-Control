using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace Speech
{
    class ReadFiles
    {
        public String readTextData(String readText)
        {
            String str = null;
            if (readText.Substring(readText.Length - 3, 3).Equals("pdf"))
            {
               PdfReader reader = new PdfReader((string)readText);

               for (int page = 1; page <= reader.NumberOfPages; page++)
               {
                   ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy();
                   String s = PdfTextExtractor.GetTextFromPage(reader, page, its);

                   s = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(s)));
                   str = str + s;

               }
                reader.Close();

            }
            else
            {
                str = System.IO.File.ReadAllText(@readText);
            }
            str.Replace("\n", " ");
            return str;
        }
    }
}
