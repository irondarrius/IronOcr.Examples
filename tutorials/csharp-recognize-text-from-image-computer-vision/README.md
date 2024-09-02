# Guide to IronOCR Computer Vision Application

## Introduction

IronOCR incorporates OpenCV technology to engage computer vision techniques capable of detecting textual content within images. This capability proves invaluable with images that contain excessive noise, multiple text locations, or distorted text. By harnessing computer vision, IronOCR pinpoints text-rich areas, enabling the Tesseract engine to interpret the text accurately.

## Installing IronOCR.ComputerVision via NuGet Package

The functionalities encompassing computer vision in IronOCR are integrated within the usual IronOCR NuGet package.

To leverage these functionalities, it's necessary to install `IronOcr.ComputerVision` across different operating systems:

- Windows: `IronOcr.ComputerVision.Windows`
- Linux: `IronOcr.ComputerVision.Linux`
- macOS: `IronOcr.ComputerVision.MacOS`
- macOS ARM: `IronOcr.ComputerVision.MacOS.ARM`

Execute the following command in the NuGet Package Manager Console to begin the installation:
```
PM> Install-Package IronOcr.ComputerVision.Windows
```
This command ensures the required assemblies are made available for utilizing IronOCR Computer Vision alongside our model file.

## Overview of Functionality and API

Below, you will find a snapshot of the available methods with their respective descriptions:
<table class="table table__configuration-variables">
    <tr>
        <th scope="col">Method</th>
        <th scope="col">Explanation</th>
    </tr>
    <tr>
        <td><a href="#anchor-findtextregion">FindTextRegion</a></td>
        <td class="word-break--break-word">Identifies text-laden regions, directing Tesseract to focus its textual extraction on those detected areas.</td>
    </tr>
     <tr>
        <td><a href="#anchor-findmultipletextregions">FindMultipleTextRegions</a></td>
        <td class="word-break--break-word">Locates multiple text-bearing areas and delineates the image into distinct segments based on these regions.</td>
    </tr>
    <tr>
        <td><a href="#anchor-gettextregions">GetTextRegions</a></td>
        <td class="word-break--break-word">Scans an image to compile a listing of `List<CropRectangle>` containing detected text zones.</td>
    </tr>
</table>

## Coding Examples

### Using `FindTextRegion`

This method facilitates the detection of textual regions within an `OcrInput` object across all image pages:
```cs
using IronOcr;

var ocr = new IronTesseract();
using var input = new OcrInput();
// Loading at least one image
input.LoadImage("https://ironsoftware.com/path/file.png");

input.FindTextRegion();
OcrResult result = ocr.Read(input);
string resultText = result.Text;
```

Tailoring the task with specific parameters is also feasible:
```cs
using IronOcr;

var ocr = new IronTesseract();
using var input = new OcrInput();
// Ensuring the image is loaded
input.LoadImage("https://ironsoftware.com/path/file.png");

input.FindTextRegion(Scale: 2.0, DilationAmount: 20, Binarize: true, Invert: true);
OcrResult result = ocr.Read(input);
string resultText = result.Text;
```

The method also allows for returning the text region as a `Rectangle`:
```cs
using IronOcr;

using var input = new OcrInput();
// Image is loaded
input.LoadImage("https://ironsoftware.com/path/file.png");

input.FindTextRegion(Scale: 2.0, Binarize: true);
```

### Using `FindMultipleTextRegions`

This function processes an `OcrInput` object, detecting text-laden areas and splitting the input into separate images aligned with these regions:
```cs
using IronOcr;

var ocr = new IronTesseract();
using var input = new OcrInput();
// Image loading is essential
input.LoadImage("https://ironsoftware.com/path/file.png");

input.FindMultipleTextRegions();
OcrResult result = ocr.Read(input);
string resultText = result.Text;
```

Alterations with additional parameters are also supported:
```cs
using IronOcr;

var ocr = new IronTesseract();
using var input = an OcrInput();
// First, load the image
input.LoadImage("https://ironsoftware.com/path/file.png");

input.FindMultipleTextRegions(Scale: 2.0, DilationAmount: -1, Binarize: true, Invert: false);
OcrResult result = ocr.Read(input);
string resultText = result.Text;
```

Another version of `FindMultipleTextRegions` can extract and return multiple OCR Pages, one for each detected text region:
```cs
using IronOcr;
using System.Collections.Generic;
using System.Linq;

int pageIndex = 0;
using var input = an OcrInput();
// Remember to load the image
input.LoadImage("https://ironsoftware.com/path/file.png");

var selectedPage = input.GetPages().ElementAt(pageIndex);
List<OcrInputPage> textRegionsOnPage = selectedPage.FindMultipleTextRegions();
```

### Using `GetTextRegions`

Retrieves a inventory of cropping zones detected with text on an image page:
```cs
using IronOcr;
using IronSoftware.Drawing;
using System.Collections.Generic;
using System.Linq;

int pageIndex = 0;
using var input = an OcrInput();
// It is necessary to load an image
input.LoadImage("https://ironsoftware.com/path/file.png");

var selectedPage = input.GetPages().ElementAt(pageIndex);
var regions = selectedPage.GetTextRegions();
```