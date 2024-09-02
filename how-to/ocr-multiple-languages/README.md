# Leveraging Multiple Languages with Tesseract and IronOCR

Optical Character Recognition (OCR) is a transformative technology that scans text within images for editing and indexing. IronOCR harnesses the power of the Tesseract Engine, renowned for its proficiency in multiple languages and scripts, making it a staple tool for developers seeking robust, multilingual OCR capabilities.

This guide explores how IronOCR employs Tesseract to process text in a variety of languages. Whether you are an adept developer needing a dependable OCR tool or just interested in the technology, this content illuminates the diverse applications and benefits of IronOCR and its integration with the Tesseract engine.

## Example: Reading Multi-Language PDFs

IronOcr supports around 125 language packs, with English available upon installation and additional languages accessible via NuGet. Explore all available [language packs here](https://ironsoftware.com/csharp/ocr/languages).

Below is an example demonstrating how to utilize IronOcr for extracting text from a PDF file in multiple languages:

```cs
using IronOcr;
using System;

// Initialize IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Include Russian as a secondary language
ocrTesseract.AddSecondaryLanguage(OcrLanguage.Russian);

// Load the PDF
using var pdfInput = new OcrPdfInput(@"example.pdf");
// Execute OCR
OcrResult result = ocrTesseract.Read(pdfInput);

// Display the extracted text
Console.WriteLine(result.Text);
```

Adding multiple secondary languages is possible via the `AddSecondaryLanguage` method. Be aware, the more languages added, the more it might impact processing time and accuracy. The sequence of language addition matters, priority is given to the first language added.

## Example: Reading Multi-Language Images

By default, the primary recognition language is set to English. This can be modified, along with the addition of secondary languages, to enhance the recognition process.

```cs
using IronOcr;
using System;

// Initialize IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Change primary language to Russian and add Japanese as secondary
ocrTesseract.Language = OcrLanguage.Russian;
ocrTesseract.AddSecondaryLanguage(OcrLanguage.Japanese);

// Load the image
using var imageInput = new OcrImageInput(@"example.png");
// Execute OCR
OcrResult result = ocrTesseract.Read(imageInput);

// Print the extracted text
Console.WriteLine(result.Text);
```

Implemented correctly, this configuration yields high-quality OCR results from various languages.

![Russian and Japanese Text Recognition](https://ironsoftware.com/static-assets/ocr/how-to/multiple-languages/russian_japanese%20.webp)

## Conclusion

IronOCR, equipped with the potent Tesseract engine, excels in extracting text from multilingual documents. Whether parsing through PDFs or analyzing images with texts in various languages, IronOCR simplifies the process of text recognition across diverse languages, offering a reliable solution for developers and enthusiasts alike.