# C# PDF OCR

***Based on <https://ironsoftware.com/how-to/csharp-pdf-ocr/>***


OCR (Optical Character Recognition) for PDF files is a pivotal task for developers of .NET applications. 

Here are some reasons why OCR is applied on PDF documents:

- To repurpose or upgrade existing content
- To enable text search functionality on scanned PDFs
- To help in filling up a search index

IronOCR excellently supports .NET and C# developers by leveraging Tesseract 5 to enhance OCR capabilities specifically for PDF files.

## Executing OCR on a PDF Using C&num;

IronOcr offers a powerful and straightforward API that allows developers to extract text from PDF files and make scanned documents searchable in C# and other .NET languages.

Here’s a C# example demonstrating OCR on an existing PDF:

```cs
using IronOcr;

var ocrEngine = new IronTesseract();
using (var input = new OcrInput())
{
    input.AddPdf("example.pdf");
    var ocrResult = ocrEngine.Read(input);
    Console.WriteLine(ocrResult.Text);
}
```

To pull out text from selective pages, consider the following snippet:

```cs
using IronOcr;

var ocrEngine = new IronTesseract();
using (var input = new OcrInput())
{
    input.AddPdfPages("example.pdf", new [] { 1, 2, 3 });
    var ocrResult = ocrEngine.Read(input);
    Console.WriteLine(ocrResult.Text);
}
```

### Understanding the OCR Results

The `ocrResult` extends beyond simple text. It includes rich details such as pages, paragraphs, lines, words, characters, and even barcodes detected in the PDF by IronOcr.

Discover more about the `IronOcr.OcrResult` class here: [Results Objects](https://ironsoftware.com/csharp/ocr/examples/results-objects/).

## Generating Searchable PDFs with OCR

A popular OCR utility is the conversion of scanned documents into searchable PDFs. This feature not only enhances accessibility for users but also simplifies the indexing process for search engines like ElasticSearch or Google.

### Make a Scanned PDF Searchable

The following C# example improves image quality of a PDF and converts it into a searchable PDF document:

```cs
using IronOcr;
var ocrEngine = new IronTesseract();
using (var input = new OcrInput())
{
    input.AddPdf("scan.pdf")

    // Correcting twisted pages
    input.Deskew();

    var ocrResult = ocrEngine.Read(input);
    ocrResult.SaveAsSearchablePdf("searchable.pdf");
}
```

### Transform Images into a Searchable PDF

OCR can also be used to transform image files into a searchable PDF format in C#/.NET environments:

```cs
using IronOcr;
var ocrEngine = new IronTesseract();
using (var input = new OcrInput())
{
    input.Add(@"images\page1.png")
    input.Add(@"images\page2.bmp")
    input.Add(@"images\page3.tiff")

    // Correct twisted pages
    input.Deskew();
    var ocrResult = ocrEngine.Read(input);
    ocrResult.SaveAsSearchablePdf("searchable.pdf");
}
```

This modern approach to handling PDF documents through OCR allows developers to extensively enhance and utilize content within .NET applications, streamline workflows, and improve content discoverability.