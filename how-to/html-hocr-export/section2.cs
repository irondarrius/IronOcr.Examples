using IronOcr;
namespace IronOcr.Examples.HowTo.HtmlHocrExport
{
    public static class Section2
    {
        public static void Run()
        {
            // Export as HTML string
            string hocr = ocrResult.SaveAsHocrString();
        }
    }
}