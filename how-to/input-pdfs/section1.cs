using IronOcr;

// Instantiate IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Add PDF
using var pdfInput = new OcrPdfInput("Potter.pdf");
// Perform OCR
OcrResult ocrResult = ocrTesseract.Read(pdfInput);