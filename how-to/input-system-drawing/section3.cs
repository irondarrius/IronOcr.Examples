using IronSoftware.Drawing;
using IronOcr;
namespace ironocr.InputSystemDrawing
{
    public class Section3
    {
        public void Run()
        {
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Open image file as AnyBitmap
            AnyBitmap anyBitmap = AnyBitmap.FromFile("Potter.tiff");
            
            // Import IronSoftware.Drawing.AnyBitmap
            using var imageInput = new OcrImageInput(anyBitmap);
            // Perform OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
        }
    }
}