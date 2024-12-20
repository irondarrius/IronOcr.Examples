# Extracting Read Results

***Based on <https://ironsoftware.com/how-to/read-results/>***


The OCR or read result contains detailed information about the paragraphs, lines, words, and individual characters detected. For each component, an extensive array of details is provided, including the text itself, exact X and Y coordinates, dimensions, text direction, and location within a [`CropRectangle`](https://ironsoftware.com/open-source/csharp/drawing/examples/convert-measurement-unit-of-croprectangle/) object.

### Starting with IronOCR

----------------------------------------

## Insights from OcrResult

The `OcrResult` not only yields the extracted text but also offers insights about the pages, paragraphs, lines, words, characters, and barcodes found in PDFs and image documents using IronOcr. You can fetch this data from the `OcrResult` object through the `Read` method.

```cs
using IronOcr;
using System;

// Initialize IronTesseract
IronTesseract ocr = new IronTesseract();

// Load image
using var image = new OcrImageInput("sample.jpg");
// Execute OCR
OcrResult result = ocr.Read(image);

// Access detected paragraphs
Paragraph[] detectedParagraphs = result.Paragraphs;

// Display information
Console.WriteLine($"Text: {detectedParagraphs[0].Text}");
Console.WriteLine($"X: {detectedParagraphs[0].X}");
Console.WriteLine($"Y: {detectedParagraphs[0].Y}");
Console.WriteLine($"Width: {detectedParagraphs[0].Width}");
Console.WriteLine($"Height: {detectedParagraphs[0].Height}");
Console.WriteLine($"Text Direction: {detectedParagraphs[0].TextDirection}");
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-results/result.webp" alt="Data in OcrResult" class="img-responsive add-shadow">
    </div>
</div>

For each text component such as paragraphs, lines, words, and characters, details provided include:

- Text: The extracted text.
- X: Horizontal positioning from the left margin in pixels.
- Y: Vertical positioning from the top margin in pixels.
- Width: The text width in pixels.
- Height: The text height in pixels.
- Text Direction: The orientation of the text, either 'Left to Right' or 'Top to Bottom.'
- Location: A rectangle indicating the text location in pixels.

## Comparison of Text Elements

Here we compare the detected paragraphs, lines, words, and characters visually:

<table class="table" style="text-align: center; background-color:
#f1f9fb;">
    <tr>
        <td style="width: 50%;">
        <div class="content-img-align-center">
            <div class="center-image-wrapper">
                <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-results/paragraph.webp" alt="Highlight paragraph" class="img-responsive add-shadow" >
                <p class="competitors__download-link" style="color: #181818; font-style: italic;">Paragraph</p>
            </div>
        </div>
        </td>
        <td style="width: 50%;">
        <div class="content-img-align-center">
            <div class="center-image-wrapper">
                <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-results/line.webp" alt="Highlight line" class="img-responsive add-shadow" >
                <p class="competitors__download-link" style="color: #181818; font-style: italic;">Line</p>
            </div>
        </div>
        </td>
    </tr>
    <tr>
        <td>
        <div class="content-img-align-center">
            <div class="center-image-wrapper">
                <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-results/word.webp" alt="Highlight word" class="img-responsive add-shadow" >
                <p class="competitors__download-link" style="color: #181818; font-style: italic;">Word</p>
            </div>
        </div>
        </td>
        <td>
        <div class="content-img-align-center">
            <div the "center-image-wrapper">
                <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-results/character.webp" alt="Highlight character" class="img-responsive add-shadow" >
                <p class="competitors__download-link" style="color: #181818; font-style: italic;">Character</p>
            </div>
        </div>
        </td>
    </tr>
</table>

## Barcode and QR Code Recognition

Indeed, IronOcr is capable of reading barcodes and QR codes. Although it might not be as comprehensive as IronBarcode, IronOcr still supports the detection of common barcode types. Activate this feature by setting the **Configuration.ReadBarCodes** to true.

Further, the barcode detection reveals essential details such as the barcode format, value, positions (x, y), size, and the placement within an [`Rectangle`](https://ironsoftware.com/open-source/csharp/drawing/docs/) object for precise localization on the document.

```cs
using IronOcr;
using System;

// Initialize IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Enable barcode detection
ocrTesseract.Configuration.ReadBarCodes = true;

// Load PDF
using OcrInput input = new OcrInput();
input.LoadPdf("sample.pdf");

// Carry out OCR
OcrResult result = ocrTesseract.Read(input);

// Output barcode details to console
foreach(var barcode in result.Barcodes)
{
    Console.WriteLine("Format = " + barcode.Format);
    Console.WriteLine("Value = " + barcode.Value);
    Console.WriteLine("X = " + barcode.X);
    Console.WriteLine("Y = " + barcode.Y);
}
Console.WriteLine(result.Text);
```

### Output
<div class="content-img-align-center">
    <div "center-image-wrapper">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-results/barcodes.webp" alt="Detect barcodes" class="img-responsive add-shadow" >
    </div>
</div>