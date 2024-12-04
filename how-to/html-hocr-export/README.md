# Guide to Saving OCR Results as hOCR in HTML Format

***Based on <https://ironsoftware.com/how-to/html-hocr-export/>***


hOCR, known as "HTML-based OCR," is a specialized file format designed to store the output of Optical Character Recognition (OCR) processes. These files, written in HTML, capture recognized text and its spatial arrangement, including detailed coordinates for each detected character within a document or image.

IronOCR offers a robust means to execute OCR on documents and save these results in the hOCR HTML file format, accommodating both HTML files and strings.



## Example: Saving OCR Results as hOCR

To save OCR results as hOCR, you need to activate the **Configuration.RenderHocr** setting by enabling it. Following the OCR process using the `Read` method, the `SaveAsHocrFile` method can be utilized to create an HTML file encapsulating the OCR outcomes. Below you'll find example code that uses the [sample TIFF image](https://ironsoftware.com/static-assets/ocr/how-to/html-export/Potter.tiff) provided.

```cs
using IronOcr;
namespace ironocr.HtmlHocrExport
{
    public class Section1
    {
        public void Run()
        {
            // Initialize IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Configure to generate hOCR
            ocrTesseract.Configuration.RenderHocr = true;
            
            // Load image for OCR
            using var imageInput = new OcrImageInput("Potter.tiff");
            imageInput.Title = "Html Title";
            
            // Execute OCR and read results
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
            
            // Output results as HTML file
            ocrResult.SaveAsHocrFile("result.html");
        }
    }
}
```

## Exporting OCR Result as HTML String

To further extend functionality with the same TIFF sample, you might want to use the `SaveAsHocrString` method. This will generate the OCR results in the form of an HTML string.

```cs
using IronOcr;
namespace ironocr.HtmlHocrExport
{
    public class Section2
    {
        public void Run()
        {
            IronTesseract ocrTesseract = new IronTesseract();
            ocrTesseract.Configuration.RenderHocr = true;
            using var imageInput = new OcrImageInput("Potter.tiff");
            OcrResult ocrResult = ocrTesseract.Read(imageInput);

            // Return the OCR results as an HTML string
            string hocr = ocrResult.SaveAsHocrString();
        }
    }
}
```