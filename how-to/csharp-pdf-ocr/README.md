# C# PDF OCR

***Based on <https://ironsoftware.com/how-to/csharp-pdf-ocr/>***


Optical Character Recognition (OCR) on PDF documents is a prevalent requirement in modern .NET software development.

The need to implement OCR on a PDF document could arise for various reasons, such as:

- Modernizing or reusing extracted content
- Enabling search functionality on scanned PDFs
- Enhancing the content for Search index population

IronOCR is a comprehensive API designed for .NET and C# developers, offering capabilities that incorporate Tesseract 5 along with specialized PDF functionalities for .NET users.

## Executing OCR on a PDF Using C&num;

IronOcr furnishes a powerful API that not only permits text extraction from PDFs but also transforms scanned PDFs into searchable documents within C# and other .NET supported languages.

Here is a basic C# example to perform OCR on an existing PDF:

```cs
using IronOcr;

var ocr = new IronTesseract();
using (var input = new OcrInput())
{
    input.AddPdf("example.pdf"); 
    var ocrResult = ocr.Read(input);
    Console.WriteLine(ocrResult.Text);
}
```

Additionally, text extraction from specific pages is possible:

```cs
using IronOcr;

var ocr = new IronTesseract();
using (var input = new OcrInput())
{
    input.AddPdfPages("example.pdf", new [] { 1, 2, 3 });
    var ocrResult = ocr.Read(input);
    Console.WriteLine(ocrResult.Text);
}
```

#### Structure of PDF OCR Results

The `ocrResult` object includes not just the text, but also detailed metadata such as Pages, Paragraphs, Lines, Words, Characters, and Barcodes detected in the PDF by IronOcr.

More on the `IronOcr.OcrResult` Class at: [IronOcr OcrResult Class](https://ironsoftware.com/csharp/ocr/examples/results-objects/).

## Generating Searchable PDFs through OCR

Creating searchable PDFs from scanned documents is a highly utilized feature of OCR, making them more user-friendly and simpler to catalog by search systems like ElasticSearch or Google.

#### Transforming a Scanned PDF into a Searchable PDF

This snippet demonstrates improving a scanned PDF's image quality and converting it into a searchable PDF:

```cs
using IronOcr;
var ocr = new IronTesseract();
using (var input = new OcrInput())
{
    input.AddPdf("scan.pdf");
 
    // Correct skewed pages
    input.Deskew();

    var ocrResult = ocr.Read(input);
    ocrResult.SaveAsSearchablePdf("searchable.pdf");
}
```

#### Converting Images to a Searchable PDF

OCR technology can also be employed to convert image files into a searchable PDF document in C#/.NET:

```cs
using IronOcr;
var ocr = new IronTesseract();
using (var input = new OcrInput())
{
    input.Add(@"images/page1.png")
    input.Add(@"images/page2.bmp")
    input.Add(@"images/page3.tiff")

    // Correct skewed pages
    input.Deskew();
    var ocrResult = ocr.Read(input);
    ocrResult.SaveAsSearchablePdf("searchable.pdf");
}
```