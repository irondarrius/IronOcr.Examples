# Extracting Read Results Overview

The OCR or read results from IronOcr deliver a detailed breakdown of all textual elements identified in the document. These elements include paragraphs, lines, words, and individual characters. Each element is enriched with valuable data.

For every element identified (paragraphs, lines, etc.), the provided information encompasses the text itself, its precise positioning via X and Y coordinates, dimensions such as width and height, text orientation (either Left to Right or Top to Bottom), and encapsulation inside a [CropRectangle](https://ironsoftware.com/open-source/csharp/drawing/examples/convert-measurement-unit-of-croprectangle/) structure.

## Insights from OcrResult

Aside from the actual extracted text, the `OcrResult` packs details on pages, paragraphs, lines, words, and even barcodes detected in any image or PDF document processed by IronOcr. This data is accessible through the `Read` method attached to the `OcrResult` object.

```cs
using IronOcr;
using System;
using static IronOcr.OcrResult;

// Creating a new IronTesseract instance
var ocrTesseract = new IronTesseract();

// Load image into OCR
using var imageInput = new OcrImageInput("sample.jpg");
// Running OCR process
var ocrResult = ocrTesseract.Read(imageInput);

// Gather detected paragraphs
var paragraphs = ocrResult.Paragraphs;

// Display results
Console.WriteLine($"Text: {paragraphs[0].Text}");
Console.WriteLine($"X Coordinate: {paragraphs[0].X}");
Console.WriteLine($"Y Coordinate: {paragraphs[0].Y}");
Console.WriteLine($"Width: {paragraphs[0].Width}");
Console.WriteLine($"Height: {paragraphs[0].Height}");
Console.WriteLine($"Reading Text Direction: {paragraphs[0].TextDirection}");
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-results/result.webp" alt="Data in OcrResult" class="img-responsive add-shadow">
    </div>
</div>

In detail, each text segment offers the following specifics:

- Text: Rendered as a string.
- X: Horizontal offset from page's left margin in pixels.
- Y: Vertical offset from the top margin in pixels.
- Width and Height: Dimensions of the text box in pixels.
- Text Direction: Orientation in which the text is read, such as 'Left to Right' or 'Top to Bottom.'
- Location: Demonstrated by a rectangle which frames the text on the page.

## Detailed Comparison of Text Elements

Here’s a clear comparison among detected paragraphs, lines, words, and individual characters.

<table class="table" style="text-align: center; background-color: #f1f9fb;">
    <tr>
        <td style="width: 50%;">
        <div class="content-img-align-center">
            <div class="center-image-wrapper">
                <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-results/paragraph.webp" alt="Highlight paragraph" class="img-responsive add-shadow">
                <p class="competitors__download-link" style="color: #181818; font-style: italic;">Paragraph</p>
            </div>
        </div>
        </td>
        <td style="width: 50%;">
        <div class="content-img-align-center">
            <div class="center-image-wrapper">
                <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-results/line.webp" alt="Highlight line" class="img-responsive add-shadow">
                <p class="competitors__download-link" style="color: #181818; font-style: italic;">Line</p>
            </div>
        </div>
        </td>
    </tr>
    <tr>
        <td>
        <div class="content-img-align-center">
            <div class="center-image-wrapper">
                <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-results/word.webp" alt="Highlight word" class="img-responsive add-shadow">
                <p class="competitors__download-link" style="color: #181818; font-style: italic;">Word</p>
            </div>
        </div>
        </td>
        <td>
        <div class="content-img-align-center">
            <div class="center-image-wrapper">
                <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-results/character.webp" alt="Highlight character" class="img-responsive add-shadow">
                <p class="competitors__download-link" style="color: #181818; font-style: italic;">Character</p>
            </div>
        </div>
        </td>
    </tr>
</table>

## Barcode and QR Code Recognition

Indeed, IronOcr also handles barcode and QR code recognition. Although not as specialized as IronBarcode, IronOcr supports the recognition of several common barcode formats. Activate this feature by setting the `Configuration.ReadBarCodes` property to true.

This also includes capturing valuable metadata from each barcode like format, value, and position, represented using the **Rectangle** class from [IronDrawing](https://ironsoftware.com/open-source/csharp/drawing/docs/).

```cs
using IronOcr;
using System;
using static IronOcr.OcrResult;

var ocrTesseract = new IronTesseract();

// Enable barcode recognition
ocrTesseract.Configuration.ReadBarCodes = true;

using var ocrInput = new OcrInput();
ocrInput.LoadPdf("sample.pdf");

var ocrResult = ocrTesseract.Read(ocrInput);

foreach(var barcode in ocrResult.Barcodes)
{
    Console.WriteLine($"Format: {barcode.Format}");
    Console.WriteLine($"Value: {barcode.Value}");
    Console.WriteLine($"X Position: {barcode.X}");
    Console.WriteLine($"Y Position: {barcode.Y}");
}
Console.WriteLine($"Recognized Text: {ocrResult.Text}");
```

### Barcode Output Visualization
<div class="content-img-align-center">
    <div class="center-image-wrapper">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-results/barcodes.webp" alt="Detect barcodes" class="img-responsive add-shadow">
    </div>
</div>