# Correcting Image Orientation for Text Recognition

***Based on <https://ironsoftware.com/how-to/image-orientation-correction/>***


Adjusting the orientation of images is crucial in image processing, especially for purposes such as optical character recognition (OCR). The IronOcr library facilitates these adjustments, which include rotating, deskewing, and resizing images to improve the accuracy of text extraction.

These procedures are critical for rendering images suitable for precise text recognition by ensuring that the text is appropriately aligned, oriented, and scaled.

### Getting Started with IronOCR

---

## Example: Rotating an Image

To change the orientation of an image, you may need to rotate it to a specific angle, such as 90 degrees clockwise or counterclockwise, to make sure the text is upright and properly aligned.

You can rotate an image by passing a degree value to the `Rotate` method. Use a positive value for clockwise rotation or a negative value for counterclockwise adjustments.

```cs
using IronOcr;

// Creating an instance of IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Loading an image
using var imageInput = new OcrImageInput("paragraph_skewed.png");

// Rotating the image 180 degrees clockwise
imageInput.Rotate(180);

// Saving the modified image
imageInput.SaveAsImages("rotate");
```

The `SaveAsImages` method allows you to easily export the rotated image. See below for a visual before and after the rotation process.

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-orientation-correction/paragraph_skewed.png" alt="Sample image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Before</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-orientation-correction/rotate_0.webp" alt="Rotated image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">After</p>
    </div>
</div>

<hr>

## Example: Deskewing an Image

Deskewing adjusts images that are slightly tilted or skewed. This rectification ensures that the text appears horizontally aligned.

To deskew an image, employ the `Deskew` method, which requires an integer value representing the maximum skew angle to adjust. High values offer greater correction but might slow down processing and increase error risks, like rendering pages upside down.

```cs
// Executing the deskew function
imageInput.Deskew();
```

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-orientation-correction/paragraph_skewed.png" alt="Sample image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Before</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-orientation-correction/deskew_0.webp" alt="Deskewed image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">After</p>
    </div>
</div>

<hr>

## Example: Scaling an Image

Resizing an image to specific dimensions or aspect ratios helps standardize image sizes for uniform text recognition.

To scale an image, utilize the `Scale` method, which accepts a percentage value for resizing. A parameter of 100% retains the original size. Set the second parameter, **ScaleCropArea**, to 'true' to proportionally adjust associated crop areas.

```cs
// Applying scaling to an image
imageInput.Scale(70);
```

### Visual Size Comparison

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-orientation-correction/size-comparison.webp" alt="Size comparison" class="img-responsive add-shadow">
    </div>
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-orientation-correction/size-comparison2.webp" alt="Size comparison" class="img-responsive add-shadow">
    </div>
</div>