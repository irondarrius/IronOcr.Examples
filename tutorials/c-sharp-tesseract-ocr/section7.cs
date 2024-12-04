using IronOcr;
namespace ironocr.CSharpTesseractOcr
{
    public class Section7
    {
        public void Run()
        {
            // For the Chinese Language Pack:
            // PM> Install IronOcr.Languages.ChineseSimplified
            
            var ocr = new IronTesseract();
            ocr.Language = OcrLanguage.ChineseSimplified;
            ocr.AddSecondaryLanguage(OcrLanguage.English);
            
            // We can add any number of languages
            using var input = new OcrInput();
            input.LoadPdf("multi-language.pdf");
            var result = ocr.Read(input);
            result.SaveAsTextFile("results.txt");
        }
    }
}