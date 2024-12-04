using IronOcr;
namespace ironocr.CsharpRecognizeTextFromImageComputerVision
{
    public class Section3
    {
        public void Run()
        {
            using var input = new OcrInput();
            // Load at least one image
            input.LoadImage("/path/file.png");
            
            input.FindTextRegion(Scale: 2.0, Binarize: true);
        }
    }
}