# How to Interpret OCR Results

***Based on <https://ironsoftware.com/how-to/read-results/>***


The OCR or optical character recognition outcome delivers detailed data about the recognized paragraphs, lines, words, and characters. For each of these segments, detailed information is provided including their content, position, and dimensions.

Each segment furnishes details such as textual content, exact `X` and `Y` coordinates, size (width and height), the direction of the text (from Left to Right or Top to Bottom), and placement within a [`CropRectangle`](https://ironsoftware.com/open-source/csharp/drawing/examples/convert-measurement-unit-of-croprectangle/) structure.

## Content of OcrResult

The returned `OcrResult` does more than just provide the extracted text; it encompasses data about pages, paragraphs, lines, words, characters, and barcodes found in the scanned PDF or image document. This data can be accessed from the `OcrResult` object using the `Read` method.

```cs
using System;
using IronOcr;
namespace ironocr.ReadResults
{
    public class Section1
    {
        public void Run()
        {
            // Create an instance of IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Load an image
            using var imageInput = new OcrImageInput("sample.jpg");
            // Execute the OCR process
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
            
            // Access paragraphs from the OCR result
            Paragraph[] paragraphs = ocrResult.Paragraphs;
            
            // Display paragraph details to console
            Console.WriteLine($"Text: {paragraphs[0].Text}");
            Console.WriteLine($"X: {paragraphs[0].X}");
            Console.WriteLine($"Y: {paragraphs[0].Y}");
            Console.WriteLine($"Width: {paragraphs[0].Width}");
            Console.WriteLine($"Height: {paragraphs[0].Height}");
            Console.WriteLine($"Text direction: {paragraphs[0].TextDirection}");
        }
    }
}
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-results/result.webp" alt="Data in OcrResult" class="img-responsive add-shadow">
    </div>
</div>

For each text section like paragraphs, lines, words, and characters, the details are as follows:

- Text: The textual content as a string.
- X: Horizontal position from the left edge of the page, measured in pixels.
- Y: Vertical position from the top edge of the page, in pixels.
- Width: The span in pixels.
- Height: The vertical extent in pixels.
- Text Direction: The orientation in which the text is read (e.g., 'Left to Right' or 'Top to Bottom').
- Location: The bounding rectangle that encloses the text, described in pixels.

## Comparing Paragraphs, Lines, Words, and Characters

Here is a visual comparison of the recognized paragraphs, lines, words, and characters.

<table class="table" style="text-align: center; background-color: #f1f9fb;">
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
            <div class="center-image-wrapper">
                <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-results/character.webp" alt="Highlight character" class="img-responsive add-shadow" >
                <p class="competitors__download-link" style="color: #181818; font-style: italic;">Character</p>
            </div>
        </div>
        </td>
    </tr>
</table>

## Barcode and QR Code Recognition

Indeed! Apart from text, IronOcr is capable of reading barcodes and QR codes. While it's not as specialized as IronBarcode, it indeed supports various common barcode formats. To activate barcode detection, simply set the `Configuration.ReadBarCodes` property to true.

The following snippet demonstrates how to extract barcode information, which includes the barcode format, value, and geometric details:

```cs
using System;
using IronOcr;
namespace ironocr.ReadResults
{
    public class Section2
    {
        public void Run()
        {
            // Initialize IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Activate barcode reading
            ocrTesseract.Configuration.ReadBarCodes = true;
            
            // Load a PDF file
            using OcrInput ocrInput = new OcrInput("sample.pdf");
            
            // Perform the OCR operation
            OcrResult ocrResult = ocrTesseract.Read(ocrInput);
            
            // Print barcode details
            foreach(var barcode in ocrResult.Barcodes)
            {
                Console.WriteLine("Format = " + barcode.Format);
                Console.WriteLine("Value = " + barcode.Value);
                Console.WriteLine("X = " + barcode.X);
                Console.WriteLine("Y = " + barcode.Y);
            }
            Console.WriteLine(ocrResult.Text);
        }
    }
}
```

### Output
<div class="content-img-align-center">
    <div class="center-image-wrapper">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-results/barcodes.webp" alt="Detect barcodes" class="img-responsive add-shadow" >
    </div>
</div>