using IronOcr;
namespace IronOcr.Examples.Tutorial.CsharpRecognizeTextFromImageComputerVision
{
    public static class Section2
    {
        public static void Run()
        {
            var ocr = new IronTesseract();
            using var input = new OcrInput();
            // Load at least one image
            input.LoadImage("/path/file.png");
            
            input.FindTextRegion(Scale: 2.0, DilationAmount: 20, Binarize: true, Invert: true);
            OcrResult result = ocr.Read(input);
            string resultText = result.Text;
        }
    }
}