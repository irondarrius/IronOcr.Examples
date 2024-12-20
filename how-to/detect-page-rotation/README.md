# How to Identify Page Rotation

***Based on <https://ironsoftware.com/how-to/detect-page-rotation/>***


Identifying the rotation of a page within a document involves determining the angle at which the page has been rotated. This could be either clockwise or counterclockwise at angles including 0, 90, 180, or 270 degrees. This detection is essential for accurate document rendering and processing, as it ensures pages appear in the intended orientation when viewed or printed.

IronOCR excels in the detection of page rotation. Once the rotation is identified, you can use the returned angle in conjunction with the `Rotate` method to align the page correctly.

<h3>Getting Started with IronOCR</h3>

------------------------------------------

## Example: Detecting Page Rotation

Start by loading the document. To determine the page rotation, apply the `DetectPageOrientation` method which handles angles of 0, 90, 180, and 270 degrees. For images that appear skewed, the `Deskew` method can help in correcting the image alignment. Afterward, use the obtained degree to rotate the image back to its intended orientation. Let's go through a [sample PDF](https://ironsoftware.com/static-assets/ocr/how-to/detect-page-rotation/Clockwise90.pdf).

This function is particularly effective with documents that contain a lot of text.

```cs
using IronOcr;
using System;

using var input = new OcrInput("Clockwise90.pdf"); // Load PDF document

// Determine page rotation
var results = input.DetectPageOrientation();

// Displaying results
foreach(var result in results)
{
    Console.WriteLine($"Page Number: {result.PageNumber}");
    Console.WriteLine($"Confidence Level: {result.HighConfidence}");
    Console.WriteLine($"Rotation Angle: {result.RotationAngle} degrees");
}
```

### Interpreting the Results

- **PageNumber**: Refers to the zero-based page index within the document.
- **RotationAngle**: Specifies the corrective angle in degrees. You can use this angle with the `Rotate` method, for instance, if an image is rotated by 90 degrees clockwise, you would apply a 270-degree rotation to correct it (`input.Rotate(RotationAngle)`).
- **HighConfidence**: Reflects the reliability of the page orientation detection.