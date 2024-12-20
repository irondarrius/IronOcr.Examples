# C# Tesseract OCR Example

***Based on <https://ironsoftware.com/tutorials/c-sharp-tesseract-ocr/>***


by [Jim Baker](#author)

Tesseract stands out as a superb and academically developed OCR (optical character recognition) library that is freely available to developers for virtually all usage scenarios.

Fortunately for C# developers, they have access to one of the quickest and most precise Tesseract Libraries.

IronOCR enhances Google Tesseract with `IronTesseract`, a native .NET OCR library that offers increased stability and accuracy compared to the freely available Tesseract library.

This article delves into the reasons why .NET developers should prioritize IronOCR's `IronTesseract` over the basic Tesseract implementation.

<div class="content-img-align-center">
  <div class="center-image-wrapper">
  <a href="https://ironsoftware.com/csharp/ocr/features/">
  <img src="https://ironsoftware.com/static-assets/ocr/tutorials/c-sharp-tesseract-ocr/c-sharp-tesseract-ocr-1.webp" alt="C# Tesseract OCR" class="img-responsive add-shadow">
  </a>
</div>
</div>

## Code Example for .NET OCR Usage - Extracting Text from Images in C&num;

To utilize IronOCR's abilities in your Visual Studio solution, start by installing the IronOCR NuGet Package using the NuGet Package Manager.

```csharp
using IronOcr;
using System;

var ocr = new IronTesseract();

// Support for multiple languages
ocr.Language = OcrLanguage.English;

// Loading and handling images
using var input = new OcrInput();
var pageIndices = new int[] { 1, 2 };
input.LoadImageFrames(@"img\example.tiff", pageIndices);
// Optional filters to improve OCR quality
// input.DeNoise();
// input.Deskew();

OcrResult result = ocr.Read(input);
Console.WriteLine(result.Text);
// Utilize IntelliSense to explore the OcrResult further
```

## Installation Options

### Integrating the Tesseract Engine for OCR with .NET

Traditionally, integrating Tesseract Engine meant dealing with a C++ library.

Interop integrations are cumbersome in .NET—boasting limited cross-platform capabilities and compatibility with Azure. It necessitates deciding the architecture of our application, restricting us to either 32 or 64-bit deployments.

Installation can be complex, requiring Visual C++ runtimes, possibly compiling Tesseract manually for the latest updates, and managing unfamiliar DLLs and EXEs. Permissions in certain environments could also restrict execution.

Conversely, IronOCR simplifies the installation process via the NuGet Package Manager, making it straightforward to perform OCR on images and PDFs.

### Tesseract with IronOCR for C&num;

With IronOCR, installation is fully handled through the NuGet Package Manager.

```shell
Install-Package IronOcr
```

This avoids the hassle of dealing with native DLLs or EXE files. The entire IronOCR API is built using native .NET, creating a seamless C# interface.

It supports various types of Visual Studio projects, including:

- .NET Framework 4.6.2 or newer
- .NET Standard 2.0 or newer (including 3.x, .NET 5, 6, 7 & 8)
- .NET Core 2.0 or newer (including 3.x, .NET 5, 6, 7 & 8)

## Staying Current & Supported

### Utilizing Google Tesseract with C&num;

Current versions of Tesseract 5 are not tailored for Windows compilation.

Installing Tesseract 5 for C# freely involves manual tweaks and compiling both **Leptonica** and **Tesseract**. Recent results show Windows interop binaries fail to emerge successfully from the MinGW cross-compilation process.

Moreover, free C# API wrappers available on GitHub could be outdated or incompatible.

### Tesseract with IronOCR for .NET

IronOCR excels with a number of benefits, such as an intuitive API that integrates smoothly into applications. It supports various image formats like JPEG, PNG, TIFF, and PDF, and includes automated image preprocessing. A dedicated commercial support team ensures it's continuously updated.

It runs Tesseract 5 immediately on multiple platforms including Windows, macOS, Linux, Azure, AWS, Lambda, Mono, and Xamarin Mac without complex configurations. There's no need to manage native binaries, making it fully compatible with all Framework and Core versions.

Simply put, IronOCR is executed correctly with minimal hassle.

### OCR Capabilities with Google

[Google Cloud OCR](https://cloud.google.com/use-cases/ocr) by Google Cloud Platform (GCP) uses advanced machine learning to extract text from images and scanned documents.

## Accuracy

### Challenges with Google Tesseract in .NET Projects

Originally, Tesseract was designed to read perfect, machine-printed text displayed in high resolution. This is where Tesseract excels.

However, real-world conditions often present rotated, skewed images, or documents with low DPI, noise, or are scanned. Under these conditions, Tesseract struggles significantly, providing slow and inaccurate readings.

For imperfect inputs, extensive image preprocessing is often necessary, typically done through Photoshop batch scripts or advanced ImageMagick applications. This can demand significant development effort for each document type.

### Enhanced Accuracy with IronOCR's Tesseract in .NET Projects

IronOCR elevates user experience by offering almost perfect accuracy with minimal configuration.

```csharp
using IronOcr;
using System;

var ocr = new IronTesseract();
using var input = new OcrInput();
var pageIndexes = new int[] { 1, 2 };
input.LoadImageFrames(@"img\example.tiff", pageIndexes);
input.DeNoise();  // Enhances image quality by reducing noise
input.Deskew();   // Corrects image orientation

// Additional filters are available, though often unnecessary
OcrResult result = ocr.Read(input);
Console.WriteLine(result.Text);
```

## Image Compatibility

### Limitations with Google Tesseract in .NET

Google Tesseract only accepts images in Leptonica's PIX format, which includes unmanaged memory in C#, potentially leading to memory leaks if not carefully managed.

_Leptonica_ supports various image types but often emits console warnings and has known compatibility issues with TIFF files and limited PDF OCR support.

### Image Support with IronOCR for .NET

IronOCR manages memory for images effectively, supporting a wide range of formats:

- PDF Documents
- MultiFrame TIFF files
- JPEG & JPEG2000
- GIF
- PNG
- BMP
- WBMP
- `System.Drawing.Image`
- `System.Drawing.Bitmap`
- `System.IO.Streams` for all image formats
- Byte arrays
- And many others...

### Example Code for OCR Image Compatibility

```csharp
using IronOcr;
using System;

var ocr = new IronTesseract();
using var input = new OcrInput();
input.LoadPdf("example.pdf", Password: "password");
var pageIndices = new int[] { 1, 2 };
input.LoadImageFrames("multi-frame.tiff", pageIndices);
input.LoadImage("image1.png");
input.LoadImage("image2.jpeg");
// Additional images can be loaded similarly

var result = ocr.Read(input);
Console.WriteLine(result.Text);
```

## Performance

### Google Tesseract's Performance

Google Tesseract can deliver fast and precise outputs if the images are preprocessed correctly using tools like Photoshop or ImageMagick.

Most documented Tesseract uses involve ideal conditions, such as high-resolution screenshots.

Tesseract documentation recommends that images be sampled at a minimum of 300 DPI for effective OCR.

### Performance of IronOCR Tesseract Library

IronOCR's .NET Tesseract library delivers high accuracy across a variety of images directly, thanks to implemented multithreading which leverages multi-core processors typically available on modern systems.

Even images of lower resolution generally yield high accuracy in applications without requiring Photoshop adjustments.

Developers often realize accuracy rates exceeding 99% with minimal configuration, rivaling contemporary Machine Learning APIs without the associated ongoing expenses, security risks, and bandwidth demands.

Performance enhancements can still be achieved with some additional coding.

### Example of Performance Tuning

```csharp
using IronOcr;
using System;

var ocr = new IronTesseract();

// Configurations for enhanced speed. Improves speed by 35% with only a 0.2% drop in accuracy.
ocr.Configuration.BlackListCharacters = "~`$#^*_}{][|\\@¢©«»°±·×‑–—‘’“”•…′″€™←↑→↓↔⇄⇒∅∼≅≈≠≤≥≪≫⌁⌘○◔◑◕●☐☑☒☕☮☯☺♡⚓✓✰";
ocr.Configuration.PageSegmentationMode = TesseractPageSegmentationMode.Auto;
ocr.Configuration.ReadBarCodes = false;
ocr.Language = OcrLanguage.EnglishFast;

using var input = new OcrInput();
var pageIndices = new int[] { 1, 2 };
input.LoadImageFrames(@"img\Potter.tiff", pageIndices);
var result = ocr.Read(input);
Console.WriteLine(result.Text);
```

## API

### Options for Google Tesseract OCR in .NET

Developers have two free options:

- **Interop layers:** Many found on GitHub are outdated, with unresolved issues, memory leaks, and console warnings. They may lack support for .NET Core or Standard.
- **Command-line executables:** These can be challenging to deploy and are often flagged by virus scanners and blocked by security policies.

Often, these options do not perform well in diverse environments like Web Applications, Azure, Mono, Xamarin, Linux, Docker, or Mac.

### .NET OCR Library: IronOCR Tesseract

`IronTesseract` is a well-documented and rigorously tested .NET Library for Tesseract.

#### Simplified "Hello World" for Tesseract in .NET

```csharp
using IronOcr;

var text = new IronTesseract().Read("img.png").Text;
```

It benefits from active development and support by a team of experienced software engineers.

## Compatibility

### Google Tesseract + Interop for .NET

While it's possible to configure Google Tesseract on various platforms by locating dependencies, building from source, or updating a free C# interop wrapper, these solutions may lack full compatibility with .NET Core or .NET Standard projects.

There is presently no straightforward, reliable method to safely install **LibTesseract5** on Windows without `IronTesseract`.

### IronOCR Tesseract .NET OCR Library

IronOCR is unit tested with continuous integration and comes equipped with everything necessary for running on:

- Desktop applications,
- Console Apps
- Server Processes
- Web Applications & MVC
- JetBrains Rider
- Xamarin Mac

Across:

- Windows
- Azure
- Linux
- Docker
- Mac
- BSD and FreeBSD

Supporting:

- .NET Framework 4.6.2 or higher
- All active versions of .NET Core above 2.0
- All active versions of .NET Standard above 2.0
- Mono
- Xamarin Mac

## Language Support

### Google Tesseract

Managing Tesseract dictionaries is complex, as they exist as files totaling around 4 GB, requiring cloning from <https://github.com/tesseract-ocr/tessdata>.

Some Linux distributions aid in dictionary management through `apt-get`, but exact folder structures must be adhered to, or Tesseract will fail.

### IronOCR Tesseract

IronOCR supports more languages than what's available through <https://github.com/tesseract-ocr/tessdata>, with each language incorporated as a NuGet Package via the NuGet Package Manager or as simple downloads.

#### Unicode Language Example

```csharp
using IronOcr;

var ocr = new IronTesseract();
ocr.Language = OcrLanguage.Arabic;

using var input = an OcrInput();
var pageIndices = new int[] { 1, 2 };
input.LoadImageFrames("img/arabic.gif", pageIndices);

// Add necessary image filters
// Even if image quality is poor, IronTesseract manages to read it, unlike conventional Tesseract.

var result = ocr.Read(input);

// Saving the result to a file since the console might not display Arabic easily on Windows.
result.SaveAsTextFile("arabic.txt");
```

#### Multi-Language Support Example

```csharp
using IronOcr;

// For including the Chinese Language Pack:
// PM> Install IronOcr.Languages.ChineseSimplified

var ocr = new IronTesseract();
ocr.Language = OcrLanguage.ChineseSimplified;
ocr.AddSecondaryLanguage(OcrLanguage.English);

// Additional languages can be added
using var input = a new OcrInput();
input.LoadPdf("multi-language.pdf");
var result = ocr.Read(input);
result.SaveAsTextFile("results.txt");
```

## Additional Features

IronOCR Tesseract extends beyond normal OCR functionalities for .NET developers:

- Automatic image analysis to configure Tesseract effectively for common errors
- Conversion from image to Searchable PDF
- Direct PDF OCR
- Searchable and indexable PDFs for search engines
- OCR conversion to HTML output
- TIFF to PDF conversion
- Barcode and QR Code reading capabilities
- Support for multithreading
- An Advanced `OcrResult` Class providing detailed insights into Blocks, Paragraphs, Lines, Words, Characters, Fonts, and statistical data regarding OCR.

## Conclusion

### Google Tesseract for C# OCR

This library is a prime choice for free and academic projects involving C#.

Though an excellent resource for C++ developers, Tesseract alone cannot fulfill all OCR requirements for .NET without considerable preprocessing for scanned or photographed images to ensure they are orthogonal, standardized, and devoid of digital noise.

### The IronOCR Tesseract OCR Library for .NET Framework & Core

Alternatively, IronOCR simplifies the entire process, yielding results through a single line of code.

Indeed, IronOCR uses a finely tuned version of [Tesseract](https://ironsoftware.com/csharp/ocr/use-case/tesseract-net/) designed specifically for .NET, enhanced with performance improvements and features as standard.

IronOCR stands as the optimal choice for any project where the value of developer time is paramount. Finding a .NET software engineer with weeks available to dedicate to manual configurations is exceptionally rare today.

## Kickstart your C# Tesseract Project

Begin by using the NuGet Package Manager in any Visual Studio project:

```shell
Install-Package IronOcr
```

Alternatively, you can [download the IronOCR Tesseract .NET DLL](https://ironsoftware.com/downloads/assets/tutorials/c-sharp-tesseract-ocr/IronOcr.CSharp.Tesseract.Alternative.zip) and install it manually.

Any .NET developer can start using IronOCR Tesseract OCR within minutes by following the examples provided here.

![C Sharp Tesseract OCR](https://ironsoftware.com/img/ocr/c-tesseract-ocr-2.png)

Explore more about OCR capabilities in our comprehensive comparison article: [AWS vs Google Vision (OCR Features Comparison)](https://ironsoftware.com/csharp/ocr/blog/compare-to-other-components/aws-vs-google-vision-comparison/), to understand the broader spectrum of OCR technology services available.