# Guide to Implementing IronOCR Filters

***Based on <https://ironsoftware.com/tutorials/c-sharp-ocr-image-filters/>***


IronOCR provides a robust suite of tools designed to prepare images for OCR processing through a variety of filters. This guide introduces these filters and demonstrates how to effectively apply them to enhance OCR accuracy.

### Getting Started with IronOCR

---

## Overview of OCR Image Filters

The following filters can significantly enhance your OCR results:

- **Image Orientation Modifiers**  
  - **Rotate** - Adjusts the image orientation by rotating it by a specified number of degrees clockwise. For counter-clockwise adjustments, use negative values.
  - **Deskew** - Corrects the image orientation to be upright and aligned, crucial for OCR as Tesseract can only tolerate up to 5 degrees of skew.
  - **Scale** - Resizes OCR input pages while maintaining proportions.
- **Image Color Manipulation**
  - **Binarize** - Converts each pixel to either black or white, enhancing OCR performance in low-contrast scenarios.
  - **ToGrayScale** - Converts images to grayscale, which may not improve accuracy but can enhance processing speed.
  - **Invert** - Reverses color values, turning whites to blacks and vice versa.
  - **ReplaceColor** - Substitutes a specific color within the image to another, within a given threshold.
- **Contrast Enhancement**
  - **Contrast** - Automatically boosts contrast, often improving both OCR speed and accuracy in low-contrast images.
  - **Dilate** - Expands the boundaries of objects within the image, enhancing definition.
  - **Erode** - Reduces the pixel boundary of image objects, the opposite effect of Dilate.
- **Noise Reduction Techniques**
  - **Sharpen** - Clarifies blurred OCR documents and sets alpha channels to white.
  - **DeNoise** - Eliminates digital artifacts, recommended for noisy images.
  - **DeepCleanBackgroundNoise** - Intensively removes background noise where it's prevalent, though it may reduce accuracy on clean documents and is resource-intensive.
  - **EnhanceResolution** - Improves the resolution on low-quality images. Typically, this is managed automatically through settings like _OcrInput.MinimumDPI_ and _OcrInput.TargetDPI_.

## Code Example: Applying Filters

Here’s a simple demonstration of how these filters can be integrated into your code:

```cs
using IronOcr;
using System;

var ocr = new IronTesseract();
using var input = new OcrInput("my_image.png");
input.Deskew();  // Correcting the image alignment before reading

var result = ocr.Read(input);
Console.WriteLine(result.Text);
```

### Debugging Filters

To troubleshoot issues with OCR reads, you can visually examine the effect of each filter on your images by saving the processed results for inspection.

```cs
using IronOcr;
using System;

string file = "skewed_image.tiff";
var ocr = new IronTesseract();
using var input = new OcrInput();
var pageIndex = new int[] { 1, 2 };
input.LoadImageFrames(file, pageIndex);
input.Deskew();  // Applying Deskew filter

input.SaveAsImages("my_deskewed");  // Saving the processed image

var result = ocr.Read(input);
Console.WriteLine(result.Text);
```


## Use Cases for Filters

### Rotate

**Filter Explanation**:
`Rotate()` manually aligns images that are significantly misaligned by directly setting a specific rotation.

**Code Example**:
This snippet rotates an upside-down image to correct its orientation:

```cs
using IronOcr;
using System;

var image = "screenshot.png";
var ocr = new IronTesseract();
using var input = new OcrInput(image);

input.Rotate(180);  // Correcting an upside-down image

var result = ocr.Read(input);
Console.WriteLine(result.Text);
```

| **Before `Input.Rotate(180)`** | **After `Input.Rotate(180)`** |
| --- | --- |
| ![Before Rotation](https://ironsoftware.com/csharp/ocr/assets/IronOCR-Tutorial/screenshot.png) | ![After Rotation](https://ironsoftware.com/csharp/ocr/assets/IronOCR-Tutorial/screenshot_rotated.png) |

### Deskew

**Filter Explanation**:
`Deskew()` leverages a Hough Transform to correct alignment within a specified tolerance. This is essential for slightly tilted images that may lead to OCR errors.

**Code Example**:
This example aligns a skewed document image:

```cs
using IronOcr;
using System;

var image = "paragraph_skewed.png";
var ocr = new IronTesseract();
using var input = new OcrInput(image);

bool didDeskew = input.Deskew(15);  // Attempting to correct skew with a 15 degree tolerance
if (didDeskew)
{
    var result = ocr.Read(input);
    Console.WriteLine(result.Text);
}
else
{
    Console.WriteLine("Deskew not applied due to undetectable image orientation.");
}
```

| **Before `Deskew()`** | **After `Deskew()`** |
| --- | --- |
| ![Before Deskew](https://ironsoftware.com/csharp/ocr/assets/IronOCR-Tutorial/paragraph_skewed.png) | ![After Deskew](https://ironsoftware.com/csharp/ocr/assets/IronOCR-Tutorial/paragraph_deskewed.png) |

### Scale

**Filter Explanation**:
`Scale()` resizes images to enhance readability or barcode detectability, maintaining pixel data.

**Code Example**:
This snippet scales up a barcode image for better readability:

```cs
using IronOcr;
using System;

var image = "small_barcode.png";
var ocr = new IronTesseract();
ocr.Configuration.ReadBarCodes = true;
using var input = new OcrInput(image);

input.Scale(400);  // Scaling the image to 400% of its original size

var result = ocr.Read(input);
Console.WriteLine(result.Text);
```

| **Before `Scale()`** | **After `Scale()`** |
| --- | --- |
| ![Before Scale](https://ironsoftware.com/csharp/ocr/assets/IronOCR-Tutorial/small_barcode.png) | ![After Scale](https://ironsoftware.com/csharp/ocr/assets/IronOCR-Tutorial/large_barcode.png) |

### Binarize

**Filter Explanation**:
`Binarize()` simplifies the image to black and white based on text detection, optimizing for clarity.

**Code Example**:
This example demonstrates the effect of binarizing a text-heavy image:

```cs
using IronOcr;
using System;

var image = "no-binarize.jpg";
var ocr = new IronTesseract();
using var input = new OcrInput(image);

input.Binarize();  // Binarizing to enhance text visibility

var result = ocr.Read(input);
Console.WriteLine(result.Text);
```

| **Before `Binarize()`** | **After `Binarize()`** |
| --- | --- |
| ![Before Binarize](https://ironsoftware.com/csharp/ocr/assets/IronOCR-Tutorial/no-binarize.jpg) | ![After Binarize](https://ironsoftware.com/csharp/ocr/assets/IronOCR-Tutorial/after-binarize.png) |

### Invert

**Filter Explanation**:
`Invert` flips the colors of the image, aiding in achieving the optimal black-on-white contrast for OCR.

**Code Example**:
This snippet inverts the colors of an image to prepare it for OCR:

```cs
using IronOcr;
using System;

var image = "before-invert.png";
var ocr = new IronTesseract();
using var input = new OcrInput(image);

input.Invert(true);  // Inverting colors

var result = ocr.Read(input);
Console.WriteLine(result.Text);
```

| **Before** | **After** |
| --- | --- |
| ![Before Invert](https://ironsoftware.com/csharp/ocr/assets/IronOCR-Tutorial/before-invert.png) | ![After Invert](https://ironsoftware.com/csharp/ocr/assets/IronOCR-Tutorial/after-invert.png) |