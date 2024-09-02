using IronOcr;
using System;

var image = @"paragraph_skewed.png";
var ocr = new IronTesseract();
using var input = new OcrInput();
// Load at least one image
input.LoadImage(image);

// Apply deskew with 15 degree snap
bool didDeskew = input.Deskew(15);
if (didDeskew)
{
    // Read image into variable: result
    var result = ocr.Read(input);
    Console.WriteLine(result.Text);
}
else
{
    Console.WriteLine("Deskew not applied because Image Orientation could not be determined.");
}