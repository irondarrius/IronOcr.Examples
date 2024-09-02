using IronOcr;
using IronSoftware.Drawing;
using System;

// Instantiate IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Specify crop region
Rectangle scanRegion = new Rectangle(800, 200, 900, 400);

// Add image
using var imageInput = new OcrImageInput("Potter.tiff", ContentArea: scanRegion);
// Perform OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);

// Output the result to console
Console.WriteLine(ocrResult.Text);