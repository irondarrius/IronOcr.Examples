# Understanding Read Confidence in OCR

***Based on <https://ironsoftware.com/how-to/tesseract-result-confidence/>***


Read confidence in Optical Character Recognition (OCR) signifies the reliability level or certainty that the OCR technology attaches to the accuracy of the text it has identified from an image or document. Essentially, it's the OCR system's assurance that the text extracted is accurate.

A higher read confidence score reflects greater certainty of correct recognition, whereas a lower score may indicate potential inaccuracies.

<h3>Begin Using IronOCR</h3>

-----------------------

## Example of Retrieving Read Confidence

Following an OCR operation on an image, the text's confidence level is stored within the **Confidence** attribute. Utilize a 'using' statement for efficient resource management. Images and PDFs can be input using `OcrImageInput` and `OcrPdfInput` classes, respectively. The `Read` method produces an `OcrResult` object, where the **Confidence** property can be accessed.

```cs
using IronOcr;

// Create an instance of IronTesseract
IronTesseract ocrInstance = new IronTesseract();

// Input image
using var inputImage = new OcrImageInput("sample.tiff");
// Execute OCR
OcrResult result = ocrInstance.Read(inputImage);

// Extract confidence level
double extractedConfidence = result.Confidence;
```

## Accessing Read Confidence at Various Granular Levels

You can determine the confidence level not only for the entire document but also for individual pages, paragraphs, lines, words, and characters. Additionally, confidence for a block, which represents a group of paragraphs in close proximity, can also be accessed.

```cs
// Retrieve the confidence level for a page
double pageConfidence = result.Pages[0].Confidence;

// Retrieve the confidence level for a paragraph
double paragraphConfidence = result.Paragraphs[0].Confidence;

// Retrieve the confidence level for a line
double lineConfidence = result.Lines[0].Confidence;

// Retrieve the confidence level for a word
double wordConfidence = result.Words[0].Confidence;

// Retrieve the confidence level for a character
double characterConfidence = result.Characters[0].Confidence;

// Retrieve the confidence level for a block
double blockConfidence = result.Blocks[0].Confidence;
```

## Exploring Character Choices

Beyond confidence levels, an intriguing attribute named **Choices** provides a list of alternative word suggestions along with their statistical significance. This feature helps users explore possible variations of the characters recognized.

```cs
using IronOcr;
using static IronOcr.OcrResult;

// Initialize IronTesseract
IronTesseract tessOcr = new IronTesseract();

// Input image
using var inputTextImage = new OcrImageInput("Potter.tiff");
// Conduct OCR
OcrResult tessResult = tessOcr.Read(inputTextImage);

// Access choices
Choice[] characterChoices = tessResult.Characters[0].Choices;
```

### Visual Representation

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/tesseract-result-confidence/choices.webp" alt="Choices" class="img-responsive add-shadow">
    </div>
</div>