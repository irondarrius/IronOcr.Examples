# Understanding PDF Reading

***Based on <https://ironsoftware.com/how-to/input-pdfs/>***


PDF, which stands for "Portable Document Format," is a file format concocted by Adobe to maintain the authenticity of document designs including fonts, images, and layouts, no matter the software or hardware where it was created. PDFs are widely embraced for their ability to display contents consistently across different environments. Using Iron Software's IronOcr, developers can successfully manage and read PDFs in various versions with efficiency and ease.

## PDF Reading Tutorial

To begin reading PDFs, establish an instance of `IronTesseract`. Use a 'using' statement to initiate an `OcrPdfInput` instance by passing the path of the PDF. Then, process the document using the `Read` method.

```cs
using IronOcr;
namespace ironocr.InputPdfs
{
    public class Section1
    {
        public void ReadPdf()
        {
            // Create a new instance of IronTesseract
            IronTesseract tesseract = new IronTesseract();
            
            // Initialize the PDF input
            using var pdfReader = new OcrPdfInput("Potter.pdf");
            // Execute the OCR process
            OcrResult result = tesseract.Read(pdfReader);
        }
    }
}
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-pdfs/read-pdf.webp" alt="Read PDF file" class="img-responsive add-shadow">
    </div>
</div>

Usually, setting the DPI parameter isn't required, but using a higher DPI might improve the precision of the OCR.

## Reading Specific PDF Pages

To extract text from particular pages within a PDF file, specify the desired pages using the `PageIndices` array. Enter zero-based index numbers for each page you want to include.

```cs
using System.Collections.Generic;
using IronOcr;
namespace ironocr.InputPdfs
{
    public class Section2
    {
        public void ReadSelectedPages()
        {
            // Initialize IronTesseract
            IronTesseract tesseract = new IronTesseract();
            
            // List desired pages
            List<int> pageIndex = new List<int> { 0, 2 };
            
            // Setup the PDF reader with specific pages
            using var pdfReader = new OcrPdfInput("Potter.pdf", PageIndices: pageIndex);
            // Execute OCR
            OcrResult result = tesseract.Read(pdfReader);
        }
    }
}
```

## Targeting Specific Scan Regions

You can enhance OCR performance by specifying the exact area of the PDF to be analyzed. This strategy is particularly useful when you need to extract information from specific portions of a page.

```cs
using System;
using IronOcr;
namespace ironocr.InputPdfs
{
    public class Section3
    {
        public void ReadRestrictedArea()
        {
            // Initialize IronTesseract
            IronTesseract tesseract = new IronTesseract();
            
            // Define specific reading regions
            Rectangle[] contentAreas = { new Rectangle(550, 100, 600, 300) };
            
            // Prepare the PDF reader with constrained content areas
            using (var pdfReader = new OcrPdfInput("Potter.pdf", ContentAreas: contentAreas))
            {
                // Perform OCR
                OcrResult result = tesseract.Read(pdfReader);
            
                // Print the output to the console
                Console.WriteLine(result.Text);
            }
        }
    }
}
```

### OCR Output Visualization

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/input-pdfs/read-specific-region.webp" alt="Read specific region" class="img-responsive add-shadow">
    </div>
</div>