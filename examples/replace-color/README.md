***Based on <https://ironsoftware.com/examples/replace-color/>***

OCR performance is enhanced when processing black text on a white background.

For instance, if dealing with blue text on a pink background, it's advantageous to change the blue to black and pink to white prior to performing OCR.

Using `System.Drawing` for this task can be labor-intensive and slow, however, IronOCR automates this process seamlessly.

The method `OcrInput.ReplaceColor` provides us the capability to substitute one color for another within a document.

This function is approximate, allowing users to set a percentage tolerance for RGB exactness.

This eliminates the necessity for employing tools like Photoshop or ImageMagick to prep images for OCR.