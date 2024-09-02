# Adjusting Image Orientation for Optimal Text Recognition

Adjusting the orientation of images is crucial in image processing to prepare them for tasks like text recognition. IronOcr excels in correcting image orientation, providing functionalities like rotation, deskewing, and scaling to ensure that images are perfectly aligned for text extraction.

These operations are vital to ensure the text within images is correctly positioned and sized, which enhances the accuracy of text recognition.

## Example of Rotating an Image

To change the orientation of an image, you can rotate it by a certain degree (e.g., 90 degrees) either in a clockwise or counterclockwise direction. This ensures content within the image is properly aligned.

Specify the degree of rotation when calling the `Rotate` method on an `OcrImageInput`. Positive values indicate a clockwise rotation, whereas negative values denote counterclockwise adjustments.

```cs
using IronOcr;

// Create an instance of IronTesseract
IronTesseract ocrEngine = new IronTesseract();

// Load the image
using var inputImage = new OcrImageInput("paragraph_skewed.png");

// Apply a 180-degree clockwise rotation
inputImage.Rotate(180);

// Save the rotated image
inputImage.SaveAsImages("rotate_result");
```

After modifying the image, it can be saved using the `SaveAsImages` method. Here’s how the image looks before and after the rotation:

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-orientation-correction/paragraph_skewed.png" alt="Sample image before rotation" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Before</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-orientation-correction/rotate_0.webp" alt="Rotated image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">After</p>
    </div>
</div>

<hr>

## Deskewing an Image Example

Deskewing corrects images that are slightly tilted or skewed, making sure that all textual or graphic content is aligned horizontally.

To deskew an image, utilize the `Deskew` method which can adjust mishaps up to a certain angle, enhancing alignment:

```cs
// Straighten the skewed image
inputImage.Deskew();
```

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-orientation-correction/paragraph_skewed.png" alt="Sample image before deskewing" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Before</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-orientation-correction/deskew_0.webp" alt="Deskewed image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">After</p>
    </div>
</div>

<hr>

## Scaling an Image Example

Scaling adjusts the size of an image to a precise dimension or ratio, which is particularly useful in standardizing sizes for uniform text recognition.

The `Scale` method adjusts the size of the image based on a percentage input, where 100% means original size. It also allows adjusting associated cropping areas proportionally:

```cs
// Resize the image
inputImage.Scale(70);
```

### Comparison of Image Sizes

<div class="content-img-align-center">
    <div class="center-image-wrapper">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-orientation-correction/size-comparison.webp" alt="Size comparison before scaling" class="img-responsive add-shadow">
    </div>
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-orientation-correction/size-comparison2.webp" alt="Size comparison after scaling" class="img-responsive add-shadow">
    </div>
</div>