using IronOcr;
using System;

// Instantiate IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Enable barcode reading
ocrTesseract.Configuration.ReadBarCodes = true;

// Add PDF
using var imageInput = new OcrPdfInput("pdfWithBarcodes.pdf");

// Perform OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);

// Output detected barcodes and text values
Console.WriteLine("Extracted text:");
Console.WriteLine(ocrResult.Text);
Console.WriteLine("Extracted barcodes:");
foreach (var barcode in ocrResult.Barcodes)
{
    Console.WriteLine(barcode.Value);
}