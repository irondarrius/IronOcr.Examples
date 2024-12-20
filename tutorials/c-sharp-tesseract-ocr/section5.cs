using IronOcr;
namespace IronOcr.Examples.Tutorial.CSharpTesseractOcr
{
    public static class Section5
    {
        public static void Run()
        {
            var text = new IronTesseract().Read("img.png").Text;
        }
    }
}