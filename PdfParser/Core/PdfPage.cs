namespace PdfParser.Core;

internal class PdfPage
{
    private readonly PdfDocument _parent;
    private readonly string _originalPageContent;
    private readonly string[] _originalPageLines;

    private readonly List<PdfLine> _lines = new List<PdfLine>();

    public PdfPage(PdfDocument parent, string pageContent)
    {
        _parent = parent;
        _originalPageContent = pageContent;
        _originalPageLines = pageContent.Split("\n");

        foreach (var originalPageLine in _originalPageLines)
        {
            _lines.Add(new PdfLine(this, originalPageLine));
        }
    }

    public void Print()
    {
        foreach (var line in _lines)
        {
            line.Print();
        }
    }

    public override string ToString()
    {
        _parent.LineCursor += _lines.Count;
        Console.WriteLine($"stringifying {_lines.Count} Lines.({_parent.LineCursor})");
        var pageLines = _lines.Select(line => line.ToString());

        var pageAsString = string.Join("\n", pageLines);
        _parent.LineCursor++; // because of "NEXTPAGE" Line.
        return pageAsString;
    }
}