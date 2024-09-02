using IronOcr;

var ocr = new IronTesseract();
ocr.Language = OcrLanguage.Arabic;

using var input = new OcrInput();
var pageindices = new int[] { 1, 2 };
input.LoadImageFrames("img/arabic.gif", pageindices);

// Add image filters if needed
// In this case, even thought input is very low quality
// IronTesseract can read what conventional Tesseract cannot.

var result = ocr.Read(input);

// Console can't print Arabic on Windows easily.
// Let's save to disk instead.
result.SaveAsTextFile("arabic.txt");