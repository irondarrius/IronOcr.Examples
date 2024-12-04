# Leveraging Computer Vision to Identify Text

***Based on <https://ironsoftware.com/how-to/computer-vision/>***


## Introduction

IronOCR integrates OpenCV to employ computer vision techniques for identifying text-rich regions in images. This capability is particularly valuable in noisy images, images with text scattered across multiple locations, or images with distorted text. IronOCR's computer vision approach identifies these text areas and then employs Tesseract to read the text from these regions.

- [OCR Tutorial for License Plates in C#](https://ironsoftware.com/csharp/ocr/blog/using-ironocr/license-plate-ocr-csharp-tutorial/)
- [Extract Text from Invoices in C# - A Tutorial](https://ironsoftware.com/csharp/ocr/blog/using-ironocr/invoice-ocr-csharp-tutorial/)
- [OCR Tutorial: Extracting Text from Screenshots in C#](https://ironsoftware.com/csharp/ocr/blog/using-ironocr/get-text-ocr-screenshot-csharp-tutorial/)
- [Subtitle OCR in C# - Comprehensive Guide](https://ironsoftware.com/csharp/ocr/blog/using-ironocr/subtitle-ocr-csharp-tutorial/)

***

***

## Installation of IronOCR.ComputerVision via NuGet Package

The Computer Vision capabilities of IronOCR, powered by OpenCV, are bundled within the standard IronOCR NuGet package.

To utilize these capabilities, the `IronOcr.ComputerVision` package must be installed from NuGet. Here are the platform-specific packages you might need:
- Windows: `IronOcr.ComputerVision.Windows`
- Linux: `IronOcr.ComputerVision.Linux`
- macOS: `IronOcr.ComputerVision.MacOS`
- macOS ARM: `IronOcr.ComputerVision.MacOS.ARM`

You can install them using the NuGet Package Manager or by entering the following command in the Package Manager Console:
```plaintext
PM> Install-Package IronOcr.ComputerVision.Windows
```
This command installs the necessary assemblies required to activate IronOCR’s Computer Vision capabilities.

## Functionality and API Overview

Below, you will find code samples demonstrating the use of IronOCR's Computer Vision features. First, here's an overview of the available methods:

<table class="table table__configuration-variables">
    <tr>
        <th scope="col">Method</th>
        <th scope="col">Explanation</th>
    </tr>
    <tr>
        <td><a href="#anchor-findtextregion">FindTextRegion</a></td>
        <td>Locates regions containing text and directs Tesseract to focus only on detected text areas.</td>
    </tr>
    <tr>
        <td><a href="#anchor-findmultipletextregions">FindMultipleTextRegions</a></td>
        <td>Identifies multiple text-laden regions and segregates the image into distinct sections based on these regions.</td>
    </tr>
    <tr>
        <td><a href="#anchor-gettextregions">GetTextRegions</a></td>
        <td>Scans the image and outputs a list of discerned text regions as `List<CropRectangle>`.</td>
    </tr>
</table>

## FindTextRegion

The `FindTextRegion` method employs computer vision to pinpoint text-containing regions on each page of an `OcrInput` object.

```cs
using IronOcr;
namespace ironocr.ComputerVision
{
    public class Section1
    {
        public void Run()
        {
            var ocr = new IronTesseract();
            using var input = new OcrInput();
            input.LoadImage("/path/file.png");
            
            // Computer Vision to detect the text regions
            input.FindTextRegion();
            
            OcrResult result = ocr.Read(input);
            string resultText = result.Text;
        }
    }
}
```

This method can be customized with various parameters for different scenarios:

```cs
using IronOcr;
namespace ironocr.ComputerVision
{
    public class Section2
    {
        public void Run()
        {
            var ocr = new IronTesseract();
            using var input = new OcrInput();
            input.LoadImage("/path/file.png");
            
            // Adjust parameters to optimize text detection
            input.FindTextRegion(Scale: 2.0, DilationAmount: 20, Binarize: true, Invert: true);
            OcrResult result = ocr.Read(input);
            string resultText = result.Text;
        }
    }
}
```

Below is an illustration of how `FindTextRegion` might be applied in an actual scenario, using a sample image:

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/computer-vision/iron-2022.webp" alt="Image with Text" class="img-responsive add-shadow">
    </div>
</div>

```cs
using System.Linq;
using IronOcr;
namespace ironocr.ComputerVision
{
    public class Section3
    {
        public void Run()
        {
            var ocr = new IronTesseract();
            using var input = new OcrInput();
            input.LoadImage("wh-words-sign.jpg");
            
            // Detect the text region
            Rectangle textCropArea = input.GetPages().First().FindTextRegion();
            
            // Demonstrate the detected region by highlighting it
            input.StampCropRectangleAndSaveAs(textCropArea, Color.Red, "image_text_area", AnyBitmap.ImageFormat.Png);
            
            // Read the text within the cropped area
            var ocrResult = ocr.Read("wh-words-sign.jpg", textCropArea);
            Console.WriteLine(ocrResult.Text);
        }
    }
}
```

Displayed image shows where IronCV detected text. The `StampCropRectangleAndSaveAs` method saves this instance for debugging, showing the effectiveness of the Computer Vision in text detection.

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/computer-vision/text_area_0.PNG" alt="Image with Text Area Highlighted" class="img-responsive add-shadow">
    </div>
</div>

The resultant text reads:

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

## FindMultipleTextRegions

The `FindMultipleTextRegions` method analyzes an `OcrInput` object, identifies all text regions, and segments the image accordingly:

```cs
using IronOcr;
namespace ironocr.ComputerVision
{
    public class Section4
    {
        public void Run()
        {
            var ocr = new IronTesseract();
            using var input = new OcrInput();
            input.LoadImage("/path/file.png");
            
            // Detect multiple text regions
            input.FindMultipleTextRegions();
            OcrResult result = ocr.Read(input);
            string resultText = result.Text;
        }
    }
}
```

Options for tweaking the method's behavior include:

```cs
using IronOcr;
namespace ironocr.ComputerVision
{
    public class Section5
    {
        public void Run()
        {
            var ocr = new IronTesseract();
            using var input = an OcrInput();
            input.LoadImage("/path/file.png");
            
            // Custom settings for detecting multiple text regions
            input.FindMultipleTextRegions(Scale: 2.0, DilationAmount: -1, Binarize: true, Invert: false);
            OcrResult result = ocr.Read(input);
            string resultText = result.Text;
        }
    }
}
```

An advanced use of `FindMultipleTextRegions` can be seen where it segments an OCR page into smaller regions, each represented by a separate OCR page:

```cs
using System.Linq;
using IronOcr;
namespace ironocr.ComputerVision
{
    public class Section6
    {
        public void Run()
        {
            int pageIndex = 0;
            using var input = an OcrInput();
            input.LoadImage("/path/file.png");
            
            var selectedPage = input.GetPages().ElementAt(pageIndex);
            List<OcrInputPage> textRegionsOnPage = selectedPage.FindMultipleTextRegions();
        }
    }
}
```

## GetTextRegions

The `GetTextRegions` method grants a list of crop areas, pinpointing each detected text segment:

```cs
using System.Linq;
using IronOcr;
namespace ironocr.ComputerVision
{
    public class Section7
    {
        public void Run()