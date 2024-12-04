using System;
using IronOcr;
namespace ironocr.ReadSpecificDocument
{
    public class Section1
    {
        public void Run()
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