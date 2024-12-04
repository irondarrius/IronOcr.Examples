# How to Use OCR to Extract Text from Images

***Based on <https://ironsoftware.com/how-to/input-images/>***


Optical Character Recognition (OCR) is a powerful technology used to identify and extract text from images. This capability is invaluable for converting printed materials into a digital format, enabling the manipulation and analysis of the text contained in images such as scanned documents, photos, and more.

IronOCR offers comprehensive support for multiple image file types including jpg, png, gif, tiff, and bmp. Additionally, it provides image filters that improve the quality and accuracy of OCR results.


## Example of Image Reading

First, create an instance of the `IronTesseract` class to access OCR functionality. Using the `using` statement, construct an `OcrImageInput` with the designated image filepath, ensuring efficient resource management. IronOCR accepts various image formats such as jpg, png, gif, tiff, and bmp. The `Read` method is then used to execute OCR on the image.

```cs
using IronOcr;
namespace ironocr.InputImages
{
    public class Section1
    {
        public void Run()
        {
            // Create an instance of IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Load the image
            using var imageInput = new OcrImageInput("Potter.png");
            
            // Execute OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
        }
    }
}
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-images/read-png.webp" alt="Read PNG image" class="img-responsive add-shadow">
    </div>
</div>

Explore more about OCR for multi-frame or multi-page images by visiting [How to Read Multi-Frame/Page GIFs and TIFFs](https://ironsoftware.com/csharp/ocr/how-to/input-tiff-gif/) to understand the handling of TIFF and GIF files.

## Importing Images as Bytes

Beyond simple file paths, the `OcrImageInput` class can also receive image data directly as bytes, `AnyBitmap`, `Stream`, or `Image`. `AnyBitmap` refers to a versatile bitmap object available at [IronSoftware.Drawing.AnyBitmap](https://ironsoftware.com/open-source/csharp/drawing/examples/bitmap-to-stream/).

```cs
using System.IO;
using IronOcr;
namespace ironocr.InputImages
{
    public class Section2
    {
        public void Run()
        {
            // Create an instance of IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Load image data from a file
            byte[] data = File.ReadAllBytes("Potter.tiff");
            
            // Import image data
            using var imageInput = new OcrImageInput(data);
            // Execute OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
        }
    }
}
```

## Defining a Scanning Region

When creating `OcrImageInput`, it's possible to specify a `CropRectangle`, defining the specific area of the image to be scanned. This can be crucial for optimizing performance by focusing on key areas of an image.

```cs
using System;
using IronOcr;
namespace ironocr.InputImages
{
    public class Section3
    {
        public void Run()
        {
            // Create an instance of IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Define the scan region
            Rectangle scanRegion = new Rectangle(800, 200, 900, 400);
            
            // Load the image with a specified content area
            using var imageInput = new OcrImageInput("Potter.tiff", ContentArea: scanRegion);
            // Execute OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
            
            // Print the OCR result
            Console.WriteLine(ocrResult.Text);
        }
    }
}
```

### Output of OCR Process

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-images/read-specific-region.webp" alt="Read specific region" class="img-responsive add-shadow">
    </div>
</div>