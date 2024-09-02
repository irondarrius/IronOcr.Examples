using IronOcr;
using System;
using System.Threading.Tasks;

IronTesseract ocr = new IronTesseract();

using (OcrPdfInput largePdf = new OcrPdfInput("PDFs/example.pdf"))
{
    var result = await ocr.ReadAsync(largePdf);
    DoOtherTasks();
    Console.Write($"##### OCR RESULTS ###### " +
                $"\n {result.Text}");
}

static void DoOtherTasks()
{
    // Simulate other tasks being performed while OCR is in progress
    Console.WriteLine("Performing other tasks...");
    System.Threading.Thread.Sleep(2000); // Simulating work for 2000 milliseconds
}