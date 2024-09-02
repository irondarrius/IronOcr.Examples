# Building an Azure OCR Service with IronOCR

Iron Software has developed an OCR (Optical Character Recognition) tool that easily integrates with Azure, resolving common interoperability challenges. IronOCR offers developers a straightforward solution for OCR tasks within Azure environments.

## Key Features of IronOCR for Microsoft Azure
IronOCR delivers robust features for Azure-based OCR applications:

* Converts PDFs into searchable text formats.
* Extract documents and images into searchable files by accurately extracting text.
* Capable of reading both barcodes and QR codes.
* Renowned for its exceptional accuracy.
* Operates locally, eliminating the need for SaaS implementations in cloud environments like Microsoft Azure.
* Renowned for its high-speed performance.

Explore how Iron Software's IronOCR simplifies text extraction for developers:

## Setting Up Azure OCR Service
Begin by installing IronOCR:

1. Start by creating a new C# Console application.
2. To install IronOCR, either use `Install-Package IronOcr` in the NuGet Package Manager console or search for IronOCR within the NuGet GUI.
3. Modify your `Program.cs` to include IronOCR's namespace and create an instance of the `IronTesseract` class to extract text from documents:

```cs
using IronOcr;
using System;

namespace IronOCR_Example
{
    class Program
    {
        static void Main(string [] args)
        {
            IronTesseract ocr = new IronTesseract();
            using (OcrInput input = new OcrInput("https://ironsoftware.com/Images/Purgatory.PNG"))
            {
                OcrResult result = ocr.Read(input);
                Console.WriteLine(result.Text);
                Console.ReadKey();
            }
        }
    }
}
```

4. Open the image `Purgatory.PNG` which depicts a scene from Dante's "Divine Comedy."

![Text extracted by IronOCR's optical capabilities](https://ironsoftware.com/img/iron-ocr-azure-2.png)
*Figure 2 - Text extracted by IronOCR's capabilities*

5. Display the text extracted from the image as shown:

![Extracted text display](https://ironsoftware.com/img/iron-ocr-azure-3.png)
*Figure 3 - Display of extracted text*

6. Perform similar operations on a PDF document named `Purgatorio.pdf`. This involves an almost identical setup to the image extraction:

```cs
var tess = new IronTesseract();
using (var content = new OcrInput())
{
    content.Title = "Divine Comedy - Purgatory"; 
    content.AddPdf("https://ironsoftware.com/Documents/Purgatorio.pdf", "dante");
    var results = tess.Read(content);
    results.SaveAsSearchablePdf("SearchablePDFDocument.pdf");
}
```
Note: Handle large files cautiously as they may trigger exceptions.

7. Deploy IronOCR as an Azure Function within a microservice architecture to extract text from images:

```cs
public static class OCRFunction
{
    static HttpClient httpClient = new HttpClient();

    [FunctionName("IronOCR_Azure")]
    public static async Task<IActionResult> Run([HttpTrigger] HttpRequest req, ExecutionContext context)
    {
        string imageUrl = req.Query["image"];
        using (Stream imageStream = await httpClient.GetStreamAsync(imageUrl))
        {
            IronTesseract ocrEngine = new IronTesseract();
            using (OcrInput input = new OcrInput(imageStream))
            {
                OcrResult result = ocrEngine.Read(input);
                return new OkObjectResult(result.Text);
            }
        }
    }
}
```

This function directly processes the input image URL and outputs the extracted text.

### Additional Capabilities and Features of IronOCR

IronOCR supports a diverse range of file types and provides robust functionality:

- High-speed processing capabilities.
- Superior accuracy in text recognition.
- Ability to read barcodes and QR codes.
- Operates independently from cloud-based SaaS.
- Easily converts PDFs and images into text-searchable formats.
- Outperforms Azure OCR services offered by Microsoft Cognitive Services.

## Enhancements for OCR Performance

IronOCR includes several filters and settings to enhance OCR performance:

- **Rotation, binarization, grayscale conversion,** and **contrast adjustments** improve readability.
- **Noise reduction** and **resolution enhancement** tools refine input image quality.

## Availability and Access

IronOCR is available under several [licensing tiers](https://ironsoftware.com/csharp/ocr/licensing), with free development licenses.

## Further Resources

Additional information and support resources are available here:

- [Tutorial Resources](https://ironsoftware.com/csharp/ocr/tutorials/how-to-read-text-from-an-image-in-csharp-net/)
- [API Documentation](https://ironsoftware.com/csharp/ocr/object-reference/api/)
- [Support](https://ironsoftware.com/contact-us/#live-chat-support)
- [Contact Iron Software](https://ironsoftware.com/contact-us/)