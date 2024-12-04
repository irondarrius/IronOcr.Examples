using IronOcr;
namespace ironocr.HowToReadTextFromAnImageInCsharpNet
{
    public class Section11
    {
        public void Run()
        {
            IronTesseract ocr = new IronTesseract();
            
            using OcrInput input = new OcrInput();
            input.Title = "Quarterly Report";
            input.LoadImage("image1.jpeg");
            input.LoadImage("image2.png");
            var pageindices = new int[] { 1, 2 };
            input.LoadImageFrames("image3.gif", pageindices);
            
            OcrResult result = ocr.Read(input);
            result.SaveAsSearchablePdf("searchable.pdf");
        }
    }
}