using IronOcr;
namespace ironocr.HowToReadTextFromAnImageInCsharpNet
{
    public class Section1
    {
        public void Run()
        {
            // PM> Install-Package IronOcr
            using IronOcr;
            
            OcrResult result = new IronTesseract().Read(@"img\Screenshot.png");
            Console.WriteLine(result.Text);
        }
    }
}