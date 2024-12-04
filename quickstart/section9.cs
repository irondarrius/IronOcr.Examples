using IronOcr;
namespace ironocr.Quickstart
{
    public class Section9
    {
        public void Run()
        {
            IronTesseract ocr = new IronTesseract();
            using OcrInput input = new OcrInput();
            var pageindices = new int[] { 1, 2 };
            input.LoadImageFrames("example.tiff", pageindices);
            ocr.Read(input).SaveAsSearchablePdf("searchable.pdf");
        }
    }
}