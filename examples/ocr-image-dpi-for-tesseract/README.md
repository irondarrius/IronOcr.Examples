***Based on <https://ironsoftware.com/examples/ocr-image-dpi-for-tesseract/>***

The `OcrInput` class efficiently handles low-resolution images when used with `IronTesseract`.

Tesseract typically operates best with a 300 DPI input, but `IronTesseract` is optimized to achieve above 99% accuracy even with 225 DPI scans, effectively doubling the OCR process's speed.

Extremely high DPI settings can reduce processing speed, while very low DPI may compromise accuracy. If unsure, it's best to let `IronTesseract` automatically adjust settings for optimal performance.