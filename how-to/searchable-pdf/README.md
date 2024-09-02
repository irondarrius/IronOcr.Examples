# Saving Documents as Searchable PDFs

A searchable PDF, often referred to by its technical term 'OCR PDF', merges the capabilities of a scanned image PDF with machine-readable text elements. This hybrid is possible thanks to Optical Character Recognition (OCR), a technology that identifies textual content within images, transforming it into editable and searchable data.

IronOCR enables the creation of these enhanced documents by providing robust features to apply OCR on imagery and convert the recognized data into searchable PDFs. These capabilities extend to various output forms including files, bytes, and streams.

## Example of Exporting a Searchable PDF

To convert OCR results into a searchable PDF, users should firstly set the `Configuration.RenderSearchablePdf` property to `true`. After OCR processing via the `Read` method, the `SaveAsSearchablePdf` method is employed to generate the output. Here's how it works, demonstrated using the [sample TIFF](https://ironsoftware.com/static-assets/ocr/how-to/html-export/Potter.tiff) image.

```cs
using IronOcr;

// Initialize the IronTesseract class
IronTesseract ocrTesseract = new IronTesseract();

// Activate rendering as a searchable PDF
ocrTesseract.Configuration.RenderSearchablePdf = true;

// Load the image file for OCR processing
using var imageInput = new OcrImageInput("Potter.tiff");

// Execute the OCR operation
OcrResult ocrResult = ocrTesseract.Read(imageInput);

// Save the OCR result as a searchable PDF file
ocrResult.SaveAsSearchablePdf("searchablePdf.pdf");
```

Below, you'll find a visual comparison using the sample TIFF alongside an embedded searchable PDF. This enables you to explore the impact of OCR; text within the PDF is now selectable, enhancing functionalities such as text search within most PDF viewing software.

While IronOCR aims for accuracy in text reproduction, variations in text size may occur as the software uses a particular font to overlay text on the image.

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/searchable-pdf/potter.webp" alt="TIFF file" class="img-responsive add-shadow">
         <p class="competitors__download-link" style="color: #181818; font-style: italic;">
            TIFF file
        </p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <iframe loading="lazy" src="https://ironsoftware.com/static-assets/ocr/how-to/searchable-pdf/searchablePdf.pdf" width="100%" height="400px" align="right"></iframe>
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">
            Searchable PDF
        </p>
    </div>
</div>

## Byte and Stream Outputs for Searchable PDFs

IronOCR not only supports file output but also allows the extraction of searchable PDF data as bytes and streams. Below is a succinct example demonstrating the use of these methods for your reference.

```cs
// Retrieve the searchable PDF through byte data
byte[] pdfByte = ocrResult.SaveAsSearchablePdfBytes();

// Get the searchable PDF as a stream
Stream pdfStream = ocrResult.SaveAsSearchablePdfStream();
```