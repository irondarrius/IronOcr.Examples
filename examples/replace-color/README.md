***Based on <https://ironsoftware.com/examples/replace-color/>***

OCR performance is optimized for reading black text against a white backdrop.

For instance, if you encounter blue text on a pink background, it's advantageous to convert the blue text to black and the pink background to white prior to OCR processing.

Using `System.Drawing` for this task can be labor-intensive and inefficient. However, IronOCR simplifies this process significantly.

The method `OcrInput.ReplaceColor` from IronOCR provides a straightforward way to change one color for another within a document.

This method includes a fuzziness setting, allowing you to define a percentage tolerance for the exact RGB color match.

With this functionality, there's no longer a necessity to employ Photoshop or ImageMagick scripts to prep images for OCR operations.