using IronOcr;

IronTesseract ocr = new IronTesseract();
using OcrInput input = new OcrInput();

// Add multiple images
input.LoadImage("images/sample.jpeg");

OcrResult result = ocr.Read(input);
Console.WriteLine(result.Text);