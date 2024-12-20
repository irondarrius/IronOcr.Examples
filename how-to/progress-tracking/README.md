# Progress Monitoring with IronOCR

***Based on <https://ironsoftware.com/how-to/progress-tracking/>***


IronOCR includes a helpful feature that allows developers to subscribe to events that monitor the progress of OCR (Optical Character Recognition) tasks. These events provide essential details such as the progress status, timing, and completion insight, which can be invaluable for applications needing real-time updates during OCR operations.

<h3>Introduction to IronOCR</h3>

---

## Example of Progress Monitoring

You can subscribe to the `OcrProgress` event in IronOCR to get continuous updates during the OCR process. This event sends details about the progress, including start and end times, page counts, percentage completed, and the duration. Consider this document for our example: ["Experiences in Biodiversity Research: A Field Course" by Thea B. Gessler, Iowa State University](https://ironsoftware.com/static-assets/ocr/how-to/progress-tracking/Experiences-in-Biodiversity-Research-A-Field-Course.pdf).

```cs
using IronOcr;
using System;

var ocrTesseract = new IronTesseract();

// Hook into the OcrProgress event
ocrTesseract.OcrProgress += (_, ocrProgressArgs) =>
{
    Console.WriteLine("Start time: " + ocrProgressArgs.StartTimeUTC.ToString());
    Console.WriteLine("Total pages: " + ocrProgressArgs.TotalPages);
    Console.WriteLine("Progress(%) | Duration(s)");
    Console.WriteLine("    " + ocrProgressArgs.ProgressPercent + "%     | " + ocrProgressArgs.Duration.TotalSeconds);
    Console.WriteLine("End time: " + ocrProgressArgs.EndTimeUTC.ToString());
    Console.WriteLine("----------------------------------------------");
};

using (var input = new OcrInput())
{
    input.LoadPdf("Experiences-in-Biodiversity-Research-A-Field-Course.pdf");

    // This will trigger progress events throughout the read process
    var result = ocrTesseract.Read(input);
}
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/progress-tracking/progress-output.webp" alt="Progress update illustration" class="img-responsive add-shadow">
    </div>
</div>

### Details Provided by the Event

**ProgressPercent**: Reflects the current progress of the OCR process, shown as a percentage of the total pages processed.

**TotalPages**: The total number of pages that the OCR engine is processing.

**PagesComplete**: The number of pages that have completed OCR processing. This number will increment as each page is processed.

**Duration**: The cumulative duration of the OCR task, displayed in `TimeSpan` format, which updates with each event trigger.

**StartTimeUTC**: The UTC timestamp marking the start of the OCR operation.

**EndTimeUTC**: The UTC timestamp when the OCR task reaches 100% completion. This attribute will be null if the OCR is still in progress and is updated at the end of the process.