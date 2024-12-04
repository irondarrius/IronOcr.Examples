using IronOcr;
namespace ironocr.HowToReadTextFromAnImageInCsharpNet
{
    public class Section13
    {
        public void Run()
        {
            IronTesseract ocr = new IronTesseract();
            using OcrInput input = new OcrInput();
            input.Title = "Pdf Title";
            var pageindices = new int[] { 1, 2 };
            input.LoadImageFrames("example.tiff", pageindices);
            OcrResult result = ocr.Read(input);
            result.SaveAsSearchablePdf("searchable.pdf");
        }
    }
}