# Enhancing Image Quality for Improved OCR Accuracy with IronOcr Filters

***Based on <https://ironsoftware.com/how-to/image-quality-correction/>***


Image correction filters are sophisticated techniques within digital image processing aimed at enhancing the features and overall quality of images, particularly to boost text recognition and extraction capabilities. IronOcr includes a suite of useful filters such as sharpen, enhance resolution, denoise, dilate, and erode, which are essential for pre-processing images in preparation for Optical Character Recognition (OCR).

These filters are instrumental in refining the image to ensure highly accurate text extraction by sharpening text visibility and minimizing unwanted noise or visual artifacts.

## Example of Using the Sharpen Filter

The sharpen filter works by increasing contrast at the edges within an image, thus enhancing the definition and making text more distinguishable. This helps OCR algorithms to better identify individual characters.

Here’s how to apply the `Sharpen` filter using the `OcrImageInput` object in IronOcr:

```cs
using IronOcr;
namespace ironocr.ImageQualityCorrection
{
    public class SharpenSection
    {
        public void Execute()
        {
            // Create an IronTesseract instance
            IronTesseract ocr = new IronTesseract();

            // Load the image
            using var inputImage = new OcrImageInput("sample.jpg");
            // Apply the sharpen filter
            inputImage.Sharpen();
            
            // Save the optimized image
            inputImage.SaveAsImages("sharpened_output");
        }
    }
}
```

You can save the optimized image using the `SaveAsImages` method. Here is a visual comparison of the image before and after the sharpen filter is applied.

<div class="image-comparison">
    <div class="image-box" style="width: 48%;">
        ![Before Sharpen](https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/sample.jpg "Original Image")
        <p>Before</p>
    </div>
    <div class="image-box" style="width: 48%;">
        ![After Sharpen](https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/sharpen_0.webp "Sharpened Image")
        <p>After</p>
    </div>
</div>

---

## Example of Enhancing Image Resolution

The enhance resolution filter increases the pixel density of an image, which sharpens and clarifies the image details, and is particularly advantageous for text in low-resolution images.

To enhance the resolution of an image, the `EnhanceResolution` method can be applied:

```cs
using IronOcr;
namespace ironocr.ImageQualityCorrection
{
    public class ResolutionEnhancement
    {
        public void Execute()
        {
            // Enhance image resolution
            imageInput.EnhanceResolution();
        }
    }
}
```

Here's how the image appears before and after resolution enhancement:

<div class="image-comparison">
    <div class="image-box" style="width: 48%;">
        ![Before Resolution Enhancement](https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/sample.jpg "Original Image")
        <p>Before</p>
    </div>
    <div class="image-box" style="width: 48%;">
        ![After Resolution Enhancement](https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/enhanceResolution_0.webp "Enhanced Resolution Image")
        <p>After</p>
    </div>
</div>

---

## Example of Applying the Denoise Filter

The denoise filter is crucial for reducing the noise level within images, aiding in the isolation of text from its background, which in turn facilitates cleaner, more precise character recognition.

Here is how to use the `DeNoise` method:

```cs
using IronOcr;
namespace ironocr.ImageQualityCorrection
{
    public class NoiseReduction
    {
        public void Execute()
        {
            // Use denoise filter
            imageInput.DeNoise();
        }
    }
}
```

Visual comparison of the image before and after noise reduction:

<div class="image-comparison">
    <div class="image-box" style="width: 48%;">
        ![Before Denoise](https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/sample.jpg "Original Image")
        <p>Before</p>
    </div>
    <div class="image-box" style="width: 48%;">
        ![After Denoise](https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/denoise_0.webp "Denoised Image")
        <p>After</p>
    </div>
</div>

---

Each of these filters—sharpen, enhance resolution, denoise, dilate, and erode—offer significant benefits to the quality and clarity of images, thus contributing to the efficiency and accuracy of OCR processes using IronOcr.