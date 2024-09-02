using IronOcr;

IronTesseract ocr = new IronTesseract();
using OcrInput input = new OcrInput();
input.Title = "Html Title";
input.LoadImage("image1.jpeg");

OcrResult Result = ocr.Read(input);
Result.SaveAsHocrFile("results.html");