# Enhancing Image Quality with Filters for Improved Text Recognition

Digital image filters are essential tools in image processing, particularly useful for augmenting the readability and quality of images in text recognition tasks. IronOcr offers several filters such as sharpen, enhance resolution, denoise, dilate, and erode, specifically designed to preprocess images for more effective OCR.

These filters are crucial for improving the clarity and visibility of text while minimizing any unwanted noise or disturbances that might impede the OCR process.

## Example of Using the Sharpen Filter

The sharpen filter is useful for enhancing the contrast at the edges within an image, which clarifies the text and details, aiding in the accuracy of character recognition by OCR technologies.

You can apply the sharpen filter by using the `Sharpen` method on an `OcrImageInput` object.

```cs
using IronOcr;

// Create an instance of IronTesseract
IronTesseract ocr = new IronTesseract();

// Load the image
using var image = new OcrImageInput("sample.jpg");

// Apply the sharpen filter
image.Sharpen();

// Save the enhanced image
image.SaveAsImages("sharpen");
```

This saves the improved image. Here's a visual before and after applying the sharpen filter:

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/sample.jpg" alt="Sample image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Before</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/sharpen_0.webp" alt="Sharpen filter applied" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">After</p>
    </div>
</div>

<hr>

## Application of the Enhance Resolution Filter

This filter boosts the pixel density in an image, significantly enhancing sharpness and text legibility in low-resolution images.

Invoke the `EnhanceResolution` method to raise the image's resolution.

```cs
// Enhance the resolution of the image
image.EnhanceResolution();
```

Below are images showing the improvement:

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/sample.jpg" alt="Sample image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Before</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/enhanceResolution_0.webp" alt="Enhance resolution filter applied" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">After</p>
    </div>
</div>

<hr>

## Denoise Filter Example

The Denoise filter aims to remove noise and artifacts, which is particularly useful for isolating text from background disturbances, resulting in clearer OCR results.

To apply it, use the `DeNoise` method.

```cs
// Reduce noise in the image
image.DeNoise();
```

Visual comparison of the effect:

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/sample.jpg" alt="Sample image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Before</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/denoise_0.webp" alt="Denoise filter applied" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">After</p>
    </div>
</div>

<hr>

## Applying the Dilate Filter

Dilating an image expands the brighter areas, enhancing and thickening text, which simplifies OCR interpretation.

Activate this effect with the `Dilate` method.

```cs
// Expand bright regions in the image
image.Dilate();
```

Here is a demonstration of its impact:

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/sample.jpg" alt="Sample image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Before</p...
    </div>
    <div class="competitors__card" style="width: 50%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/dilate_0.webp" alt="Dilate filter applied" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">After</p>
    </div>
</div>

<hr>

## Erode Filter Application

The erosion filter minimizes the size of bright spots in an image, which can refine and clear up characters or lines that are overly bold or slightly blurred.

Implement this by using the `Erode` method.

```cs
// Reduce bright regions in the image
image.Erode();
```

Visualization of results before and after:

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/sample.jpg" alt="Sample image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Before</p...
    </div>
    <div class="competitors__card" style="width: 50%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/erode_0.webp" alt="Erode filter applied" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">After</p>
    </div>
</div>