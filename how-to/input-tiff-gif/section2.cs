using IronOcr;

// Instantiate IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Import GIF
using var imageInput = new OcrImageInput("Potter.gif");
// Perform OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);