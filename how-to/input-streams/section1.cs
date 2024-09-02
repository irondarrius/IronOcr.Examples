using IronOcr;
using IronSoftware.Drawing;

// Instantiate IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Read image file to AnyBitmap
AnyBitmap anyBitmap = AnyBitmap.FromFile("Potter.tiff");

// Import image stream
using var imageInput = new OcrImageInput(anyBitmap.GetStream());
// Perform OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);