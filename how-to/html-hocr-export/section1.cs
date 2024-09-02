using IronOcr;

// Instantiate IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Enable render as hOCR
ocrTesseract.Configuration.RenderHocr = true;

// Add image
using var imageInput = new OcrImageInput("Potter.tiff");
imageInput.Title = "Html Title";

// Perform OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);

// Export as HTML
ocrResult.SaveAsHocrFile("result.html");