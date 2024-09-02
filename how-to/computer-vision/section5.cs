using IronOcr;

var ocr = new IronTesseract();
using var input = new OcrInput();
input.LoadImage("/path/file.png");

input.FindMultipleTextRegions(Scale: 2.0, DilationAmount: -1, Binarize: true, Invert: false);
OcrResult result = ocr.Read(input);
string resultText = result.Text;