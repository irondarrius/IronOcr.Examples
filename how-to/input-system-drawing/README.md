# Understanding System.Drawing Objects

***Based on <https://ironsoftware.com/how-to/input-system-drawing/>***


The `System.Drawing.Bitmap` is a vital class under the .NET Framework utilized for bitmap image processing. This includes capabilities for generating, transforming, and visualizing bitmap images.

The `System.Drawing.Image` serves as the foundational class for all GDI+ image objects within the .NET Framework, acting as the superclass for numerous image types like `System.Drawing.Bitmap`.

`IronSoftware.Drawing.AnyBitmap`, a component of [IronDrawing](https://ironsoftware.com/open-source/csharp/drawing/docs/), an open-source project spearheaded by Iron Software, is designed to facilitate the replacement of `System.Drawing.Common` across .NET applications on Windows, macOS, and Linux environments.

<h3>Initiating IronOCR</h3>

--------------------------------------

## Example of Reading `System.Drawing.Bitmap`

Start by creating an instance of the **IronTesseract** class to enable OCR capabilities. Then, generate a `System.Drawing.Bitmap` using a chosen method; here we retrieve the image from a file.

Proceed by employing the 'using' statement to initialize an OcrImageInput object, passing in the `System.Drawing.Bitmap` object. Subsequently, utilize the `Read` method to execute OCR.

```cs
using IronOcr;
using System.Drawing;

// Instantiate IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Load image into Bitmap
Bitmap bitmap = new Bitmap("Potter.tiff");

// Pass Bitmap to OcrImageInput
using var imageInput = new OcrImageInput(bitmap);

// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);
```

## Example of Reading `System.Drawing.Image`

To read from a `System.Drawing.Image`, first generate an OcrImageInput object using the Image, and then perform OCR by applying the `Read` method.

```cs
using IronOcr;
using Image = System.Drawing.Image;

// Initialize IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Open image file and load it into Image
Image image = Image.FromFile("Potter.tiff");

// Pass Image to OcrImageInput
using var imageInput = new OcrImageInput(image);

// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);
```

## Example of Reading `IronSoftware.Drawing.AnyBitmap`

For handling an AnyBitmap object, construct an OcrImageInput class, ensuring all data is correctly imported. Below is an illustration of this process.

```cs
using IronOcr;
using IronSoftware.Drawing;

// Set up IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Load image into AnyBitmap
AnyBitmap anyBitmap = AnyBitmap.FromFile("Potter.tiff");

// Pass AnyBitmap to OcrImageInput
using var imageInput = new OcrImageInput(anyBitmap);

// Perform OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);
```

## Setting Scan Region

When creating the OcrImageInput class, you can define a specific scan area. This approach enables targeting a particular section of the image document for OCR, potentially boosting efficiency significantly. In the example below, the region containing only the chapter number and title is specified.

```cs
using IronOcr;
using IronSoftware.Drawing;
using System;

// Create IronTesseract instance
IronTesseract ocrTesseract = new IronTesseract();

// Define target crop
Rectangle scanRegion = new Rectangle(800, 200, 900, 400);

// Load image with defined content area
using var imageInput = new OcrImageInput("Potter.tiff", ContentArea: scanRegion);

// Conduct OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);

// Display result in console
Console.WriteLine(ocrResult.Text);
```

### OCR Result Display

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-images/read-specific-region.webp" alt="Read specific region" class="img-responsive add-shadow">
    </div>
</div>