using IronOcr;
namespace IronOcr.Examples.HowTo.CsharpPdfOcr
{
    public static class Section1
    {
        public static void Run()
        {
            var Ocr = new IronTesseract();
            using (var Input = new OcrInput())
            {
                Input.AddPdf("example.pdf"); 
                var Result = Ocr.Read(Input);
                Console.WriteLine(Result.Text);
            }
        }
    }
}