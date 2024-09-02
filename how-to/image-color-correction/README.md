# Enhancing Image Colors for Efficient OCR Processing

Enhancing colors in images incorporates a range of techniques aimed at augmenting legibility and overall image quality. IronOcr supports multiple methods such as binarization, conversion to grayscale, color inversion, and specific color replacements to render text within images more decipherable and visually appealing. This is crucial in Optical Character Recognition (OCR) to accurately extract text from images. Moreover, IronOcr allows for the exclusive reading of text in chosen colors.

## Example of Image Binarization

Binarization modifies the image into a two-tone (black and white) format, which is extremely useful for text-background distinction and noise reduction, rendering the text sharper and easier to read.

The `Binarize` method is used to achieve this high-contrast black text on a white background setup, which is ideal for OCR operations as it enhances the background's distinctness from the text.

```cs
using IronOcr;

// Instantiate IronTesseract OCR engine
IronTesseract ocrEngine = new IronTesseract();

// Load image
using var loadImage = new OcrImageInput("sample.jpg");
// Apply binarization effect
loadImage.Binarize();

// Save the processed image
loadImage.SaveAsImages("binarized-image");
```

You can save the processed image using the `SaveAsImages` method. Here's how the image looks before and after binarization:

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/sample.jpg" alt="Sample image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Before</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-color-correction/binarize_0.png" alt="Binarized image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">After</p>
    </div>
</div>

<hr>

## Grayscale Conversion Example

Transforming an image to grayscale simplifies it to shades of gray, which minimizes distractions caused by colors and enhances readability.

For converting images to grayscale, use the `ToGrayScale` method which computes the average of the RGB color channels to achieve gray tones.

```cs
// Convert image to grayscale
loadImage.ToGrayScale();
```

See the comparative results below:

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/sample.jpg" alt="Original colored image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Before</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-color-correction/grayscale_0.webp" alt="Grayscale image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">After</p>
    </div>
</div>

<hr>

## Inversion of Image Colors Example

Inverting colors enhances contrast notably, which can transform a white text on a black background to a black text on a white background, improving readability.

Use the `Invert` method to reverse the image colors, optionally aiming for a grayscale result by specifying a Boolean.

```cs
// Invert image colors
loadImage.Invert();
```

Below are visuals of the Invert method applied with and without the grayscale conversion:

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-color-correction/invert_0.webp" alt="Inverted image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Inverted</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-color-correction/invertTrue_0.webp" alt="Inverted and grayscaled image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Inverted & Grayscaled</p>
    </div>
</div>

<hr>

## Replacing Specific Image Colors Example

This technique allows altering particular colors within the image, which can help emphasize or suppress certain features, especially useful in improving text visibility or correcting color discrepancies.

Specify the color to change, the new color, and a tolerance level using the `ReplaceColor` method. The tolerance helps manage less sharp images to get the intended outcome.

```cs
using IronOcr;
using IronSoftware.Drawing;

// Initialize IronTesseract OCR engine
IronTesseract ocrEngine = new IronTesseract();

// Load image
using var loadImage = new OcrImageInput("sample.jpg");
Color oldColor = Color.FromHtml("#DB645C");
Color newColor = Color.DarkCyan;

// Change specific color
loadImage.ReplaceColor(oldColor, newColor, 80);

// Save the result
loadImage.SaveAsImages("color-replaced");
```

Here's the before and after of color replacement:

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/sample.jpg" alt="Original image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Before</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-color-correction/replaceColor_0.webp" alt="Color replaced image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">After</p>
    </div>
</div>

<hr>

## Reading Text in Specific Colors Example

This functionality focuses on text in a selected color, enhancing OCR accuracy for specific color-coded text content. Use the `SelectTextColor` method to define the target color and a tolerance value, allowing for minor variations in the color perception.

```cs
using IronOcr;
using IronSoftware.Drawing;
using System;

// Initialize the OCR engine
IronTesseract ocrEngine = new IronTesseract();

// Load image
using var loadImage = new OcrImageInput("sample.jpg");
Color targetedColor = Color.FromHtml("#DB645C");

// Set specific text color for reading
loadImage.SelectTextColor(targetedColor, 60);

// Execute OCR
OcrResult ocrText = ocrEngine.Read(loadImage);

// Display OCR result
Console.WriteLine(ocrText.Text);
```

The resulting extracted text demonstrates the focused OCR on the specified orange-ish color:

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-color-correction/read-certain-text-color.webp" alt="Specific text color OCR result" class="img-responsive add-shadow">
    </div>
</div>