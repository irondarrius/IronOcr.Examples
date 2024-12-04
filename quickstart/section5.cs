using IronOcr;
namespace ironocr.Quickstart
{
    public class Section5
    {
        public void Run()
        {
            IronTesseract ocr = new IronTesseract();
            ocr.Configuration.ReadBarCodes = true;
            
            using OcrInput input = new OcrInput();
            input.LoadImage("img/Barcode.png");
            
            OcrResult Result = ocr.Read(input);
            foreach (var Barcode in Result.Barcodes)
            {
                // type and location properties also exposed
                Console.WriteLine(Barcode.Value);
            }
        }
    }
}