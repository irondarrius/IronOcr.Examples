using IronOcr;
namespace ironocr.ImageQualityCorrection
{
    public class Section1
    {
        public void Run()
        {
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Add image
            using var imageInput = new OcrImageInput("sample.jpg");
            // Apply sharpen filter
            imageInput.Sharpen();
            
            // Export filtered image
            imageInput.SaveAsImages("sharpen");
        }
    }
}