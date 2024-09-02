# Understanding Page Rotation Detection

Identifying page rotation is crucial in understanding the orientation of a page within a document. This involves detecting whether a page rotates left (counterclockwise) or right (clockwise), and it applies rotations of 0, 90, 180, and 270 degrees. Knowing the rotation is essential for correctly displaying or printing document pages.

IronOCR leverages this concept by enhancing the detection of page rotation. Once the rotation degree is identified, you can use it in conjunction with the `Rotate` method to correctly orient the image.

## Example: Detecting Page Rotation

When you have loaded a document, the `DetectPageOrientation` method is there to help you ascertain each page's rotation. This method is capable of recognizing rotations of 0, 90, 180, and 270 degrees. In case of tilted or skewed images, the `Deskew` method is a handy tool for image correction. After that, you can restore the image to its original orientation based on the detected rotation degree, as demonstrated in the following [example PDF](https://ironsoftware.com/static-assets/ocr/how-to/detect-page-rotation/Clockwise90.pdf).

This capability is particularly effective for documents that are rich in text.

```cs
using IronOcr;
using System;

using var input = new OcrInput();

// Load a PDF document
input.LoadPdf("Clockwise90.pdf");

// Execute page rotation detection
var results = input.DetectPageOrientation();

// Display results
foreach(var result in results)
{
    Console.WriteLine($"Page Number: {result.PageNumber}");
    Console.WriteLine($"High Confidence: {result.HighConfidence}");
    Console.WriteLine($"Detected Rotation Angle: {result.RotationAngle}");
}
```

### Interpreting the Results

- **PageNumber**: The zero-based page number in the document.
- **RotationAngle**: This is the rotation angle to be corrected, expressed in degrees. You might need to pass this value to the `Rotate` command like so: `input.Rotate(RotationAngle)` to adjust the page orientation correctly.
- **HighConfidence**: Signifies the reliability of the rotation detection result.