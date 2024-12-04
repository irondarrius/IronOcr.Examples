using System;
using IronOcr;
namespace ironocr.CSharpOcrImageFilters
{
    public class Section1
    {
        public void Run()
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