using IronOcr;
namespace ironocr.Quickstart
{
    public class Section1
    {
        public void Run()
        {
            string Text = new IronTesseract().Read(@"img\Screenshot.png").Text;
        }
    }
}