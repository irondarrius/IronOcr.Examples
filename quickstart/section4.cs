using IronOcr;
namespace ironocr.Quickstart
{
    public class Section4
    {
        public void Run()
        {
            IronTesseract ocr = new IronTesseract();
            using OcrInput input = new OcrInput();
            var pageindices = new int[] { 1, 2 };
            input.LoadImageFrames("multi-frame.tiff", pageindices);
            OcrResult result = ocr.Read(input);
            Console.WriteLine(result.Text);
        }
    }
}