using IronOcr;
namespace IronOcr.Examples.Tutorial.HowToReadTextFromAnImageInCsharpNet
{
    public static class Section14
    {
        public static void Run()
        {
            IronTesseract ocr = new IronTesseract();
            
            using OcrInput input = new OcrInput();
            input.Title = "Html Title";
            
            // Add more content as required...
            input.LoadImage("image2.jpeg");
            input.LoadPdf("example.pdf",Password: "password");
            var pageindices = new int[] { 1, 2 };
            input.LoadImageFrames("example.tiff", pageindices);
            
            OcrResult result = ocr.Read(input);
            result.SaveAsHocrFile("hocr.html");
        }
    }
}