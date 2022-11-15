using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using TrentsLibrary.HelperClasses;

namespace PdfParser.Core;

public class PdfParser
{
    public PdfParser()
    {
        var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//db-abr-parser";
        var files = Directory.GetFiles(path).ToList();
        foreach (var file in files)
        {
            if (!file.EndsWith(".pdf")) continue;
            var filePath = new PathObject(file + ".txt");
            Console.WriteLine($"Working File: {filePath.File}");
            var pdf = ReadPdfFile(file);
            var pdfContent = pdf.ToString();
            filePath.CreateAndWriteFile(new ReadOnlySpan<byte>(Encoding.UTF8.GetBytes(pdfContent)));
        }
    }

    private static PdfDocument ReadPdfFile(string path)
    {
        var its = new LocationTextExtractionStrategy();
        var reader = new PdfReader(path);

        var pdf = new PdfDocument(reader, its);

        

        return pdf;
    }
}