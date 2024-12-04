# Leveraging IronOCR for Multilingual OCR Using Tesseract

***Based on <https://ironsoftware.com/how-to/ocr-multiple-languages/>***


IronOCR stands out in the Optical Character Recognition (OCR) domain for its proficiency in deciphering text across a variety of languages and scripts. It harnesses the power of the Tesseract Engine to deliver a dependable and user-friendly OCR solution.

This guide explores how IronOCR efficiently processes text in multiple languages with Tesseract. It is designed for both seasoned developers in search of a robust multilingual OCR tool and individuals keen to learn about the technology behind it. We aim to illuminate the functionalities of IronOCR and its Tesseract engine, highlighting the immense value this tool provides.



## Extracting Text from Multilanguage PDFs

IronOCR supports approximately 125 language packs. By default, only the English language pack is installed; additional packs are available via NuGet. Discover all the supported [language packs here](https://ironsoftware.com/csharp/ocr/languages).

Below is an example demonstrating how to employ multiple languages with IronOCR to extract text from a PDF document.

```cs
using System;
using IronOcr;
namespace ironocr.OcrMultipleLanguages
{
    public class Section1
    {
        public void Run()
        {
            // Create a new IronTesseract instance
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Include Russian as a secondary language
            ocrTesseract.AddSecondaryLanguage(OcrLanguage.Russian);
            
            // Load a PDF file
            using var pdfInput = new OcrPdfInput(@"example.pdf");
            // Execute OCR
            OcrResult result = ocrTesseract.Read(pdfInput);
            
            // Display the extracted text
            Console.WriteLine(result.Text);
        }
    }
}
```

Additional secondary languages can be added using the `AddSecondaryLanguage` method. Note that adding languages might impact the processing speed and performance. The sequence in which languages are added influences their priority; languages added earlier have higher precedence.

## Extracting Text from Multilanguage Images

By default, the primary language is English. To modify the primary OCR language and add secondary languages, follow the example below.

```cs
using System;
using IronOcr;
namespace ironocr.OcrMultipleLanguages
{
    public class Section2
    {
        public void Run()
        {
            // Instantiate a new IronTesseract object
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Set Russian as the primary language
            ocrTesseract.Language = OcrLanguage.Russian;
            ocrTesseract.AddSecondaryLanguage(OcrLanguage.Japanese);
            
            // Load an image
            using var imageInput = new OcrImageInput(@"example.png");
            // Conduct OCR
            OcrResult result = ocrTesseract.Read(imageInput);
            
            // Print the OCR results
            Console.WriteLine(result.Text);
        }
    }
}
```

Below is the visual output showcasing the OCR results.

![Russian and Japanese OCR Results](https://ironsoftware.com/static-assets/ocr/how-to/multiple-languages/russian_japanese%20.webp)

## Summary

In conclusion, IronOCR, with its robust Tesseract engine, is excellent at extracting text from documents in multiple languages. It offers a comprehensive solution for developers and enthusiasts dealing with multilingual texts in PDFs or images, streamlining the task of recognizing and extracting such content. Whether your applications deal with varied linguistic content across different document types, IronOCR simplifies the endeavor with its powerful capabilities.