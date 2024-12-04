using IronSoftware.Drawing;
using IronOcr;
namespace ironocr.HowToReadTextFromAnImageInCsharpNet
{
    public class Section16
    {
        public void Run()
        {
            // We can delve deep into OCR results as an object model of Pages, Barcodes, Paragraphs, Lines, Words and Characters
            // This allows us to explore, export and draw OCR content using other APIs
            
            IronTesseract ocr = new IronTesseract();
            ocr.Configuration.ReadBarCodes = true;
            
            using OcrInput input = new OcrInput();
            var pageindices = new int[] { 1, 2 };
            input.LoadImageFrames(@"img\Potter.tiff", pageindices);
            
            OcrResult result = ocr.Read(input);
            
            foreach (var page in result.Pages)
            {
                // Page object
                int pageNumber = page.PageNumber;
                string pageText = page.Text;
                int pageWordCount = page.WordCount;
            
                // null if we don't set Ocr.Configuration.ReadBarCodes = true;
                OcrResult.Barcode[] barcodes = page.Barcodes;
            
                AnyBitmap pageImage = page.ToBitmap(input);
                System.Drawing.Bitmap pageImageLegacy = page.ToBitmap(input);
                double pageWidth = page.Width;
                double pageHeight = page.Height;
            
                foreach (var paragraph in page.Paragraphs)
                {
                    // Pages -> Paragraphs
                    int paragraphNumber = paragraph.ParagraphNumber;
                    String paragraphText = paragraph.Text;
                    System.Drawing.Bitmap paragraphImage = paragraph.ToBitmap(input);
                    int paragraphXLocation = paragraph.X;
                    int paragraphYLocation = paragraph.Y;
                    int paragraphWidth = paragraph.Width;
                    int paragraphHeight = paragraph.Height;
                    double paragraphOcrAccuracy = paragraph.Confidence;
                    var paragraphTextDirection = paragraph.TextDirection;
            
                    foreach (var line in paragraph.Lines)
                    {
                        // Pages -> Paragraphs -> Lines
                        int lineNumber = line.LineNumber;
                        String lineText = line.Text;
                        AnyBitmap lineImage = line.ToBitmap(input);
                        System.Drawing.Bitmap lineImageLegacy = line.ToBitmap(input);
                        int lineXLocation = line.X;
                        int lineYLocation = line.Y;
                        int lineWidth = line.Width;
                        int lineHeight = line.Height;
                        double lineOcrAccuracy = line.Confidence;
                        double lineSkew = line.BaselineAngle;
                        double lineOffset = line.BaselineOffset;
            
                        foreach (var word in line.Words)
                        {
                            // Pages -> Paragraphs -> Lines -> Words
                            int wordNumber = word.WordNumber;
                            String wordText = word.Text;
                            AnyBitmap wordImage = word.ToBitmap(input);
                            System.Drawing.Image wordImageLegacy = word.ToBitmap(input);
                            int wordXLocation = word.X;
                            int wordYLocation = word.Y;
                            int wordWidth = word.Width;
                            int wordHeight = word.Height;
                            double wordOcrAccuracy = word.Confidence;
            
                            if (word.Font != null)
                            {
                                // Word.Font is only set when using Tesseract Engine Modes rather than LTSM
                                String fontName = word.Font.FontName;
                                double fontSize = word.Font.FontSize;
                                bool isBold = word.Font.IsBold;
                                bool isFixedWidth = word.Font.IsFixedWidth;
                                bool isItalic = word.Font.IsItalic;
                                bool isSerif = word.Font.IsSerif;
                                bool isUnderlined = word.Font.IsUnderlined;
                                bool fontIsCaligraphic = word.Font.IsCaligraphic;
                            }
            
                            foreach (var character in word.Characters)
                            {
                                // Pages -> Paragraphs -> Lines -> Words -> Characters
                                int characterNumber = character.CharacterNumber;
                                String characterText = character.Text;
                                AnyBitmap characterImage = character.ToBitmap(input);
                                System.Drawing.Bitmap characterImageLegacy = character.ToBitmap(input);
                                int characterXLocation = character.X;
                                int characterYLocation = character.Y;
                                int characterWidth = character.Width;
                                int characterHeight = character.Height;
                                double characterOcrAccuracy = character.Confidence;
            
                                // Output alternative symbols choices and their probability.
                                // Very useful for spell checking
                                OcrResult.Choice[] characterChoices = character.Choices;
                            }
                        }
                    }
                }
            }
        }
    }
}