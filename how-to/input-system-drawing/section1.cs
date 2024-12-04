using System.Drawing;
using IronOcr;
namespace ironocr.InputSystemDrawing
{
    public class Section1
    {
        public void Run()
        {
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Read image file to Bitmap
            Bitmap bitmap = new Bitmap("Potter.tiff");
            
            // Import System.Drawing.Bitmap
            using var imageInput = new OcrImageInput(bitmap);
            // Perform OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
        }
    }
}