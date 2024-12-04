using IronOcr;
namespace ironocr.TesseractResultConfidence
{
    public class Section1
    {
        public void Run()
        {
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Add image
            using var imageInput = new OcrImageInput("sample.tiff");
            // Perform OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
            
            // Get confidence level
            double confidence = ocrResult.Confidence;
        }
    }
}