# Interpreting Barcodes and QR Codes using OCR

Optical Character Recognition (OCR) technology facilitates the automatic processing of barcodes and QR codes within both printed and digital documents. This capability enables automated data extraction from diverse sources, proving greatly beneficial for business operations and software development purposes.

IronOcr has simplified the automation of barcode and QR code detection, requiring only a minor adjustment to activate this feature.

## Barcode Reading Example

Firstly, create an instance of the IronTesseract class to initiate the OCR process. Activate the barcode detection feature by setting the **ReadBarCodes** property to true. Load the PDF document through the `OcrPdfInput` constructor and then deploy the `Read` method to commence the OCR on the loaded PDF document.

Here's an interactive view of a PDF document containing barcodes:

<iframe loading="lazy" src="https://ironsoftware.com/static-assets/ocr/how-to/barcodes/pdfWithBarcodes.pdf#view=fit" width="100%" height="400px"></iframe>

Below is the C# code snippet for reading barcodes:

```cs
using IronOcr;
using System;

// Create an IronTesseract instance
IronTesseract ocrTesseract = new IronTesseract();

// Activate barcode reading feature
ocrTesseract.Configuration.ReadBarCodes = true;

// Load the PDF
using var imageInput = new OcrPdfInput("pdfWithBarcodes.pdf");

// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);

// Display detected barcodes and text
Console.WriteLine("Extracted text:");
Console.WriteLine(ocrResult.Text);
Console.WriteLine("Extracted barcodes:");
foreach (var barcode in ocrResult.Barcodes)
{
    Console.WriteLine(barcode.Value);
}
```

Below is the captured image showing the output results of barcode reading:

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/barcodes/read-barcodes.webp" alt="Reading result" class="img-responsive add-shadow">
    </div>
</div>

The acquired barcode values from the extracted text are displayed below each barcode in the image.

## QR Code Interpretation Example

Configuring your system to read QR codes is similar to setting up barcode reading; ensure that the **ReadBarCodes** property is enabled. The PDF file path is the only variable that differs in the script. Below, we process a PDF document that contains QR codes:

<iframe loading="lazy" src="https://ironsoftware.com/static-assets/ocr/how-to/barcodes/pdfWithQrCodes.pdf#view=fit" width="100%" height="400px"></iframe>

The following C# script demonstrates the QR code reading process:

```cs
using IronOcr;
using System;

// Instantiate IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Turn on barcode reading feature
ocrTesseract.Configuration.ReadBarCodes = true;

// Import the PDF containing QR codes
using var imageInput = new OcrPdfInput("pdfWithQrCodes.pdf");

// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);

// Output detected text and barcodes
Console.WriteLine("Extracted text:");
Console.WriteLine(ocrResult.Text);
Console.WriteLine("Extracted barcodes:");
foreach (var barcode in ocrResult.Barcodes)
{
    Console.WriteLine(barcode.Value);
}
```

The image below exemplifies the outcomes of the QR code interpretation process:

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/barcodes/read-qr-codes.webp" alt="Reading result" class="img-responsive add-shadow">
    </div>
</div>

This streamlined approach allows developers to efficiently integrate barcode and QR code reading functionality into their applications.