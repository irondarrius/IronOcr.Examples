using IronOcr;
namespace ironocr.Quickstart
{
    public class Section13
    {
        public void Run()
        {
            // PM> Install IronOcr.Languages.ChineseSimplified
            IronTesseract ocr = new IronTesseract();
            ocr.Language = OcrLanguage.ChineseSimplified;
            
            // We can add any number of languages
            ocr.AddSecondaryLanguage(OcrLanguage.English);
            
            using OcrInput input = new OcrInput();
            input.LoadPdf("multi-language.pdf");
            OcrResult result = ocr.Read(input);
            result.SaveAsTextFile("results.txt");
        }
    }
}