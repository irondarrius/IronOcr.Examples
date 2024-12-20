# Employing Computer Vision to Extract Text

***Based on <https://ironsoftware.com/how-to/computer-vision/>***


## Introduction

IronOCR harnesses OpenCV for computer vision techniques to identify regions of text in images. This capability proves particularly useful in images with substantial background noise, varied text placement, or distorted text. IronOCR's computer vision functionality pinpoints areas with text and leverages Tesseract to read these areas.

- [OCR License Plate Recognition in C# Guide](https://ironsoftware.com/csharp/ocr/blog/using-ironocr/license-plate-ocr-csharp-tutorial/)
- [Extracting Text From Invoices in C# Tutorial](https://ironsoftware.com/csharp/ocr/blog/using-ironocr/invoice-ocr-csharp-tutorial/)
- [Text Extraction From Screenshots using OCR in C#](https://ironsoftware.com/csharp/ocr/blog/using-ironocr/get-text-ocr-screenshot-csharp-tutorial/)
- [OCR Subtitling in C# Guide](https://ironsoftware.com/csharp/ocr/blog/using-ironocr/subtitle-ocr-csharp-tutorial/)

***

***

## Setting up IronOCR.ComputerVision with NuGet

The Computer Vision capabilities of IronOCR, leveraging OpenCV, are integrated within the standard IronOCR NuGet package.

To utilize these features, one must install the `IronOcr.ComputerVision` package into their solution. Depending on the operating system, different packages are needed:
- Windows: `IronOcr.ComputerVision.Windows`
- Linux: `IronOcr.ComputerVision.Linux`
- macOS: `IronOcr.ComputerVision.MacOS`
- macOS ARM: `IronOcr.ComputerVision.MacOS.ARM`

Install the necessary package via NuGet Package Manager or input the following command in the Package Manager Console:
```plaintext
PM> Install-Package IronOcr.ComputerVision.Windows
```
This will include the required assemblies to employ IronOCR Computer Vision with our model file.

## Available Methods and APIs

Below is an overview of currently available methods:

<table class="table">
    <tr>
        <th>Method</th>
        <th>Description</th>
    </tr>
    <tr>
        <td><a href="#anchor-findtextregion">FindTextRegion</a></td>
        <td>Detects text-containing regions and instructs Tesseract to target these detected areas.</td>
    </tr>
     <tr>
        <td><a href="#anchor-findmultipletextregions">FindMultipleTextRegions</a></td>
        <td>Identifies text-containing areas and segments the image according to these regions.</td>
    </tr>
    <tr>
        <td><a href="#anchor-gettextregions">GetTextRegions</a></td>
        <td>Returns a list of detected text regions as `List<CropRectangle>`.</td>
    </tr>
</table>

## FindTextRegion

`FindTextRegion` identifies text-containing regions in every page of an `OcrInput` object:
```cs
using IronOcr;

var ocr = new IronTesseract();
using var input = new OcrInput();
input.LoadImage("/path/file.png");

input.FindTextRegion();
OcrResult result = ocr.Read(input);
string resultText = result.Text;
```

Custom parameters can be added:
```cs
using IronOcr;

var ocr = new IronTesseract();
using var input = new OcrInput();
input.LoadImage("/path/file.png");

input.FindTextRegion(Scale: 2.0, DilationAmount: 20, Binarize: true, Invert: true);
OcrResult result = ocr.Read(input);
string resultText = result.Text;
```

To demonstrate, consider the below image:
```cs
using IronOcr;
using IronSoftware.Drawing;
using System;
using System.Linq;

var ocr = new IronTesseract();
using var input = new OcrInput();
input.LoadImage("wh-words-sign.jpg");

Rectangle textCropArea = input.GetPages().First().FindTextRegion();

input.StampCropRectangleAndSaveAs(textCropArea, Color.Red, "image_text_area", AnyBitmap.ImageFormat.Png);

var ocrResult = ocr.Read("wh-words-sign.jpg", textCropArea);
Console.WriteLine(ocrResult.Text);
```
This provides a `.png` showcasing the detected region by Computer Vision, as illustrated here:

<div class="center-image-wrapper">
    <img src="https://ironsoftware.com/static-assets/ocr/how-to/computer-vision/text_area_0.PNG" alt="Highlighted Text Area" class="img-responsive add-shadow">
</div>

The printed output is:
```text
IRONSOFTWARE

50,000+

Developers in our active community

10,777,061 19,313
NuGet downloads Support tickets resolved
50%+ 80%+
Engineering Team growth Support Team growth
$25,000+

Raised with #TEAMSEAS to clean our beaches & waterways
```

## Advanced Detection with FindMultipleTextRegions

This method parses all pages of an `OcrInput` object to discover regions with text, dividing them into separate images based on these regions:
```cs
using IronOcr;

var ocr = the IronTesseract();
using var input = new OcrInput();
input.LoadImage("/path/file.png");

input.FindMultipleTextRegions();
OcrResult result = ocr.Read(input);
string resultText = result.Text;
```
Customization options are available:
```cs
using IronOcr;

var ocr = new IronTesseract();
using var input = a new OcrInput();
input.LoadImage("/path/file.png");

input.FindMultipleTextRegions(Scale: 2.0, DilationAmount: -1, Binarize: true, Invert: false);
OcrResult result = ocr.Read(input);
string resultText = result.Text;
```
Another function allows for extracting multiple OCR Pages from a single OCR Page based on text regions:
```cs
using IronOcr;
using System.Collections.Generic;
using System.Linq;

int pageIndex = 0;
using var input = new OcrInput();
input.LoadImage("/path/file.png");

var selectedPage = input.GetPages().ElementAt(pageIndex);
List<OcrInputPage> textRegionsOnPage = selectedPage.FindMultipleTextRegions();
```

## Comprehensive Analyses with GetTextRegions

This function delivers a list of textual regions identified in an image page:
```cs
using IronOcr;
using IronSoftware.Drawing;
using System.Collections.Generic;
using System.Linq;

int pageIndex = 0;
using var input = new OcrInput();
input.LoadImage("/path/file.png");

var selectedPage = input.GetPages().ElementAt(pageIndex);
// List<Rectangle> regions = selectedPage.GetTextRegions();
```

### Specialized Usage Scenarios

With optimal settings and input, OCR can strikingly replicate human reading abilities.