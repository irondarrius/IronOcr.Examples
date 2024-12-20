# Using Image Filters to Enhance OCR Accuracy

***Based on <https://ironsoftware.com/how-to/image-quality-correction/>***


Image filters are essential tools in digital image processing that enhance the quality and properties of an image to improve text recognition and extraction. In IronOcr, you have access to several useful filters such as sharpen, enhance resolution, denoise, dilate, and erode, which are crucial for preparing images for OCR by enhancing text clarity and minimizing noise and other disruptions.

### Getting Started with IronOCR

---

## Example of Using the Sharpen Filter

The sharpen filter boosts edge contrast, making text more defined and legible, which aids in the OCR process. To apply this filter, just use the `Sharpen` method on the `OcrImageInput` object.

```cs
using IronOcr;

// Create a new instance of IronTesseract
IronTesseract ocr = new IronTesseract();

// Load in the image
using var imageInput = new OcrImageInput("sample.jpg");
// Enhance the image sharpness
imageInput.Sharpen();

// Save the sharpened image 
imageInput.SaveAsImages("sharpened");
```

You can use the `SaveAsImages` method to save the enhanced image. See the difference in the images below before and after applying the sharpen filter.

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

## Enhance Resolution Filter Example

This filter improves the pixel density, enhancing overall sharpness and text readability, especially in lower resolution images. To apply the enhance resolution filter, use the `EnhanceResolution` method. The default DPI is 225.

```cs
// Enhance the image resolution
imageInput.EnhanceResolution();
```

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

Reducing image noise is essential, as it helps eliminate background interference, enhancing the OCR's capability to discern text. Activate the `DeNoise` method to apply this filter. If you want a stronger denoising effect, pass 'true' for a 3x3 morphology.

```cs
// Reduce image noise
imageInput.DeNoise();
```

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

## Dilate Filter Example

The dilation filter expands the bright areas which enhances and thickens text, aiding its legibility during OCR. Invoke the `Dilate` method to apply this filter. Passing 'true' will switch to a stronger 3x3 morphology.

```cs
// Expand bright image areas
imageInput.Dilate();
```

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/sample.jpg" alt="Sample image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Before</p>
    </div>
    <div class="competitors__card" style="width: 50%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/dilate_0.webp" alt="Dilate filter applied" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">After</p>
    </div>
</div>

<hr>

## Erode Filter Example

Contrarily, erosion minimizes bright regions, refining text and line appearances, useful for correcting thick or blurred characters. Use the `Erode` method to erode the image. A 3x3 morphology is applied when 'true' is passed.

```cs
// Minimize bright areas
imageInput.Erode();
```

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/sample.jpg" alt="Sample image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Before</p>
    </div>
    <div class="competitors__card" style="width: 50%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/erode_0.webp" alt="Erode filter applied" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">After</p>
    </div>
</div