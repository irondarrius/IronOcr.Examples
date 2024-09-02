using IronOcr;

IronTesseract ocr = new IronTesseract();

ocr.Configuration.ReadBarCodes = true;

using OcrInput input = new OcrInput();
input.LoadImage("img/Barcode.png");

OcrResult result = ocr.Read(input);

foreach (var barcode in result.Barcodes)
{
    Console.WriteLine(barcode.Value);
    // type and location properties also exposed
}