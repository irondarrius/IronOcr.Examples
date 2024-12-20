using System;
using IronOcr;
namespace IronOcr.Examples.Tutorial.CSharpTesseractOcr
{
    public static class Section4
    {
        public static void Run()
        {
            var ocr = new IronTesseract();
            
            // Configure for speed.  35% faster and only 0.2% loss of accuracy
            ocr.Configuration.BlackListCharacters = "~`$#^*_}{][|\\@¢©«»°±·×‑–—‘’“”•…′″€™←↑→↓↔⇄⇒∅∼≅≈≠≤≥≪≫⌁⌘○◔◑◕●☐☑☒☕☮☯☺♡⚓✓✰";
            ocr.Configuration.PageSegmentationMode = TesseractPageSegmentationMode.Auto;
            ocr.Configuration.ReadBarCodes = false;
            ocr.Language = OcrLanguage.EnglishFast;
            
            using var input = new OcrInput();
            var pageindices = new int[] { 1, 2 };
            input.LoadImageFrames(@"img\Potter.tiff", pageindices);
            var result = ocr.Read(input);
            Console.WriteLine(result.Text);
        }
    }
}