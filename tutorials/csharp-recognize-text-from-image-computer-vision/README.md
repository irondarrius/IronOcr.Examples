# Guide to Leveraging IronOCR Computer Vision

***Based on <https://ironsoftware.com/tutorials/csharp-recognize-text-from-image-computer-vision/>***


## Introduction

IronOCR employs OpenCV to implement Computer Vision, which identifies text-rich regions within an image. This feature is particularly beneficial for processing images that are noisy, contain text in multiple places, or have distorted text. By deploying computer vision, IronOCR can pinpoint regions where text is present and subsequently use Tesseract for text extraction.

## Installing IronOCR.ComputerVision via NuGet Package

The Computer Vision functionality in IronOCR is accessible through the standard IronOCR NuGet package. To use these functionalities, you need to ensure the `IronOcr.ComputerVision` package is installed in your project. Here are the platform-specific packages:
- Windows: `IronOcr.ComputerVision.Windows`
- Linux: `IronOcr.ComputerVision.Linux`
- macOS: `IronOcr.ComputerVision.MacOS`
- macOS ARM: `IronOcr.ComputerVision.MacOS.ARM`

For installation, utilize the NuGet Package Manager or execute the following command in the Package Manager Console:
```
PM> Install-Package IronOcr.ComputerVision.Windows
```
This command installs the essential assemblies required to integrate IronOCR Computer Vision into your application.

## Functionality and API Overview

Below are some key methods available for IronOCR Computer Vision:

<table class="table table__configuration-variables">
    <tr>
        <th scope="col">Method</th>
        <th scope="col">Explanation</th>
    </tr>
    <tr>
        <td><a href="#anchor-findtextregion">FindTextRegion</a></td>
        <td class="word-break--break-word">Identifies regions with text and directs Tesseract to analyze these specific areas.</td>
    </tr>
    <tr>
        <td><a href="#anchor-findmultipletextregions">FindMultipleTextRegions</a></td>
        <td class="word-break--break-word">Locates text regions and segregates them into distinct images for individual processing.</td>
    </tr>
    <tr>
        <td><a href="#anchor-gettextregions">GetTextRegions</a></td>
        <td class="word-break--break-word">Scans an image and outputs a collection of identified text regions as `List<CropRectangle>`.</td>
    </tr>
</table>

## Code Examples

### FindTextRegion

The `FindTextRegion` method applies computer vision to detect text across all pages of an `OcrInput` object.
```cs
using IronOcr;
namespace ironocr.CsharpRecognizeTextFromImageComputerVision
{
    public class Section1
    {
        public void Run()
        {
            var ocr = new IronTesseract();
            using var input = new OcrInput();
            // Loading an image
            input.LoadImage("https://ironsoftware.com/path/file.png");
            
            input.FindTextRegion();
            OcrResult result = ocr.Read(input);
            string resultText = result.Text;
        }
    }
}
```

This method can be customized using additional parameters:
```cs
using IronOcr;
namespace ironocr.CsharpRecognizeTextFromImageComputerVision
{
    public class Section2
    {
        public void Run()
        {
            var ocr = new IronTesseract();
            using var input = new OcrInput();
            // Loading an image
            input.LoadImage("https://ironsoftware.com/path/file.png");
            
            input.FindTextRegion(Scale: 2.0, DilationAmount: 20, Binarize: true, Invert: true);
            OcrResult result = ocr.Read(input);
            string resultText = result.Text;
        }
    }
}
```

You can also retrieve the text region as a `Rectangle` using this overload:
```cs
using IronOcr;
namespace ironocr.CsharpRecognizeTextFromImageComputerVision
{
    public class Section3
    {
        public void Run()
        {
            using var input = new OcrInput();
            // Loading image for processing
            input.LoadImage("https://ironsoftware.com/path/file.png");
            
            input.FindTextRegion(Scale: 2.0, Binarize: true);
        }
    }
}
```
### FindMultipleTextRegions

`FindMultipleTextRegions` processes all pages of an `OcrInput` 객체 to detect text areas and splits the data into distinct images:
```cs
using IronOcr;
namespace ironocr.CsharpRecognizeTextFromImageComputerVision
{
    public class Section4
    {
        public void Run()
        {
            var ocr = new IronTesseract();
            using var input = new OcrInput();
            // Loading image for OCR
            input.LoadImage("https://ironsoftware.com/path/file.png");
            
            input.FindMultipleTextRegions();
            OcrResult result = ocr.Read(input);
            string resultText = result.Text;
        }
    }
}
```
Customizable parameters are available for this method:
```cs
using IronOcr;
namespace ironocr.CsharpRecognizeTextFromImageComputerVision
{
    public class Section5
    {
        public void Run()
        {
            var ocr = new IronTesseract();
            using var input = a new OcrInput();
            // Loading image
            input.LoadImage("https://ironsoftware.com/path/file.png");
            
            input.FindMultipleTextRegions(Scale: 2.0, DilationAmount: -1, Binarize: true, Invert: false);
            OcrResult result = ocr.Read(input);
            string resultText = result.Text;
        }
    }
}
```
Another option for `FindMultipleTextRegions` returns an array of OCR Pages, each representing a discovered text area:
```cs
using System.Linq;
using IronOcr;
namespace ironocr.CsharpRecognizeTextFromImageComputerVision
{
    public class Section6
    {
        public void Run()
        {
            int pageIndex = 0;
            using var input = a new OcrInput();
            // Load an image for extraction
            input.LoadImage("https://ironsoftware.com/path/file.png");
            
            var selectedPage = input.GetPages().ElementAt(pageIndex);
            List<OcrInputPage> textRegionsOnPage = selectedPage.FindMultipleTextRegions();
        }
    }
}
```

### GetTextRegions

The `GetTextRegions` function retrieves a list of cropping areas detected with text within a page:
```cs
using System.Linq;
using IronOcr;
namespace ironocr.CsharpRecognizeTextFromImageComputerVision
{
    public class Section7
    {
        public void Run()
        {
            int pageIndex = 0;
            using var input = new OcrInput();
            // Image loading for OCR task
            input.LoadImage("https://ironsoftware.com/path/file.png");
            
            var selectedPage = input.GetPages().Elementat(pageIndex);
            var regions = selectedPage.GetTextRegions();
        }
    }
}
```
These examples illustrate how to implement IronOCR's Computer Vision features to enhance text recognition in complex images.