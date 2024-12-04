using IronOcr;
namespace ironocr.HowToReadTextFromAnImageInCsharpNet
{
    public class Section2
    {
        public void Run()
        {
            IronTesseract ocr = new IronTesseract();
            using OcrInput input = new OcrInput();
            var pageindices = new int[] { 1, 2 };
            input.LoadImageFrames(@"img\Potter.tiff", pageindices);
            OcrResult result = ocr.Read(input);
            Console.WriteLine(result.Text);
        }
    }
}