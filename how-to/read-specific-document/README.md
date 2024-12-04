# Reading Specific Documents Effectively

***Based on <https://ironsoftware.com/how-to/read-specific-document/>***


Accurately processing distinct documents like text files, license plates, passports, and photographs through a single method proves to be immensely challenging. This complexity is due to the various formats, layouts, and unique contents of each document type coupled with challenges like image quality and distortion. Moreover, the task of contextual comprehension alongside managing performance and efficiency increases as the diversity of document types expands.

IronOCR introduces tailored methods for OCR operations on specific documents such as text documents, license plates, passports, and photos to enhance accuracy and performance.

## Overview of the Package

The functions `ReadLicensePlate`, `ReadPassport`, `ReadPhoto`, and `ReadScreenShot` build upon the base IronOCR package and require installation of the [IronOcr.Extensions.AdvancedScan](https://www.nuget.org/packages/IronOcr.Extensions.AdvancedScan) package, which is currently available only for Windows.

These methods employ OCR engine configurations, facilitating the use of blacklist and whitelist options. They support multiple languages, including Chinese, Japanese, Korean, and the Latin alphabet, with the exception being the `ReadPassport` method. Note that each language integration necessitates an additional package, [IronOcr.Languages](https://www.nuget.org/packages?q=ironocr.languages&includeComputedFrameworks=true&prerel=true&sortby=relevance).

For utilizing advanced scans in the .NET Framework, configure your project to operate under x64 architecture by deselecting the "Prefer 32-bit" option in project settings. Further details can be found in the troubleshooting guide: "[Advanced Scan on .NET Framework](https://ironsoftware.com/csharp/ocr/troubleshooting/advanced-scan-on-net-framework/)."

## Example: Reading a Document

The `ReadDocument` method excels in processing scanned documents or photos containing substantial text. The **PageSegmentationMode** configuration plays a crucial role in accurately reading documents with varying layouts, such as **SingleBlock** for cohesive blocks of text or **SparseText** for documents where text is dispersed.

```cs
using System;
using IronOcr;
namespace ironocr.ReadSpecificDocument
{
    public class Section1
    {
        public void Run()
        {
            var ocr = new IronTesseract(); // Initialize OCR engine
            ocr.Configuration.PageSegmentationMode = TesseractPageSegmentationMode.SingleBlock;

            using var input = new OcrInput();
            input.LoadPdf("Five.pdf"); // Load the document

            OcrResult result = ocr.ReadDocument(input); // Execute OCR
            Console.WriteLine(result.Text); // Output the extracted text
        }
    }
}
```

### Example: Reading a License Plate

Optimized for extracting information from license plate images, the `ReadLicensePlate` method identifies the license plate's position and reads its content.

```cs
using System;
using IronOcr;
namespace ironocr.ReadSpecificDocument
{
    public class Section2
    {
        public void Run()
        {
            var ocr = new IronTesseract(); // Initialize OCR engine

            using var inputLicensePlate = new OcrInput();
            inputLicensePlate.LoadImage("LicensePlate.jpeg"); // Load the license plate image

            OcrLicensePlateResult result = ocr.ReadLicensePlate(inputLicensePlate); // Execute OCR

            Rectangle rectangle = result.Licenseplate; // License plate rectangle
            string output = result.Text; // Extracted text from license plate
        }
    }
}
```

### Example: Reading a Passport

The `ReadPassport` method specializes in extracting details from passport photos, particularly from the machine-readable zone (MRZ), which typically includes critical personal details. Currently, this method supports only the English language.

```cs
using System;
using IronOcr;
namespace ironocr.ReadSpecificDocument
{
    public class Section3
    {
        public void Run()
        {
            var ocr = new IronTesseract(); // Initialize OCR engine

            using var inputPassport = new OcrInput();
            inputPassport.LoadImage("Passport.jpg"); // Load the passport image

            OcrPassportResult result = ocr.ReadPassport(inputPassport); // Execute OCR

            // Display extracted passport information
            Console.WriteLine(result.PassportInfo.GivenNames);
            Console.WriteLine(result.PassportInfo.Country);
            Console.WriteLine(result.PassportInfo.PassportNumber);
            Console.WriteLine(result.PassportInfo.Surname);
            Console.WriteLine(result.PassportInfo.DateOfBirth);
            Console.WriteLine(result.PassportInfo.DateOfExpiry);
        }
    }
}
```

#### Result

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-specific-document/read-passport.webp" alt="Read Passport" class="img-responsive add-shadow">
    </div>
</div>

Ensure that the image includes only the passport's photo region to prevent confusion during extraction.

### Example: Reading a Photo

The `ReadPhoto` method is tailored for images with difficult-to-read text. It returns the **TextRegions** property, denoting identified text regions.

```cs
using IronSoftware.Drawing;
using IronOcr;
namespace ironocr.ReadSpecificDocument
{
    public class Section4
    {
        public void Run()
        {
            var ocr = new IronTesseract(); // Initialize OCR engine

            using var inputPhoto = new OcrInput();
            inputPhoto.LoadImageFrame("photo.tif", 2); // Load specific frame from a TIFF image

            OcrPhotoResult result = ocr.ReadPhoto(inputPhoto); // Execute OCR

            [snip]
```

## Example: Reading a Screenshot

The `ReadScreenShot` method, similar to `ReadPhoto`, specializes in screenshots containing text, returning valuable information about the text regions within the image.

```cs
using System.Linq;
using IronOcr;
namespace ironocr.ReadSpecificDocument
{
    [snip]