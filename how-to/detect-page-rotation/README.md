# Identifying Page Orientation

***Based on <https://ironsoftware.com/how-to/detect-page-rotation/>***


Recognizing the specific rotation applied to a document page is essential in understanding if it has been rotated clockwise or counterclockwise by 0, 90, 180, or 270 degrees. Accurate determination of page orientation is crucial for properly rendering or processing documents, ensuring the pages are positioned correctly for display or printing purposes.

IronOCR enhances the capabilities of page rotation detection. After determining the rotation, the information can be utilized with the `Rotate` method to properly align the page to its intended orientation.

## Example: Detecting Page Rotation

Once the document has opened, the `DetectPageOrientation` method can be employed to ascertain the rotation degree of each page. This methodology is adept for rotations including 0, 90, 180, and 270 degrees. For addressing document skewness, the `Deskew` method can be applied to correct the image alignment. After this correction, the image should be rotated back to its rightful orientation according to the rotation degree identified. We will demonstrate using a [sample PDF](https://ironsoftware.com/static-assets/ocr/how-to/detect-page-rotation/Clockwise90.pdf).

This technique ensures high efficiency with text-heavy documents.

```cs
using System;
using IronOcr;
namespace ironocr.DetectPageRotation
{
    public class OrientationDetectionExample
    {
        public void Execute()
        {
            using var document = new OcrInput();
            
            // Loading the PDF Document
            document.LoadPdf("Clockwise90.pdf");
            
            // Determining the page orientation
            var orientationResults = document.DetectPageOrientation();
            
            // Displaying the results
            foreach(var orientation in orientationResults)
            {
                Console.WriteLine(orientation.PageNumber);
                Console.WriteLine(orientation.HighConfidence);
                Console.WriteLine(orientation.RotationAngle);
            }
        }
    }
}
```

### Interpretation of Results

- **PageNumber**: Shows the position of the page within the document, starting from zero.
- **RotationAngle**: Indicates the degree of correction needed. This angle is the orientation value used with the `Rotate` method, such as `document.Rotate(RotationAngle)` to correct the orientation. For instance, an image rotated clockwise by 90 degrees will have an angle return of 270 degrees.
- **HighConfidence**: Reflects the confidence level associated with the detected orientation, ensuring reliability in the orientation result.