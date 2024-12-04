using IronOcr;
namespace ironocr.InputTiffGif
{
    public class Section1
    {
        public void Run()
        {
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Import TIFF/TIF
            using var imageInput = new OcrImageInput("Potter.tiff");
            // Perform OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
        }
    }
}