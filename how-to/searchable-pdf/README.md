# How to Generate Searchable PDFs with OCR

***Based on <https://ironsoftware.com/how-to/searchable-pdf/>***


A searchable PDF, often termed as an OCR PDF, encompasses a hybrid of scan-quality images and text that is readable by machine, made possible through Optical Character Recognition (OCR). This capability derives from OCR technology applied to digital scans or image files, converting embedded textual content into a format that is both searchable and selectable.

IronOCR is a robust library that facilitates optical character recognition of documents and enables the generation of these enhanced PDFs. It supports creating searchable PDFs in various formats such as files, bytes, and streams.

## Creating a Searchable PDF

To generate a searchable PDF, users should enable the **Configuration.RenderSearchablePdf** to `true`. Following this, after extracting the OCR results from the `Read` method, the `SaveAsSearchablePdf` method is utilized for saving the output. Below illustrates this process using the [sample TIFF image](https://ironsoftware.com/static-assets/ocr/how-to/html-export/Potter.tiff).

```cs
using IronOcr;
namespace ironocr.SearchablePdf
{
    public class Section1
    {
        public void Run()
        {
            // Initialize IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Configuration for rendering a searchable PDF
            ocrTesseract.Configuration.RenderSearchablePdf = true;
            
            // Load image for OCR processing
            using var imageInput = new OcrImageInput("Potter.tiff");
            // Execute OCR on the image
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
            
            // Saving OCR result as a searchable PDF
            ocrResult.SaveAsSearchablePdf("searchablePdf.pdf");
        }
    }
}
```

Below you'll find a visual of the original TIFF image and the produced searchable PDF for sampling purposes. You'll notice you can select text in the searchable PDF, enabling search functionality in your desired PDF viewer application.

IronOCR employs a specific font when overlaying recognized text onto images; therefore, at times, you might notice variations in the text and image sizes.

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

## Outputting Searchable PDF as Bytes and Streams

It's also feasible to retrieve the searchable PDF in byte array format or as a stream, utilizing the `SaveAsSearchablePdfBytes` and `SaveAsSearchablePdfStream` methods accordingly. Here's a code example showcasing these outputs.

```cs
using IronOcr;
namespace ironocr.SearchablePdf
{
    public class Section2
    {
        public void Run()
        {
            // Export the searchable PDF as a byte array
            byte[] pdfByte = ocrResult.SaveAsSearchablePdfBytes();
            
            // Export the searchable PDF as a stream
            Stream pdfStream = ocrResult.SaveAsSearchablePdfStream();
        }
    }
}
```