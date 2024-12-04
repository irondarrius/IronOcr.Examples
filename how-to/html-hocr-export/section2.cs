using IronOcr;
namespace ironocr.HtmlHocrExport
{
    public class Section2
    {
        public void Run()
        {
            // Export as HTML string
            string hocr = ocrResult.SaveAsHocrString();
        }
    }
}