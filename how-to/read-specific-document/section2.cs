using System;
using IronOcr;
namespace IronOcr.Examples.HowTo.ReadSpecificDocument
{
    public static class Section2
    {
        public static void Run()
        {
            // Instantiate OCR engine
            var ocr = new IronTesseract();
            
            using var inputLicensePlate = new OcrInput();
            
            inputLicensePlate.LoadImage("LicensePlate.jpeg");
            
            // Perform OCR
            OcrLicensePlateResult result = ocr.ReadLicensePlate(inputLicensePlate);
            
            // Retrieve license plate coordinates
            Rectangle rectangle = result.Licenseplate;
            
            // Retrieve license plate value
            string output = result.Text;
        }
    }
}