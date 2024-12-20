# Multilingual Text Extraction Using IronOCR and Tesseract

***Based on <https://ironsoftware.com/how-to/ocr-multiple-languages/>***


IronOCR is a distinguished Optical Character Recognition (OCR) solution, leveraging the capabilities of the Tesseract Engine to proficiently extract text from a plethora of languages and scripts. This guide aims to elucidate the multilingual capabilities of IronOCR, providing both new and experienced developers with an understanding of this powerful tool.

### Initial Setup with IronOCR

---

## Extracting Text from Multilingual PDFs

IronOCR offers support for approximately 125 languages, but it installs only the English language pack by default. Additional languages can be acquired via NuGet. Explore the variety of available [language packs here](https://ironsoftware.com/csharp/ocr/languages).

Below is an example demonstrating how to utilize IronOCR for extracting text from a multilingual PDF document:

```cs
using IronOcr;
using System;

// Create an IronTesseract instance
IronTesseract ocrTesseract = new IronTesseract();

// Include Russian as a secondary language
ocrTesseract.AddSecondaryLanguage(OcrLanguage.Russian);

// Load a PDF file
using var pdfInput = new OcrPdfInput(@"example.pdf");
// Execute OCR
OcrResult result = ocrTesseract.Read(pdfInput);

// Display the extracted text
Console.WriteLine(result.Text);
```

When adding secondary languages, be aware that this might impact the processing speed and overall performance. The order in which you add languages may influence their priority during text extraction.

## Extracting Text from Multilingual Images

By default, IronOCR assumes English as the primary language. You may adjust the primary language and add secondary languages to suit your needs.

```cs
using IronOcr;
using System;

// Initialize IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Set primary language to Russian and add Japanese as a secondary
ocrTesseract.Language = OcrLanguage.Russian;
ocrTesseract.AddSecondaryLanguage(OcrLanguage.Japanese);

// Load an image file
using var imageInput = new OcrImageInput(@"example.png");
// Execute OCR
OcrResult result = ocrTesseract.Read(imageInput);

// Print the extracted text
Console.WriteLine(result.Text);
```

Upon correct configuration, you should be able to achieve results such as those shown below.

![Russian and Japanese OCR Result](https://ironsoftware.com/static-assets/ocr/how-to/multiple-languages/russian_japanese.webp)

## Conclusion

In summary, IronOCR, powered by the robust Tesseract engine, stands out in its ability to accurately extract text from documents in various languages. This tool is invaluable for developers dealing with the intricacies of multilingual text reading, whether the text resides in PDFs or images. IronOCR simplifies multilingual text extraction, ensuring efficient and accurate processing.