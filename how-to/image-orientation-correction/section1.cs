using IronOcr;
namespace IronOcr.Examples.HowTo.ImageOrientationCorrection
{
    public static class Section1
    {
        public static void Run()
        {
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Add image
            using var imageInput = new OcrImageInput("paragraph_skewed.png");
            
            // Rotate the image 180 degrees clockwise
            imageInput.Rotate(180);
            
            // Export the modified image
            imageInput.SaveAsImages("rotate");
        }
    }
}