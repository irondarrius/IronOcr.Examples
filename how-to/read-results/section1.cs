using System;
using IronOcr;
namespace ironocr.ReadResults
{
    public class Section1
    {
        public void Run()
        {
            using static IronOcr.OcrResult;
            
            // Instantiate IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Add image
            using var imageInput = new OcrImageInput("sample.jpg");
            // Perform OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
            
            // Retrieve list of detected paragraphs
            Paragraph[] paragraphs = ocrResult.Paragraphs;
            
            // Output information to console
            Console.WriteLine($"Text: {paragraphs[0].Text}");
            Console.WriteLine($"X: {paragraphs[0].X}");
            Console.WriteLine($"Y: {paragraphs[0].Y}");
            Console.WriteLine($"Width: {paragraphs[0].Width}");
            Console.WriteLine($"Height: {paragraphs[0].Height}");
            Console.WriteLine($"Text direction: {paragraphs[0].TextDirection}");
        }
    }
}