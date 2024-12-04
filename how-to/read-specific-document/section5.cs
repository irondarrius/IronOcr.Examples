using System.Linq;
using IronOcr;
namespace ironocr.ReadSpecificDocument
{
    public class Section5
    {
        public void Run()
        {
            // Instantiate OCR engine
            var ocr = new IronTesseract();
            
            using var inputScreenshot = new OcrInput();
            inputScreenshot.LoadImage("screenshot.png");
            
            // Perform OCR
            OcrPhotoResult result = ocr.ReadScreenShot(inputScreenshot);
            
            // Output screenshoot information
            Console.WriteLine(result.Text);
            Console.WriteLine(result.TextRegions.First().Region.X);
            Console.WriteLine(result.TextRegions.Last().Region.Width);
            Console.WriteLine(result.Confidence);
        }
    }
}