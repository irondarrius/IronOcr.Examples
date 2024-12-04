# Enhancing Image Readability for OCR Applications

***Based on <https://ironsoftware.com/how-to/image-color-correction/>***


Enhancing the readability and quality of images is crucial, especially in Optical Character Recognition (OCR) applications. IronOcr provides various techniques such as binarization, grayscale conversion, color inversion, and color replacement to improve the clarity and aesthetic appeal of images. These methods are particularly valuable for ensuring that the text within images is more legible and easier to extract.

## Example of Binarization

Binarization is a technique that converts images to a two-tone color scheme, commonly black and white. This is beneficial for distinguishing text from its background and minimizing visual noise, thereby making the text clearer.

You can achieve binarization using the `Binarize` method. This technique is essential for creating high-contrast images (black text on a white background), which are ideal for OCR processes.

```cs
using IronOcr;
namespace ironocr.ImageColorCorrection
{
    public class BinarizationExample
    {
        public void Execute()
        {
            IronTesseract tesseract = new IronTesseract();
            
            using var inputImage = new OcrImageInput("sample.jpg");
            inputImage.Binarize();
            
            inputImage.ExportAs("binarized-image");
        }
    }
}
```

You can save the processed image using the `ExportAs` method. Here's a visual before and after applying binarization:

<div class="image-comparison">
    <div style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/sample.jpg" alt="Original image" class="responsive-image shadow">
        <p style="color: #181818; font-style: italic;">Before</p>
    </div>
    <div style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-color-correction/binarize_0.png" alt="Binarized image" class="responsive-image shadow">
        <p style="color: #181818; font-style: italic;">After</p>
    </div>
</div>

<hr>

## Grayscale Conversion Example

Transforming images to grayscale involves converting them into shades of gray, which can reduce distractions caused by colors and enhance readability.

Implement the grayscale conversion by using the `ToGrayScale` method, which calculates the average of the RGB values of the original colors.

```cs
using IronOcr;
namespace ironocr.ImageColorCorrection
{
    public class GrayscaleExample
    {
        public void Execute()
        {
            using var inputImage = new OcrImageInput("sample.jpg");
            inputImage.ToGrayScale();
        }
    }
}
```

Below are images showing the effects of the grayscale process:

<div class="image-comparison">
    <div style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/sample.jpg" alt="Original image" class="responsive-image shadow">
        <p style="color: #181818; font-style: italic;">Before</p>
    </div>
    <div style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-color-correction/grayscale_0.webp" alt="Grayscaled image" class="responsive-image shadow">
        <p style="color: #181818; font-style: italic;">After</p>
    </div>
</div>

<hr>

## Inverting Colors Example

Color inversion can be used to switch colors, such as turning white text on a black background to black text on a white background, which might help in improving text visibility.

Use the `Invert` method to invert colors. This method can also accept a boolean to return the image in grayscale form.

```cs
using IronOcr;
namespace ironocr.ImageColorCorrection
{
    public class InversionExample
    {
        public void Execute()
        {
            using var inputImage = new OcrImageInput("sample.jpg");
            inputImage.Invert();
        }
    }
}
```

Here are the images showing the results of using the Invert method:

<div class="image-comparison">
    <div style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-color-correction/invert_0.webp" alt="Inverted image" class="responsive-image shadow">
        <p style="color: #181818; font-style: italic;">Inverted</p>
    </div>
    <div style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-color-correction/invertTrue_0.webp" alt="Inverted and grayscaled image" class="responsive-image shadow">
        <p style="color: #181818; font-style: italic;">Inverted & Grayscaled</p>
    </div>
</div>

<hr>

## Color Replacement Example

Replacing specific colors in an image with others can help in emphasizing or reducing the prominence of certain elements. This method is often used to make text stand out or to adjust color contrasts that are problematic.

To replace a color, use the `ReplaceColor` method, specifying the original and new colors along with a tolerance value to account for variations in similar colors.

```cs
using IronOcr;
namespace ironocr.ImageColorCorrection
{
    public class ColorReplacementExample
    {
        public void Execute()
        {
            IronTesseract tesseract = new IronTesseract();
            
            using var inputImage = new OcrImageInput("sample.jpg");
            var originalColor = IronSoftware.Drawing.Color.FromHtml("#DB645C");
            var newColor = IronSoftware.Drawing.Color.DarkCyan;
            
            inputImage.ReplaceColor(originalColor, newColor, 80);
            
            inputImage.ExportAs("color-replaced");
        }
    }
}
```

Images below illustrate the change before and after color replacement:
<div class="image-comparison">
    <div style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/sample.jpg" alt="Before color replacement" class="responsive-image shadow">
        <p style="color: #181818; fontStyle: italic;">Before</p>
    </div>
    <div style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-color-correction/replaceColor_0.webp" alt="After color replacement" class="responsive-image shadow">
        <p style="color: #181818; fontStyle: italic;">After</p>
    </div>
</div>

<hr>

## Reading Specific Text Color Example

Reading specific text colors can be crucial in OCR applications where only particular text colors are of interest.

The `SelectTextColor` method allows specifying the text color that IronOcr should focus on during the OCR process. Here's how you can set it up:

```cs
using System;
using IronOcr;
namespace ironocr.ImageColorCorrection
{
    public class SpecificTextColorExample
    {
        public void Execute()
        {
            IronTesseract tesseract = new IronTesseract();
            
            using var inputImage = new OcrImageInput("sample.jpg");
            var focusColor = IronSoftware.Drawing.Color.FromHtml("#DB645C");
            
            inputImage.SelectTextColor(focusColor, 60);
            
            var ocrResult = tesseract.Read(inputImage);
            
            Console.WriteLine(ocrResult.Text);
        }
    }
}
```

The OCR result specifically focusing on the chosen text color is shown below:

<div class="image-center">
    <div>
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-color-correction/read-certain-text-color.webp" alt="OCR result" class="responsive-image shadow">
    </div>
</div>