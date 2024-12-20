# Managing Multi-Frame/Page GIFs and TIFFs with IronOCR

***Based on <https://ironsoftware.com/how-to/input-tiff-gif/>***


TIFF (Tagged Image File Format) is favored for storing images in high quality. Its ability to use lossless compression is particularly useful for retaining the pristine quality of scanned documents and professional photographs.

On the other hand, GIF (Graphics Interchange Format) is typically used for creating lightweight, web-optimized images and animations. This format is celebrated for its capability to house animated sequences in a single file, leading to its prevalent use in web graphics and digital communications.

IronOCR seamlessly handles both TIFF and GIF formats, including those with multiple frames or pages. Just load your image file with our easy-to-use methods, and let IronOCR take care of the rest.

<h3>Get Started with IronOCR</h3>

---

## Example: OCR on Single/Multi-Frame TIFF

First, create an instance of the `IronTesseract` class. Use a `using` statement for memory management and initialize an `OcrImageInput` object to handle either single or multi-frame TIFF files. Then, apply the `Read` method to start the OCR process on the TIFF.

```cs
using IronOcr;

// Create an IronTesseract instance
IronTesseract ocrTesseract = new IronTesseract();

// Load the TIFF image into IronOCR
using var imageInput = new OcrImageInput("Potter.tiff");

// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-tiff-gif/read-tiff.webp" alt="Read TIFF image" class="img-responsive add-shadow">
    </div>
</div>

## OCR with GIFs

To read GIF images, just specify the path to your GIF file while initializing your `OcrImageInput`. The constructor automatically handles the image loading.

```cs
using IronOcr;

// Initialize IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Load GIF for OCR
using var imageInput = new OcrImageInput("Potter.gif");

// Start OCR process
OcrResult ocrResult = ocrTesseract.Read(imageInput);
```

## Defining a Scan Region

You can enhance OCR performance by defining a specific scan region within the image. Create a `CropRectangle` during the initialization of `OcrImageInput` to specify the area you want to focus on.

```cs
using IronOcr;
using IronSoftware.Drawing;  // Needed for Rectangle
using System;  // Using System for the Console class

// Initialize IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Define the crop area
Rectangle scanRegion = new Rectangle(800, 200, 900, 400);

// Load the Image with defined crop region
using var imageInput = new OcrImageInput("Potter.tiff", ContentArea: scanRegion);

// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);

// Print OCR results
Console.WriteLine(ocrResult.Text);
```

### Viewing OCR Results

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-images/read-specific-region.webp" alt="Read specific region" class="img-responsive add-shadow">
    </div>
</div>