using IronOcr;
namespace IronOcr.Examples.HowTo.ImageColorCorrection
{
    public static class Section1
    {
        public static void Run()
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