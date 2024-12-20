# Reading Images with OCR

***Based on <https://ironsoftware.com/how-to/input-images/>***


Optical Character Recognition (OCR) is a transformative technology used to identify and extract text embedded within images. It proves invaluable in converting printed contents into editable formats, facilitating the handling of text from images such as scanned documents, photos, and digital files.

IronOCR seamlessly handles various image formats including JPG, PNG, GIF, TIFF, and BMP, and offers image filters to improve text extraction accuracy.

### Initiating IronOCR

---

## Example: Reading Images

To begin, create an instance of the `IronTesseract` class to access OCR functionalities. Using the `using` statement, set up an `OcrImageInput` for the image you intend to read, ensuring efficient resource management. IronOCR is compatible with multiple image formats such as JPG, PNG, GIF, TIFF, and BMP. Execute the OCR process by calling the `Read` method.

```cs
using IronOcr;

// Create an instance of IronTesseract
IronTesseract ocrEngine = new IronTesseract();

// Configure the image input
using var imageInput = new OcrImageInput("Potter.png");

// Execute OCR
OcrResult ocrText = ocrEngine.Read(imageInput);
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-images/read-png.webp" alt="Read PNG image" class="img-responsive add-shadow">
    </div>
</div>

Discover advanced techniques in reading multi-frame images by exploring our guide on [Reading Multi-Frame/Page GIFs and TIFFs](https://ironsoftware.com/csharp/ocr/how-to/input-tiff-gif/).

## Reading Images from Various Sources

IronOCR's `OcrImageInput` not only takes file paths but can also handle images from bytes, streams, `AnyBitmap` objects, and more. `AnyBitmap` refers to a bitmap type defined by [IronSoftware.Drawing.AnyBitmap](https://ironsoftware.com/open-source/csharp/drawing/examples/bitmap-to-stream/).

```cs
using IronOcr;
using System.IO;

// Initialize the OCR engine
IronTesseract ocrEngine = new IronTesseract();

// Read image as byte array
byte[] imageData = File.ReadAllBytes("Potter.tiff");

// Setup image input from bytes
using var imageInput = new OcrImageInput(imageData);
// Execute OCR
OcrResult processedText = ocrEngine.Read(imageInput);
```

## Defining Specific Scan Regions

You can enhance efficiency by defining a specific region of the image for OCR with a `CropRectangle`. Focusing on particular areas of an image can lead to faster processing and more accurate results. Below is an example where only a selected part of the image is processed.

```cs
using IronOcr;
using IronSoftware.Drawing;
using System;

// Initialize OCR functionality
IronTesseract ocrEngine = new IronTesseract();

// Define the area to be OCR'ed
Rectangle regionOfInterest = new Rectangle(800, 200, 900, 400);

// Configure image input with specific region
using var imageInput = new OcrImageInput("Potter.tiff", ContentArea: regionOfInterest);
// Process OCR
OcrResult ocrContent = ocrEngine.Read(imageInput);

// Display OCR results
Console.WriteLine(ocrContent.Text);
```

### Reviewing OCR Outputs

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-images/read-specific-region.webp" alt="Read specific region" class="img-responsive add-shadow">
    </div>
</div>