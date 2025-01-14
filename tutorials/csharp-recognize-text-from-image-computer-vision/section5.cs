using IronOcr;
namespace IronOcr.Examples.Tutorial.CsharpRecognizeTextFromImageComputerVision
{
    public static class Section5
    {
        public static void Run()
        {
            var ocr = new IronTesseract();
            using var input = new OcrInput();
            // Load at least one image
            input.LoadImage("/path/file.png");
            
            input.FindMultipleTextRegions(Scale: 2.0, DilationAmount: -1, Binarize: true, Invert: false);
            OcrResult result = ocr.Read(input);
            string resultText = result.Text;
        }
    }
}