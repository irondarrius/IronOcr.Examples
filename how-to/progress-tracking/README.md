# Tracking Progress with IronOCR

***Based on <https://ironsoftware.com/how-to/progress-tracking/>***


IronOCR includes a specific event, `OcrProgress`, giving developers the ability to monitor the Optical Character Recognition process. This feature provides valuable insights, including the progress, duration, and status of the operation, which allows applications to manage and relay the progress of OCR tasks effectively.

## Example of Implementing Progress Tracking

By subscribing to the `OcrProgress` event, developers can receive real-time updates during the OCR process. This event dispatches details such as the operation's start time, total pages, progress percentage, duration, and completion time. For illustration, consider the following example document: "[Experiences in Biodiversity Research: A Field Course](https://ironsoftware.com/static-assets/ocr/how-to/progress-tracking/Experiences-in-Biodiversity-Research-A-Field-Course.pdf)" by Thea B. Gessler from Iowa State University.

```cs
using System;
using IronOcr;
namespace ironocr.ProgressTracking
{
    public class Section1
    {
        public void Run()
        {
            var ocrEngine = new IronTesseract();
            
            // Attaching to the OcrProgress event
            ocrEngine.OcrProgress += (_, eventArgs) =>
            {
                Console.WriteLine("Start time (UTC): " + eventArgs.StartTimeUTC);
                Console.WriteLine("Total pages: " + eventArgs.TotalPages);
                Console.WriteLine("Current Progress(%) | Duration in Seconds");
                Console.WriteLine("    " + eventArgs.ProgressPercent + "%     | " + eventArgs.Duration.TotalSeconds + "s");
                Console.WriteLine("End time (UTC): " + eventArgs.EndTimeUTC);
                Console.WriteLine("----------------------------------------------");
            };
            
            using var document = new OcrInput("Experiences-in-Biodiversity-Research-A-Field-Course.pdf");
            
            // The event is triggered during the OCR operation
            var ocrResult = ocrEngine.Read(document);
        }
    }
}
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/progress-tracking/progress-output.webp" alt="Progress update snapshot" class="img-responsive add-shadow">
    </div>
</div>

### Detailed Information on Event Properties

- **ProgressPercent**: Displays the completion level of the OCR task as a percentage. This number varies from 0 to 100.
- **TotalPages**: The total count of pages being processed.
- **PagesComplete**: Number of pages for which the OCR has been completed fully. This count may rise incrementally as more pages undergo processing.
- **Duration**: Indicates the overall time elapsed for the OCR operation, formatted as a TimeSpan. This metric updates every time the event is triggered.
- **StartTimeUTC**: The Coordinated Universal Time marking the commencement of the OCR process.
- **EndTimeUTC**: Coordinated Universal Time marking when the OCR process reaches completion. This value is null until the OCR finishes.