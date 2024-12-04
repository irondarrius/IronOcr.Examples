using System;
using IronOcr;
namespace ironocr.CSharpTesseractOcr
{
    public class Section3
    {
        public void Run()
        {
            var ocr = new IronTesseract();
            using var input = new OcrInput();
            input.LoadPdf("example.pdf", Password: "password");
            var pageindices = new int[] { 1, 2 };
            input.LoadImageFrames("multi-frame.tiff", pageindices);
            input.LoadImage("image1.png");
            input.LoadImage("image2.jpeg");
            //... many more
            
            var result = ocr.Read(input);
            Console.WriteLine(result.Text);
        }
    }
}