using IronOcr;
using System;

var image = @"no-binarize.jpg";
var ocr = new IronTesseract();

using var input = new OcrInput();
// Load at least one image
input.LoadImage(image);

// Apply Binarize
input.Binarize();

// Read image into variable: result
var result = ocr.Read(input);

// Example print to console
Console.WriteLine(result.Text);