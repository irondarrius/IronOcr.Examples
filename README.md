![Nuget](https://img.shields.io/nuget/v/IronOcr?color=informational&label=latest)![Installs](https://img.shields.io/nuget/dt/IronOcr?color=informational&label=installs&logo=nuget)![Passed](https://img.shields.io/badge/build-%20%E2%9C%93%20392%20tests%20passed%20(0%20failed)%20-107C10?logo=visualstudio)[![windows](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=windows)](https://ironsoftware.com/csharp/ocr/docs/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield)![macOS](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=apple)[![linux](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=linux&logoColor=white)](https://ironsoftware.com/csharp/ocr/docs/questions/tesseract-ocr-setup-linux-ubuntu-debian/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield)[![docker](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=docker&logoColor=white)](https://ironsoftware.com/csharp/ocr/docs/questions/csharp-tesseract-ocr-docker-linux-setup-tutorial/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield)![aws](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=amazonaws)[![microsoftazure](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=microsoftazure)](https://ironsoftware.com/csharp/ocr/docs/questions/iron-ocr-azure-tutorial/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield)[![livechat](https://img.shields.io/badge/Live%20Chat-8%20Engineers%20Active%20Today-purple?logo=googlechat&logoColor=white)](https://ironsoftware.com/csharp/ocr/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield#helpscout-support)

## IronOCR: Your Premier .NET OCR Library

[![IronOCR NuGet Trial Banner Image](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronOCR-readme/nuget-trial-banner.png)](https://ironsoftware.com/csharp/ocr/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topbanner#trial-license)

[Get Started](https://ironsoftware.com/csharp/ocr/docs/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=navigation) | [Code Examples](https://ironsoftware.com/csharp/ocr/examples/simple-csharp-ocr-tesseract/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=navigation) | [Licensing](https://ironsoftware.com/csharp/ocr/licensing/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=navigation) | [Free Trial](https://ironsoftware.com/csharp/ocr/docs/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=navigation#trial-license)

IronOCR is an advanced library from Iron Software specifically designed for .NET developers who need robust Optical Character Recognition, Barcode Scanning, and Text Extraction capabilities.

#### Highlights of IronOCR:

  * Capable of reading multiple formats including images (jpg, png, gif, tiff, bmp), PDFs, and more.
  * Provides [a suite of image correction filters](https://ironsoftware.com/csharp/ocr/tutorials/c-sharp-ocr-image-filters/) such as Deskew, Denoise, Binarize, Enhance Resolution, Dilate, among others.
  * Supports barcode reading from over 20 different formats, including QR codes.
  * Features an optimally tuned build of Tesseract OCR.
  * Outputs Searchable PDFs, hOCR/HTML, and image content as text.

### Compatibility of IronOCR:

  * Versions: **.NET 8**, .NET 7, .NET 6, .NET 5, .NET Core, .NET Standard, and .NET Framework
  * Platforms: Windows, macOS, Linux, Docker, Azure, AWS

[![IronOCR Cross Platform Compatibility Support Image](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronOCR-readme/cross-platform-compatibility.png)](https://ironsoftware.com/csharp/ocr/docs/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=crossplatformbanner)

For additional resources such as our [API reference](https://ironsoftware.com/csharp/ocr/object-reference/api/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs) and [licensing details](https://ironsoftware.com/csharp/ocr/licensing/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs), visit our website.

### Getting Started with IronOCR

To use IronOCR in your project, simply install the NuGet package using the following command:

    PM> Install-Package IronOCR
    
After installation, include `using IronOcr` at the beginning of your C# scripts. Below is a basic example of using IronOCR to read text from images and PDFs:

    using IronOcr;
    
    var ocr = new IronTesseract();
    
    using (var ocrInput = new OcrInput())
    {
        ocrInput.LoadImage("image.png");
        ocrInput.LoadPdf("document.pdf");
        
        // Apply Filters if necessary:
        // ocrInput.Deskew();  // Corrects tilted images
        // ocrInput.DeNoise(); // Cleans digital noise
        
        var ocrResult = ocr.Read(ocrInput);
        Console.WriteLine(ocrResult.Text);
    }
    

### IronOCR Capabilities Chart

[![IronOCR Features](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronOCR-readme/features-table.png)](https://ironsoftware.com/csharp/ocr/features/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=featuresbanner)

Explore the forefront of .NET OCR technology with IronOCR 2024, supporting:

  * Languages: C#, F#, VB.NET
  * .NET versions: 8, 7, 6, 5, Core 2x & 3x, Standard 2, Framework 4.6.2+
  * App types: Console, Web, Desktop
  * Platforms: Windows, Linux, macOS, Docker, AWS, Azure
  * Tools: Microsoft Visual Studio, JetBrains ReSharper & Rider
  * Features: Barcode, QR Code, Text detection

#### Licensing and Support

For tutorials, documentation and code samples visit our [support page](https://ironsoftware.com/csharp/ocr/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs).

For additional assistance or inquiries, contact us at: support@ironsoftware.com

### Documentation Links

  * Code Samples: [https://ironsoftware.com/csharp/ocr/examples/](https://ironsoftware.com/csharp/ocr/examples/simple-csharp-ocr-tesseract/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)
  * API Reference: [https://ironsoftware.com/csharp/ocr/object-reference/api/](https://ironsoftware.com/csharp/ocr/object-reference/api/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)
  * Tutorials: [https://ironsoftware.com/csharp/ocr/tutorials/](https://ironsoftware.com/csharp/ocr/tutorials/how-to-read-text-from-an-image-in-csharp-net/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)
  * Licensing Info: [https://ironsoftware.com/csharp/ocr/licensing/](https://ironsoftware.com/csharp/ocr/licensing/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)
  * Live Chat Support: [https://ironsoftware.com/csharp/ocr/#helpscout-support](https://ironsoftware.com/csharp/ocr/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs#helpscout-support)