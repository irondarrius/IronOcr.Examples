using IronOcr;
namespace ironocr.InputSystemDrawing
{
    public class Section2
    {
        public void Run()
        {
            using Image = System.Drawing.Image;
            
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Open image file as Image
            Image image = Image.FromFile("Potter.tiff");
            
            // Import System.Drawing.Image
            using var imageInput = new OcrImageInput(image);
            // Perform OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
        }
    }
}