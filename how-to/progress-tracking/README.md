# Progress Monitoring with IronOCR

IronOCR offers a dedicated event to track the progression of OCR (Optical Character Recognition) tasks. This functionality provides essential data about the OCR operation's progress, timelines, and completion status, allowing software applications to efficiently supervise and manage the OCR process.

## Example of Progress Monitoring

By subscribing to the `OcrProgress` event, one can obtain updates about the OCR operation's ongoing status. This event delivers an object with details such as the start time, number of pages, progress percentage, duration, and completion time. We will use the following document for our example, titled [Experiences in Biodiversity Research: A Field Course](https://ironsoftware.com/static-assets/ocr/how-to/progress-tracking/Experiences-in-Biodiversity-Research-A-Field-Course.pdf) by Thea B. Gessler from Iowa State University.

```cs
using IronOcr;
using System;

var ocr = new IronTesseract();

// Hook into the OcrProgress event
ocr.OcrProgress += (_, progressArgs) =>
{
    Console.WriteLine("Start Time: " + progressArgs.StartTimeUTC.ToString());
    Console.WriteLine("Number of pages: " + progressArgs.TotalPages);
    Console.WriteLine("Current Progress(%) | Elapsed Time (s)");
    Console.WriteLine("        " + progressArgs.ProgressPercent + "%          | " + progressArgs.Duration.TotalSeconds + " s");
    Console.WriteLine("End Time: " + progressArgs.EndTimeUTC.ToString());
    Console.WriteLine("--------------------------------------------------");
};

using var document = new OcrInput();
document.LoadPdf("Experiences-in-Biodiversity-Research-A-Field-Course.pdf");

// Trigger progress events as the OCR reads through the document
var ocrResult = ocr.Read(document);
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/progress-tracking/progress-output.webp" alt="Progress update" class="img-responsive add-shadow">
    </div>
</div>

### Detailed Information Provided by the Event

**ProgressPercent**: Tracks the OCR task's completion level as a percentage of the total number of pages scanned. It starts from 0 and can go up to 100.

**TotalPages**: The total count of pages that the OCR engine plans to process.

**PagesComplete**: Indicates the count of pages that have been completely processed. This number will increment progressively as the OCR operation advances.

**Duration**: This TimeSpan value notes the total time expended on the OCR job to date. This field updates after each event occurrence.

**StartTimeUTC**: Indicates the Coordinated Universal Time (UTC) at which the OCR process began.

**EndTimeUTC**: This shows the Coordinated Universal Time (UTC) at which the OCR process was completed. This attribute remains unset during the OCR session and is filled once the OCR is fully done.