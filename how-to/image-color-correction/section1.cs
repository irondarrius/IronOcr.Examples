using IronOcr;
namespace ironocr.ImageColorCorrection
{
    public class Section1
    {
        public void Run()
        {
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Add image
            using var imageInput = new OcrImageInput("sample.jpg");
            // Apply binarize affect
            imageInput.Binarize();
            
            // Export the modified image
            imageInput.SaveAsImages("binarize");
        }
    }
}