using IronOcr;
namespace ironocr.Quickstart
{
    public class Section2
    {
        public void Run()
        {
            IronTesseract ocr = new IronTesseract();
            using OcrInput input = new OcrInput();
            
            // Add multiple images
            input.LoadImage("images/sample.jpeg");
            
            OcrResult result = ocr.Read(input);
            Console.WriteLine(result.Text);
        }
    }
}