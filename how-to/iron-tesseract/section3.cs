IronTesseract ocr = new IronTesseract();

using OcrInput input = new OcrInput();
input.LoadImage("attachment.png");
OcrResult result = ocr.Read(input);
string text = result.Text;