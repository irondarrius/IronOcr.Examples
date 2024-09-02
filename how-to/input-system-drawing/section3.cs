using IronOcr;
using IronSoftware.Drawing;

// Instantiate IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Open image file as AnyBitmap
AnyBitmap anyBitmap = AnyBitmap.FromFile("Potter.tiff");

// Import IronSoftware.Drawing.AnyBitmap
using var imageInput = new OcrImageInput(anyBitmap);
// Perform OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);