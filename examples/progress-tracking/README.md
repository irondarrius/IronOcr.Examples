***Based on <https://ironsoftware.com/examples/progress-tracking/>***

The `IronTesseract` class contains an `OcrProgress` event that is useful for monitoring the progress of OCR operations. Each time a page completes its OCR processing, an `OcrProgresEventsArgs` object is dispatched to this event.

This functionality serves as an essential tool in various applications such as GUIs, web applications, and command-line interfaces, providing updates to users on the expected time remaining.