# C# PDF OCR

Optical Character Recognition (OCR) of PDF documents is a prevalent requirement in the world of real-world .NET software development.

Reasons for performing OCR on a PDF include:

- Extracting content to be repurposed or updated
- Enabling search capabilities in scanned PDF documents
- Enhancing a search index

IronOCR extends the capabilities of Tesseract 5, specifically tailored for .NET developers, to handle these tasks proficiently.

## How to Perform OCR on a PDF using C#

IronOcr offers a powerful API to extract text from PDF documents and make scanned PDFs searchable across C# and other .NET languages.

Below is a C# code example demonstrating how to perform OCR on an existing PDF:

```cs
using IronOcr;

var OcrEngine = new IronTesseract();
using (var PdfInput = new OcrInput("example.pdf"))
{
    var OcrResult = OcrEngine.Read(PdfInput);
    Console.WriteLine(OcrResult.Text);  // Displaying extracted text
}
```

To perform OCR on specific pages of a PDF, consider the following code:

```cs
using IronOcr;

var OcrEngine = new IronTesseract();
using (var PdfInput = new OcrInput())
{
    PdfInput.AddPdfPages("example.pdf", new[] { 1, 2, 3 });  // Specifying pages to OCR
    var OcrResult = OcrEngine.Read(PdfInput);
    Console.WriteLine(OcrResult.Text);  // Displaying extracted text from specified pages
}
```

#### PDF OCR Results Class

The `OcrResult` object encompasses far more than just the text of the PDF. It also includes details regarding pages, paragraphs, lines, words, characters, and any barcodes that IronOcr detects within the document.

Learn more about the `IronOcr.OcrResult` Class at: [IronOCR Results Objects](https://ironsoftware.com/csharp/ocr/examples/results-objects/).

## Creating Searchable PDFs via OCR

One of the popular functionalities is to create searchable PDFs from scanned documents. This feature enhances accessibility and simplifies indexing in search platforms like ElasticSearch or even Google.

#### Making a Scanned PDF Searchable

The following code snippet demonstrates enhancing a scanned PDF image quality and converting it into a searchable PDF:

```cs
using IronOcr;
var OcrEngine = new IronTesseract();
using (var PdfInput = new OcrInput("scan.pdf"))
{
    PdfInput.Deskew();  // Correction for misaligned pages

    var OcrResult = OcrEngine.Read(PdfInput);
    OcrResult.SaveAsSearchablePdf("searchable.pdf");  // Saving as searchable PDF
}
```

#### Converting Image Files to Searchable PDF

IronOCR can also be used to convert image files into searchable PDFs using C#/.NET:

```cs
using IronOcr;
var OcrEngine = new IronTesseract();
using (var ImgInput = new OcrInput())
{
    ImgInput.Add(@"images\page1.png");
    ImgInput.Add(@"images\page2.bmp");
    ImgInput.Add(@"images\page3.tiff");

    ImgInput.Deskew();  // Correcting page orientation issues
    var OcrResult = OcrEngine.Read(ImgInput);
    OcrResult.SaveAsSearchablePdf("searchable.pdf");  // Outputing as searchable PDF
}
```

This tutorial guides you through utilizing IronOCR for proficiently handling PDF OCR tasks within the .NET framework.