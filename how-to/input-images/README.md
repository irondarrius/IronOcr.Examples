# Reading Text from Images with OCR Technology

Optical Character Recognition (OCR) technology enables the identification and extraction of text from images. This is incredibly beneficial for converting printed documents into a digital format, allowing the manipulation and use of text from scans, photos, and other image-based files.

The IronOCR library is adept at processing various image formats such as jpg, png, gif, tiff, and bmp. It includes image filters which enhance its ability to accurately read text.

## Example: Using OCR to Read Images

To begin OCR operations with IronOCR, you first need to create an instance of the `IronTesseract` class. With a `using` statement, construct an `OcrImageInput` object by providing the path to the image. This approach ensures that system resources are managed efficiently by disposing of them when they are not needed anymore. IronOCR can handle different image formats like jpg, png, gif, tiff, and bmp. To execute the OCR process, call the `Read` method.

```cs
using IronOcr;

// Create a new instance of IronTesseract
IronTesseract ocr = new IronTesseract();

// Load the image
using var imageInput = new OcrImageInput("Potter.png");

// Execute OCR
OcrResult result = ocr.Read(imageInput);
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-images/read-png.webp" alt="Read PNG image" class="img-responsive add-shadow">
    </div>
</div>

For detailed guidance on processing multi-frame/page GIF and TIFF images, check out [How to Read Multi-Frame/Page GIFs and TIFFs](https://ironsoftware.com/csharp/ocr/how-to/input-tiff-gif/).

## Importing Image Data Directly

Beyond simple file paths, the `OcrImageInput` class is versatile in accepting image data in bytes, `AnyBitmap`, `Stream`, and `Image`. The `AnyBitmap` refers to an object from [IronSoftware.Drawing.AnyBitmap](https://ironsoftware.com/open-source/csharp/drawing/examples/bitmap-to-stream/).

```cs
using IronOcr;
using System.IO;

// Initialize IronTesseract
IronTesseract ocr = new IronTesseract();

// Read image bytes from a file
byte[] imageData = File.ReadAllBytes("Potter.tiff");

// Load image from bytes
using var imageInput = new OcrImageInput(imageData);
// Execute OCR
OcrResult result = ocr.Read(imageInput);
```

## Defining the Scanning Area

You can increase the efficiency and focus of OCR by defining a crop rectangle when creating `OcrImageInput`. This allows you to specify the exact area of the image that should be scanned for text. In the example below, the crop rectangle isolates a chapter number and title.

```cs
using IronOcr;
using IronSoftware.Drawing;
using System;

// Create an instance of IronTesseract
IronTesseract ocr = new IronTesseract();

// Define the scanning area
Rectangle cropArea = new Rectangle(800, 200, 900, 400);

// Load the image with specified content area
using var imageInput = new OcrImageInput("Potter.tiff", ContentArea: cropArea);
// Perform OCR
OcrResult result = ocr.Read(imageInput);

// Print the extracted text
Console.WriteLine(result.Text);
```

### OCR Outcome

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-images/read-specific-region.webp" alt="Read specific region" class="img-responsive add-shadow">
    </div>
</div>