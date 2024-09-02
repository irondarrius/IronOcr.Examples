using IronOcr;

IronTesseract ocr = new IronTesseract();
using OcrInput input = new OcrInput();

// We can also select specific PDF page numbers to OCR
input.LoadPdf("example.pdf", Password: "password");

OcrResult result = ocr.Read(input);
Console.WriteLine(result.Text);

// 1 page for every page of the PDF
Console.WriteLine($"{result.Pages.Length} Pages");