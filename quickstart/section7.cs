using IronOcr;

IronTesseract ocr = new IronTesseract();
using OcrInput input = new OcrInput();
var pageindices = new int[] { 1, 2 };
input.LoadImageFrames(@"img\Potter.tiff", pageindices);

// fixes digital noise and poor scanning
input.DeNoise();

// fixes rotation and perspective
input.Deskew();

OcrResult result = ocr.Read(input);
Console.WriteLine(result.Text);