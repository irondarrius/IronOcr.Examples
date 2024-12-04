# Developing an OCR Service on Azure with IronOCR

***Based on <https://ironsoftware.com/how-to/iron-ocr-azure-tutorial/>***


Iron Software has engineered the IronOCR library to streamline the process of integrating OCR capabilities in Azure. Historically, incorporating OCR functionalities with Azure has presented considerable challenges for developers. IronOCR not only addresses these difficulties but also offers enhancements to optimize OCR processes.

## Benefits of Using IronOCR on Microsoft Azure

The utility of IronOCR in Azure spans several functions:

- Converts PDFs to searchable formats, simplifying text extraction.
- Converts images into searchable text documents.
- Capable of reading both barcodes and QR codes.
- Offers stellar accuracy.
- Delivers rapid processing speeds.
- Operates onsite without the need for SaaS, aligning with the cloud services provided by platforms like Microsoft Azure.

Let's explore how IronOCR by Iron Software can simplify the developer's experience in extracting text from various documents.

## Getting Started with Azure OCR Service

First, we need to integrate IronOCR into our project:

1. Begin by creating a new C# Console application.
2. Add the IronOCR package via NuGet by executing the command: `Install-Package IronOcr` or by browsing through the NuGet package manager.
3. Modify your `Program.cs` to incorporate the IronOcr namespace, enabling the reading and extraction of document contents:

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
            using (var Input = new OcrInput("https://ironsoftware.com/Assets/Images/Purgatory.PNG"))
            {
                var result = ocrEngine.Read(Input); // OCR processing on PNG image
                Console.WriteLine(result.Text); // Output the extracted text
                Console.ReadLine(); 
            }
        }
    }
}
```

4. Load and process the image `Purgatory.PNG`, which is inspired by Dante's "Divine Comedy".

![OCR Text Extraction](https://ironsoftware.com/img/iron-ocr-azure-2.png)
*Figure 2 - Extracting text using IronOCR's capabilities*

5. Display the OCR extracted text from the preceding image.

![Extracted Text](https://ironsoftware.com/img/iron-ocr-azure-3.png)
*Figure 3 - Display of Extracted Text*

6. Replicate the above process using a PDF document, `Purgatorio.pdf`:

 ```cs
 var ocrEngine = new IronTesseract();
 using (var input = new OcrInput())
 {
    input.Title = "Divine Comedy - Purgatory"; 
    input.AddPdf("https://ironsoftware.com/Documents/Purgatorio.pdf", "dante");
    var result = ocrEngine.Read(input); 
    
    result.SaveAsSearchablePdf("SearchablePDFDocument.pdf"); 
 }
 ```

Essentially, this code mimics the steps taken for image text extraction, now applied to a PDF.

7. Explore using OCR with Microsoft Azure through a functional example in Azure Functions, showcasing how IronOCR can efficiently integrate into cloud environments:

```cs
public static class OCRFunction
{
    private static readonly HttpClient httpClient = new HttpClient();

    [FunctionName("ExampleOCRFunction")]
    public static async Task<IActionResult> Run([HttpTrigger] HttpRequest request, ExecutionContext context)
    {
        string imageUrl = request.Query["image"];
        Stream imageStream = await httpClient.GetStreamAsync(imageUrl);

        var ocr = new IronTesseract();
        using (var input = new OcrInput(imageStream))
        {
            var result = ocr.Read(input);
            return new OkObjectResult(result.Text);
        }
    }
}
```

This feature utilizes the incoming image URL, processes it through IronOCR, and outputs the extracted text.

### Additional Features of IronOCR for .NET on Azure

- High-speed and accurate OCR processing.
- Reads barcodes and QR codes.
- Functions locally without dependency on SaaS.
- Converts both PDFs and images into searchable text.

### Image Filters to Enhance OCR Performance

- **OcrInput.Rotate** – Adjust image orientation.
- **OcrInput.Binarize()** – Converts images to binary (black and white) format.
- **OcrInput.ToGrayScale()** – Changes images to grayscale to improve processing speed.
- **OcrInput.Contrast()** – Enhances image contrast for better text clarity.
- **OcrInput.DeNoise()** – Cleans up noise in images.
- **OcrInput.Invert()** – Inverts colors in images.
- **OcrInput.Dilate()** and **OcrInput.Erode()** – Modifies image pixel boundaries.
- **OcrInput.Deskew()** – Corrects tilted images.
- **OcrInput.DeepCleanBackgroundNoise()** – Intensively removes background noise.
- **OcrInput.EnhanceResolution** – Boosts resolution of low-quality images.

### Considerations and Resources

IronOCR offers various licensing tiers, all based on a one-time purchase model and are free for development use.

- Find detailed information and resources [here](https://ironsoftware.com/csharp/ocr/tutorials/how-to-read-text-from-an-image-in-csharp-net/).
- View the API references [here](https://ironsoftware.com/csharp/ocr/object-reference/api/).
- Get support for IronOCR products [here](#live-chat-support).
- Contact Iron Software [here](https://ironsoftware.com/contact-us/).

IronOCR is equipped with support for numerous .NET frameworks and configurations and makes a robust companion for developers looking to enhance their applications with efficient OCR functionalities within Azure and beyond.