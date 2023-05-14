using System;
using System.Diagnostics;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace Merge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter First File");

            var FirstFile = Console.ReadLine();

            Console.WriteLine("Enter Second File");

            var SecondFile = Console.ReadLine();

            var FilePaths = Path.GetDirectoryName(SecondFile);

            var NameOfFirstFile = Path.GetFileNameWithoutExtension(FirstFile);

            string fileName = FilePaths +"\\" + NameOfFirstFile + ".SUBMITTED.pdf";

            Console.WriteLine(fileName.ToString());

            using (PdfDocument one = PdfReader.Open(FirstFile, PdfDocumentOpenMode.Import))
            using (PdfDocument two = PdfReader.Open(SecondFile, PdfDocumentOpenMode.Import))

            using (PdfDocument outPdf = new PdfDocument())
            {
                CopyPages(one, outPdf);

                CopyPages(two, outPdf);

                outPdf.Save(fileName);

                Process.Start(fileName);
            }

            void CopyPages(PdfDocument from, PdfDocument to)
            {
                for (int i = 0; i < from.PageCount; i++)
                {
                    to.AddPage(from.Pages[i]);
                }
            }
        }
    }
}
