using System;
using IronOcr;
namespace ironocr.DetectPageRotation
{
    public class Section1
    {
        public void Run()
        {
            using var input = new OcrInput();
            
            // Load PDF document
            input.LoadPdf("Clockwise90.pdf");
            
            // Detect page rotation
            var results = input.DetectPageOrientation();
            
            // Ouput result
            foreach(var result in results)
            {
                Console.WriteLine(result.PageNumber);
                Console.WriteLine(result.HighConfidence);
                Console.WriteLine(result.RotationAngle);
            }
        }
    }
}