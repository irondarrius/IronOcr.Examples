# Guide to Implementing IronOCR Image Filters

IronOCR offers a suite of image processing filters designed to enhance the readability of images prior to OCR processing. These filters are crucial for adapting images to conditions ideal for OCR technology.

## Overview of OCR Image Filters

Implementing image filters can significantly enhance the OCR process:

- **Image Orientation Correction Filters**
  - **Rotate** - Rotates the image by a specified degree clockwise. For counter-clockwise rotation, input negative values.
  - **Deskew** - Adjusts an image's alignment to be upright and orthogonal, crucial for OCR processing as even a slight tilt can hamper accuracy.
  - **Scale** - Proportionally scales OCR input pages.
  
- **Image Color Manipulation Filters**
  - **Binarize** - Converts all pixels to either black or white, enhancing text-background contrast, potentially boosting OCR accuracy.
  - **ToGrayScale** - Converts the image to grayscale, which may help in speeding up the OCR process.
  - **Invert** - Reverses all colors in the image (e.g., white to black and vice versa).
  - **ReplaceColor** - Swaps one color in the image for another within a specified threshold.
  
- **Contrast Enhancement Filters**
  - **Contrast** - Automatically enhances image contrast which can improve the speed and accuracy of the OCR.
  - **Dilate** - Expands the boundaries of objects within an image, the opposite of erosion.
  - **Erode** - Reduces the boundaries of objects within an image, the opposite of dilation.
  
- **Noise Reduction Filters**
  - **Sharpen** - Enhances the clarity of blurred OCR documents and sets alpha channels to white.
  - **DeNoise** - Targets and removes digital noise, ideal where noise is anticipated in images.
  - **DeepCleanBackgroundNoise** - Intensively removes background noise, recommended for extremely noisy backgrounds.
  - **EnhanceResolution** - Boosts the resolution of low-quality images, although automatic DPI adjustments typically handle resolution issues.

## Applying Filters: Code Example

Here's an example demonstrating how to apply image preprocessing filters using IronOCR:

```cs
using IronOcr;
using System;

var ocr = new IronTesseract();
using (var input = new OcrInput())
{
    input.LoadImage("my_image.png");
    input.Deskew();  // This line corrects the skewness of the image

    var result = ocr.Read(input);
    Console.WriteLine(result.Text);
}
```

### Debugging Filters

If encountering issues with image or barcode readability in your application, save the results of filter applications for debugging purposes:

```cs
using IronOcr;
using System;

var ocr = new IronTesseract();
using (var input = new OcrInput("skewed_image.tiff"))
{
    input.Deskew();  // Apply the Deskew filter

    input.SaveAsImages("my_deskewed_image");  // Save the processed image for debugging

    var result = ocr.Read(input);
    Console.WriteLine(result.Text);
}
```

## Practical Use Cases of Filters

### Rotate

**Rotate** helps manually set a picture's orientation. It's useful when an automatic `Deskew()` might not suffice due to the image being significantly rotated.

- [IronOCR Rotate API Documentation](https://ironsoftware.com/csharp/ocr/object-reference/api/IronOcr.OcrInput.html#IronOcr_OcrInput_Rotate_System_Double_)

**Code Example**:
```cs
using IronOcr;
import System;

var ocr = new IronTesseract();
using (var input = new OcrInput("screenshot.png"))
{
    input.Rotate(180);  // Perfect for correcting an upside-down image

    var result = ocr.Read(input);
    Console.WriteLine(result.Text);
}
```

**Visual Comparison**:

| **Before `Input.Rotate(180)`** | **After `Input.Rotate(180)`** |
| --- | --- |
| ![Before Rotate](https://ironsoftware.com/csharp/ocr/assets/IronOCR-Tutorial/screenshot.png) | ![After Rotate](https://ironsoftware.com/csharp/ocr/assets/IronOCR-Tutorial/screenshot_rotated.png) |

### Deskew

**Deskew** uses a Hough Transform to attempt straightening an image. This filter is vital when even a slight misalignment might result in OCR inaccuracies.

- [IronOCR Deskew API Documentation](https://ironsoftware.com/csharp/ocr/object-reference/api/IronOcr.OcrInput.html#IronOcr_OcrInput_Deskew_IronOcr_IronTesseract_System_Int32_IronOcr_OrientationConfidence_)

**Code Example**:
```cs
using IronOcr;
import System;

var ocr = new IronTesseract();
using (var input = new OcrInput("paragraph_skewed.png"))
{
    bool didDeskew = input.Deskew(15);
    if (didDeskew)
    {
        var result = ocr.Read(input);
        Console.WriteLine(result.Text);
    }
    else
    {
        Console.WriteLine("Deskew not applied: Image orientation undetectable.");
    }
}
```

**Visual Comparison**:

| **Before `Deskew()`** | **After `Deskew()`** |
| --- | --- |
| ![Before Deskew](https://ironsoftware.com/csharp/ocr/assets/IronOCR-Tutorial/paragraph_skewed.png) | ![After Deskew](https://ironsoftware.com/csharp/ocr/assets/IronOCR-Tutorial/paragraph_deskewed.png) |