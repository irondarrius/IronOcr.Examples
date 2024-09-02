using IronOcr;

// Instantiate IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Add image
using var imageInput = new OcrImageInput("Potter.png");

// Perform OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);