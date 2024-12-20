using IronOcr;
namespace IronOcr.Examples.Tutorial.CsharpRecognizeTextFromImageComputerVision
{
    public static class Section4
    {
        public static void Run()
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