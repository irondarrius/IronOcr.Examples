![Nuget Version](https://img.shields.io/nuget/v/IronOcr?color=informational&label=latest)![Downloads](https://img.shields.io/nuget/dt/IronOcr?color=informational&label=installs&logo=nuget)![Build Status](https://img.shields.io/badge/build-%20%E2%9C%93%20392%20tests%20passed%20(0%20failed)%20-107C10?logo=visualstudio)[![Windows Compatible](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=windows)](https://ironsoftware.com/csharp/ocr/docs/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield)![macOS Compatible](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=apple)[![Linux Compatible](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=linux&logoColor=white)](https://ironsoftware.com/csharp/ocr/docs/questions/tesseract-ocr-setup-linux-ubuntu-debian/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield)[![Docker Compatible](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=docker&logoColor=white)](https://ironsoftware.com/csharp/ocr/docs/questions/csharp-tesseract-ocr-docker-linux-setup-tutorial/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield)![AWS Compatible](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=amazonaws)[![Azure Compatible](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=microsoftazure)](https://ironsoftware.com/csharp/ocr/docs/questions/iron-ocr-azure-tutorial/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield)[![Live Chat Support](https://img.shields.io/badge/Live%20Chat-8%20Engineers%20Active%20Today-purple?logo=googlechat&logoColor=white)](https://ironsoftware.com/csharp/ocr/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield#helpscout-support)

## IronOCR - A Sophisticated Optical Character Recognition Library for .NET

[![IronOCR NuGet Trial](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronOCR-readme/nuget-trial-banner.png)](https://ironsoftware.com/csharp/ocr/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topbanner#trial-license)

[Get Started](https://ironsoftware.com/csharp/ocr/docs/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=navigation) | [Code Samples](https://ironsoftware.com/csharp/ocr/examples/simple-csharp-ocr-tesseract/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=navigation) | [License Details](https://ironsoftware.com/csharp/ocr/licensing/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=navigation) | [Try for Free](https://ironsoftware.com/csharp/ocr/docs/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=navigation#trial-license)

IronOCR is crafted by Iron Software, which equips C# developers with tools to enable Optical Character Recognition, Barcode Scanning, and Text Extraction functionalities in .NET based applications.

#### IronOCR stands out by:

  * Extracting text from various formats like images (jpg, png, gif, tiff, bmp), gif, tif/tiff, streams, and PDFs.
  * Enhancing low-quality scans and images using [a variety of filters](https://ironsoftware.com/csharp/ocr/tutorials/c-sharp-ocr-image-filters/) such as Deskew, Denoise, Binarize, Increase Resolution, Dilate, among others.
  * Decoding barcodes from over 20 formats including QR Code capabilities.
  * Using an optimally tuned version of Tesseract OCR, superior to other versions.
  * Generating Searchable PDFs, exporting text as hOCR/HTML, and converting image contents to text.

#### Cross-platform support includes:

  * **.NET 8**, .NET 7, .NET 6 .NET 5, .NET Core, Standard, and Framework
  * Compatibility with Windows, macOS, Linux, Docker, Azure, and AWS

[![IronOCR Platform Compatibility](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronOCR-readme/cross-platform-compatibility.png)](https://ironsoftware.com/csharp/ocr/docs/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=crossplatformbanner)

Further explore detailed [API documentation](https://ironsoftware.com/csharp/ocr/object-reference/api/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs) and [comprehensive licensing information](https://ironsoftware.com/csharp/ocr/licensing/) on our website.

### Integrating IronOCR Into Your Project

You can easily add IronOCR to your project with the following NuGet command:

    PM> Install-Package IronOCR
    
After the installation, include `using IronOcr` at the beginning of your C# files. Here's an example of how to scan image and PDF text:

    using IronOcr;
    
    var ocr = new IronTesseract();
    
    using (var ocrInput = new OcrInput())
    {
        ocrInput.LoadImage("image.png");
        ocrInput.LoadPdf("document.pdf");
        
        // Optional Filters if required:
        // ocrInput.Deskew();  // use if image is crooked
        // ocrInput.DeNoise(); // use if image is noisy
        
        var ocrResult = ocr.Read(ocrInput);
        Console.WriteLine(ocrResult.Text);
    }
    

### Feature Overview

[![IronOCR Features Overview](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronOCR-readme/features-table.png)](https://ironsoftware.com/csharp/ocr/features/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=featuresbanner)

Experience the forefront of .NET OCR technology with the IronOCR 2024, fully supporting:

  * C#, F#, and VB.NET
  * .NET 8, .NET 7, 6, 5, Core 2x & 3x, Standard 2, and Framework 4.6.2+
  * Console, Web, and Desktop Applications
  * Platforms like Windows, Linux (Debian, CentOS, Ubuntu), macOS, Docker, AWS, and Azure
  * Tools such as Microsoft Visual Studio or JetBrains ReSharper & Rider
  * Features including Barcode, QR Code, and Text extraction

#### Licensing & Additional Support

For detailed examples, tutorials, and more information, visit our [website](https://ironsoftware.com/csharp/ocr/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs).

For further assistance, contact us at: support@ironsoftware.com

### Helpful Resources

  * Code Examples : [https://ironsoftware.com/csharp/ocr/examples/](https://ironsoftware.com/csharp/ocr/examples/simple-csharp-ocr-tesseract/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)
  * API Guide : [https://ironpdf.com/object-reference/api/](https://ironsoftware.com/csharp/ocr/object-reference/api/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)
  * Learning Tutorials : [https://ironsoftware.com/csharp/ocr/tutorials/](https://ironsoftware.com/csharp/ocr/tutorials/how-to-read-text-from-an-image-in-csharp-net/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)
  * Licensing Information : [https://ironsoftware.com/csharp/ocr/licensing/](https://ironsoftware.com/csharp/ocr/licensing/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)
  * Live Chat : [https://ironsoftware.com/csharp/ocr/#helpscout-support](https://ironsoftware.com/csharp/ocr/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs#helpscout-support)