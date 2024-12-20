***Based on <https://ironsoftware.com/examples/csharp-tesseract-multithreading-for-speed/>***

`IronTesseract` underwent considerable improvements in 2021, including the `ReadMultithreaded` method which enabled .NET developers to process images and PDFs with greater efficiency.

As of 2022, this specific method is no longer necessary. `IronOCR`, the underlying library for `IronTesseract`, now inherently supports multithreading across all its image processing and OCR tasks. This enhancement eliminates the requirement for developers to invoke special APIs for multithreading.

`IronTesseract` is now smartly designed to automatically utilize all available threads across all processor cores while maintaining smooth operation and responsiveness of the main or GUI thread.