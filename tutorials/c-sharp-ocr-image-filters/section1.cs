using System;
using IronOcr;
namespace IronOcr.Examples.Tutorial.CSharpOcrImageFilters
{
    public static class Section1
    {
        public static void Run()
        {
            var ocr = new IronTesseract();
            using var input = new OcrInput();
            input.LoadImage("my_image.png");
            input.Deskew();
            
            var result = ocr.Read(input);
            Console.WriteLine(result.Text);
        }
    }
}