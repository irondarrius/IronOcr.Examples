using IronOcr;
namespace ironocr.ComputerVision
{
    public class Section4
    {
        public void Run()
        {
            var ocr = new IronTesseract();
            using var input = new OcrInput();
            input.LoadImage("/path/file.png");
            
            input.FindMultipleTextRegions();
            OcrResult result = ocr.Read(input);
            string resultText = result.Text;
        }
    }
}