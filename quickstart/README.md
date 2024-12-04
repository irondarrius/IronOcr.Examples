# Introduction to Optical Character Recognition (OCR) using C# and VB.NET

***Based on <https://ironsoftware.com/docs/docs/>***


IronOCR is a robust C# library designed for .NET developers who require functionality to interpret and extract text from images and PDF files. This powerful OCR tool leverages the highly advanced Tesseract engine, making it one of the top .NET solutions for OCR tasks.

## Setup Guidelines

### Installing via NuGet Package Manager

To integrate IronOcr into your project using the NuGet Package Manager, either within Visual Studio or via the command line, follow these steps in Visual Studio:

- Navigate to:
  - **Tools** 
  - **NuGet Package Manager**
  - **Package Manager Console**

```shell
Install-Package IronOcr
```

Explore more about IronOcr including version details and more on its [NuGet page](https://www.nuget.org/packages/IronOcr).

IronOCR is also available for various platforms through different dedicated NuGet Packages:

- **Windows**: [IronOcr NuGet](https://www.nuget.org/packages/IronOcr)
- **Linux**: [IronOcr.Linux NuGet](https://www.nuget.org/packages/IronOcr.Linux)
- **MacOs**: [IronOcr.MacOs NuGet](https://www.nuget.org/packages/IronOcr.MacOs)
- **MacOs (ARM)**: [IronOcr.MacOs.ARM NuGet](https://www.nuget.org/packages/IronOcr.MacOs.ARM)

### Direct Download via ZIP File

Alternatively, IronOCR can be downloaded directly as a ZIP file. [Download the DLL directly](https://ironsoftware.com/csharp/ocr/packages/IronOcr.zip) by clicking this link. After downloading:

#### Set up for .NET Framework 4.0 and above:
- Incorporate the `IronOcr.dll` from the `net40` folder into your project.
- Add Assembly references for:
    - `System.Configuration`
    - `System.Drawing`
    - `System.Web`

#### Set up for .NET Standard & .NET Core 2.0+, including .NET 5:
- Include the `IronOcr.dll` from the `netstandard2.0` folder in your project.
- Add a NuGet Package Reference to:
    - `System.Drawing.Common` version 4.7 or higher

### Downloading and Installing via Windows Installer

For Windows users, a convenient installation option is the IronOCR Windows installer, which sets up everything necessary for the library to function properly. This is solely available for Windows OS. [Click here to download the installer](https://ironsoftware.com/csharp/ocr/packages/IronOcrInstaller.zip).

Once downloaded, follow these steps:

#### Installation for .NET Framework 4.0 and newer:
- Add the `IronOcr.dll` from the `net40` folder to your project.
- Add Assembly references to:
    - `System.Configuration`
    - `System.Drawing`
    - `System.Web`

#### Installation for .NET Standard & .NET Core 2.0+ up to .NET 5:
- Ensure to incorporate `IronOcr.dll` from the `netstandard2.0` folder into your project.
- Include a NuGet package reference to:
    - `System.Drawing.Common` 4.7 or better

### NuGet Package Manager Installation

To incorporate IronOcr into your project, utilize the NuGet Package Manager in Visual Studio or through the command line. In Visual Studio, access the console via the following path:

- Tools ->
- NuGet Package Manager ->
- Package Manager Console

Below is the paraphrased section you've requested:

```shell
Install-Package IronOcr
```

For additional details on version updates and installation guidelines, visit [IronOcr on NuGet](https://www.nuget.org/packages/IronOcr).

IronOCR also provides specialized NuGet packages tailored for various operating systems:

- **Windows**: [IronOcr for Windows](https://www.nuget.org/packages/IronOcr)
- **Linux**: [IronOcr for Linux](https://www.nuget.org/packages/IronOcr.Linux)
- **macOS**: [IronOcr for macOS](https://www.nuget.org/packages/IronOcr.MacOs)
- **macOS (ARM)**: [IronOcr for macOS ARM](https://www.nuget.org/packages/IronOcr.MacOs.ARM)

### IronOCR .ZIP File Download

Alternatively, you can opt to download the IronOCR library as a .ZIP file. To do so, please [download the DLL directly](https://ironsoftware.com/csharp/ocr/packages/IronOcr.zip). After downloading the .ZIP file, you can proceed with the following installation steps:

Here is the paraphrased section with relative URL paths resolved to ironsoftware.com:

#### Steps for Installing on .NET Framework 4.0+:

- Integrate the `IronOcr.dll` from the `net40` directory into your project.

- Subsequently, insert references to the following assemblies:

    * `System.Configuration`
    
    * `System.Drawing`
    
    * `System.Web`

#### Setup for .NET Standard, .NET Core 2.0+, and .NET 5

- Add the IronOcr.dll from the netstandard2.0 directory to your project.

- Then, incorporate a NuGet package reference for:

  * System.Drawing.Common version 4.7 or later.
```

### Acquire the IronOCR Installer for Windows

For Windows users, we provide an alternative method to get started by downloading the IronOCR installer. This installer comes packed with all the necessary components for IronOCR to function immediately. Please note, this method is exclusively for Windows platforms. To secure the installer, please [click here](https://ironsoftware.com/csharp/ocr/packages/IronOcrInstaller.zip). After downloading the .zip file:

#### Setup Guide for .NET Framework 4.0 and Above:

- First, incorporate the `IronOcr.dll` from the `net40` directory into your project.

- Next, proceed to add references to the following assemblies:

    * `System.Configuration`
    
    * `System.Drawing`
    
    * `System.Web`

#### Guidelines for Setting Up IronOCR with .NET Standard, .NET Core 2.0+, and .NET 5

- Import the IronOcr.dll from the netstandard2.0 directory into your project.

- Subsequently, ensure to include a reference to the NuGet package:

        * System.Drawing.Common version 4.7 or above

## Advantages of Using IronOCR

IronOCR stands out as a comprehensive, well-supported .NET library that's straightforward to set up.

Opt for IronOCR for a remarkable **99.8%+ OCR accuracy** rate, eliminating the need for external web services, recurring charges, or the risk of exposing sensitive documents online.

#### Reasons Why C# Developers Prefer IronOCR to Vanilla Tesseract:

* Installable as either a single DLL or through NuGet.

* Out-of-the-box support for multiple Tesseract engines (versions 5, 4, and 3).

* Achieves an impressive **99.8% accuracy**, significantly surpassing standard Tesseract's capabilities.

* Offers exceptional speed and supports multithreading.

* Compatible across various applications including MVC, WebApps, desktop, console, and server environments.

* No need to manage Exes or C++ code.

* Comprehensive support for PDF OCR operations.

* Capable of performing OCR on almost any image file or PDF format.

* Extensive support across .NET Core, Standard, and Framework.

* Broad deployment options including Windows, Mac, Linux, Azure, Docker, Lambda, AWS.

* Capable of reading barcodes and QR codes.

* Allows for exporting OCR results to XHTML and searchable PDF formats.

* Supports multithreading for enhanced performance.

* Access to 125 international languages managed either through NuGet or OcrData files.

* Enables image, coordinates, statistical data, and font extraction, not just plain text.

* Suitable for re-distributing Tesseract OCR within commercial and proprietary software solutions.

*IronOCR excels in processing real-world images and documents with imperfections such as photos, scans of low-resolution, or documents with digital noise.*

Other [free OCR libraries](https://ironsoftware.com/csharp/ocr/use-case/free-ocr-csharp/) designed for .NET platforms, like alternative .NET Tesseract APIs and web services, commonly fall short in handling such complex real-world scenarios.

## OCR with Tesseract 5 - Start Coding in C# 

Below is a simple code example demonstrating how effortlessly text can be extracted from an image using C# or VB.NET.

### Quick Start Example

```cs
using IronOcr;
namespace ironocr.Quickstart
{
    public class QuickExample
    {
        public void Execute()
        {
            var textContent = new IronTesseract().Read(@"img\Screenshot.png").Text;
        }
    }
}
``` 

This code sample provides a straightforward example of how to extract text from an image using the IronOcr library within a C# application. It utilizes the `IronTesseract` class to perform optical character recognition swiftly and efficiently.

```cs
using IronOcr;
namespace ironocr.Quickstart
{
    public class BasicOCR
    {
        public void Execute()
        {
            string extractedText = new IronTesseract().Read(@"img\Screenshot.png").Text;
        }
    }
}
```

### Hello World with Configuration

The following example demonstrates a configurable approach to utilizing C# or VB .NET for optical character recognition using the IronOcr library.

```cs
using IronOcr;
namespace ironocr.Quickstart
{
    public class Section2
    {
        public void Run()
        {
            IronTesseract ocrInstance = new IronTesseract();
            using (OcrInput setup = new OcrInput())
            {
                // Load an image from the filesystem
                setup.LoadImage("images/sample.jpeg");
                
                // Perform OCR on the loaded image
                OcrResult ocrResult = ocrInstance.Read(setup);
                
                // Print the extracted text
                Console.WriteLine(ocrResult.Text);
            }
        }
    }
}
```

This snippet sets up the IronTesseract object, loads an image, and reads text from it. The results are then displayed in the console.
```

Here is the paraphrased code section:

```cs
using IronOcr;
namespace ironocr.Quickstart
{
    public class ExampleSection
    {
        public void Execute()
        {
            // Initialize IronTesseract
            IronTesseract OCR_engine = new IronTesseract();
            
            // Prepare input object for OCR
            using OcrInput input = new OcrInput();

            // Loading multiple images into the OCR engine
            input.LoadImage("images/sample.jpeg");

            // Execute OCR process
            OcrResult ocrResults = OCR_engine.Read(input);
            
            // Display the recognized text in the console
            Console.WriteLine(ocrResults.Text);
        }
    }
}
```

### OCR for PDFs in C#

This method can also be applied effectively to retrieve text from PDF files.

Here's the paraphrased section of the article, with resolved relative URL paths:

```cs
using IronOcr;
namespace ironocr.Quickstart
{
    public class Section3
    {
        public void ExecuteOcr()
        {
            IronTesseract tesseract = new IronTesseract();
            using (OcrInput pdfInput = new OcrInput())
            {
                // Option to focus on specific pages of a PDF by specifying page numbers
                pdfInput.LoadPdf("example.pdf", Password: "password");

                OcrResult ocrResult = tesseract.Read(pdfInput);
                Console.WriteLine(ocrResult.Text);

                // Print the count of pages processed
                Console.WriteLine($"Total Pages Processed: {ocrResult.Pages.Length}");
            }
        }
    }
}
```

This revised code maintains the original intent and functionality while altering descriptions and variable names for a refreshed perspective of the implementation.

### OCR for MultiPage TIFFs

```cs
using IronOcr;
namespace ironocr.Quickstart
{
    public class Section4
    {
        public void Run()
        {
            IronTesseract ocr = new IronTesseract();
            using OcrInput input = new OcrInput();
            var pageIndices = new int[] { 1, 2 };
            input.LoadImageFrames("multi-frame.tiff", pageIndices);
            OcrResult result = ocr.Read(input);
            Console.WriteLine(result.Text);
        }
    }
}
```

This section demonstrates using IronOCR for extracting text from TIFF files that contain multiple pages. By utilizing the `IronTesseract` class along with the `OcrInput` object, users can efficiently load specific frames of a multipage TIFF file and perform OCR to convert the image data into readable text. This example specifically targets the first two frames of the TIFF file for OCR, showcasing the flexibility and precision of IronOCR in handling complex document formats.

Here is a paraphrased version of the provided C# code snippet from the article, with the relative URL paths resolved to `ironsoftware.com`:

```cs
using IronOcr;
namespace ironocr.Quickstart
{
    public class Section4
    {
        public void Execute()
        {
            IronTesseract tesseractOcr = new IronTesseract();
            using (OcrInput imageInput = new OcrInput())
            {
                // Define the frame indices to be processed
                int[] frameIndices = { 1, 2 };
                // Load the TIFF image frames for OCR processing
                imageInput.LoadImageFrames("multi-frame.tiff", frameIndices);
                
                // Perform OCR and obtain the result
                OcrResult ocrTextResult = tesseractOcr.Read(imageInput);
                // Display the extracted text in the console
                Console.WriteLine(ocrTextResult.Text);
            }
        }
    }
}
```

This revised code does more than just alter variable names; it also includes additional comments to enhance readability and clarify each step of the process. This approach ensures that anyone reviewing the code can easily understand what each section does, which is crucial for maintaining clarity in collaborative or educational environments.

### Barcodes and QR Code Scanning

One of the standout features of IronOCR is its ability to detect and decipher barcodes and QR codes directly from documents during the text recognition process. Each barcode that is scanned is thoroughly analyzed, and comprehensive details are provided by the `OcrResult.OcrBarcode` class, offering developers insightful data about each barcode encountered.

Certainly! The following is a paraphrased version of the given code section, with a focus on natural, conversational language, and a few additional explanatory comments for clarity:

```cs
using IronOcr;
namespace ironocr.Quickstart
{
    public class BarcodeReadingExample
    {
        public void Execute()
        {
            // Initialize IronTesseract with default configuration
            IronTesseract ocrEngine = new IronTesseract();
            // Enable barcode reading
            ocrEngine.Configuration.ReadBarCodes = true;

            // Create a new OCR input and load a barcode image
            using OcrInput ocrInput = new OcrInput();
            ocrInput.LoadImage("https://ironsoftware.com/csharp/ocr/img/Barcode.png");

            // Perform OCR to read image contents, including barcodes
            OcrResult ocrResult = ocrEngine.Read(ocrInput);
            // Iterate through each detected barcode and print its value
            foreach (var barcode in ocrResult.Barcodes)
            {
                // Access and display additional barcode info like type and location
                Console.WriteLine($"Barcode Value: {barcode.Value}");
            }
        }
    }
}
```

In this version, I rearranged some variable names to enhance readability and included slight changes to comments to increase understanding. The actual logic and behavior remain faithful to the original implementation while presenting a refreshed perspective in documenting code processes.

### Targeted OCR on Specified Image Areas

IronOCR offers capabilities that allow users to pinpoint specific areas on a page or document for text recognition. This feature is particularly beneficial when dealing with forms that have a standard layout, significantly enhancing both time efficiency and processing speed.

To facilitate this targeted OCR scanning, it's necessary to incorporate a system reference to `System.Drawing`. This enables the utilization of the `System.Drawing.Rectangle` object, which defines the exact region to be scanned.

Here's a rephrased version of the given section from the article, with the relative URL paths resolved against ironsoftware.com:

```cs
using IronOcr;
namespace ironocr.Quickstart
{
    public class Section6
    {
        public void Run()
        {
            IronTesseract tessEngine = new IronTesseract();
            using OcrInput ocrInput = new OcrInput();

            // Set the pixel dimensions for the area to be scanned
            var scanArea = new System.Drawing.Rectangle() { X = 215, Y = 1250, Width = 1335, Height = 280 };

            // Load the specific image area into the OCR engine
            ocrInput.LoadImage("document.png", scanArea);

            // Execute the OCR process and retrieve the results
            OcrResult ocrText = tessEngine.Read(ocrInput);
            Console.WriteLine(ocrText.Text);  // Output the extracted text to the console
        }
    }
}
```

In this revised version, variable names and comments have been altered for clarity and distinction from the original code.

### Enhanced OCR for Substandard Scans

The `OcrInput` class from IronOCR has the capability to correct scans that are beyond the capabilities of traditional Tesseract to interpret successfully.

Here is the paraphrased version of the provided C# code with relevant explanations for each line:

```cs
using IronOcr;
namespace ironocr.Quickstart
{
    public class Section7
    {
        public void Run()
        {
            // Initialize an IronTesseract instance for OCR operations
            IronTesseract ocrEngine = new IronTesseract();
            // Prepare the input image containing the pages to be scanned
            using OcrInput ocrInput = new OcrInput();
            int[] pagesToScan = { 1, 2 }; // Define which pages to read
            ocrInput.LoadImageFrames(@"img\Potter.tiff", pagesToScan);

            // Apply noise reduction to improve image quality for OCR
            ocrInput.DeNoise();

            // Correct any skew in the image to ensure accurate OCR reading
            ocrInput.Deskew();

            // Perform the OCR operation and get the result
            OcrResult ocrText = ocrEngine.Read(ocrInput);
            // Output the extracted text to the console
            Console.WriteLine(ocrText.Text);
        }
    }
}
```

This revised code maintains the functionality of the original while altering variable names and adding comments for clarity. The operations for denoising and deskewing are retained, with added descriptions to explain their purpose clearly.

### Creating a Searchable PDF from OCR Results

Transform your OCR results into searchable PDF documents easily with IronOCR. This functionality is essential for storing and retrieving digital documents in industries where data archiving is crucial.

```csharp
using IronOcr;
namespace ironocr.Quickstart
{
    public class Section8
    {
        public void Run()
        {
            IronTesseract ocr = new IronTesseract();
            using OcrInput input = new OcrInput();
            input.Title = "Quarterly Report";
            input.LoadImage("image1.jpeg");
            input.LoadImage("image2.png");
            var pageIndices = new int[] { 1, 2 };
            input.LoadImageFrames("image3.gif", pageIndices);
            
            OcrResult result = ocr.Read(input);
            result.SaveAsSearchablePdf("searchable.pdf");
        }
    }
}
```
In this example, the `IronTesseract` class is incorporated to process OCR on multiple images, which are then compiled into a single searchable PDF with a specified title. This feature is pivotal for creating digitized texts that are not only readable but also searchable, enhancing accessibility and efficiency in document management.

Here's the paraphrased section of the article with resolved relative URL paths:

```cs
using IronOcr; // Import IronOcr namespace

namespace ironocr.Quickstart
{
    public class Section8
    {
        public void Execute()
        {
            // Initialize IronTesseract
            IronTesseract tesseractOCR = new IronTesseract();
            using OcrInput inputDocument = new OcrInput();

            // Set the title for the OCR input
            inputDocument.Title = "Quarterly Report";

            // Load multiple image files into the OCR input
            inputDocument.LoadImage("image1.jpeg");
            inputDocument.LoadImage("image2.png");

            // Define specific pages to be loaded from a multi-frame image
            int[] selectedPages = new int[] { 1, 2 };
            inputDocument.LoadImageFrames("image3.gif", selectedPages);

            // Perform OCR on the loaded images
            OcrResult ocrText = tesseractOCR.Read(inputDocument);

            // Save the OCR results as a searchable PDF file
            ocrText.SaveAsSearchablePdf("searchable.pdf");
        }
    }
}
```

This repository reformulates the code for readability and understanding, adhering to standard .NET coding practices.

### Converting TIFF Files to Searchable PDFs

Using the IronOCR library, developers can effortlessly convert images in the TIFF format into searchable PDF documents. This process leverages the optical character recognition capabilities of IronOCR to extract text from TIFF images and embed it into a PDF that supports text search.

```cs
using IronOcr;
namespace ironocr.Quickstart
{
    public class Section9
    {
        public void Run()
        {
            IronTesseract ocr = new IronTesseract();
            using OcrInput input = new OcrInput();
            var pageIndices = new int[] { 1, 2 };
            input.LoadImageFrames("example.tiff", pageIndices);
            var ocrResult = ocr.Read(input);
            ocrResult.SaveAsSearchablePdf("searchable.pdf");
        }
    }
}
```

In this code snippet:
- We initiate an instance of `IronTesseract`.
- Create an `OcrInput` object and load TIFF image frames using specific indices.
- Perform OCR on these images.
- Save the OCR results directly as a searchable PDF, preserving the original layout and enabling text search within the document.

```cs
using IronOcr;
namespace ironocr.Quickstart
{
    public class Section9
    {
        public void Execute()
        {
            IronTesseract tesseract = new IronTesseract();
            using OcrInput imageInput = new OcrInput();
            int[] selectedPages = { 1, 2 };
            imageInput.LoadImageFrames("example.tiff", selectedPages);
            
            // Perform OCR and save the output as a searchable PDF file
            tesseract.Read(imageInput).SaveAsSearchablePdf("searchable.pdf");
        }
    }
}
```

### Outputting OCR Results as HTML

IronOCR provides the capability to export OCR results in HTML format, offering a seamless way to handle OCR data for web applications.

```cs
using IronOcr;
namespace ironocr.Quickstart
{
    public class Section10
    {
        public void Run()
        {
            IronTesseract ocr = new IronTesseract();
            using OcrInput input = new OcrInput();
            input.Title = "Html Title";
            input.LoadImage("image1.jpeg");

            OcrResult Result = ocr.Read(input);
            Result.SaveAsHocrFile("results.html");
        }
    }
}
```

In this sample, an instance of `IronTesseract` is initialized and an `OcrInput` object is prepared with a title and an image file. Once the OCR process is executed and the result is obtained, it's then saved as an HTML file. This feature is ideal for integrating OCR technology into HTML-based systems, enabling formatted display of recognized text.

Here is the paraphrased version of the given code section, with the relative URL paths resolved to `ironsoftware.com`:

```cs
using IronOcr;
namespace ironocr.Quickstart
{
    public class HTMLExportSection
    {
        public void Execute()
        {
            IronTesseract tesseract = new IronTesseract();
            using OcrInput imageInput = new OcrInput();
            imageInput.Title = "Output HTML Title";
            imageInput.LoadImage("image1.jpeg");

            // Perform OCR on the loaded image
            OcrResult ocrOutput = tesseract.Read(imageInput);
            // Save the OCR results as an HTML file
            ocrOutput.SaveAsHocrFile("extractedContent.html");
        }
    }
}
```

This code excerpt initializes an instance of `IronTesseract`, loads an image for OCR, and then saves the results as an HTML file.

## OCR Image Improvement Techniques

IronOCR incorporates specialized filters for `OcrInput` objects that enhance the accuracy and performance of OCR processing.

### Demonstration of Image Enhancement with Code

```cs
using IronOcr;
namespace ironocr.Quickstart
{
    public class Section11
    {
        public void Run()
        {
            IronTesseract ocr = new IronTesseract();
            // Initialize OcrInput with the image
            using OcrInput input = new OcrInput("LowQuality.jpeg");

            // Applying image filters to enhance quality
            // Removes digital noise
            input.DeNoise();
            
            // Corrects any skew in the image
            input.Deskew();

            // Perform OCR on the enhanced image
            OcrResult result = ocr.Read(input);
            Console.WriteLine(result.Text);
        }
    }
}
```

This code snippet illustrates how to apply image enhancement filters using IronOCR to improve OCR accuracy. The example specifically demonstrates the use of de-noising and de-skewing filters on an image before performing OCR to extract text.
```

```cs
using IronOcr;
namespace ironocr.Quickstart
{
    public class ImageEnhancementExample
    {
        public void Execute()
        {
            IronTesseract ocrEngine = new IronTesseract();
            using (OcrInput prepareInput = new OcrInput("LowQuality.jpeg"))
            {
                // Enhance the image quality by removing noise
                prepareInput.DeNoise();

                // Correct any skew to align the text properly
                prepareInput.Deskew();

                // Perform OCR on the prepared image and get the result
                OcrResult ocrText = ocrEngine.Read(prepareInput);
                Console.WriteLine(ocrText.Text);
            }
        }
    }
}
```

### OCR Image Enhancement Options

IronOCR integrates several input filters specifically designed to boost the effectiveness of OCR operations:

* **`OcrInput.Rotate(double degrees)`** - This function allows the rotation of images by a specified number of degrees in a clockwise direction. For counter-clockwise rotation, negative values should be used.
* **`OcrInput.Binarize()`** - Converts all image pixels to strictly black or white, which may enhance OCR accuracy in instances where text and background contrasts are very low.
* **`OcrInput.ToGrayScale()`** - Changes all image pixels to various shades of gray. While this may not necessarily boost OCR accuracy, it can improve processing speed.
* **`OcrInput.Contrast()`** - Automatically enhances the image contrast, often leading to improved speed and accuracy of OCR in low contrast images.
* **`OcrInput.DeNoise()`** - Eliminates digital noise from images, recommended for use only when noise is present.
* **`OcrInput.Invert()`** - Reverses the color scheme of images, turning white to black and vice versa.
* **`OcrInput.Dilate()`** - Utilizes advanced morphology to expand the boundaries of objects in an image, enhancing edge definition. This is the contrary operation to erosion.
* **`OcrInput.Erode()`** - Reduces pixels at the object boundaries, enhancing small feature definition by thinning object sizes.
* **`OcrInput.Deskew()`** - Corrects the alignment of the image to ensure it is straight and upright, crucial for optimal OCR performance as even minor skewing can be problematic.
* **`OcrInput.EnhanceResolution()`** - Heightens the resolution of low-quality images, improving text sharpness for better OCR readability. This is automatically applied on images under 275 dpi to upscale and sharpen the text.
* **`Language`** - Supports 22 international languages, allowing users to specify one or several languages for OCR processing to accommodate multilingual documents.
* **`Strategy`** - Users can select between a fast, less precise OCR scan or a more sophisticated, AI-driven approach for enhanced accuracy by analyzing contextual text relationships.
* **`ColorSpace`** - Offers a choice between grayscale and full-color OCR to accommodate different document types for optimal results.
* **`DetectWhiteTextOnDarkBackgrounds`** - Unlike typical OCR expectations of black text on white backgrounds, this setting recognizes and reads white text on dark backgrounds.
* **`InputImageType`** - Guides the OCR on the nature of the content, whether it is a full document or just a segment like a screenshot.
* **`RotateAndStraighten`** - Enables IronOCR to process images with rotation or perspective distortions, common in photographed documents.
* **`ReadBarcodes`** - Simultaneously scans for barcodes and QR codes while performing OCR, minimizing the time impact.
* **`ColorDepth`** - Adjusts the bit depth per pixel used during OCR, affecting both the quality of the result and the duration of the OCR process. Higher color depths can improve quality but require more processing time.

## Multilingual Language Support in IronOCR

IronOCR offers comprehensive support for **125 international languages** through its language packs. These packs are available as DLLs and can be accessed [directly from Iron Software's site](https://ironsoftware.com/csharp/ocr/languages/) or via the [NuGet Package Manager](https://www.nuget.org/packages?q=IronOcr.Languages).

The supported languages range from widely used ones such as English, French, German, Chinese, and Japanese, to more specialized ones. IronOCR is also equipped with specialized language packs designed for specific applications, including passport MRZ, financial documents, MICR checks, and vehicle license plates. Additionally, IronOCR allows the use of any Tesseract ".traineddata" file, offering the flexibility to implement custom-trained language models.

### Example of Language Support

```cs
using IronOcr;
namespace ironocr.Quickstart
{
    public class Section12
    {
        public void Run()
        {
            // Install the Arabic language packages via the Package Manager
            IronTesseract ocr = new IronTesseract();
            ocr.Language = OcrLanguage.Arabic;
            
            using OcrInput input = new OcrInput();
            
            var pageIndices = new int[] { 1, 2 };
            input.LoadImageFrames("img/arabic.gif", pageIndices);
            // Apply necessary image filters to enhance quality
            // Even with low-quality inputs, IronTesseract manages to deliver clear results that standard Tesseract might not decode.
            OcrResult result = ocr.Read(input);
            // Output to a text file as Arabic might not display correctly on console in Windows.
            result.SaveAsTextFile("arabic.txt");
        }
    }
}
```
In this example, we demonstrate how to utilize IronOCR's language features by incorporating Arabic OCR capabilities into your application. IronOCR's robust engine allows even low-quality images to be processed effectively, ensuring accurate results where traditional methods might fail.

```cs
using IronOcr;
namespace ironocr.Quickstart
{
    public class ArabicOCRDemo
    {
        public void Execute()
        {
            // Add Arabic language support by installing the respective language pack
            IronTesseract ocr = new IronTesseract();
            ocr.Language = OcrLanguage.Arabic;

            using OcrInput input = new OcrInput();

            // Define which pages to process
            int[] pagesToProcess = new int[] { 1, 2 };
            input.LoadImageFrames("img/arabic.gif", pagesToProcess);
            // Optional: Apply image filters here if necessary
            // In this scenario, despite the low quality of the input,
            // IronTesseract manages to capture content that standard Tesseract might miss.
            OcrResult result = ocr.Read(input);
            // Due to limitations in console output on Windows for Arabic text,
            // we will save the results directly to a file.
            result.SaveAsTextFile("arabic.txt");
        }
    }
}
```

### Example of Multilingual OCR

IronOCR also provides functionality to perform OCR operations across multiple languages simultaneously. This feature is extremely beneficial for extracting English language metadata and URLs from documents that contain Unicode text.

```cs
using IronOcr;
namespace ironocr.Quickstart
{
    public class Section13
    {
        public void Execute()
        {
            // Add the IronOcr.Languages.ChineseSimplified package via NuGet Package Manager
            IronTesseract tesseract = new IronTesseract();
            tesseract.Language = OcrLanguage.ChineseSimplified;

            // Additional languages can be included as needed
            tesseract.AddSecondaryLanguage(OcrLanguage.English);

            using OcrInput document = new OcrInput();
            document.LoadPdf("multi-language.pdf");
            OcrResult ocrResult = tesseract.Read(document);
            ocrResult.SaveAsTextFile("results.txt");
        }
    }
}
```

## Sophisticated OCR Result Structures

Every OCR operation with IronOCR generates a dedicated OCR result object. Typically, developers primarily utilize the text attribute of this object to extract text from scanned images. Nevertheless, the structure of OCR results is considerably more elaborate than this basic use suggests.

Here is the paraphrased section of the article with relative URL paths resolved to `ironsoftware.com`.

```cs
using IronOcr;
namespace ironocr.Quickstart
{
    public class Section14
    {
        public void Run()
        {
            // Create a new IronTesseract instance
            IronTesseract ocr = new IronTesseract();

            // Enabling barcode reading feature
            ocr.Configuration.ReadBarCodes = true;

            // Prepare OCR input with specific page indices
            using OcrInput input = new OcrInput();
            int[] pageIndexes = new int[] { 1, 2 };
            input.LoadImageFrames(@"img\sample.tiff", pageIndexes);

            // Perform OCR operation
            OcrResult ocrResult = ocr.Read(input);

            // Accessing different components of the OCR result
            var pages = ocrResult.Pages;
            var words = pages[0].Words;
            var barcodes = ocrResult.Barcodes;

            // Access a broad, detailed API for further processing and analysis:
            // Explore Pages, Blocks, Paragraphs, Lines, Words, Characters
            // And also Image Export, Font Coordinates, Statistical Data, Tables
        }
    }
}
```

## Performance

IronOCR is designed for immediate use, requiring no additional adjustments or significant alterations to input images for effective performance.

Its processing speed is exceptionally rapid: IronOcr.2020 and later versions deliver performance that is 10 times swifter and incur significantly fewer errors—reducing them by more than 250% compared to earlier versions.

## Learn More

For further insights into OCR utilizing C#, VB, F#, or other .NET languages, explore our [community tutorials](https://ironsoftware.com/csharp/ocr/tutorials/how-to-read-text-from-an-image-in-csharp-net/). These tutorials provide practical examples of IronOCR's capabilities and demonstrate how to optimize its use for various applications.

Additionally, check out the [comprehensive API reference](https://ironsoftware.com/csharp/ocr/object-reference/) tailored for .NET developers.

