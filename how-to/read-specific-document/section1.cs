using System;
using IronOcr;
namespace IronOcr.Examples.HowTo.ReadSpecificDocument
{
    public static class Section1
    {
        public static void Run()
        {
            // Instantiate OCR engine
            var ocr = new IronTesseract();
            
            // Configure OCR engine
            ocr.Configuration.PageSegmentationMode = TesseractPageSegmentationMode.SingleBlock;
            
            using var input = new OcrInput();
            
            input.LoadPdf("Five.pdf");
            
            // Perform OCR
            OcrResult result = ocr.ReadDocument(input);
            
            Console.WriteLine(result.Text);
        }
    }
}