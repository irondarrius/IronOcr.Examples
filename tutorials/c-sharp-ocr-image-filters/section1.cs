using IronOcr;
using System;

var ocr = new IronTesseract();
using var input = new OcrInput();
input.LoadImage("my_image.png");
input.Deskew();

var result = ocr.Read(input);
Console.WriteLine(result.Text);