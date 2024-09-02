`IronTesseract`, up until 2021, featured a method called `ReadMultithreaded` that enabled .NET developers to more efficiently process images and PDFs.

As of 2022, this method has become redundant. The entire image processing and OCR reading functionalities in IronOCR have been upgraded to operate in a multithreaded manner by default. This enhancement eliminates the need for developers to rely on a specific API for multithreading.

Now, `IronTesseract` seamlessly utilizes all available threads across all processor cores while maintaining smooth operations on the main or GUI thread.