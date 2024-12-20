using IronOcr;
namespace IronOcr.Examples.HowTo.CsharpPdfOcr
{
    public static class Section3
    {
        public static void Run()
        {
            var Ocr = new IronTesseract();
            using (var Input = new OcrInput())
            {
                Input.AddPdf("scan.pdf")
             
                // clean up twisted pages
                Input.Deskew();
            
                var Result = Ocr.Read(Input);
                Result.SaveAsSearchablePdf("searchable.pdf");
            }
        }
    }
}