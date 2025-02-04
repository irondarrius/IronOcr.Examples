using System;
using IronOcr;
namespace IronOcr.Examples.Tutorial.CSharpTesseractOcr
{
    public static class Section2
    {
        public static void Run()
        {
            var ocr = new IronTesseract();
            using var input = new OcrInput();
            var pageindices = new int[] { 1, 2 };
            input.LoadImageFrames(@"img\example.tiff", pageindices);
            input.DeNoise();  //fixes digital noise
            input.Deskew();   //fixes rotation and perspective
            
            // there are dozens more filters, but most users wont need them
            OcrResult result = ocr.Read(input);
            Console.WriteLine(result.Text);
        }
    }
}