using IronOcr;
namespace ironocr.CsharpRecognizeTextFromImageComputerVision
{
    public class Section1
    {
        public void Run()
        {
            var ocr = new IronTesseract();
            using var input = new OcrInput();
            // Load at least one image
            input.LoadImage("/path/file.png");
            
            input.FindTextRegion();
            OcrResult result = ocr.Read(input);
            string resultText = result.Text;
        }
    }
}