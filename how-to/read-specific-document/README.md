# Reading Specific Documents Effectively

***Based on <https://ironsoftware.com/how-to/read-specific-document/>***


Reading specific types of documents, such as standard texts, license plates, passports, and image-based content presents numerous challenges. The diversity in document formats and layouts, the variability of image quality and distortions, along with specialized content, make it tough to rely on a single method for accurate document reading. Moreover, understanding the context and balancing both performance and efficiency is increasingly complex when dealing with a wide array of document types.

IronOCR has developed tailored methods for OCR on distinct document items including standard text documents, license plates, passports, and photos, ensuring high accuracy and optimal performance.

### Introduction to IronOCR

## Package Overview

To utilize specialized OCR methods such as `ReadLicensePlate`, `ReadPassport`, `ReadPhoto`, and `ReadScreenShot`, the [IronOcr.Extensions.AdvancedScan](https://www.nuget.org/packages/IronOcr.Extensions.AdvancedScan) extension package must be installed. This package currently works exclusively on Windows platforms.

These methods leverage OCR engine settings including blacklist and whitelist configurations. They also support multiple languages such as Chinese, Japanese, Korean, and the Latin alphabet in all methods except `ReadPassport`. Each language integration requires an additional package, [IronOcr.Languages](https://www.nuget.org/packages?q=ironocr.languages&includeComputedFrameworks=true&prerel=true&sortby=relevance).

For effective advanced scanning on the .NET Framework, the application must run on x64 architecture. To configure this, navigate to your project settings and deselect the "Prefer 32-bit" option. For further details, check the guide on ["Advanced Scan on .NET Framework"](https://ironsoftware.com/csharp/ocr/troubleshooting/advanced-scan-on-net-framework/).

## Example Usage of the ReadDocument Method

`ReadDocument` is a method specifically designed for scanning high-text-volume documents or photos. Configuring the **PageSegmentationMode** is crucial for different document layouts, as modes like **SingleBlock** treat the text as a cohesive block, while **SparseText** assumes text is dispersed across the document.

```cs
using IronOcr;
using System;

// Create a new OCR engine instance
var ocr = new IronTesseract();

// Set OCR configuration for page segmentation
ocr.Configuration.PageSegmentationMode = TesseractPageSegmentationMode.SingleBlock;

using var input = new OcrInput();
input.LoadPdf("Example-Document.pdf");

// Execute OCR
OcrResult result = ocr.ReadDocument(input);

// Display extracted text
Console.WriteLine(result.Text);
```

## Read License Plate Example

`ReadLicensePlate` method is finely tuned to extract details from license plate images. It identifies the license plate's location within the image document.

```cs
using IronOcr;
using IronSoftware.Drawing;
using System;

// Initialize the OCR engine
var ocr = new IronTesseract();

using var inputLicensePlate = new OcrInput();
inputLicensePlate.LoadImage("Vehicle-License-Plate.jpeg");

// Execute OCR to read the license plate
OcrLicensePlateResult result = ocr.ReadLicensePlate(inputLicensePlate);

// Extract coordinates and value of the license plate
Rectangle rectangle = result.Licenseplate;
string output = result.Text;
```

## Read Passport Example

`ReadPassport` efficiently extracts and reads passport information, focusing primarily on the machine-readable zone (MRZ), which includes critical data such as name, date of birth, and document number.

```cs
using IronOcr;
using System;

// Initialize the OCR engine
var ocr = new IronTesseract();

using var inputPassport = new OcrInput();
inputPassport.LoadImage("passport-image.jpg");

// Perform OCR to extract passport data
OcrPassportResult result = ocr.ReadPassport(inputPassport);

// Display the extracted passport information
Console.WriteLine(result.PassportInfo.GivenNames);
Console.WriteLine(result.PassportInfo.Country);
Console.WriteLine(result.PassportInfo.PassportNumber);
Console.WriteLine(result.PassportInfo.Surname);
Console.WriteLine(result.PassportInfo.DateOfBirth);
Console.WriteLine(result.PassportInfo.DateOfExpiry);
```

### Results Visualization

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-specific-document/read-passport.webp" alt="Read Passport" class="img-responsive add-shadow">
    </div>
</div>

Ensure that the document image is clear of any unnecessary text like headers or footers to prevent incorrect data extraction.

## Read Photo Example

`ReadPhoto` is well-suited for images with challenging text readability. It identifies text regions within the image.

```cs
using IronOcr;
using IronSoftware.Drawing;

// Create an OCR engine instance
var ocr = new IronTesseract();

using var inputPhoto = new OcrInput();
inputPhoto.LoadImageFrame("challenging-text-photo.tif", 2);

// Carry out OCR on the photo
OcrPhotoResult result = ocr.ReadPhoto(inputPhoto);

// Access text and region information
int number = result.TextRegions[0].FrameNumber;
string textinregion = result.TextRegions[0].TextInRegion;
Rectangle region = result.TextRegions[0].Region;
```

## Read Screenshot Example

The `ReadScreenShot` method applies similar text recognition techniques as the ReadPhoto method to decipher text in screenshots.

```cs
using IronOcr;
using System;
using System.Linq;

// Start the OCR engine
var ocr = new IronTesseract();

using var inputScreenshot = new OcrInput();
inputScreenshot.LoadImage("desktop-screenshot.png");

// Execute OCR
OcrPhotoResult result = ocr.ReadScreenShot(inputScreenshot);

// Output recognized text and region details
Console.WriteLine(result.Text);
Console.WriteLine(result.TextRegions.First().Region.X);
Console.WriteLine(result.TextRegions.Last().Region.Width);
Console.WriteLine(result.Confidence);
```