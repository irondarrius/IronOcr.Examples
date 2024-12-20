# How to Decode Barcodes and QR Codes

***Based on <https://ironsoftware.com/how-to/barcodes/>***


Decoding barcodes and QR codes using OCR technology offers a major advantage when these elements need to be integrated and processed from both printed and digital documents. This approach automates data extraction across various media, offering a flexible tool for businesses and developers alike.

IronOcr simplifies the task of detecting barcodes and QR codes, requiring minimal configuration for activation.

<h3>Getting Started with IronOCR</h3>

--------------------------------------

## Barcode Reading Example

Initialize the `IronTesseract` class to start the decoding process. Activate barcode reading by setting the `ReadBarCodes` attribute to true. Load the PDF through the `OcrPdfInput` constructor. Subsequently, apply the `Read` method to execute OCR on the loaded PDF document.

Consider the OCR operation on this PDF document:

<iframe loading="lazy" src="https://ironsoftware.com/static-assets/ocr/how-to/barcodes/pdfWithBarcodes.pdf#view=fit" width="100%" height="400px">
</iframe>

```cs
using IronOcr;
using System;

// Create an IronTesseract instance
IronTesseract ocrEngine = new IronTesseract();

// Turn on barcode detection
ocrEngine.Configuration.ReadBarCodes = true;

// Load the PDF
using var documentInput = new OcrPdfInput("pdfWithBarcodes.pdf");

// Execute OCR
OcrResult result = ocrEngine.Read(documentInput);

// Display the results
Console.WriteLine("Text extracted:");
Console.WriteLine(result.Text);
Console.WriteLine("Barcodes detected:");
foreach (var barcode in result.Barcodes)
{
    Console.WriteLine(barcode.Value);
}
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/barcodes/read-barcodes.webp" alt="Reading result" class="img-responsive add-shadow">
    </div>
</div>

Multiple barcode values can be seen in the output alongside the text extracted from them.

## Example of QR Code Reading

Set the `ReadBarCodes` to true, similar to barcode reading. The modification in the file path marks the only difference in the setup. Now, let's decode a PDF document embedded with QR codes:

<iframe loading="lazy" src="https://ironsoftware.com/static-assets/ocr/how-to/barcodes/pdfWithQrCodes.pdf#view=fit" width="100%" height="400px">
</iframe>

```cs
using IronOcr;
using System;

// Initialize IronTesseract
IronTesseract ocrReader = new IronTesseract();

// Activate barcode detection
ocrReader.Configuration.ReadBarCodes = true;

// Incorporate the PDF
using var inputFile = new OcrPdfInput("pdfWithQrCodes.pdf");

// Execute OCR
OcrResult decodedResult = ocrReader.Read(inputFile);

// Output results
Console.WriteLine("Text decoded:");
Console.WriteLine(decodedResult.Text);
Console.WriteLine("Barcodes decoded:");
foreach (var barcode in decodedResult.Barcodes)
{
    Console.WriteLine(barcode.Value);
}
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/barcodes/read-qr-codes.webp" alt="Reading result" class="img-responsive add-shadow">
    </div>
</div>

These examples display the straightforward integration and robust capabilities of IronOCR for automating the extraction of information from barcodes and QR codes embedded in documents.