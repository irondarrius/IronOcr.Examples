# Leveraging Computer Vision to Locate Text in Images

## Introduction
IronOCR incorporates OpenCV to harness the power of Computer Vision in identifying potential text regions within images. This functionality proves valuable in scenarios involving complex images with background noise, multiple text areas, or distorted texts. IronOCR's Computer Vision component locates text regions for further processing by Tesseract OCR engine which reads the text.

- [How to OCR License Plate in C# (Tutorial)](https://ironsoftware.com/csharp/ocr/blog/using-ironocr/license-plate-ocr-csharp-tutorial/)
- [How to Extract Text From Invoice in C# Tutorial](https://ironsoftware.com/csharp/ocr/blog/using-ironocr/invoice-ocr-csharp-tutorial/)
- [How to Retrieve Text From Screenshot in C#](https://ironsoftware.com/csharp/ocr/blog/using-ironocr/get-text-ocr-screenshot-csharp-tutorial/)
- [How to OCR Subtitles in C# (Tutorial)](https://ironsoftware.com/csharp/ocr/blog/using-ironocr/subtitle-ocr-csharp-tutorial/)

***



***

## Installation of IronOCR.ComputerVision via NuGet
The OpenCV functionalities, which enable Computer Vision within IronOCR, can be found within the conventional IronOCR NuGet package.

For utilizing these functionalities, the following targeted installations are necessary through the NuGet:
- For Windows: `IronOcr.ComputerVision.Windows`
- For Linux: `IronOcr.ComputerVision.Linux`
- For macOS: `IronOcr.ComputerVision.MacOS`
- For macOS ARM: `IronOcr.ComputerVision.MacOS.ARM`

You can install the necessary package using the NuGet Package Manager Console as shown:
```plaintext
PM> Install-Package IronOcr.ComputerVision.Windows
```
This installation ensures the required assemblies are available for using IronOCR's Computer Vision capabilities.

## Capabilities and API Details
Below are methods highlighted with their respective functionalities:

<table class="table table__configuration-variables">
    <tr>
        <th scope="col">Method</th>
        <th scope="col">Description</th>
    </tr>
    <tr>
        <td><a href="#anchor-findtextregion">FindTextRegion</a></td>
        <td>Identifies text-containing regions to isolate text searching within those detected areas.</td>
    </tr>
     <tr>
        <td><a href="#anchor-findmultipletextregions">FindMultipleTextRegions</a></td>
        <td>Splits the page into separate images by identifying multiple text-rich areas.</td>
    </tr>
    <tr>
        <td><a href="#anchor-gettextregions">GetTextRegions</a></td>
        <td>Returns identified text areas as a list of `List<CropRectangle>`.</td>
    </tr>
</table>

## Text Detection Techniques

### FindTextRegion

The `FindTextRegion` method employs Computer Vision to discern text-rich zones on every page of an `OcrInput` object:

```cs
using IronOcr;

var ocr = new IronTesseract();
using var input = new OcrInput("/path/file.png");

input.FindTextRegion();
OcrResult result = ocr.Read(input);
string resultText = result.Text;
```

For further refinement, you can adjust parameters as required:

```cs
using IronOcr;

var ocr = new IronTesseract();
using var input = new OcrInput("/path/file.png");

input.FindTextRegion(Scale: 2.0, DilationAmount: 20, Binarize: true, Invert: true);
OcrResult result = ocr.Read(input);
string resultText = result.Text;
```

In the following example, `FindTextRegion` is used to pinpoint the text area in a custom scenario:

```cs
using IronOcr;
using IronSoftware.Drawing;
using System;
using System.Linq;

var ocr = new IronTesseract();
using var input = new OcrInput("wh-words-sign.jpg");

// Using Computer Vision to find the text region
Rectangle textCropArea = input.GetPages().First().FindTextRegion();

// Debugging: Viewing the detected text area
input.StampCropRectangleAndSaveAs(textCropArea, Color.Red, "image_text_area", AnyBitmap.ImageFormat.Png);

// Optimizing OCR read by applying the detected area
var ocrResult = ocr.Read("wh-words-sign.jpg", textCropArea);
Console.WriteLine(ocrResult.Text);
```

Here you see two outcomes: a `.png` file which helps in debugging by highlighting text regions, and the text output from OCR.

```plaintext
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

### FindMultipleTextRegions

The `FindMultipleTextRegions` approach isolates different text-rich zones into separate images for detailed analysis:

```cs
using IronOcr;

var ocr = new IronTesseract();
using var input = new OcrInput();
input.LoadImage("/path/file.png");

input.FindMultipleTextRegions();
OcrResult result = ocr.Read(input);
string resultText = result.Text;
```

Optionally, modify parameters to adjust the detection setting:

```cs
using IronOcr;

var ocr = new IronTesseract();
using var input = a new OcrInput("/path/file.png");

input.FindMultipleTextRegions(Scale: 2.0, DilationAmount: -1, Binarize: true, Invert: false);
OcrResult result = ocr.Read(input);
string resultText = result.Text;
```

By segmenting an OCR page into text regions, further analysis can be performed more efficiently:

```cs
using IronOcr;
using System.Collections.Generic;
using System.Linq;

int pageIndex = 0;
using var input = a new OcrInput("/path/file.png");

var selectedPage = input.GetPages().ElementAt(pageIndex);
List<OcrInputPage> textRegionsOnPage = selectedPage.FindMultipleTextRegions();
```

### GetTextRegions

Utilizing `GetTextRegions` provides a clear list of identified text areas on a page:

```cs
using IronOcr;
using IronSoftware.Drawing;
using System.Collections.Generic;
using System.Linq;

int pageIndex = 0;
using var input = a new OcrInput("/path/file.png");

var selectedPage = input.GetPages().ElementAt(pageIndex);
// List<Rectangle> regions = selectedPage.GetTextRegions();
```

### Specific Application Guides

Properly configured and utilized, OCR offers remarkable capabilities approximating human-level reading accuracy.