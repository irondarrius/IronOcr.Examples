using IronOcr;
namespace IronOcr.Examples.HowTo.NetMauiOcrTutorial
{
    public static class Section4
    {
        public static void Run()
        {
            var ocr = new IronTesseract();
                using (var input = new OcrInput())
                {
                    input.AddImage(path);
                    OcrResult result = ocr.Read(input);
                    string text = result.Text;
                    outputText.Text = text; 
                }
        }
    }
}