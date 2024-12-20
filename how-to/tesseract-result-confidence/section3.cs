using IronOcr;
namespace IronOcr.Examples.HowTo.TesseractResultConfidence
{
    public static class Section3
    {
        public static void Run()
        {
            using static IronOcr.OcrResult;
            
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Add image
            using var imageInput = new OcrImageInput("Potter.tiff");
            // Perform OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
            
            // Get choices
            Choice[] choices = ocrResult.Characters[0].Choices;
        }
    }
}