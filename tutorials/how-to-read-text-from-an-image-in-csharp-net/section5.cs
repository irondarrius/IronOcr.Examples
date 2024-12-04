using IronSoftware.Drawing;
using IronOcr;
namespace ironocr.HowToReadTextFromAnImageInCsharpNet
{
    public class Section5
    {
        public void Run()
        {
            IronTesseract ocr = new IronTesseract();
            using OcrInput input = new OcrInput();
            // a 41% improvement on speed
            Rectangle contentArea = new Rectangle(x: 215, y: 1250, height: 280, width: 1335);
            input.LoadImage("img/ComSci.png", contentArea);
            OcrResult result = ocr.Read(input);
            Console.WriteLine(result.Text);
        }
    }
}