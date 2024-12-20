using System;
using IronOcr;
namespace IronOcr.Examples.HowTo.Async
{
    public static class Section1
    {
        public static void Run()
        {
            var ocr = new IronTesseract();
            
            using (var input = new OcrPdfInput(@"example.pdf"))
            {
                var result = ocr.Read(input);
                Console.WriteLine(result.Text);
            };
        }
    }
}