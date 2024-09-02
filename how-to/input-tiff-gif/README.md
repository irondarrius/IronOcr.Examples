# How to Utilize IronOCR for Multi-Frame/Page GIFs and TIFFs Reading

TIFF (Tagged Image File Format) is well-known for its high-quality image storage capabilities. It utilizes lossless compression, which preserves the image's original quality, making it ideal for applications such as scanned documents and professional photography.

GIF (Graphics Interchange Format), on the other hand, is often used for simple web graphics and animations. It supports both lossless and lossy compression and is renowned for its capability to hold multiple frames, enabling animations, making it a favorite for short loops used on websites and communication applications.

IronOCR offers comprehensive support for reading both single and multi-frame/page images in GIF and TIFF formats. Simply load the image using the methods provided and IronOCR will handle the rest efficiently.

## Example of Reading Single/Multi-Frame TIFF

When using OCR technology, you start by creating an instance of the `IronTesseract` class. Using the `using` statement helps manage resources efficiently by creating an instance of `OcrImageInput`. This supports reading both single and multi-frame TIFF and TIF files. After initializing, use the `Read()` method to apply OCR on your TIFF file.

```cs
using IronOcr;

// Create an instance of IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Load TIFF/TIF file
using var imageInput = new OcrImageInput("Potter.tiff");
// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-tiff-gif/read-tiff.webp" alt="Read TIFF image" class="img-responsive add-shadow">
    </div>
</div>

## Example of Reading a GIF File

Reading a GIF file is just as easy. You need to specify the path of the GIF file when creating the `OcrImageInput` instance. The class takes care of all the necessary steps to load the image.

```cs
using IronOcr;

// Initialize IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Load GIF file
using var imageInput = new OcrImageInput("Potter.gif");
// Apply OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);
```

## Define a Scan Region for OCR

Adding a `CropRectangle` during the construction of `OcrImageInput` allows you to specify a particular area in the image for OCR. This is particularly useful for large images where analyzing the entire image is unnecessary and resource-heavy.

```cs
using IronOcr;
using IronSoftware.Drawing;
using System;

// Create an instance of IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Define OCR scan region
Rectangle scanRegion = new Rectangle(800, 200, 900, 400);

// Load image with specific scan area
using var imageInput = new OcrImageInput("Potter.tiff", ContentArea: scanRegion);
// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);

// Print the result
Console.WriteLine(ocrResult.Text);
```

### Displaying OCR Results

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-images/read-specific-region.webp" alt="Read specific region" class="img-responsive add-shadow">
    </div>
</div>