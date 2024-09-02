using IronOcr;
using System;

IronTesseract Ocr = new IronTesseract();

Ocr.Language = OcrLanguage.English;
Ocr.Configuration.PageSegmentationMode = TesseractPageSegmentationMode.AutoOsd;

// Configure Tesseract Engine
Ocr.Configuration.TesseractVariables["tessedit_parallelize"] = false;

using var input = new OcrInput();
input.LoadImage("/path/file.png");

OcrResult Result = Ocr.Read(input);
Console.WriteLine(Result.Text);