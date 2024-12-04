# How to Correct Image Orientation for Text Recognition

***Based on <https://ironsoftware.com/how-to/image-orientation-correction/>***


Correcting the orientation of images for text recognition involves adjusting their alignment to facilitate better extraction of text. The IronOcr library provides robust tools to handle image orientation by offering techniques such as rotation, deskewing, and scaling, which significantly enhance the accuracy of text extraction by ensuring the images are correctly oriented and appropriately scaled.

## Example of Image Rotation

Changing the orientation of an image to make the content upright is achieved by rotating the image by a specific degree. This adjustment ensures the text within the image is vertically aligned.

Assign a degree to the `Rotate` method to rotate the image. Positive values rotate the image clockwise and negative values counterclockwise.

```cs
using IronOcr;
namespace ironocr.ImageOrientationCorrection
{
    public class Section1
    {
        public void Execute()
        {
            IronTesseract ocrTesseract = new IronTesseract();
            
            using var inputImage = new OcrImageInput("paragraph_skewed.png");
            
            // Rotating the image by 180 degrees
            inputImage.Rotate(180);
            
            // Saving the modified image
            inputImage.SaveAsImages("rotated");
        }
    }
}
```

You can save the modified version of the image using the `SaveAsImages` method. Here is a visual comparison of the image before and after the rotation:

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

## Example of Deskewing an Image

Deskewing corrects any tilt or skew in the images by realigning them so that the text appears horizontally straight.

Utilize the `Deskew` method to straighten the image. This method corrects misalignments to a specified maximum angle, enhancing text alignment but possibly increasing processing time and error risk.

```cs
using IronOcr;
namespace ironocr.ImageOrientationCorrection
{
    public class Section2
    {
        public void Execute()
        {
            imageInput.Deskew();
        }
    }
}
```

Here is how the image looks before and after the deskewing process:

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-orientation-correction/paragraph_skewed.png" alt="Sample image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Before</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-orientation-correction/deskew_0.webp"  alt="Deskewed image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">After</p>
    </div>
</div>

<hr>

## Example of Scaling an Image

Scaling adjusts the size of an image, which is useful for standardizing dimensions for reliable text recognition.

To resize an image, use the `Scale` method. This function requires a percentage value; at 100%, the original size is maintained. The **ScaleCropArea** parameter should typically be set to `true` to keep crop areas proportionally scaled.

```cs
using IronOcr;
namespace ironocr.ImageOrientationCorrection
{
    public class Section3
    {
        public void Execute()
        {
            imageInput.Scale(70, true);
        }
    }
}
```

### Image Size Comparison

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-orientation-correction/size-comparison.webp" alt="Size comparison" class="img-responsive add-shadow">
    </div>
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-orientation-correction/size-comparison2.webp" alt="Size comparison" class="img-responsive add-shadow">
    </div>
</div>