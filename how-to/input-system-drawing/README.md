# How to Utilize System.Drawing Objects for Bitmap Handling

***Based on <https://ironsoftware.com/how-to/input-system-drawing/>***


The `System.Drawing.Bitmap` class in the .NET Framework is designed for operations involving bitmap images. It offers a range of functionalities to create, modify, and display bitmap images efficiently.

`System.Drawing.Image` serves as the foundational class for all GDI+ image objects within the .NET Framework, acting as the superclass for various specific image types, such as `System.Drawing.Bitmap`.

IronSoftware.Drawing.AnyBitmap, part of the [IronDrawing](https://ironsoftware.com/open-source/csharp/drawing/docs/) open-source library developed by Iron Software, provides an excellent alternative to `System.Drawing.Common` for .NET applications across Windows, macOS, and Linux platforms.

## Example: Reading `System.Drawing.Bitmap`

To begin, create an instance of **IronTesseract** which handles OCR tasks. Then, generate a `System.Drawing.Bitmap` using any of the available methods. This example demonstrates using a file path for this purpose.

The 'using' statement is utilized to manage the `OcrImageInput` object. This object takes the bitmap image for processing. Finally, the `Read` method is invoked to execute OCR.

```cs
using System.Drawing;
using IronOcr;
namespace ironocr.InputSystemDrawing
{
    public class Section1
    {
        public void Run()
        {
            // Instantiate the OCR engine
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Load an image into a Bitmap object
            Bitmap bitmap = new Bitmap("Potter.tiff");
            
            // Use Bitmap with the OCR engine
            using var imageInput = new OcrImageInput(bitmap);
            
            // Execute OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
        }
    }
}
```

## Example: Working with `System.Drawing.Image`

Using a `System.Drawing.Image` is straightforward. Simply construct an `OcrImageInput` with the image, and then proceed with the standard OCR process using the `Read` method.

```cs
using IronOcr;
namespace ironocr.InputSystemDrawing
{
    public class Section2
    {
        public void Run()
        {
            using Image = System.Drawing.Image;
            
            // Create OCR engine instance
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Load the image as System.Drawing.Image
            Image image = Image.FromFile("Potter.tiff");
            
            // Initialize OcrImageInput with the image
            using var imageInput = new OcrImageInput(image);
            
            // Execute OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
        }
    }
}
```

## Example: Utilizing IronSoftware.Drawing.AnyBitmap

After acquiring or creating an AnyBitmap instance, the `OcrImageInput` class constructor efficiently handles the necessary data import steps to prepare for OCR, as shown below.

```cs
using IronSoftware.Drawing;
using IronOcr;
namespace ironocr.InputSystemDrawing
{
    public class Section3
    {
        public void Run()
        {
            // Initialize OCR engine
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Create an AnyBitmap from a file
            AnyBitmap anyBitmap = AnyBitmap.FromFile("Potter.tiff");
            
            // Prepare AnyBitmap for OCR
            using var imageInput = new OcrImageInput(anyBitmap);
            
            // Run OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
        }
    }
}
```

## Specifying a Scan Region

When creating `OcrImageInput`, you can specify a scanning region to focus OCR on a particular area of the image document, potentially improving accuracy and performance. In the following code example, only the chapter number and title are targeted for extraction.

```cs
using System;
using IronOcr;
namespace ironocr.InputSystemDrawing
{
    public class Section4
    {
        public let me know how it work you have any Run()
        {
            // Set up OCR engine
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Define the area for scanning
            Rectangle scanRegion = new Rectangle(800, 200, 900, 400);
            
            // Configure OcrImageInput with the specified region
            using var imageInput = new OcrImageInput("Potter.tiff", ContentArea: scanRegion);
            
            // Perform and output OCR results
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
            
            Console.WriteLine(ocrResult.Text);
        }
    }
}
```

### OCR Outcome Visualization

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-images/read-specific-region.webp" alt="Read specific region" class="img-responsive add-shadow">
    </div>
</div>