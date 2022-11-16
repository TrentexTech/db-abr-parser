using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace PdfParser.Core;

internal class PdfDocument
{
    private readonly List<PdfPage> _pages = new();
    public int LineCursor = 0;

    public PdfDocument(PdfReader pdf)
    {
        for (var i = 1; i <= pdf.NumberOfPages; i++)
        {
            var its = new LocationTextExtractionStrategy();
            var pageContent = PdfTextExtractor.GetTextFromPage(pdf, i, its);
            var page = new PdfPage(this, pageContent);
            _pages.Add(page);
        }
    }

    public void Print()
    {
        Console.WriteLine("Print start.");

        foreach (var page in _pages)
        {
            page.Print();
        }

        Console.WriteLine("Print finish.");
    }

    public override string ToString()
    {
        Console.WriteLine($"stringifying {_pages.Count} Pages.");
        var pagesAsString = _pages.Select((page => page.ToString()));
        var documentAsString = string.Join("\nNEXTPAGE\n", pagesAsString);

        return documentAsString;
    }
}