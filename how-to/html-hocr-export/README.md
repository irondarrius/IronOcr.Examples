# Exporting OCR Results as hOCR in HTML

***Based on <https://ironsoftware.com/how-to/html-hocr-export/>***


hOCR stands for "HTML-based OCR," a file format ideal for representing the outcome of Optical Character Recognition (OCR). This format utilizes HTML to store recognized text, layout details, and each character's coordinates from the scanned documents or images.

IronOCR, a robust library from Iron Software, facilitates the optical character recognition of documents and subsequently allows the export of these results as hOCR in an HTML format. This capability extends to both HTML files and strings.

### Setting up Iron Software's IronOCR

------

## Example: Exporting OCR Results as hOCR

To begin exporting OCR results as hOCR, you must first activate the `Configuration.RenderHocr` setting by switching it to `true`. Once the OCR operation has been completed using the `Read` method, proceed to export the OCR results by employing the `SaveAsHocrFile` method. This method generates an HTML file populated with the OCR data from the input image. Below is an example using the mentioned [sample TIFF image](https://ironsoftware.com/static-assets/ocr/how-to/html-export/Potter.tiff).

```cs
using IronOcr;

// Create an instance of IronTesseract
IronTesseract ocr = new IronTesseract();

// Configure to output as hOCR
ocr.Configuration.RenderHocr = true;

// Load the image file
using var image = new OcrImageInput("Potter.tiff");
image.Title = "Sample HTML Title";

// Execute OCR process
OcrResult result = ocr.Read(image);

// Save the OCR result as HTML file
result.SaveAsHocrFile("output.html");
```

## Converting OCR Result to HTML String

With the same TIFF image, you can convert the OCR results into an HTML string by using the `SaveAsHocrString` method. This functionality returns the OCR data as a string formatted in HTML.

```cs
// Convert OCR results to HTML string format
string hocrHtmlString = result.SaveAsHocrString();
```