using System;
using IronOcr;
namespace IronOcr.Examples.Tutorial.CSharpTesseractOcr
{
    public static class Section1
    {
        public static void Run()
        {
            var ocr = new IronTesseract();
            
            // Hundreds of languages available
            ocr.Language = OcrLanguage.English;
            
            using var input = new OcrInput();
            var pageindices = new int[] { 1, 2 };
            input.LoadImageFrames(@"img\example.tiff", pageindices);
            // input.DeNoise();  optional filter
            // input.Deskew();   optional filter
            
            OcrResult result = ocr.Read(input);
            Console.WriteLine(result.Text);
            // Explore the OcrResult using IntelliSense
        }
    }
}