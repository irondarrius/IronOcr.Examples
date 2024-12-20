using IronOcr;
namespace IronOcr.Examples.Tutorial.HowToReadTextFromAnImageInCsharpNet
{
    public static class Section7
    {
        public static void Run()
        {
            IronTesseract ocr = new IronTesseract();
            ocr.Language = OcrLanguage.ChineseSimplified;
            
            // We can add any number of languages.
            ocr.AddSecondaryLanguage(OcrLanguage.English);
            // Optionally add custom tesseract .traineddata files by specifying a file path
            
            using OcrInput input = new OcrInput();
            input.LoadImage("img/MultiLanguage.jpeg");
            OcrResult result = ocr.Read(input);
            result.SaveAsTextFile("MultiLanguage.txt");
        }
    }
}