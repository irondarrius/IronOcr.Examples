using IronOcr;

IronTesseract ocr = new IronTesseract();
using OcrInput input = new OcrInput();
input.LoadImage("LowQuality.jpeg");

// fixes digital noise and poor scanning
input.DeNoise();

// fixes rotation and perspective
input.Deskew();

OcrResult result = ocr.Read(input);
Console.WriteLine(result.Text);