using IronOcr;
namespace IronOcr.Examples.Tutorial.HowToReadTextFromAnImageInCsharpNet
{
    public static class Section4
    {
        public static void Run()
        {
            IronTesseract ocr = new IronTesseract();
            
            // Configure for speed
            ocr.Configuration.BlackListCharacters = "~`$#^*_}{][|\\";
            ocr.Configuration.PageSegmentationMode = TesseractPageSegmentationMode.Auto;
            ocr.Language = OcrLanguage.EnglishFast;
            
            using OcrInput input = new OcrInput();
            var pageindices = new int[] { 1, 2 };
            input.LoadImageFrames(@"img\Potter.tiff", pageindices);
            
            OcrResult result = ocr.Read(input);
            Console.WriteLine(result.Text);
        }
    }
}