using System.Linq;
using IronOcr;
namespace IronOcr.Examples.Tutorial.CsharpRecognizeTextFromImageComputerVision
{
    public static class Section6
    {
        public static void Run()
        {
            int pageIndex = 0;
            using var input = new OcrInput();
            // Load at least one image
            input.LoadImage("/path/file.png");
            
            var selectedPage = input.GetPages().ElementAt(pageIndex);
            List<OcrInputPage> textRegionsOnPage = selectedPage.FindMultipleTextRegions();
        }
    }
}