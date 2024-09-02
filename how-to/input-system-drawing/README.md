# Interpreting Bitmaps with System.Drawing and IronSoftware

The `.NET Framework` includes `System.Drawing.Bitmap`, a class specifically tailored for operations involving bitmap images such as creation, manipulation, and display. 

`System.Drawing.Image` acts as the foundational class for all GDI+ image objects within the framework, serving as a parent for numerous image derivatives, including `System.Drawing.Bitmap`.

`IronSoftware.Drawing.AnyBitmap` represents a bitmap class part of [IronDrawing](https://ironsoftware.com/open-source/csharp/drawing/docs/), a versatile library developed by Iron Software designed to provide a replacement for `System.Drawing.Common` in .NET applications across Windows, macOS, and Linux platforms.

## Example: Extract Text from System.Drawing.Bitmap

Start by initializing the **IronTesseract** class. Generate a `System.Drawing.Bitmap` instance, as demonstrated below where a file path is employed for the bitmap creation.

Employ the 'using' statement to create an `OcrImageInput` object, passing the bitmap. Subsequently, execute OCR by calling the `Read` method.

```cs
using IronOcr;
using System.Drawing;

// Initialize IronTesseract
IronTesseract ocr = new IronTesseract();

// Load the image file into a Bitmap
Bitmap myBitmap = new Bitmap("Potter.tiff");

// Create an OCR input from System.Drawing.Bitmap
using var ocrInput = new OcrImageInput(myBitmap);
// Execute OCR
OcrResult result = ocr.Read(ocrInput);
```

## Example: Reading from System.Drawing.Image

Creating an `OcrImageInput` with a `System.Drawing.Image` and performing OCR is straightforward.

```cs
using IronOcr;
using Image = System.Drawing.Image;

// Create an instance of IronTesseract
IronTesseract tesseract = new IronTesseract();

// Read the image file as Image
Image myImage = Image.FromFile("Potter.tiff");

// Create OCR input from System.Drawing.Image
using var input = new OcrImageInput(myImage);
// Initiate OCR process
OcrResult result = tesseract.Read(input);
```

## Example: Utilizing IronSoftware.Drawing.AnyBitmap

After either creating or receiving an `AnyBitmap` object, construct the `OcrImageInput`. This process is encapsulated in the constructor as shown below.

```cs
using IronOcr;
using IronSoftware.Drawing;

// Instantiate IronTesseract
IronTesseract tesseract = new IronTesseract();

// Load image as AnyBitmap
AnyBitmap anyImage = AnyBitmap.FromFile("Potter.tiff");

// Setup OCR with AnyBitmap
using var input = new OcrImageInput(anyImage);
// Execute OCR
OcrResult result = tesseract.Read(input);
```

## Define a Specific Scan Region

Define the exact scan area within the `OcrImageInput` constructor to enhance OCR performance by focusing on specific parts of the image.

```cs
using IronOcr;
using IronSoftware.Drawing;
using System;

// Create IronTesseract instance
IronTesseract tesseract = new IronTesseract();

// Define the scan area
Rectangle region = new Rectangle(800, 200, 900, 400);

// Prepare the image with specified content area
using var input = new OcrImageInput("Potter.tiff", ContentArea: region);
// Conduct the OCR
OcrResult result = tesseract.Read(input);

// Print the extracted text
Console.WriteLine(result.Text);
```

### Result of OCR

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-images/read-specific-region.webp" alt="Read specific region" class="img-responsive add-shadow">
    </div>
</div>