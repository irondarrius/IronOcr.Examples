# Saving OCR Results as hOCR in an HTML Format

hOCR, an abbreviation for "HTML-based OCR," is a format used to express the output of Optical Character Recognition (OCR) in a structured HTML format. It is designed to encapsulate the recognized text, layout details, and positions of individual characters from scanned documents.

IronOCR, a robust .NET library, facilitates OCR on various documents, allowing results to be exported as hOCR in an HTML file. This functionality supports both direct HTML file outputs and HTML strings.

## Example of Exporting Results as hOCR

To export OCR results as hOCR, set the `Configuration.RenderHocr` property of the IronOCR configuration object to `true`. After executing the OCR process using the `Read` method, you can then save the results as an hOCR HTML file using the `SaveAsHocrFile` method. The following code snippet uses a sample TIFF file available [here](https://ironsoftware.com/static-assets/ocr/how-to/html-export/Potter.tiff).

```cs
using IronOcr;

// Create an instance of IronTesseract
IronTesseract ocrEngine = new IronTesseract();

// Set the rendering mode to hOCR
ocrEngine.Configuration.RenderHocr = true;

// Load the image for OCR processing
using var inputImage = new OcrImageInput("Potter.tiff");
inputImage.Title = "Sample OCR Document";

// Execute the OCR process
OcrResult result = ocrEngine.Read(inputImage);

// Save the OCR results as hOCR-formatted HTML file
result.SaveAsHocrFile("output.html");
```

## Exporting Result as an HTML String

For instances where you might prefer to obtain a string representation of the hOCR results, proceed with the `SaveAsHocrString` method, following the processing of the same TIFF sample image. This method returns an HTML-formatted string representing the OCR results.

```cs
// Convert OCR results to HTML string
string htmlResult = result.SaveAsHocrString();
```