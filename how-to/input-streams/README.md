# How to Read from Streams

***Based on <https://ironsoftware.com/how-to/input-streams/>***


In computing, "stream data" refers to a continuous sequence of binary data that can be incrementally read or written. Streams are particularly useful when processing large datasets that might not fit completely into memory, allowing for data handling in manageable portions.

IronOcr supports reading from data streams, specifically for images. This functionality allows you to directly pass a stream into its import methods for image reading and processing.

<h3>Getting Started with IronOCR</h3>

--------------------------------------

## Reading Streams Example

Begin by creating an instance of the **IronTesseract** class to execute OCR operations. Utilize the `FromFile` method of the AnyBitmap class to load an image. This method converts the image file into a data stream. By utilizing the `using` statement, you can create an `OcrImageInput` instance by feeding it the stream from the AnyBitmap's `GetStream` method. Complete the process by invoking the `Read` method to perform OCR.

```cs
using IronOcr;
using IronSoftware.Drawing;

// Create an IronTesseract instance
IronTesseract ocrTesseract = new IronTesseract();

// Load the image into AnyBitmap
AnyBitmap anyBitmap = AnyBitmap.FromFile("Potter.tiff");

// Convert image to stream
using var imageInput = new OcrImageInput(anyBitmap.GetStream());
// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);
```

## Specifying a Scan Region

To enhance OCR performance on large images or to focus on specific areas of the image, use the CropRectangle class. When constructing the OcrImageInput, you can pass a CropRectangle instance as an additional parameter to define the image area to be analyzed. The following example demonstrates setting this up to only read the region containing a chapter number and title.

```cs
using IronOcr;
using IronSoftware.Drawing;
using System;

// Initialize IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Load the image to AnyBitmap
AnyBitmap anyBitmap = AnyBitmap.FromFile("Potter.tiff");

// Define the area of interest
Rectangle scanRegion = new Rectangle(800, 200, 900, 400);

// Prepare the image for OCR
using var imageInput = new OcrImageInput(anyBitmap.GetStream(), ContentArea: scanRegion);
// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);

// Display the OCR result
Console.WriteLine(ocrResult.Text);
```

### OCR Result

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-images/read-specific-region.webp" alt="Read specific region" class="img-responsive add-shadow">
    </div>
</div>