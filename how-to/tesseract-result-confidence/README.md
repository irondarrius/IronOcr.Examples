# Understanding Read Confidence in OCR

Read confidence in optical character recognition (OCR) is a metric used to denote how sure the OCR system is about the correctness of the text it has identified in a document or image. High read confidence implies that the OCR algorithm is almost certain about its text recognition results, whereas a low score might indicate potential inaccuracies.

## Example: Obtaining Read Confidence

Once OCR is conducted on an image, the certainty of the results can be examined through the **Confidence** attribute. For managing resources efficiently, make use of the `using` statement. Employ classes such as `OcrImageInput` and `OcrPdfInput` for adding image and PDF files respectively. The `Read` method processes the added document and provides an `OcrResult` object, enabling access to the **Confidence** property.

```cs
using IronOcr;

// Initialize IronTesseract
IronTesseract ocrInstance = new IronTesseract();

// Load the image
using var inputImage = new OcrImageInput("sample.tiff");
// Perform OCR on the image
OcrResult result = ocrInstance.Read(inputImage);

// Extract confidence level
double confidenceScore = result.Confidence;
```

## Accessing Various Confidence Levels

The OCR process does not only allow you to assess the overall confidence but also lets you inspect confidence scores at multiple granular levels such as pages, paragraphs, lines, words, and even characters. Additionally, confidence for blocks of text can also be retrieved, where a block is a group of closely situated paragraphs.

```cs
// Retrieve confidence per page
double pageConfidence = result.Pages[0].Confidence;

// Determine confidence per paragraph
double paragraphConfidence = result.Paragraphs[0].Confidence;

// Evaluate confidence per line
double lineConfidence = result.Lines[0].Confidence;

// Check confidence for each word
double wordConfidence = result.Words[0].Confidence;

// Obtain confidence for individual characters
double characterConfidence = result.Characters[0].Confidence;

// Get confidence for text blocks
double blockConfidence = result.Blocks[0].Confidence;
```

## Exploring Character Choices

Besides simple confidence metrics, OCR results include **Choices**, which is a collection of possible alternatives for each recognized word along with their likely accuracy. This attribute can significantly aid in refining text recognition processes.

```cs
using IronOcr;
using static IronOcr.OcrResult;

// Create an IronTesseract instance
IronTesseract tessOcr = new IronTesseract();

// Load the image
using var input = new OcrImageInput("Potter.tiff");
// Execute OCR
OcrResult tessResult = tessOcr.Read(input);

// Access alternative character choices
Choice[] alternativeChoices = tessResult.Characters[0].Choices;
```

### Displaying Retrieved Data

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/tesseract-result-confidence/choices.webp" alt="Choices" class="img-responsive add-shadow">
    </div>
</div>