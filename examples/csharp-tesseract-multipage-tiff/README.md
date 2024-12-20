***Based on <https://ironsoftware.com/examples/csharp-tesseract-multipage-tiff/>***

The `OcrInput` seamlessly handles TIFF files, even those that are incompatible with standard Tesseract implementations.

Every single frame from your TIFF files will be processed to generate an extensive, multi-page `IronOcr.OcrResult` document.