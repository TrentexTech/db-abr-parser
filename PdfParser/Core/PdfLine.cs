namespace PdfParser.Core;

internal class PdfLine
{
    private readonly PdfPage _parent;
    private readonly string _originalPageLine;
    private readonly char[] _originalLineAsCharArray;
    private readonly int[] _originalLineAsAsciiArray;

    public PdfLine(PdfPage parent, string originalPageLine)
    {
        _parent = parent;
        _originalPageLine = originalPageLine;
        _originalLineAsCharArray = originalPageLine.ToCharArray();
        _originalLineAsAsciiArray = Array.ConvertAll(_originalLineAsCharArray, c => (int) c);
    }

    public void Print()
    {
        foreach (var character in _originalLineAsAsciiArray)
        {
            Console.WriteLine(character);
        }
    }

    public override string ToString()
    {
        var lineAsString = _originalLineAsAsciiArray.Aggregate("", (current, i) => current + i.GetStringByAsciiInt());

        return lineAsString;
    }
}