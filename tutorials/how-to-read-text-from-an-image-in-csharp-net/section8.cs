using IronOcr;
namespace IronOcr.Examples.Tutorial.HowToReadTextFromAnImageInCsharpNet
{
    public static class Section8
    {
        public static void Run()
        {
            IronTesseract ocr = new IronTesseract();
            
            using OcrInput input = new OcrInput();
            input.LoadImage("image1.jpeg");
            input.LoadImage("image2.png");
            var pageindices = new int[] { 1, 2 };
            input.LoadImageFrames("image3.gif", pageindices);
            
            OcrResult result = ocr.Read(input);
            
            Console.WriteLine($"{result.Pages.Length} Pages"); // 3 Pages
        }
    }
}