using IronOcr;

// Instantiate IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Add image
using var imageInput = new OcrImageInput("sample.jpg");
// Apply sharpen filter
imageInput.Sharpen();

// Export filtered image
imageInput.SaveAsImages("sharpen");