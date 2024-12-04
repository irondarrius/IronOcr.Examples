using IronOcr;
namespace ironocr.CSharpTesseractOcr
{
    public class Section5
    {
        public void Run()
        {
            var text = new IronTesseract().Read("img.png").Text;
        }
    }
}