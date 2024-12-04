# Understanding Read Confidence in OCR

***Based on <https://ironsoftware.com/how-to/tesseract-result-confidence/>***


Read confidence in OCR, or Optical Character Recognition, is a metric that quantifies the certainty or assurance in the accuracy of the text that the OCR process identified within a document or image. This metric serves as an indicator of the likelihood that the recognized text matches the text in the document.

A high read confidence score reflects a strong assurance in the accuracy of the text identified, whereas a low score might imply potential inaccuracies.

## Example: Obtaining Read Confidence

Post-OCR processing, the accuracy of the recognized text can be gauged through the **Confidence** attribute. Use the `using` statement for proper resource management. You can feed the OCR engine with different types of documents, like images and PDFs, using `OcrImageInput` and `OcrPdfInput` classes respectively. The `Read` method produces an `OcrResult` object which provides access to the **Confidence** property.

```cs
using IronOcr;
namespace ironocr.TesseractResultConfidence {
    public class Section1 {
        public void Run() {
            // Create a new IronTesseract instance
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Load the image
            using var imageInput = new OcrImageInput("sample.tiff");
            // Execute OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);

            // Retrieve the confidence score
            double confidence = ocrResult.Confidence;
        }
    }
}
```

## Detailed Confidence Levels Retrieval

OCR results can be detailed to the extent of fetching confidence levels for each document segment—pages, paragraphs, lines, words, and characters. Additionally, the confidence level for a block, which is a grouping of one or more paragraphs, can be obtained as well.

```cs
using IronOcr;
namespace ironocr.TesseractResultConfidence {
    public class Section2 {
        public void Run() {
            // Retrieve page confidence
            double pageConfidence = ocrResult.Pages[0].Confidence;
            
            // Retrieve paragraph confidence
            double paragraphConfidence = ocrResult.Paragraphs[0].Confidence;
            
            // Retrieve line confidence
            double lineConfidence = ocrResult.Lines[0].Confidence;
            
            // Retrieve word confidence
            double wordConfidence = ocrResult.Words[0].Confidence;
            
            // Retrieve character confidence
            double characterConfidence = ocrResult.Characters[0].Confidence;
            
            // Retrieve block confidence
            double blockConfidence = ocrResult.Blocks[0].Confidence;
        }
    }
}
```

## Exploring Character Choices

Another insightful aspect of OCR results is the **Choices** property. This feature offers a list of alternative word suggestions along with their statistical relevance, providing additional interpretations of the scanned text.

```cs
using IronOcr;
namespace ironocr.TesseractResultConfidence {
    public class Section3 {
        public void Run() {
            using static IronOcr.OcrResult;
            
            // Initialize IronTesseract
            IronTesseract ocrTesseract = new IronTesseract();
            
            // Load the image
            using var imageInput = new OcrImageInput("Potter.tiff");
            // Carry out OCR
            OcrResult ocrResult = ocrTesseract.Read(imageInput);
            
            // List possible character choices
            Choice[] choices = ocrResult.Characters[0].Choices;
        }
    }
}
```

### Visual Information

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/tesseract-result-confidence/choices.webp" alt="Choices" class="img-responsive add-shadow">
    </div>
</div>