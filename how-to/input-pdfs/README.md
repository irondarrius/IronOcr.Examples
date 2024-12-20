# PDF Reading Overview

***Based on <https://ironsoftware.com/how-to/input-pdfs/>***


PDF, which stands for "Portable Document Format," is a versatile file format developed by Adobe. It effectively preserves the fonts, images, graphics, and overall layout of any document, irrespective of the application or platform originally used to create it. This makes PDFs ideal for consistent document sharing and viewing across various devices. IronOcr is adept at handling different versions of PDF documents with ease.

<h3>Initializing IronOCR for OCR Tasks</h3>

---

## Reading PDF Example

Start by creating an instance of the `IronTesseract` class for Optical Character Recognition (OCR). Then, within a 'using' statement, initialize an `OcrPdfInput` object by providing the path to your PDF file. Finally, execute the OCR process by calling the `Read` method.

```cs
using IronOcr;

// Create an IronTesseract instance
IronTesseract ocrTesseract = new IronTesseract();

// Load a PDF
using var pdfInput = new OcrPdfInput("Potter.pdf");
// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(pdfInput);
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-pdfs/read-pdf.webp" alt="Read PDF file" class="img-responsive add-shadow">
    </div>
</div>

Generally, it's not necessary to adjust the DPI setting, but increasing this value in the `OcrPdfInput` constructor can improve the accuracy of the OCR results.

## Reading Specific PDF Pages Example

To read particular pages from a PDF, specify the page indices at which import should occur. While constructing the `OcrPdfInput`, pass these indices to the `PageIndices` parameter. Remember, these indices are zero-based.

```cs
using IronOcr;
using System.Collections.Generic;

// Initialize IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Define specific page indices to be read
List<int> pageIndices = new List<int>() { 0, 2 };

// Load PDF with specified pages
using var pdfInput = new OcrPdfInput("Potter.pdf", PageIndices: pageIndices);
// Process OCR
OcrResult ocrResult = ocrTesseract.Read(pdfInput);
```

## Setting Scanning Region

Focusing on a specific region of a PDF can substantially increase the precision and efficiency of the OCR process. This can be configured by setting specific areas for the OCR engine to analyze. The following example demonstrates how to instruct IronOcr to focus on specific sections of a document, such as extracting chapter numbers and titles.

```cs
using IronOcr;
using IronSoftware.Drawing;
using System;

// Create an IronTesseract instance
IronTesseract ocrTesseract = new IronTesseract();

// Define regions to scan
Rectangle[] scanRegions = { new Rectangle(550, 100, 600, 300) };

// Load PDF with specific content areas
using (var pdfInput = new OcrPdfInput("Potter.pdf", ContentAreas: scanRegions))
{
    // Execute OCR
    OcrResult ocrResult = ocrTesseract.Read(pdfInput);

    // Print the OCR results
    Console.WriteLine(ocrResult.Text);
}
```

### OCR Results Display

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-pdfs/read-specific-region.webp" alt="Read specific region" class="img-responsive add-shadow">
    </div>
</div>