using IronOcr;
namespace ironocr.InputPdfs
{
    public class Section1
    {
        public void Run()
        {
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Add PDF
            using var pdfInput = new OcrPdfInput("Potter.pdf");
            // Perform OCR
            OcrResult ocrResult = ocrTesseract.Read(pdfInput);
        }
    }
}