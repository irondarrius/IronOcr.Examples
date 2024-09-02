using IronOcr;

// Instantiate IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Add image
using var imageInput = new OcrImageInput("sample.tiff");
// Perform OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);

// Get confidence level
double confidence = ocrResult.Confidence;