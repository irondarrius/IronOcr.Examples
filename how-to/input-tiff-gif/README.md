# Reading Multi-Frame/Page GIFs and TIFFs

***Based on <https://ironsoftware.com/how-to/input-tiff-gif/>***


TIFF (Tagged Image File Format) is commonly used for high-quality images, supporting lossless compression, ideal for archival quality images such as scanned documents and professional photographs.

GIF (Graphics Interchange Format) is chosen for simple, internet-friendly images and animations due to its support for both lossless and lossy compression. Known for its animated capabilities in a single file, GIF is widely adopted for brief, repeating animations frequently seen on web pages and social media platforms.

IronOCR offers functionality to process both single and multiple-frame/page GIFs and TIFFs effortlessly. Just by importing the image file with one of the provided methods, IronOCR handles the image reading seamlessly.

## Example: Reading Single/Multi-Frame TIFF

To utilize OCR, initiate by creating an instance of the `IronTesseract` class. Through the `using` statement, form an `OcrImageInput` object. This object accommodates single or multiple frames in both TIFF and TIF formats. Use the `Read` method afterward to execute OCR on your TIFF file.

```cs
using IronOcr;
namespace ironocr.InputTiffGif
{
    public class Section1
    {
        public void Run()
        {
            // Set up IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Load the TIFF/TIF image
            using var imageInput = new OcrImageInput("Potter.tiff");
            // Execute OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
        }
    }
}
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-tiff-gif/read-tiff.webp" alt="Read TIFF image" class="img-responsive add-shadow">
    </div>
</div>

## Example: Reading GIF

For reading GIF files, simply define the file path in the `OcrImageInput` constructor. The class automatically prepares the image file for processing.

```cs
using IronOcr;
namespace ironocr.InputTiffGif
{
    public class Section2
    {
        public void Run()
        {
            // Create IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Import the GIF
            using var imageInput = new OcrImageInput("Potter.gif");
            // Apply OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
        }
    }
}
```

## Specifying a Scan Region

Incorporate a `CropRectangle` object when initializing the `OcrImageInput` class to specify a region within the image document for targeted OCR. This technique is particularly beneficial for large images to improve OCR accuracy and performance.

```cs
using System;
using IronOcr;
namespace ironocr.InputTiffGif
{
    public class Section3
    {
        public void Run()
        {
            // Initialize IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Set the crop area
            Rectangle scanRegion = new Rectangle(800, 200, 900, 400);
            
            // Include the image location and crop area
            using var imageInput = new OcrImageInput("Potter.tiff", ContentArea: scanRegion);
            // Start the OCR process
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
            
            // Print the OCR results
            Console.WriteLine(ocrResult.Text);
        }
    }
}
```

### OCR Output Example

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-images/read-specific-region.webp" alt="Read specific region" class="img-responsive add-shadow">
    </div>
</div>