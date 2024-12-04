***Based on <https://ironsoftware.com/examples/select-text-by-color/>***

Optical Character Recognition (OCR) is most effective and precise when deciphering text that is a single color against a uniform background.

The feature `SelectTextColor` transforms the image into a binary format, rendering all pixels of the chosen text color as black (factoring in variations in shade), and conversely turning all other colors to white.

Take, for instance, the scenario where it's necessary to isolate text of one or several specified colors set against a backdrop of varying hues. Using `SelectTextColor` and `SelectTextColors`, text in the selected colors will be converted to black, while text and backgrounds in non-selected colors will turn white. This transformation is not strict; rather, it enables a degree of leeway in matching the exact RGB values. This capacity obviates the need for pre-processing images with tools like Photoshop or ImageMagick for OCR tasks.

The class `IronSoftare.Drawing.Color` adopts HTML color coding.

For additional information and reference, please visit: [Color Hex](https://www.ironsoftware.com/www.color-hex.com)