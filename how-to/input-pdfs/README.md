# How to Read PDFs

PDF stands for "Portable Document Format." Created by Adobe, this file format ensures the preservation of all visual elements including fonts, images, and layouts no matter which application or platform was originally used to create the document. PDFs are primarily utilized for document sharing and viewing, maintaining a consistent appearance across all software and hardware environments. The IronOcr library is adept at managing various versions of PDF documents smoothly.

## Read PDF Example

Start by creating an instance of the `IronTesseract` class to utilize OCR capabilities. Proceed by setting up a `using` statement to manage an `OcrPdfInput` instance, into which you feed the path of the PDF file. Then, execute the OCR process by calling the `Read` method.

```cs
using IronOcr;

// Create a new IronTesseract instance
IronTesseract ocrTesseract = new IronTesseract();

// Define the PDF input
using var pdfInput = new OcrPdfInput("Potter.pdf");
// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(pdfInput);
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-pdfs/read-pdf.webp" alt="Read PDF file" class="img-responsive add-shadow">
    </div>
</div>

Typically, it is not necessary to adjust the DPI settings. However, setting a higher DPI via the `OcrPdfInput` constructor can improve the accuracy of the read.

## Read PDF Pages Example

To read specific pages within a PDF, specify the desired page index numbers. Insert these indices into the `PageIndices` parameter when creating the `OcrPdfInput`. Remember that pages are specified with zero-based indexing.

```cs
using IronOcr;
using System.Collections.Generic;

// Create a new IronTesseract instance
IronTesseract ocrTesseract = new IronTesseract();

// Define a list of page indices
List<int> pageIndices = new List<int>() { 0, 2 };

// Setup PDF input with specific pages
using var pdfInput = new OcrPdfInput("Potter.pdf", PageIndices: pageIndices);
// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(pdfInput);
```

## Specify Scan Region

For improved efficiency, you can limit OCR to specific areas of the PDF. Below, the process focuses only on a designated section meant to extract chapter numbers and titles.

```cs
using IronOcr;
using IronSoftware.Drawing;
using System;

// Create a new IronTesseract instance
IronTesseract ocrTesseract = new IronTesseract();

// Define scan regions
Rectangle[] scanRegions = { new Rectangle(550, 100, 600, 300) };

// Configure PDF input with specific content areas
using (var pdfInput = new OcrPdfInput("Potter.pdf", ContentAreas: scanRegions))
{
    // Execute OCR
    OcrResult ocrResult = ocrTesseract.Read(pdfInput);

    // Display the OCR result
    Console.WriteLine(ocrResult.Text);
}
```

### OCR Result

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-pdfs/read-specific-region.webp" alt="Read specific region" class="img-responsive add-shadow">
    </div>
</div>