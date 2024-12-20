using IronOcr;
namespace IronOcr.Examples.Overview.Quickstart
{
    public static class Section1
    {
        public static void Run()
        {
            string Text = new IronTesseract().Read(@"img\Screenshot.png").Text;
        }
    }
}