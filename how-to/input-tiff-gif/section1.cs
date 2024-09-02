using IronOcr;

// Instantiate IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Import TIFF/TIF
using var imageInput = new OcrImageInput("Potter.tiff");
// Perform OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);