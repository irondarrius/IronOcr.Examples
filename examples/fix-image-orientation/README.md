***Based on <https://ironsoftware.com/examples/fix-image-orientation/>***

## Rotate Images

Adjust the orientation of images by rotating them a specific number of degrees in a clockwise direction. To rotate images counter-clockwise, input negative values.

## Correct Image Alignment

Correct any skewness in images to ensure they are vertically and horizontally aligned. This adjustment is crucial for effective OCR processing, as the OCR engine, Tesseract, can only handle deviations of up to 5 degrees.

## Adjust Image Size

Resize the pages within an `OcrInput` in a proportional manner, maintaining the aspect ratio of the images.