using System.IO;
using IronOcr;
namespace ironocr.InputImages
{
    public class Section2
    {
        public void Run()
        {
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Read byte from file
            byte[] data = File.ReadAllBytes("Potter.tiff");
            
            // Import image byte
            using var imageInput = new OcrImageInput(data);
            // Perform OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
        }
    }
}