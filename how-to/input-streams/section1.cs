using IronSoftware.Drawing;
using IronOcr;
namespace ironocr.InputStreams
{
    public class Section1
    {
        public void Run()
        {
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Read image file to AnyBitmap
            AnyBitmap anyBitmap = AnyBitmap.FromFile("Potter.tiff");
            
            // Import image stream
            using var imageInput = new OcrImageInput(anyBitmap.GetStream());
            // Perform OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
        }
    }
}