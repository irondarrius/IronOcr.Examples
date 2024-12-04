using IronOcr;
namespace ironocr.HowToReadTextFromAnImageInCsharpNet
{
    public class Section9
    {
        public void Run()
        {
            IronTesseract ocr = new IronTesseract();
            
            using OcrInput input = new OcrInput();
            var pageindices = new int[] { 1, 2 };
            input.LoadImageFrames("MultiFrame.Tiff", pageindices);
            OcrResult result = ocr.Read(input);
            
            Console.WriteLine(result.Text);
            Console.WriteLine($"{result.Pages.Length} Pages");
            // 1 page for every frame (page) in the TIFF
        }
    }
}