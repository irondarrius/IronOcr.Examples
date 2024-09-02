# Reading from Data Streams

Data streams are continuous sequences of binary data processed dynamically, often because they're too substantial to store fully in memory. This dynamic handling is essential for managing large datasets efficiently, chunk by chunk.

IronOcr supports this model by allowing streams of image data, which can be imported directly into its OCR functions. This involves simply passing the stream to one of IronOcr's import methods, which orchestrates the necessary steps to read from the stream.

## Example: Reading Streams with IronOcr

To start, create an instance of the **IronTesseract** class for OCR operations. Use the `FromFile` method on `AnyBitmap` to load the image, which then can convert the image data to a stream. Subsequently, with a 'using' statement, create an instance of `OcrImageInput` by supplying the stream via the `GetStream` method from `AnyBitmap`. Perform OCR by calling the `Read` method.

```cs
using IronOcr;
using IronSoftware.Drawing;

// Create an IronTesseract instance
IronTesseract ocrTesseract = new IronTesseract();

// Load an image to AnyBitmap
AnyBitmap anyBitmap = AnyBitmap.FromFile("Potter.tiff");

// Convert the image data to a stream
using var imageInput = new OcrImageInput(anyBitmap.GetStream());
// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);
```

## Defining a Scan Region

For enhanced performance with large images, or to focus on specific portions of images, you can use the `CropRectangle` class to define scanning boundaries. Modify the `OcrImageInput` constructor to include a `CropRectangle` for targeted reading. In the example below, the OCR focuses only on the region that typically contains a chapter number and title.

```cs
using IronOcr;
using IronSoftware.Drawing;
using System;

// Instantiate IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Load image into AnyBitmap
AnyBitmap anyBitmap = AnyBitmap.FromFile("Potter.tiff");

// Define the area to be scanned
Rectangle scanRegion = new Rectangle(800, 200, 900, 400);

// Setup OCR input with specific area
using var imageInput = new OcrImageInput(anyBitmap.GetStream(), ContentArea: scanRegion);
// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);

// Print the OCR result
Console.WriteLine(ocrResult.Text);
```

### OCR Output Visualization

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-images/read-specific-region.webp" alt="Reading a specific region" class="img-responsive add-shadow">
    </div>
</div>