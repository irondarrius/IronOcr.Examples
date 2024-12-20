using IronOcr;
namespace IronOcr.Examples.Tutorial.HowToReadTextFromAnImageInCsharpNet
{
    public static class Section10
    {
        public static void Run()
        {
            IronTesseract ocr = new IronTesseract();
            using OcrInput input = new OcrInput();
            input.LoadPdf("example.pdf", Password: "password");
            // We can also select specific PDF page numbers to OCR
            
            OcrResult result = ocr.Read(input);
            
            Console.WriteLine(result.Text);
            Console.WriteLine($"{result.Pages.Length} Pages");
            // 1 page for every page of the PDF
        }
    }
}