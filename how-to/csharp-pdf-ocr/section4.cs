using IronOcr;
namespace IronOcr.Examples.HowTo.CsharpPdfOcr
{
    public static class Section4
    {
        public static void Run()
        {
            var Ocr = new IronTesseract();
            using (var Input = new OcrInput())
            {
                Input.Add(@"images\page1.png")
                Input.Add(@"images\page2.bmp")
                Input.Add(@"images\page3.tiff")
            
                // clean up twisted pages
                Input.Deskew();
                var Result = Ocr.Read(Input);
                Result.SaveAsSearchablePdf("searchable.pdf");
            }
        }
    }
}