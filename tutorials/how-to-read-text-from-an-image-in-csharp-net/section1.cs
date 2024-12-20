using IronOcr;
namespace IronOcr.Examples.Tutorial.HowToReadTextFromAnImageInCsharpNet
{
    public static class Section1
    {
        public static void Run()
        {
            // PM> Install-Package IronOcr
            using IronOcr;
            
            OcrResult result = new IronTesseract().Read(@"img\Screenshot.png");
            Console.WriteLine(result.Text);
        }
    }
}