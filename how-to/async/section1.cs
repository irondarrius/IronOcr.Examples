using IronOcr;
using System;

var ocr = new IronTesseract();

using (var input = new OcrPdfInput(@"example.pdf"))
{
    var result = ocr.Read(input);
    Console.WriteLine(result.Text);
};