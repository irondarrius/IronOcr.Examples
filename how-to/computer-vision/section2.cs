using IronOcr;

var ocr = new IronTesseract();
using var input = new OcrInput();
input.LoadImage("/path/file.png");

input.FindTextRegion(Scale: 2.0, DilationAmount: 20, Binarize: true, Invert: true);
OcrResult result = ocr.Read(input);
string resultText = result.Text;