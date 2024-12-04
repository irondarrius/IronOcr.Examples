using IronOcr;
namespace ironocr.CsharpRecognizeTextFromImageComputerVision
{
    public class Section2
    {
        public void Run()
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