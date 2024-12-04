using IronOcr;
namespace ironocr.CsharpRecognizeTextFromImageComputerVision
{
    public class Section4
    {
        public void Run()
        {
            var ocr = new IronTesseract();
            using var input = new OcrInput();
            // Load at least one image
            input.LoadImage("/path/file.png");
            
            input.FindMultipleTextRegions();
            OcrResult result = ocr.Read(input);
            string resultText = result.Text;
        }
    }
}