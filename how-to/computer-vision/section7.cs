using System.Linq;
using IronOcr;
namespace ironocr.ComputerVision
{
    public class Section7
    {
        public void Run()
        {
            int pageIndex = 0;
            using var input = new OcrInput();
            input.LoadImage("/path/file.png");
            
            var selectedPage = input.GetPages().ElementAt(pageIndex);
            // List<Rectangle> regions = selectedPage.GetTextRegions();
        }
    }
}