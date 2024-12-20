# Building an Azure OCR Service with IronOCR

***Based on <https://ironsoftware.com/how-to/iron-ocr-azure-tutorial/>***


Iron Software has designed IronOCR, an Optical Character Recognition (OCR) library, meticulously crafted to simplify the integration of OCR functionality in Azure. Historically, developers have found OCR integration with Azure challenging, but IronOCR offers a streamlined solution to these and other OCR-related issues.

## Features of IronOCR for Microsoft Azure

IronOCR is packed with powerful features suited for Azure environments, including:

- Conversion of PDFs to searchable documents for easy text extraction
- Conversion of images into searchable text documents
- Capability to read both barcodes and QR codes
- Exceptional recognition accuracy
- High-speed performance
- Designed to run locally, obviating the need for SaaS which typically involves cloud-hosted applications made available to end users by providers like Microsoft Azure.

Explore how Iron Software’s IronOCR simplifies text extraction from any type of document with Azure integration.

## Initializing the Azure OCR Service using IronOCR

First, we need to install IronOCR to begin setting up an OCR service in Azure.

1. Create a new C# Console application.
2. Install IronOCR via NuGet using `Install-Package IronOcr` or by using the NuGet package manager in your development environment.
3. Modify your `Program.cs` as follows:
   - Import the `IronOcr` namespace to leverage its OCR capabilities for reading and extracting PDF content.
   - Instantiate a new `IronTesseract` object to enable text extraction from images.

```cs
using IronOcr;
using System;

namespace IronOCR_Example
{
    class Program
    {
        static void Main(string [] args)
        {
            var ocrEngine = new IronTesseract();
            using (var inputImage = new OcrInput("https://ironsoftware.com/Images/Purgatory.PNG"))
            {
                var ocrResult = ocrEngine.Read(inputImage); // Read the PNG image
                Console.WriteLine(ocrResult.Text); // Output the extracted text
                Console.ReadLine();
            }
        }
    }
}
```

4. Load and process the image named `Purgatory.PNG`, inspired by Dante's "Divine Comedy".

![Text extraction using IronOCR](https://ironsoftware.com/img/iron-ocr-azure-2.png)
*Figure 2 - The text to be extracted using IronOCR*

5. After processing, the extracted text from the image appears as shown.

![Extracted text display](https://ironsoftware.com/img/iron-ocr-azure-3.png)
*Figure 3 - Display of extracted text*

6. Replicate the process for extracting text from a PDF document, using similar steps.

```cs
var ocrInstance = new IronTesseract();
using (var inputFile = new OcrInput())
{
    inputFile.Title = "Divine Comedy - Purgatory"; // Assign a title to the input document
    inputFile.AddPdf("https://ironsoftware.com/Documents/Purgatorio.pdf", "dante"); // Load PDF with an optional password
    var ocrResults = ocrInstance.Read(inputFile); // Process the PDF

	ocrResults.SaveAsSearchablePdf("SearchablePDFDocument.pdf"); // Save results as a searchable PDF
}
```

7. Use IronOCR in a Microsoft Azure function to extract text within a microservice architecture.

```cs
public static class OCRProcessingFunction
{
    static HttpClient httpClient = new HttpClient();

    [FunctionName("ProcessImageWithIronOCR")]
    public static async Task<IActionResult> Run([HttpTrigger] HttpRequest request, ExecutionContext context)
    {
        string imageUrl = request.Query["image"];
        Stream imageStream = await httpClient.GetStreamAsync(imageUrl);

        var ironOcr = new IronTesseract();
        using (var ocrInput = new OcrInput(imageStream))
        {
            var result = ironOcr.Read(ocrInput);
            return new OkObjectResult(result.Text);
        }
    }
}
```

This function directly processes images received and outputs the extracted text using IronOCR.

## Additional Features and Functionalities of IronOCR for .NET and Azure

IronOCR not only offers robust OCR capabilities but also includes functionality such as:
- Support for 127 international languages with various quality levels
- Full compatibility with .NET including Xamarin, Mono, and Docker on Azure
- Support for PDFs, multi-frame TIFFs, and all major image formats

IronOCR is pre-configured to function optimally out-of-the-box in .NET environments, offering superior accuracy and speed over conventional OCR solutions like Tesseract.

## Further Resources and Support

- For development-related queries and additional resources, visit [IronOCR Tutorials](https://ironsoftware.com/csharp/ocr/tutorials/how-to-read-text-from-an-image-in-csharp-net/)
- API documentation is available [here](https://ironsoftware.com/csharp/ocr/object-reference/api/)
- For support inquiries, please use [Support](https://ironsoftware.com/csharp/ocr/#live-chat-support)
- Contact Information is available [here](https://ironsoftware.com/contact-us/)

Leverage the capabilities of IronOCR for efficient, accurate, and fast optical character recognition, especially tailored for Azure platforms.