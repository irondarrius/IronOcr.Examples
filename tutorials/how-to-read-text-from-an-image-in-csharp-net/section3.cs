using IronOcr;
namespace IronOcr.Examples.Tutorial.HowToReadTextFromAnImageInCsharpNet
{
    public static class Section3
    {
        public static void Run()
        {
            IronTesseract ocr = new IronTesseract();
            using OcrInput input = new OcrInput();
            var pageindices = new int[] { 1, 2 };
            input.LoadImageFrames(@"img\Potter.LowQuality.tiff", pageindices);
            input.Deskew(); // removes rotation and perspective
            OcrResult result = ocr.Read(input);
            Console.WriteLine(result.Text);
        }
    }
}