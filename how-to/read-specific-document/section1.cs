using IronOcr;
using System;

// Instantiate OCR engine
var ocr = new IronTesseract();

// Configure OCR engine
ocr.Configuration.PageSegmentationMode = TesseractPageSegmentationMode.SingleBlock;

using var input = new OcrInput();

input.LoadPdf("Five.pdf");

// Perform OCR
OcrResult result = ocr.ReadDocument(input);

Console.WriteLine(result.Text);