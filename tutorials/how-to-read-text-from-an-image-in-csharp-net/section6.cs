using IronOcr;
namespace IronOcr.Examples.Tutorial.HowToReadTextFromAnImageInCsharpNet
{
    public static class Section6
    {
        public static void Run()
        {
            // PM> Install IronOcr.Languages.Arabic
            using IronOcr;
            
            IronTesseract ocr = new IronTesseract();
            ocr.Language = OcrLanguage.Arabic;
            
            using OcrInput input = new OcrInput();
            input.LoadImageFrame("img/arabic.gif", 1);
            // add image filters if needed
            // In this case, even thought input is very low quality
            // IronTesseract can read what conventional Tesseract cannot.
            
            OcrResult result = ocr.Read(input);
            
            // Console can't print Arabic on Windows easily.
            // Let's save to disk instead.
            result.SaveAsTextFile("arabic.txt");
        }
    }
}