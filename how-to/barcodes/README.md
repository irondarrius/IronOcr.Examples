# How to Read Barcodes and QR Codes

***Based on <https://ironsoftware.com/how-to/barcodes/>***


Utilizing OCR technology to read barcodes and QR codes is highly effective in situations where these identifiers must be scanned from either printed or digital documents. This capability supports automation and facilitates the extraction of information from diverse sources, providing a flexible tool for businesses and developers alike.

IronOcr simplifies the process of barcode and QR code recognition by requiring minimal configuration adjustments.

## Example of Barcode Reading

First, create an instance of the `IronTesseract` class to initiate the OCR process. Activate the barcode reading feature by setting the `ReadBarCodes` property to `true`. Load the PDF document into the OCR tool by using the `OcrPdfInput` class. Execute the OCR process on the document by calling the `Read` method.

Here is an example where OCR is applied to a PDF containing barcodes:

<iframe loading="lazy" src="https://ironsoftware.com/static-assets/ocr/how-to/barcodes/pdfWithBarcodes.pdf#view=fit" width="100%" height="400px">
</iframe>

```cs
using System;
using IronOcr;
namespace ironocr.Barcodes
{
    public class Section1
    {
        public void Execute()
        {
            // Create a new IronTesseract instance
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Activate barcode and QR code reading
            ocrTesseract.Configuration.ReadBarCodes = true;
            
            // Load the PDF document
            using var documentInput = new OcrPdfInput("pdfWithBarcodes.pdf");
            
            // Run OCR process
            OcrResult result = ocrTesseract.Read(documentInput);
            
            // Display the OCR and barcode results
            Console.WriteLine("OCR Text Output:");
            Console.WriteLine(result.Text);
            Console.WriteLine("Detected Barcodes:");
            foreach (var barcode in result.Barcodes)
            {
                Console.WriteLine(barcode.Value);
            }
        }
    }
}
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/barcodes/read-barcodes.webp" alt="Reading result" class="img-responsive add-shadow">
    </div>
</div>

The results include the decoded text and barcode values displayed within the OCR output.

## Example of QR Code Reading

Setting up for QR code reading is similar to barcode reading, requiring the `ReadBarCodes` property to be enabled. The main difference is the source PDF file, which in this case, contains QR codes. Now, let's apply OCR to this document:

<iframe loading="lazy" src="https://ironsoftware.com/static-assets/ocr/how-to/barcodes/pdfWithQrCodes.pdf#view=fit" width="100%" height="400px">
</iframe>

```cs
using System;
using IronOcr;
namespace ironocr.Barcodes
{
    public class Section2
    {
        public void Execute()
        {
            // Initialize IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Enable reading of barcodes and QR codes
            ocrTesseract.Configuration.ReadBarCodes = true;
            
            // Load the targeted PDF
            using var documentInput = new OcrPdfInput("pdfWithQrCodes.pdf");
            
            // Conduct OCR
            OcrResult result = ocrTesseract.Read(documentInput);
            
            // Print text and barcode outputs
            Console.WriteLine("OCR Text Output:");
            Console.WriteLine(result.Text);
            Console.WriteLine("Detected Barcodes:");
            foreach (var barcode in result.Barcodes)
            {
                Console.WriteLine(barcode.Value);
            }
        }
    }
}
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/barcodes/read-qr-codes.webp" alt="Reading result" class="img-responsive add-shadow">
    </div>
</div>

Similarly, the decoding session produces both the text retrieved through OCR and the values of the QR codes that were scanned.