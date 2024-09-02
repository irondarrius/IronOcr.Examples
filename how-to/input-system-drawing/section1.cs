using IronOcr;
using System.Drawing;

// Instantiate IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Read image file to Bitmap
Bitmap bitmap = new Bitmap("Potter.tiff");

// Import System.Drawing.Bitmap
using var imageInput = new OcrImageInput(bitmap);
// Perform OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);