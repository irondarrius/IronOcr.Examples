using System;
using IronOcr;
namespace ironocr.ReadSpecificDocument
{
    public class Section3
    {
        public void Run()
        {
            // Instantiate OCR engine
            var ocr = new IronTesseract();
            
            using var inputPassport = new OcrInput();
            
            inputPassport.LoadImage("Passport.jpg");
            
            // Perform OCR
            OcrPassportResult result = ocr.ReadPassport(inputPassport);
            
            // Output passport information
            Console.WriteLine(result.PassportInfo.GivenNames);
            Console.WriteLine(result.PassportInfo.Country);
            Console.WriteLine(result.PassportInfo.PassportNumber);
            Console.WriteLine(result.PassportInfo.Surname);
            Console.WriteLine(result.PassportInfo.DateOfBirth);
            Console.WriteLine(result.PassportInfo.DateOfExpiry);
        }
    }
}