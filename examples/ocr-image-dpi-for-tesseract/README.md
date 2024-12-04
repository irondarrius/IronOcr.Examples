***Based on <https://ironsoftware.com/examples/ocr-image-dpi-for-tesseract/>***

The `OcrInput` class in IronTesseract is designed to efficiently handle images of low resolution.

`IronTesseract` is optimized for high accuracy, exceeding 99% on scans with a resolution of 225 DPI, despite the general requirement of 300 DPI by standard Tesseract. This optimization can result in OCR operations that are twice as fast.

Using a DPI that is too high can slow down the process, whereas a DPI that is too low may lead to inaccuracies. If you're unsure, it's best to let IronTesseract automatically configure the optimal settings for you.