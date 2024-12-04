***Based on <https://ironsoftware.com/examples/csharp-tesseract-multithreading-for-speed/>***

Previously, in 2021, `IronTesseract` included a method called `ReadMultithreaded` intended to enhance the efficiency of reading images and PDFs for .NET developers.

As of 2022, this method is obsolete. `IronOCR` has improved its capabilities, ensuring that all image processing and OCR reading tasks are handled in a multithreaded manner automatically. Developers no longer need to rely on specific APIs for multithreading.

`IronTesseract` is designed to optimally utilize available threads across all cores, maintaining smooth operation and responsiveness, especially concerning the main or GUI thread.