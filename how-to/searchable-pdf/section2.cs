using IronOcr;
namespace ironocr.SearchablePdf
{
    public class Section2
    {
        public void Run()
        {
            // Export searchable PDF byte
            byte[] pdfByte = ocrResult.SaveAsSearchablePdfBytes();
            
            // Export searchable PDF stream
            Stream pdfStream = ocrResult.SaveAsSearchablePdfStream();
        }
    }
}