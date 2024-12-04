using IronOcr;
namespace ironocr.HowToReadTextFromAnImageInCsharpNet
{
    public class Section12
    {
        public void Run()
        {
            IronTesseract ocr = new IronTesseract();
            
            using OcrInput input = new OcrInput();
            input.Title = "Pdf Metadata Name";
            input.LoadPdf("example.pdf", Password: "password");
            OcrResult result = ocr.Read(input);
            result.SaveAsSearchablePdf("searchable.pdf");
        }
    }
}