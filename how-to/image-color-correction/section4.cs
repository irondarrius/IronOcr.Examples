using IronOcr;
namespace ironocr.ImageColorCorrection
{
    public class Section4
    {
        public void Run()
        {
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Add image
            using var imageInput = new OcrImageInput("sample.jpg");
            IronSoftware.Drawing.Color currentColor = new IronSoftware.Drawing.Color("#DB645C");
            IronSoftware.Drawing.Color newColor = IronSoftware.Drawing.Color.DarkCyan;
            
            // Replace color
            imageInput.ReplaceColor(currentColor, newColor, 80);
            
            // Export the modified image
            imageInput.SaveAsImages("replaceColor");
        }
    }
}