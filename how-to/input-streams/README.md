# Stream Reading Techniques in Programming

***Based on <https://ironsoftware.com/how-to/input-streams/>***


In computer programming, ‘stream’ data signifies a steady flow of binary data that can be efficiently read or written piece by piece. This approach is particularly useful for handling large datasets that are too extensive to fully load into memory.

IronOcr supports the use of data streams, allowing the import and OCR of image streams seamlessly. By feeding image stream data directly into its import functions, IronOcr simplifies the process, seamlessly handling the complexities of stream management.

## Example of Reading Streams

To commence, create an instance of the **IronTesseract** class to utilize OCR capabilities. Utilize the `FromFile` method from AnyBitmap to load the image file, which can subsequently convert the image into a stream. With the aid of a 'using' statement, construct an OcrImageInput by injecting the stream produced by the `GetStream` method from AnyBitmap, and then apply the `Read` method to execute OCR.

```cs
using IronSoftware.Drawing;
using IronOcr;
namespace ironocr.InputStreams
{
    public class Section1
    {
        public void Run()
        {
            // Creates an instance of IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Loads image file into AnyBitmap
            AnyBitmap anyBitmap = AnyBitmap.FromFile("Potter.tiff");
            
            // Transfers image stream
            using var imageInput = new OcrImageInput(anyBitmap.GetStream());
            // Executes OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
        }
    }
}
```

## Setting a Scan Region

For enhanced efficiency with large images or to target specific sections of an image, the CropRectangle is a useful feature. This class can be passed as a parameter to the OcrImageInput constructor, specifying the desired area of the image to be processed. The subsequent example demonstrates setting the OCR region to include only the chapter number and title from an image.

```cs
using System;
using IronOcr;
namespace ironocr.InputStreams
{
    public class Section2
    {
        public void Run()
        {
            // Initializes IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Loads the image into AnyBitmap
            AnyBitmap anyBitmap = AnyBitmap.FromFile("Potter.tiff");
            
            // Sets the scanning region
            Rectangle scanRegion = new Rectangle(800, 200, 900, 400);
            
            // Processes the specified image section
            using var imageInput = new OcrImageInput(anyBitmap.GetStream(), ContentArea: scanRegion);
            // Executes OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
            
            // Prints the OCR result to the console
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