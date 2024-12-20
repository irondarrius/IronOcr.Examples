using IronOcr;
namespace IronOcr.Examples.HowTo.CsharpPdfOcr
{
    public static class Section2
    {
        public static void Run()
        {
            var Ocr = new IronTesseract();
            using (var Input = new OcrInput())
            {
                Input.AddPdfPages("example.pdf", new [] { 1, 2, 3 });
                var Result = Ocr.Read(Input);
                Console.WriteLine(Result.Text);
            }
        }
    }
}