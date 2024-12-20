using IronOcr;
namespace IronOcr.Examples.Overview.Quickstart
{
    public static class Section4
    {
        public static void Run()
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