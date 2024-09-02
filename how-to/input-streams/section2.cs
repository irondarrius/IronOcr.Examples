using IronOcr;
using IronSoftware.Drawing;
using System;

// Instantiate IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Read image file to AnyBitmap
AnyBitmap anyBitmap = AnyBitmap.FromFile("Potter.tiff");

// Specify crop region
Rectangle scanRegion = new Rectangle(800, 200, 900, 400);

// Add image
using var imageInput = new OcrImageInput(anyBitmap.GetStream(), ContentArea: scanRegion);
// Perform OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);

// Output the result to console
Console.WriteLine(ocrResult.Text);