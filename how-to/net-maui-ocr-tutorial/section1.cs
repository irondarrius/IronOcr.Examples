using IronOcr;
namespace IronOcr.Examples.HowTo.NetMauiOcrTutorial
{
    public static class Section1
    {
        public static void Run()
        {
            private async void IOCR(object sender, EventArgs e)
            {
                var images = await FilePicker.Default.PickAsync(new PickOptions
                {
                    PickerTitle = "Pick image",
                    FileTypes = FilePickerFileType.Images
                });
                var path = images.FullPath.ToString();
                OCRImage.Source = path;
            
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
}