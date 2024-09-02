# Understanding Document Processing Techniques

Reading various types of documents like standard text files, license plates, passports, and photos using a uniform approach can be exceedingly difficult. The complexities arise from the variability in layouts, formats, and content specific to each type of document. Additionally, factors like image quality issues and specialized content make it tougher to maintain accuracy while managing performance efficiently across a broader set of document types.

IronOCR offers specialized methods aimed at enhancing OCR (Optical Character Recognition) accuracy and efficiency for distinct document types including standard text documents, license plates, passports, and photos.

## Overview of the Package

The specialized techniques `ReadLicensePlate`, `ReadPassport`, `ReadPhoto`, and `ReadScreenShot` complement the core functionalities of the IronOCR library, necessitating the installation of [IronOcr.Extensions.AdvancedScan](https://www.nuget.org/packages/IronOcr.Extensions.AdvancedScan). Presently, this extension is available exclusively for Windows platforms.

These methods leverage OCR engine settings like blacklists and whitelists. Support for multiple languages such as Chinese, Japanese, Korean, and those using the Latin alphabet is available across all functionalities except for `ReadPassport`. Each additional language requires the corresponding package from [IronOcr.Languages](https://www.nuget.org/packages?q=ironocr.languages&includeComputedFrameworks=true&prerel=true&sortby=relevance).

To utilize advanced scanning with the .NET Framework, ensure the project is set to run in x64 architecture by deselecting the "Prefer 32-bit" option in the project configuration. More details can be found in the guide: "[Advanced Scan on .NET Framework](https://ironsoftware.com/csharp/ocr/troubleshooting/advanced-scan-on-net-framework/)."

## Example of Reading a Document

The `ReadDocument` method excels in processing scanned documents or photos with substantial text. Setting the **PageSegmentationMode** properly is crucial for handling various document layouts effectively. For instance, **SingleBlock** handles text in a consolidated block, while **SparseText** is suitable for documents where text is distributed sporadically.

```cs
using IronOcr;
using System;

// Create a new OCR engine
var ocr = new IronTesseract();

// Set the page segmentation mode
ocr.Configuration.PageSegmentationMode = TesseractPageSegmentationMode.SingleBlock;

// Load a PDF into the OCR engine
using var input = new OcrInput("Five.pdf");

// Execute OCR on the document
OcrResult result = ocr.Read(input);

// Output the extracted text
Console.WriteLine(result.Text);
```

## License Plate Recognition Example

The `ReadLicensePlate` function is tailored for extracting license plate information from images.

```cs
using IronOcr;
using IronSoftware.Drawing;
using System;

var ocr = new IronTesseract();

using var inputLicensePlate = new OcrInput("LicensePlate.jpeg");

OcrLicensePlateResult result = ocr.ReadLicensePlate(inputLicensePlate);

Rectangle rectangle = result.Licenseplate;
string output = result.Text;
```

## Passport Information Extraction Example

The `ReadPassport` method efficiently extracts crucial information from passport photos.

```cs
using IronOcr;
using System;

var ocr = new IronTesseract();

using var inputPassport = new OcrInput();
inputPassport.LoadImage("Passport.jpg");

OcrPassportResult result = ocr.ReadPassport(inputPassport);

Console.WriteLine(result.PassportInfo.GivenNames);
Console.WriteLine(result.PassportInfo.Country);
Console.WriteLine(result.PassportInfo.PassportNumber);
Console.WriteLine(result.PassportInfo.Surname);
Console.WriteLine(result.PassportInfo.DateOfBirth);
Console.WriteLine(result.PassportInfo.DateOfExpiry);
```

### Passport Reading Result Visual Example

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-specific-document/read-passport.webp" alt="Read Passport" class="img-responsive add-shadow">
    </div>
</div>

It's important to ensure the document image is clear of any extraneous text to avoid misinterpretation.

## Photo Text Extraction Example

The `ReadPhoto` method specializes in texts embedded within complex image backgrounds.

```cs
using IronOcr;
using IronSoftware.Drawing;

var ocr = new IronTesseract();

using var inputPhoto = new OcrInput();
inputPhoto.LoadImageFrame("photo.tif", 2);

OcrPhotoResult result = ocr.ReadPhoto(inputPhoto);

int number = result.TextRegions[0].FrameNumber;
string textinregion = result.TextRegions[0].TextInRegion;
Rectangle region = result.TextRegions[0].Region;
```

## Screenshot Text Retrieval Example

`ReadScreenShot` is designed to capture and decode text from screenshots.

```cs
using IronOcr;
using System;
using System.Linq;

var ocr = new IronTesseract();

using var inputScreenshot = new OcrInput();
inputScreenshot.LoadImage("screenshot.png");

OcrPhotoResult result = ocr.ReadScreenShot(inputScreenshot);

Console.WriteLine(result.Text);
Console.WriteLine(result.TextRegions.First().Region.X);
Console.WriteLine(result.TextRegions.Last().Region.Width);
Console.WriteLine(result.Confidence);
```