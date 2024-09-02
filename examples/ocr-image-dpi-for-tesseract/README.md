The `OcrInput` class within `IronTesseract` is designed to accommodate low-resolution images effectively.

Typically, Tesseract requires inputs with a resolution of 300 DPI, but `IronTesseract` has been optimized to consistently achieve over 99% accuracy using scans at 225 DPI, which can result in a twofold increase in OCR processing speed.

Using overly high resolutions can diminish speed, while excessively low resolutions may lead to errors. If unsure, it's best to take no action; `IronTesseract` will automatically configure the optimal settings on your behalf.