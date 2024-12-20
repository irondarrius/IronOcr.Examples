# Enhancing Image Colors for Optimal Reading

***Based on <https://ironsoftware.com/how-to/image-color-correction/>***


Enhancing the colors of an image involves various techniques aimed at improving the readability and overall appearance of the image. IronOcr provides a suite of methods like binarization, grayscale, inversion, and color replacement to adjust the visual elements of an image for better clarity and aesthetics. This is particularly useful in OCR (Optical Character Recognition) applications, where extracting text from images is essential. Additionally, it's possible to isolate and read text based on specific color selections.

### Getting Started with IronOCR

---

## Example of Binarizing Images

The binarization process transforms the image to a two-tone, usually black and white, which is ideal for enhancing text visibility against backgrounds and minimizing visual noise.

You can binarize an image using the `Binarize` method. Since OCR technology operates most effectively with clear contrast, such as black text on a white backdrop, this adjustment is crucial for distinct text visibility.

```cs
using IronOcr;

// Create a new instance of IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Initialize a new OCR image input
using var imageInput = new OcrImageInput("sample.jpg");
// Apply binarization
imageInput.Binarize();

// Save the altered image
imageInput.SaveAsImages("binarize.jpg");
```

You can easily save the altered image using the `SaveAsImages` method. Here's a look at how the image appears before and after binarization:

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

---

## Grayscale Image Conversion Example

Transforming an image into grayscale simplifies the image by reducing it to shades of gray, which can be less distracting and easier on the eyes, especially when colors in the original image are too loud.

Implement the grayscale effect with the `ToGrayScale` method. The process essentially averages the red, green, and blue values of each pixel.

```cs
// Change image to grayscale
imageInput.ToGrayScale();
```

Here are comparative visuals before and after applying grayscale:

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/sample.jpg" alt="Sample image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Before</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-color-correction/grayscale_0.webp" alt="Grayscaled image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">After</p>
    </div>
</div>

---

## Inverting Image Colors Example

Inverting image colors can significantly enhance the contrast between text and its background. Converting light text on dark backgrounds to dark text on light backgrounds, for example, can enhance legibility.

Use the `Invert` method to toggle the colors of an image. Optionally, pass a boolean to convert the image to grayscale post-inversion.

```cs
// Apply color inversion
imageInput.Invert();
```

Here are the images showing the result of applying the Invert method, with and without converting to grayscale:

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

---

## Replacing Specific Colors in Images Example

Altering specific colors within an image can make elements either stand out or recede, which is useful for emphasizing text or correcting poor color choices.

To change a color, use the `ReplaceColor` method, specifying the current and new colors and a tolerance level, which helps in images with blurriness.

```cs
using IronOcr;

// Create a new IronTesseract instance
IronTesseract ocrTesseract = new IronTesseract();

// Load the image
using var imageInput = new OcrImageInput("sample.jpg");
IronSoftware.Drawing.Color currentColor = new IronSoftware.Drawing.Color("#DB645C");
IronSoftware.Drawing.Color newColor = IronSoftware.Drawing.Color.DarkCyan;

// Execute color replacement
imageInput.ReplaceColor(currentColor, newColor, 80);

// Save the newly adjusted image
imageInput.SaveAsImages("replaceColor.jpg");
```

Below are the results showing the image before and after the color replacement:

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="w