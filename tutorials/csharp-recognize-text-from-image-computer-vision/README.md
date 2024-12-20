# Guide to Utilizing IronOCR Computer Vision

***Based on <https://ironsoftware.com/tutorials/csharp-recognize-text-from-image-computer-vision/>***


## Introduction

IronOCR leverages OpenCV to implement computer vision techniques for detecting textual regions within images. This functionality is particularly beneficial for processing images with background noise, multiple text placements, or distorted text. By employing computer vision, IronOCR identifies areas likely to contain text and then utilizes the Tesseract engine to interpret the text from these identified regions.

### Start Working with IronOCR

---

## Installation of IronOCR.ComputerVision via NuGet Package

The OpenCV-based computer vision capabilities of IronOCR are integrated within the standard IronOCR NuGet package.

To access these features, you must install the `IronOcr.ComputerVision` package within your project environment. The installation commands differ based on the operating system:

- **Windows:** `IronOcr.ComputerVision.Windows`
- **Linux:** `IronOcr.ComputerVision.Linux`
- **macOS:** `IronOcr.ComputerVision.MacOS`
- **macOS ARM:** `IronOcr.ComputerVision.MacOS.ARM`

To install, you can use the NuGet Package Manager or execute the following command in the Package Manager Console:

```shell
PM> Install-Package IronOcr.ComputerVision.Windows
```

This command sets up all necessary assemblies for Computer Vision usage with IronOCR.

## API Features and Examples

Below you'll find an overview of available methods along with code examples:

| **Method**                                          | **Explanation**                                                                                                     |
|-----------------------------------------------------|---------------------------------------------------------------------------------------------------------------------|
| [FindTextRegion](#anchor-findtextregion)            | Identifies regions containing text and directs Tesseract to focus only on these specific areas.                     |
| [FindMultipleTextRegions](#anchor-findmultipletextregions) | Identifies text regions and splits the page into separate images based on these identified text areas.               |
| [GetTextRegions](#anchor-gettextregions)            | Scans the image and returns a detailed list of identified text areas as a `List<CropRectangle>`.                    |

## Practical Code Examples

### FindTextRegion

This example demonstrates how `FindTextRegion` employs computer vision to pinpoint text areas within each page of an `OcrInput`:

```cs
using IronOcr;

var ocr = new IronTesseract();
using var input = new OcrInput();
// Load image to be processed
input.LoadImage("https://ironsoftware.com/path/file.png");

input.FindTextRegion();
OcrResult result = ocr.Read(input);
string resultText = result.Text;
```

Optional custom parameters enhance detection capabilities:

```cs
using IronOcr;

var ocr = new IronTesseract();
using var input = new OcrInput();
// Load image for OCR analysis
input.LoadImage("https://ironsoftware.com/path/file.png");

input.FindTextRegion(Scale: 2.0, DilationAmount: 20, Binarize: true, Invert: true);
OcrResult result = ocr.Read(input);
string resultText = result.Text;
```

### FindMultipleTextRegions

This method detects text across all pages of an `OcrInput` and divides them into separate images based on these regions:

```cs
using IronOcr;

var ocr = new IronTesseract();
using var input = new OcrInput();
// Input image loading
input.LoadImage("https://ironsoftware.com/path/file.png");

input.FindMultipleTextRegions();
OcrResult result = ocr.Read(input);
string resultText = result.Text;
```

Customization options are available as shown:

```cs
using IronOcr;

var ocr = new IronTesseract();
using var input = new OcrInput();
// Load your image here
input.LoadImage("https://ironsoftware.com/path/file.png");

input.FindMultipleTextRegions(Scale: 2.0, DilationAmount: -1, Binarize: true, Invert: false);
OcrResult result = ocr.Read(input);
string resultText = result.Text;
```

### GetTextRegions

This code snippet retrieves a list of crop areas where text is detected on a page:

```cs
using IronOcr;
using IronSoftware.Drawing;
using System.Collections.Generic;
using System.Linq;

int pageIndex = 0;
using var input = new OcrInput();
// Specifying the image for text detection
input.LoadImage("https://ironsoftware.com/path/file.png");

var selectedPage = input.GetPages().ElementAt(pageIndex);
var regions = selectedPage.GetTextRegions();
```