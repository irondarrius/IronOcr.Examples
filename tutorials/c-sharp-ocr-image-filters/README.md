# Guide to Using IronOCR Filters

***Based on <https://ironsoftware.com/tutorials/c-sharp-ocr-image-filters/>***


IronOCR offers a comprehensive set of filters that preprocess images to make them suitable for OCR processing. These filters adjust various aspects of the images, helping to enhance their readability.

## Overview of OCR Image Filters

Here's how using specific image filters can improve OCR performance:

- **Filters to Adjust Image Orientation**
  - **Rotate**: Rotates images by a specified degree clockwise. For counter-clockwise rotation, negative numbers are used.
  - **Deskew**: Corrects the alignment of an image to its proper orientation, crucial for OCR processing since the accuracy may significantly decrease with even a small degree of skew.
  - **Scale**: Adjusts the size of OCR input pages while maintaining proportions.
- **Filters for Color Manipulation**
  - **Binarize**: Transforms each pixel to black or white, enhancing contrast in low-contrast scenarios.
  - **ToGrayScale**: Converts images to grayscale, potentially increasing processing speed.
  - **Invert**: Reverses the color spectrum, turning white to black and vice versa.
  - **ReplaceColor**: Substitutes one color in the image for another within a specified threshold.
- **Filters to Enhance Contrast**
  - **Contrast**: Automatically boosts the contrast, often improving both speed and accuracy of OCR.
  - **Dilate**: Expands the boundaries of objects in images, the opposite of erode.
  - **Erode**: Reduces the boundary pixels of objects, the opposite of dilate.
- **Filters to Minimize Noise**
  - **Sharpen**: Enhances the sharpness of blurred text and converts any alpha channels to white.
  - **DeNoise**: Eliminates digital noise, which is useful in noisy images.
  - **DeepCleanBackgroundNoise**: Aggressively removes background noise but may also decrease OCR accuracy on clean documents.
  - **EnhanceResolution**: Improves the resolution of low-quality images. This is typically redundant as `OcrInput.MinimumDPI` and `OcrInput.TargetDPI` manage resolution issues automatically.

## Example of Applying Filters in Code

Below is a demonstration of applying a filter using IronOCR in C#:

```cs
using System;
using IronOcr;

namespace ironocr.CSharpOcrImageFilters
{
    public class Section1
    {
        public void Run()
        {
            var ocr = new IronTesseract();
            using var input = new OcrInput("my_image.png");
            input.Deskew();
            
            var result = ocr.Read(input);
            Console.WriteLine(result.Text);
        }
    }
}
```

### Debugging Filters - Visual Insight
If you're encountering problems with image processing, you can save filtered results for debugging purposes. This allows visual verification of each filter's effect.

```cs
using System;
using IronOcr;

namespace ironocr.CSharpOcrImageFilters
{
    public class Section2
    {
        public void Run()
        {
            var file = "skewed_image.tiff";
            var ocr = new IronTesseract();
            using var input = new OcrInput();
            input.LoadImageFrames(file, new int[] { 1, 2 });
            input.Deskew();
            input.SaveAsImages("my_deskewed");
            
            var result = ocr.Read(input);
            Console.WriteLine(result.Text);
        }
    }
}
```

## Practical Use Cases for Filters

### Rotate

Rotate to correct an image that is upside-down:

```cs
using System;
using IronOcr;

namespace ironocr.CSharpOcrImageFilters
{
    public class Section3
    {
        public void Run()
        {
            var image = "screenshot.png";
            var ocr = new IronTesseract();
            using var input = new OcrInput(image);
            
            input.Rotate(180);
            
            var result = ocr.Read(input);
            Console.WriteLine(result.Text);
        }
    }
}
```
|**Before `Input.Rotate(180)`**|**After `Input.Rotate(180)`**|
|--|--|
| ![Before Rotate](https://ironsoftware.com/csharp/ocr/assets/IronOCR-Tutorial/screenshot.png) | ![After Rotate](https://ironsoftware.com/csharp/ocr/assets/IronOCR-Tutorial/screenshot_rotated.png) |

### Deskew

Rectify a skewed image to enhance OCR accuracy:

```cs
using System;
using IronOcr;

namespace ironocr.CSharpOcrImageFilters
{
    public class...