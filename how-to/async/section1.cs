using System;
using IronOcr;
namespace ironocr.Async
{
    public class Section1
    {
        public void Run()
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