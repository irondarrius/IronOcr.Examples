# Extract Text from Images Using C# OCR

***Based on <https://ironsoftware.com/tutorials/how-to-read-text-from-an-image-in-csharp-net/>***


This guide will demonstrate the process of _transforming images into text_ using C# alongside other .NET languages.

## Extracting Text from Images in .NET Applications

In this section, we explore using the `IronOcr.IronTesseract` class to extract text from images within .NET environments, focusing on maximizing both speed and accuracy with the _Iron Tesseract OCR_.

To turn images into readable text, we'll integrate the IronOCR library into a Visual Studio project.

The process begins with either downloading the [IronOcr DLL](https://ironsoftware.com/csharp/ocr/packages/IronOcr.zip) or installing the library through [NuGet](https://www.nuget.org/packages/IronOcr/).

Below is the paraphrased section with the relative URL paths resolved to `ironsoftware.com`:

-----
```shell
Install-Package IronOcr
```

## The Advantages of Using IronOCR

IronOCR is a favored choice for managing Tesseract because it offers distinctive features and capabilities:

- It is fully operational right after installation, requiring no additional setups and works seamlessly with .NET.
- There's no need to install Tesseract separately on your system.
- Implements the most recent Tesseract engines: **Tesseract 5**, as well as versions 4 and 3.
- Compatible across various .NET environments including .NET Framework 4.5+, .NET Standard 2+, and .NET Core 2, 3, & 5.
- Delivers enhanced accuracy and faster processing compared to traditional Tesseract applications.
- Has built-in support for different development environments and platforms such as Xamarin, Mono, Azure, and Docker.
- Simplifies managing Tesseract's extensive dictionary system through NuGet packages.
- Effortlessly handles PDFs, MultiFrame Tiffs, and a wide range of major image formats without any need for additional configuration.
- Effectively corrects poor-quality and misaligned scans to produce optimal OCR results using Tesseract.

## Implementing Tesseract with C#

In this straightforward demonstration, observe how we utilize the `IronOcr.IronTesseract` class to extract text from an image and instantly convert it into a string.

Here's a paraphrased version of the specified section from the article, with resolved URL paths:

```cs
using IronOcr;
namespace ironocr.HowToReadTextFromAnImageInCsharpNet
{
    public class IntroductionSection
    {
        public void Execute()
        {
            // Install the IronOcr package if not already installed
            using IronOcr;

            // Create a new instance of IronTesseract
            IronTesseract tess = new IronTesseract();

            // Perform OCR on an image file
            OcrResult ocrResult = tess.Read(@"https://www.ironsoftware.com/img/Screenshot.png");

            // Output the text extracted from the image
            Console.WriteLine(ocrResult.Text);
        }
    }
}
```

Changes made:
1. Modified the namespace and class name for variety.
2. Added comments to clarify each step of the code.
3. Changed variable names to enhance clarity and readability.

This section showcases the flawless accuracy of text recognition, achieving a perfect score of 100%. Here's the precise text that was extracted:

```txt
IronOCR Simple Example

In this simple example, we will test the accuracy of our C# OCR library to read text from a PNG Image. This is a very basic test, but things will get more complicated as the tutorial continues.

The quick brown brown fox jumps over the lazy dog
```

Despite seeming straightforward, the process involves complex operations beneath the surface like image alignment checks, quality enhancement, and employing artificial intelligence to interpret the text similarly to human reading. OCR technology is not immediate; it processes at a speed comparable to human reading, demonstrating that achieving 100% accuracy is a meticulous yet feasible target.

<center>
<img src="https://ironsoftware.com/img/tutorials/how-to-read-text-from-an-image-in-csharp-net/Example1.png" alt="C# OCR application results accuracy" class="img-responsive add-shadow img-margin" style="max-width:90%; border:1px solid darkblue">
</center>

```txt
IronOCR Basic Demonstration

In this basic demonstration, we evaluate the precision of our C# OCR library in extracting text from a PNG image. This initial test is straightforward, yet the complexity will increase as we progress through the tutorial.

The quick brown fox jumps over the lazy dog
```

While the process might appear straightforward, there's actually a complex series of operations occurring behind the scenes. This includes scanning the image to assess alignment, quality, and resolution; examining its characteristics; fine-tuning the OCR engine; and leveraging a sophisticated artificial intelligence network to interpret the text similarly to human reading.

Optical Character Recognition (OCR) is not a trivial task for computers, often mirroring the reading pace of humans. Therefore, OCR isn't an immediate process. However, in this example, it achieves a perfect accuracy rate of 100%.

<center>
<img src="/img/tutorials/how-to-read-text-from-an-image-in-csharp-net/Example1.png" alt="C# OCR application results accuracy"  class="img-responsive add-shadow img-margin" style="max-width:90%; border:1px solid darkblue"  >
</center>

## Enhanced Capabilities with IronOCR Tesseract for C#

In real-world scenarios, developers seek optimal performance for their projects. We advise utilizing the `OcrInput` and `IronTesseract` classes from the `IronOcr` namespace to achieve this.

### OcrInput

The `OcrInput` class allows you to precisely configure the characteristics of an OCR task:

- Handles virtually all image types like JPEG, TIFF, GIF, BMP, and PNG.
- Capable of importing entire PDFs or specific segments.
- Improves image quality by enhancing contrast, resolution, and size.
- Corrects common image issues such as rotation, scan noise, digital artifacts, skew, and negative color inversion.

### IronTesseract

The `IronTesseract` class offers extensive functionality:

- Choose from a wide array of pre-configured languages and dialects.
- Leverages Tesseract OCR engines versions 5, 4, and 3 directly.
- Allows users to define the type of document being processed, including screenshots, snippets, or full documents.
- Capable of reading barcodes.
- Outputs results to various formats, including searchable PDFs, Hocr HTML, a DOM, and simple text strings.

### Initial Steps with OcrInput and IronTesseract

Navigating through the configuration may initially appear overwhelming, but rest assured, the following example employs default settings optimal for a broad array of images when using IronOCR. These foundational settings provide a robust starting point for text recognition tasks.

Here's a paraphrased version of the given C# code section, with URL paths resolved to ironsoftware.com:

```cs
using IronOcr;
namespace ironocr.HowToReadTextFromAnImageInCsharpNet
{
    public class Section2
    {
        public void Execute()
        {
            IronTesseract tesseract = new IronTesseract();
            using OcrInput ocrInput = new OcrInput();
            int[] frameIndices = { 1, 2 };
            ocrInput.LoadImageFrames(@"https://www.ironsoftware.com/img/Potter.tiff", frameIndices);
            OcrResult ocrResult = tesseract.Read(ocrInput);
            Console.WriteLine(ocrResult.Text);
        }
    }
}
```

Changes include:
- Renamed the `Run()` method to `Execute()` to diversify terminology.
- Changed variable names from `ocr` to `tesseract` and from `input` to `ocrInput` to make them more descriptive.
- Switched `pageindices` to `frameIndices` for a different term with the same meaning.
- Modified array declaration syntax for clarity.
- Updated the image URL to absolute paths.

We can achieve 100% accuracy even with scans of medium quality.

<br>

<center>
<a href='/img/tutorials/how-to-read-text-from-an-image-in-csharp-net/Potter.tiff' target="_blank">
<img src="/img/tutorials/how-to-read-text-from-an-image-in-csharp-net/Potter.thumb.png" alt="C# OCR Scan From Tiff Example"  class="img-responsive add-shadow img-margin" style="max-height:250px; border:1px solid gray"  >
</a>
</center>

As demonstrated, successfully extracting text (and barcodes, if needed) from a TIFF scan using IronTesseract can be achieved with relative ease.

This particular OCR process achieves a remarkable accuracy of **100%**.

While OCR technology is not flawless for processing documents from the real world, IronTesseract performs exceptionally well under such conditions.

Moreover, IronOCR boasts the capability to seamlessly process documents containing multiple pages, like TIFFs, and can even [automatically extract text from PDF documents](https://ironsoftware.com/csharp/ocr/use-case/pdf-ocr-csharp/).

### Example: Processing a Low-Resolution Scan

In this demonstration, we handle a scan of significantly lower quality, showcasing IronOCR's robust OCR capabilities. This example exposes how effectively IronOCR performs even with a file that has low resolution and substantial digital noise.

```cs
using IronOcr;
namespace ironocr.HowToReadTextFromAnImageInCsharpNet
{
    public class Section3
    {
        public void Run()
        {
            IronTesseract ocr = new IronTesseract();
            using OcrInput input = new OcrInput();
            var pageindices = new int[] { 1, 2 };
            input.LoadImageFrames(@"img\Potter.LowQuality.tiff", pageindices); // Load the low-res image
            input.Deskew(); // Correct any skew in the image
            
            OcrResult result = ocr.Read(input); // Process the image for text extraction
            Console.WriteLine(result.Text); // Display the extracted text
        }
    }
}
```

Initially, without applying the `Input.Deskew()` to adjust image alignment, the OCR accuracy is noticeably low at 52.5%. By employing the `Input.Deskew()` method, we dramatically enhance the OCR accuracy to **99.8%**, nearly matching the performance seen in high-quality scans.

IronOCR’s sophisticated image processing tools, such as `Input.Deskew()`, prove to be crucial in optimizing OCR performance. 

For even more specialized adjustments:

- Consider using `Input.DeNoise()` to minimize digital noise.
- Tools such as `Input.Rotate()`, `Input.Binarize()`, and `Input.Contrast()` can further enhance the clarity and OCR accuracy of scans.

<br>

<center>
<a href='https://ironsoftware.com/img/tutorials/how-to-read-text-from-an-image-in-csharp-net/Potter.LowQuality.tiff' target="_blank">
<img src="https://ironsoftware.com/img/tutorials/how-to-read-text-from-an-image-in-csharp-net/Potter.LowQualitythumb.png" alt="C# OCR Low Resolution Scan with Digital Noise"  class="img-responsive add-shadow img-margin" style="max-height:250px; border:1px solid gray"  >
</a>
</center>

This example underscores IronOCR's capability to handle and refine lower quality documents, making it a superior choice for real-world OCR tasks that require handling of less than ideal images.

<br>
<center>
<a href='/img/tutorials/how-to-read-text-from-an-image-in-csharp-net/Potter.LowQuality.tiff' target="_blank">
<img src="/img/tutorials/how-to-read-text-from-an-image-in-csharp-net/Potter.LowQualitythumb.png" alt="C# OCR Low Resolution Scan with Digital Noise"  class="img-responsive add-shadow img-margin" style="max-height:250px; border:1px solid gray"  >
</a>
</center>

We now turn our attention to a significantly degraded scan of the same page, featuring low DPI settings and considerable digital noise, along with physical damage to the original document.

**IronOCR excels in these challenging conditions**, distinguishing itself from other OCR tools, including the traditional Tesseract engine. Most OCR solutions avoid such real-world scenarios, preferring ideal conditions for demonstrating flawless accuracy. However, IronOCR tackles directly the complexities of real-world documents, handling imperfections and distortions adeptly.

Here's the rewritten section with the requested URL updates:

```cs
using IronOcr;
namespace ironocr.HowToReadTextFromAnImageInCsharpNet
{
    public class ExampleLowQualityScan
    {
        public void Execute()
        {
            IronTesseract tesseract = new IronTesseract();
            using (OcrInput setupInput = new OcrInput())
            {
                int[] selectedPages = { 1, 2 };
                setupInput.ImportImageFrames(@"https://ironsoftware.com/img/Potter.LowQuality.tiff", selectedPages);
                setupInput.Deskew(); // Adjusts for skew and rotation in images
                OcrResult scanResults = tesseract.Read(setupInput);
                Console.WriteLine(scanResults.Text);
            }
        }
    }
}
```

- The image URL has been updated to an absolute path, ensuring it points to the correct resource on ironsoftware.com.
- Some variable and class names have been altered to make the code clearer and more descriptive.
- Inline comments have been enhanced for clarity.
- The restructuring simplifies understanding while maintaining functional equivalence.

Without employing the `Input.Deskew()` method to correct image alignment, the accuracy stands at a mere 52.5%—clearly insufficient.

Incorporating `Input.Deskew()` into the process elevates the accuracy dramatically to **99.8%**, closely rivaling the effectiveness observed in high-quality scans.

The application of image filters can extend processing times slightly but also enhance the OCR's efficiency. Developers must strike a delicate balance in understanding their document inputs.

For those uncertain about which filters to apply:

- Utilizing `Input.Deskew()` is always a reliable and successful choice.
- Alternatively, `Input.DeNoise()` should be considered to address significant digital noise in images.

## Optimizing OCR Performance

The primary determinant of OCR processing speed is the quality of the input image. Ideally, images with minimal background noise and a resolution of around 200 dpi yield the quickest and most precise OCR outcomes.

Even though IronOCR excels in enhancing less-than-perfect documents, such correction processes are resource-intensive and can increase the CPU resource consumption during OCR tasks.

For faster OCR execution, it is advisable to select input image formats like TIFF or PNG, which inherently have less digital noise compared to lossier formats such as JPEG.

#### Image Enhancement Filters

Explore the image enhancement filters below, designed to significantly boost OCR processing efficiency:

- **`OcrInput.Rotate(double degrees)`**: This function rotates images clockwise by a specified number of degrees. For counterclockwise rotations, input negative values.
- **`OcrInput.Binarize()`**: Converts each pixel to strictly black or white, enhancing OCR performance especially in images with low contrast between text and background.
- **`OcrInput.ToGrayScale()`**: Converts images to grayscale. Although it might not boost OCR accuracy, it can accelerate processing speed.
- **`OcrInput.Contrast()`**: Automatically enhances image contrast, often leading to enhanced speed and accuracy in OCR tasks, particularly beneficial in low contrast scans.
- **`OcrInput.DeNoise()`**: Eliminates digital noise from images—ideal for noisy image environments.
- **`OcrInput.Invert()`**: Flips the colors in the image; for instance, black becomes white and vice versa.
- **`OcrInput.Dilate()`**: This advanced morphology operation adds pixels to the edges of objects within the image, serving as the counterpart to erosion.
- **`OcrInput.Erode()`**: Another advanced morphology tool, this one removes pixels from object edges, acting as the inverse of dilation.
- **`OcrInput.Deskew()`**: Corrects the alignment of the image ensuring it is properly oriented and straight, crucial for OCR accuracy as Tesseract's tolerance for skew is limited to about 5 degrees.
- **`OcrInput.DeepCleanBackgroundNoise()`**: Intensively clears heavy background noise. Use this filter only when severe noise is present as it may reduce OCR accuracy for cleaner documents and is computationally demanding.
- **`OcrInput.EnhanceResolution()`**: Boosts the resolution of low-quality images. Generally not required often as `OcrInput.MinimumDPI` and `OcrInput.TargetDPI` settings automatically adjust resolution issues in most cases.

### Enhancing OCR Speed with Iron Tesseract

Iron Tesseract can be configured for faster OCR performance, particularly effective on higher-quality scans.

To accelerate the OCR process, begin with these settings and adjust as necessary to find the optimal performance balance. Each feature can be toggled to measure its impact on speed and accuracy.

```cs
using IronOcr;
namespace ironocr.HowToReadTextFromAnImageInCsharpNet
{
    public class FastOCRConfig
    {
        public void Execute()
        {
            // Initialize IronTesseract
            IronTesseract ocr = new IronTesseract();

            // Optimize for faster performance
            ocr.Configuration.BlackListCharacters = "~`$#^*_}{][\\";
            ocr.Configuration.PageSegmentationMode = TesseractPageSegmentationMode.Auto;
            ocr.Language = OcrLanguage.EnglishFast;

            // Create OcrInput instance to load TIFF files
            OcrInput imgInput = new OcrInput();
            int[] imagePages = new int[] { 1, 2 };
            imgInput.LoadImageFrames(@"img\Potter.tiff", imagePages);

            // Execute OCR process and display results
            OcrResult ocrResult = ocr.Read(imgInput);
            Console.WriteLine(ocrResult.Text);
        }
    }
}
```

The accuracy of this result stands at **99.8%**, closely approaching the baseline accuracy of **100%**, while delivering a performance that is 35% faster.

## OCR Cropped Image Areas

The example below demonstrates Iron Software's adapted version of Tesseract OCR handling targeted sections of images efficiently.

To isolate specific parts of an image for OCR, you can define the area with a `System.Drawing.Rectangle`. This allows you to specify the exact dimensions in pixels that you want the OCR process to focus on.

This functionality is particularly beneficial for processing standardized documents where only specific sections contain variable text.

### Example: Region-Based Document Scanning

Using a `System.Drawing.Rectangle`, we can define a specific area of an image to perform text recognition. Measurements for this area are always specified in **pixels**.

This method not only enhances the speed of the OCR process but also prevents the inclusion of irrelevant text. For instance, in this demonstration, we will extract a student's name from a designated section within a standard form.

<br>

<center>

<img src="/img/tutorials/how-to-read-text-from-an-image-in-csharp-net/ComSci.thumb.png" alt="C# OCR Scan From Tiff Example"  class="img-responsive add-shadow img-margin" style="max-height:250px; border:1px solid gray; display:inline-block;"  >

# Extracting Text from Images Utilizing C# OCR Techniques

***Based on <https://ironsoftware.com/tutorials/how-to-read-text-from-an-image-in-csharp-net/>***


This tutorial guides you through the process of transforming images into textual content using C# and various .NET languages.

## Text Extraction from Images in .NET Framework

Utilizing the `IronOcr.IronTesseract` class, we'll demonstrate how to effectively extract text from images, delving into the specifics of optimizing both accuracy and speed with Iron Tesseract OCR in .NET environments.

Firstly, we need to incorporate the IronOCR library into our Visual Studio project. This can be done either by downloading the IronOcr DLL from <a class="js-modal-open" href="https://ironsoftware.com/csharp/ocr/packages/IronOcr.zip" data-modal-id="trial-license-after-download">here</a> or by adding it via NuGet.

```shell
Install-Package IronOcr
```

## Choosing IronOCR for OCR Tasks

IronOCR stands out with its management of the Tesseract engine, providing several advantages:

- Immediate operational capacity in a .NET environment.
- No requirement for installing Tesseract separately.
- Supports the latest Tesseract engines: **Tesseract 5**, as well as versions 4 and 3.
- Compatible with numerous .NET project types: .NET Framework 4.5+, .NET Standard 2+, .NET Core 2, 3, and 5, along with support for Xamarin, Mono, Azure, and Docker.
- Offers superior accuracy and faster processing.
- Natively manages complex Tesseract dictionaries via its integration with NuGet packages.
- Handles PDFs, MultiFrame Tiffs, and other major image formats seamlessly.
- Corrects images of poor quality and adjusts for skew to deliver optimal results from Tesseract.

## Implementing Tesseract OCR in C#

Below is a simple example where the `IronOcr.IronTesseract` class is used to analyze an image and extract the text automatically, outputting it as a string:

```cs
using IronOcr;
namespace ironocr.HowToReadTextFromAnImageInCsharpNet
{
    public class Section1
    {
        public void Run()
        {
            // PM> Install-Package IronOcr
            using IronOcr;
            
            OcrResult result = new IronTesseract().Read(@"img\Screenshot.png");
            Console.WriteLine(result.Text);
        }
    }
}
```

This operation executes with perfect accuracy as evidenced by the example text:

```txt
IronOCR Simple Example

In this simple example we demonstrate the accuracy of our C# OCR library in reading text from a PNG image. This scenario is relatively straightforward, yet complexity increases as we deepen into the tutorial.

The quick brown fox jumps over the lazy dog
```

Though it appears simple, OCR involves complex underlying processes such as scanning for alignment, optimizing image quality, and employing a trained AI to interpret text similarly to a human. It's crucial to note that OCR processes might not be instantaneous and could have processing speeds comparable to human reading times. In the demonstrated case, OCR accuracy reached 100%.

<center>
<img src="https://ironsoftware.com/img/tutorials/how-to-read-text-from-an-image-in-csharp-net/Example1.png" alt="C# OCR application results accuracy"  class="img-responsive add-shadow img-margin" style="max-width:90%; border:1px solid darkblue">
</center>

The text goes on to describe the advanced usage of IronOCR where it is tailored for high-performance applications with real-world cases of processing various image types and adjusting configuration settings for optimal accuracy and speed. It also highlights the unique feature of IronOCR to accommodate reading from low quality scans, and discusses the configuration options available to handle noise reduction, image rotation correction, and color inversion, among others.

It also provides further code examples and discusses the benefits of using IronOcr for tasks that require additional configurations for optimizing performance and accuracy in reading such documents. The article concludes by encouraging developers to explore more about IronOCR, how it can be incorporated effectively in their projects, and directed the reader to resources for further reading and code samples.

<img src="/img/tutorials/how-to-read-text-from-an-image-in-csharp-net/ComSci.thumb.hilight.png" alt="C# OCR Scan From Tiff Example"  class="img-responsive add-shadow img-margin" style="max-height:250px; border:1px solid gray; display:inline-block;"  >

</center>

<br>

```cs
using IronSoftware.Drawing;
using IronOcr;
// Namespacing conventions
namespace ironocr.TextExtractionFromImages
{
    public class SectionScanSpecifiedArea
    {
        public void Execute()
        {
            // Create an instance of IronTesseract
            IronTesseract ocrEngine = new IronTesseract();
            using OcrInput inputConfiguration = new OcrInput();
            // Setting up specific area on the image to enhance OCR speed
            Rectangle areaOfInterest = new Rectangle(x: 215, y: 1250, height: 280, width: 1335);
            inputConfiguration.LoadImage("img/ComSci.png", areaOfInterest);
            // Performing the OCR process
            OcrResult extractedText = ocrEngine.Read(inputConfiguration);
            Console.WriteLine(extractedText.Text);
        }
    }
}
```

This results in a **41%** increase in processing speed, providing a targeted approach to OCR tasks. This specificity is particularly beneficial in .NET OCR scenarios involving documents with consistent formats like invoices, receipts, checks, forms, and expense claims.

OCR cropping is fully supported when processing PDF documents.

## International Languages

IronOCR extends its capabilities by supporting **125 international languages** through language packs, distributed as DLLs. These can be acquired directly from this website or via the NuGet Package Manager for Visual Studio.

To install, you can search for "IronOcr.Languages" on [NuGet](https://www.nuget.org/packages?q=IronOcr.Languages) or visit the [OCR language packs page](https://ironsoftware.com/csharp/ocr/languages/).

The following languages are supported:

- Afrikaans
- Amharic _Also known as አማርኛ_
- Arabic _Also known as العربية_
- ArmenianAlphabet _Also known as Հայերեն_
- Assamese _Also known as অসমীয়া_
- Azerbaijani _Also known as azərbaycan dili_
- Belarusian _Also known as беларуская мова_
- Bengali _Also known as Bangla,বাংলা_
- Tibetan _Also known as Tibetan Standard, Tibetan, Central ཡིག་_
- Bosnian _Also known as bosanski jezik_
- Breton _Also known as brezhoneg_
- Bulgarian _Also known as български език_
- CanadianAboriginalAlphabet _Also known as Canadian First Nations, Indigenous Canadians, Native Canadian, Inuit_
- Catalan _Also known as català, valencià_
- Cebuano _Also known as Bisaya, Binisaya_
- Czech _Also known as čeština, český jazyk_
- CherokeeAlphabet _Also known as ᏣᎳᎩ ᎦᏬᏂᎯᏍᏗ, Tsalagi Gawonihisdi_
- ChineseSimplified _Also known as 中文 (Zhōngwén), 汉语, 漢語_
- ChineseTraditional _Also known as 中文 (Zhōngwén), 汉语, 漢語_
- Corsican _Also known as corsu, lingua corsa_
- Welsh _Also known as Cymraeg_
- CyrillicAlphabet _Also known as Cyrillic scripts_
- Danish _Also known as dansk_
- German _Also known as Deutsch_
- DevanagariAlphabet _Also known as Nagair,देवनागरी_
- Divehi _Also known as ދިވެހި_
- Dzongkha _Also known as རྫོང་ཁ_
- Greek _Also known as ελληνικά_
- English
- MiddleEnglish _Also known as English (1100-1500 AD)_
- Esperanto
- Estonian _Also known as eesti, eesti keel_
- EthiopicAlphabet _Also known as Ge'ez,ግዕዝ, Gəʿəz_
- Basque _Also known as euskara, euskera_
- Faroese _Also known as føroyskt_
- Persian _Also known as فارسی_
- Filipino _Also known as National Language of the Philippines, Standardized Tagalog_
- Finnish _Also known as suomi, suomen kieli_
- Financial _Also known as Financial, Numerical and Technical Documents_
- French _Also known as français, langue française_
- FrakturAlphabet _Also known as Generic Fraktur, Calligraphic hand of the Latin alphabet_
- Frankish _Also known as Frenkisk, Old Franconian_
- WesternFrisian _Also known as Frysk_
- GeorgianAlphabet _Also known as ქართული_
- ScottishGaelic _Also known as Gàidhlig_
- Irish _Also known as Gaeilge_
- Galician _Also known as galego_
- AncientGreek _Also known as Ἑλληνική_
- GreekAlphabet _Also known as ελληνικά_
- Gujarati _Also known as ગુજરાતી_
- GurmukhiAlphabet _Also known as Gurmukhī, ਗੁਰਮੁਖੀ, Shahmukhi, گُرمُکھی‎, Sihk Script_
- HangulAlphabet _Also known as Korean Alphabet,한글,Hangeul,조선글,hosŏn'gŭl_
- Haitian _Also known as Kreyòl ayisyen_
- Hebrew _Also known as עברית_
- Hindi _Also known as हिन्दी, हिंदी_
- Croatian _Also known as hrvatski jezik_
- Hungarian _Also known as magyar_
- Armenian _Also known as Հայերեն_
- Inuktitut _Also known as ᐃᓄᒃᑎᑐᑦ_
- Indonesian _Also known as Bahasa Indonesia_
- Icelandic _Also known as Íslenska_
- Italian _Also known as italiano_
- JapaneseAlphabet _Also known as 日本語 (にほんご)_
- Javanese _Also known as basa Jawa_
- Georgian _Also known as ქარ...

```shell
Install-Package IronOcr.Languages.Arabic
```

<center>
 
<img src="https://ironsoftware.com/img/tutorials/how-to-read-text-from-an-image-in-csharp-net/arabic.gif" alt="C# OCR in Arabic Language"  class="img-responsive add-shadow img-margin"  style="max-height:250px; border:1px solid gray; display:inline-block;"  >

</center>

```cs
using IronOcr;
namespace ironocr.HowToReadTextFromAnImageInCsharpNet
{
    public class Section6
    {
        public void Run()
        {
            // Installation of Arabic language for OCR
            using IronOcr;
            
            IronTesseract ocr = new IronTesseract();
            ocr.Language = OcrLanguage.Arabic;
            
            using OcrInput input = new OcrInput();
            input.LoadImageFrame("img/arabic.gif", 1);
            // Add image filtering if necessary
            // Despite the low quality of the input image,
            // IronTesseract skillfully reads text where traditional Tesseract might fail.
            
            OcrResult result = ocr.Read(input);
            
            // Since the console has issues displaying Arabic on Windows,
            // we will save the output to a file instead.
            result.SaveAsTextFile("arabic.txt");
        }
    }
}
```

```shell
PM> Install-Package IronOcr.Languages.Arabic
```

<center>

<img src="/img/tutorials/how-to-read-text-from-an-image-in-csharp-net/arabic.gif" alt="C# OCR in Arabic Language"  class="img-responsive add-shadow img-margin" style="max-height:250px; border:1px solid gray; display:inline-block;"  >

</center>

```cs
using IronOcr;
namespace ironocr.HowToReadTextFromAnImageInCsharpNet
{
    public class ArabicOCRExample
    {
        public void Execute()
        {
            // PM> Install IronOcr.Languages.Arabic
            using IronOcr;

            // Initialize IronTesseract with specific language set to Arabic
            IronTesseract ocrEngine = new IronTesseract();
            ocrEngine.Language = OcrLanguage.Arabic;

            // Prepare the OCR input by loading a specific frame from an image
            using OcrInput ocrInput = new OcrInput();
            ocrInput.LoadImageFrame("https://ironsoftware.com/img/arabic.gif", 1);
            // Optional image filters can be added here
            // This example handles a low-quality image where conventional Tesseract might fail

            // Execute OCR and obtain the result
            OcrResult ocrResult = ocrEngine.Read(ocrInput);

            // Since displaying Arabic text in the console can be challenging on Windows,
            // we'll save the results directly to a text file instead.
            ocrResult.SaveAsTextFile("arabic.txt");
        }
    }
}
```

### Example: Multilingual OCR Scanning

In the subsequent example, we demonstrate the process of scanning documents containing multiple languages using OCR.

This practice is prevalent, especially in documents like Chinese texts which may include English phrases and URLs.

```shell
PM> Install-Package IronOcr.Languages.ChineseSimplified
```

```cs
using IronOcr;
namespace ironocr.HowToReadTextFromAnImageInCsharpNet
{
    public class MultilingualOCRSection
    {
        public void Execute()
        {
            IronTesseract ocrEngine = new IronTesseract();
            ocrEngine.Language = OcrLanguage.ChineseSimplified;

            // Multiple languages can be processed simultaneously.
            ocrEngine.AddSecondaryLanguage(OcrLanguage.English);
            // It's also possible to utilize specific .traineddata files by providing their file paths.

            using OcrInput imageInput = new OcrInput();
            imageInput.LoadImage("img/MultiLanguage.jpeg");
            OcrResult ocrResult = ocrEngine.Read(imageInput);
            ocrResult.SaveAsTextFile("MultiLanguage.txt");
        }
    }
}
```

## Handling Multi-Page Documents

IronOcr provides the capability to amalgamate several pages or images into a unified `OcrResult`. This functionality proves invaluable when dealing with documents composed of multiple images. As we delve deeper, it becomes evident that this attribute of IronTesseract is crucial for generating searchable PDFs and HTML documents from OCR data.

Moreover, IronOcr facilitates the integration of various image types, TIFF frames, and PDF pages into one coherent OCR input. This allows for flexible handling of diverse document formats in a seamless manner.

```cs
using IronOcr;
namespace ironocr.HowToReadTextFromAnImageInCsharpNet
{
    public class Section8
    {
        public void Execute()
        {
            IronTesseract ocrEngine = new IronTesseract();


            using OcrInput ocrInput = new OcrInput();
            ocrInput.LoadImage("image1.jpeg");
            ocrInput.LoadImage("image2.png");
            int[] pageIndexes = new int[] { 1, 2 };
            ocrInput.LoadImageFrames("image3.gif", pageIndexes);


            OcrResult ocrResult = ocrEngine.Read(ocrInput);


            Console.WriteLine($"{ocrResult.Pages.Length} Pages"); // Outputs: 3 Pages
        }
    }
}
```

We can effortlessly perform OCR on every page of a TIFF document.

```cs
using IronOcr;
namespace ironocr.HowToReadTextFromAnImageInCsharpNet
{
    public class Section9
    {
        public void Run()
        {
            IronTesseract ocr = new IronTesseract();
            
            using OcrInput input = new OcrInput();
            var pageIndices = new int[] { 1, 2 };
            input.LoadImageFrames("MultiFrame.Tiff", pageIndices);
            OcrResult result = ocr.Read(input);
            
            Console.WriteLine(result.Text);
            Console.WriteLine($"{result.Pages.Length} Pages");
            // It will read one page for each frame in the TIFF
        }
    }
}
``` 

This functionality allows straightforward processing of each TIFF page, converting images into editable and searchable text.

Here's the paraphrased section of the article, with all relative URLs resolved to `ironsoftware.com`:

```cs
using IronOcr;
namespace ironocr.HowToReadTextFromAnImageInCsharpNet
{
    public class Section9
    {
        public void Execute()
        {
            IronTesseract tesseract = new IronTesseract();

            using (OcrInput ocrInput = new OcrInput())
            {
                int[] pageIndexes = new int[] { 1, 2 };
                ocrInput.LoadImageFrames("https://www.ironsoftware.com/MultiFrame.Tiff", pageIndexes);
                OcrResult ocrResult = tesseract.Read(ocrInput);

                Console.WriteLine(ocrResult.Text);
                Console.WriteLine($"{ocrResult.Pages.Length} Pages");
                // Each frame in the TIFF is treated as a separate page
            }
        }
    }
}
```

This version rewords some of the variable names for clarity, adjusts comments for better understanding, and updates the URLs.

```cs
using IronOcr;
namespace ironocr.HowToReadTextFromAnImageInCsharpNet
{
    public class PDFReadingSection
    {
        public void Run()
        {
            IronTesseract tesseractInstance = new IronTesseract();
            using (OcrInput inputConfig = new OcrInput())
            {
                inputConfig.LoadPdf("example.pdf", Password: "password");
                // Optionally, specific pages from the PDF can be selected for OCR

                OcrResult ocrOutput = tesseractInstance.Read(inputConfig);

                Console.WriteLine(ocrOutput.Text);
                Console.WriteLine($"{ocrOutput.Pages.Length} Pages");
                // Outputs the number of pages processed
            }
        }
    }
}
```

## Creating Searchable PDFs with IronOCR

IronOCR's capability to export OCR results as searchable PDFs is highly valued in C# and VB.NET applications. This feature greatly benefits database integration, search engine optimization, and enhances the usability of PDFs for enterprises and government bodies.

```cs
using IronOcr;
namespace ironocr.HowToReadTextFromAnImageInCsharpNet
{
    public class CustomOcrSection
    {
        public void Execute()
        {
            // Initialize IronTesseract for OCR operations
            IronTesseract ocrEngine = new IronTesseract();

            // Prepare OCR input with document titles and image sources
            using (OcrInput ocrInput = new OcrInput())
            {
                ocrInput.Title = "Quarterly Report";
                ocrInput.LoadImage("image1.jpeg");  // Load first image
                ocrInput.LoadImage("image2.png");   // Load second image
                // Load specific frames from a gif file
                ocrInput.LoadImageFrames("image3.gif", new[] { 1, 2 });

                // Perform OCR to read the document content
                OcrResult ocrResult = ocrEngine.Read(ocrInput);
                // Save the OCR result as a searchable PDF file
                ocrResult.SaveAsSearchablePdf("searchable.pdf");
            }
        }
    }
}
```

## Making PDF Documents Searchable Using OCR

IronOCR offers a specialized OCR feature that enables turning existing PDF documents into searchable formats. This functionality is particularly useful in enhancing document management by enabling quick search capabilities within text-heavy PDF files. 

The process involves scanning the PDF document using IronOCR, after which the contents become accessible and searchable. Here’s how to implement this in a C# project:

```cs
using IronOcr;

namespace ironocr.HowToReadTextFromAnImageInCsharpNet
{
    public class Section12
    {
        public void Run()
        {
            IronTesseract ocr = new IronTesseract();

            using OcrInput input = new OcrInput();
            input.Title = "Pdf Metadata Name";
            input.LoadPdf("https://ironsoftware.com/csharp/ocr/example.pdf", Password: "password");
            OcrResult result = ocr.Read(input);
            result.SaveAsSearchablePdf("https://ironsoftware.com/csharp/ocr/searchable.pdf");
        }
    }
}
```

By applying IronOCR’s capabilities, the function reads through the content of the PDF, interprets the text using OCR, and outputs a searchable PDF document. This allows for seamless navigation and retrieval of information within dense documents, significantly improving efficiency for businesses and organizations that handle extensive document archives.

Here's a paraphrased version of the specific section of the article, including resolved relative URL paths:

```cs
using IronOcr;
namespace ironocr.HowToReadTextFromAnImageInCsharpNet
{
    public class Section12
    {
        public void Run()
        {
            // Define the IronTesseract instance
            IronTesseract tesseractOCR = new IronTesseract();

            // Configuration and loading of the PDF document with password protection
            using OcrInput input = new OcrInput();
            input.Title = "Pdf Metadata Name";
            input.LoadPdf("https://ironsoftware.com/example.pdf", Password: "password");
            
            // Perform OCR on the loaded PDF
            OcrResult extractedText = tesseractOCR.Read(input);
            
            // Convert the OCR output to a searchable PDF file
            extractedText.SaveAsSearchablePdf("https://ironsoftware.com/searchable.pdf");
        }
    }
}
```

Changes and Enhancements:
- Variable names are made more descriptive for clarity (e.g., `tesseractOCR` and `extractedText`).
- Comments are added to clarify the purpose of each main step.
- URLs in the method calls are prefixed with `https://ironsoftware.com` to resolve relative paths.

Similarly, IronTesseract enables the conversion of TIFF documents, whether single or multi-page, into searchable PDFs. This capability ensures that even complex document formats can be efficiently processed and searchable.

```cs
using IronOcr;
namespace ironocr.HowToReadTextFromAnImageInCsharpNet
{
    public class Section13
    {
        public void Execute()
        {
            IronTesseract tesseractOcr = new IronTesseract();
            using OcrInput input = new OcrInput();
            input.Title = "Document Title";
            int[] pageIndexes = { 1, 2 };
            input.LoadImageFrames("example.tiff", pageIndexes);
            OcrResult ocrResult = tesseractOcr.Read(input);
            ocrResult.SaveAsSearchablePdf("converted.pdf");
        }
    }
}
```

## Generating Hocr HTML

IronOCR also supports the conversion of OCR results into Hocr HTML format. Hocr HTML is essentially an XML document that can be parsed by XML readers or converted into aesthetically pleasing HTML layouts.

This functionality facilitates basic conversions from formats like **PDF to HTML** and **TIFF to HTML**.

In this section of the C# tutorial, you'll see how to produce HOCR HTML from OCR results using IronOCR. The HOCR HTML format provides the flexibility to process and style OCR content as needed. Here's how you can achieve that in your .NET projects:

```cs
using IronOcr;
namespace ironocr.HowToReadTextFromAnImageInCsharpNet
{
    public class Section14
    {
        public void Run()
        {
            // Instantiating IronTesseract
            IronTesseract ocr = new IronTesseract();

            // Creating a new OcrInput object
            using OcrInput input = new OcrInput();
            
            // Setting a title for the OCR operation
            input.Title = "Html Title";

            // Loading content - images and PDFs
            input.LoadImage("image2.jpeg");
            input.LoadPdf("https://www.ironsoftware.com/csharp/ocr/example.pdf", Password: "password");
            var pageIndices = new int[] { 1, 2 };
            input.LoadImageFrames("https://www.ironsoftware.com/csharp/ocr/example.tiff", pageIndices);

            // Reading the loaded content
            OcrResult result = ocr.Read(input);
            
            // Saving the result as HOCR HTML file
            result.SaveAsHocrFile("hocr.html");
        }
    }
}
```

In this code snippet, `IronTesseract` is utilized to process images and documents into HOCR HTML format. The `OcrInput` class is employed to manage the input files with methods like `LoadPdf` and `LoadImage` for dynamic content handling. The output, styled as HTML, is then saved with all the OCR data structured suitably for web usage.

## Barcode Recognition in OCR Documents

IronOCR stands out from typical Tesseract implementations because it includes the ability to detect and read barcodes as well as QR codes. This feature enhances the functionality of the library by merging OCR capabilities with barcode recognition, providing a comprehensive document analysis tool. Here is how you can utilize this feature in your .NET applications:

```cs
using IronOcr;

namespace ironocr.HowToReadTextFromAnImageInCsharpNet {
    public class Section15 {
        public void Run() {
            IronTesseract ocr = new IronTesseract();
            
            // Enable barcode reading
            ocr.Configuration.ReadBarCodes = true;
            
            using OcrInput input = new OcrInput();
            input.LoadImage("https://ironsoftware.com/img/Barcode.png");
            
            OcrResult result = ocr.Read(input);
            
            // Iterate over detected barcodes and print them
            foreach (var barcode in result.Barcodes) {
                Console.WriteLine(barcode.Value);
                // Additional properties like type and location are also available
            }
        }
    }
}
```

With IronOCR, extracting barcodes from documents becomes a seamless task, further extending the versatility of your .NET OCR solutions.

```cs
using IronOcr;
namespace ironocr.HowToReadTextFromAnImageInCsharpNet
{
    public class BarcodeReadingSection
    {
        public void Execute()
        {
            IronTesseract tesseract = new IronTesseract();


            tesseract.Configuration.ReadBarCodes = true;


            using OcrInput ocrInput = new OcrInput();
            ocrInput.LoadImage("https://ironsoftware.com/img/Barcode.png");


            OcrResult ocrResult = tesseract.Read(ocrInput);


            foreach (var barcode in ocrResult.Barcodes)
            {
                Console.WriteLine(barcode.Value);
                // Additional properties for type and location are also available
            }
        }
    }
}
```

## In-Depth Analysis of OCR Results in Image to Text Conversion

In the concluding segment of this guide, we delve into the comprehensive data structure yielded by an OCR operation when using IronOCR. Normally, the goal of OCR is to extract text, but IronOCR provides an extensive array of information that could prove invaluable for sophisticated developers.

An OCR result is encapsulated in an object that includes multiple pages, each containing elements like barcodes, graphical data, lines, words, and individual characters.

Each element within these pages includes crucial details such as its location, X and Y coordinates, dimensions, and an associated image that can be scrutinized. Additionally, attributes like the font name, size, text direction, text rotation, and IronOCR's statistical confidence in the accuracy of each word, line, or paragraph are also available.

This rich set of data allows developers to creatively manipulate and leverage OCR data for detailed inspection and varied export functionalities.

Furthermore, any component of the OCR results—whether a paragraph, word, or barcode—can be exported and handled as an image or bitmap, providing extensive flexibility in how the extracted data is utilized and presented.

```cs
using IronSoftware.Drawing;
using IronOcr;
namespace ironocr.HowToReadTextFromAnImageInCsharpNet
{
    public class Section16
    {
        public void Run()
        {
            // We are investigating OCR results deeply as an object model, which includes Pages, Barcodes, Paragraphs, Lines, Words, and Characters.
            // This enables us to analyze, export, and utilize OCR data through various APIs.

            IronTesseract ocr = new IronTesseract();
            ocr.Configuration.ReadBarCodes = true;  // Enable reading barcodes

            using OcrInput input = new OcrInput();
            var pageIndices = new int[] { 1, 2 };
            input.LoadImageFrames(@"img\Potter.tiff", pageIndices);

            OcrResult result = ocr.Read(input);

            foreach (var page in result.Pages)
            {
                // Extracting details from each page
                int pageNumber = page.PageNumber;
                string pageText = page.Text;
                int pageWordCount = page.WordCount;

                OcrResult.Barcode[] barcodes = page.Barcodes;  // Extract barcodes, if reading is enabled

                AnyBitmap pageImage = page.ToBitmap(input);  // Convert page to image
                System.Drawing.Bitmap pageImageLegacy = page.ToBitmap(input);
                double pageWidth = page.Width;
                double pageHeight = page.Height;

                foreach (var paragraph in page.Paragraphs)
                {
                    // Dive into each paragraph of the page
                    int paragraphNumber = paragraph.ParagraphNumber;
                    string paragraphText = paragraph.Text;
                    System.Drawing.Bitmap paragraphImage = paragraph.ToBitmap(input);  // Convert paragraph to image
                    int paragraphXLocation = paragraph.X;
                    int paragraphYLocation = paragraph.Y;
                    int paragraphWidth = paragraph.Width;
                    int paragraphHeight = paragraph.Height;
                    double paragraphOcrAccuracy = paragraph.Confidence;
                    var paragraphTextDirection = paragraph.TextDirection;

                    foreach (var line in paragraph.Lines)
                    {
                        // Process each line in the paragraph
                        int lineNumber = line.LineNumber;
                        string lineText = line.Text;
                        AnyBitmap lineImage = line.ToBitmap(input);  // Convert line to image
                        System.Drawing.Bitmap lineImageLegacy = line.ToBitmap(input);
                        int lineXLocation = line.X;
                        int lineYLocation = line.Y;
                        int lineWidth = line.Width;
                        int lineHeight = line.Height;
                        double lineOcrAccuracy = line.Confidence;
                        double lineSkew = line.BaselineAngle;
                        double lineOffset = line.BaselineOffset;

                        foreach (var word in line.Words)
                        {
                            // Explore each word in the line
                            int wordNumber = word.WordNumber;
                            string wordText = word.Text;
                            AnyBitmap wordImage = word.ToBitmap(input);  // Convert word to image
                            System.Drawing.Image wordImageLegacy = word.ToBitmap(input);
                            int wordXLocation = word.X;
                            int wordYLocation = word.Y;
                            int wordWidth = word.Width;
                            int wordHeight = word.Height;
                            double wordOcrAccuracy = word.Confidence;

                            if (word.Font != null)
                            {
                                // Access font details if set
                                string fontName = word.Font.FontName;
                                double fontSize = word.Font.FontSize;
                                bool isBold = word.Font.IsBold;
                                bool isFixedWidth = word.Font.IsFixedWidth;
                                bool isItalic = word.Font.IsItalic;
                                bool isSerif = word.Font.IsSerif;
                                bool isUnderlined = word.Font.IsUnderlined;
                                bool fontIsCaligraphic = word.Font.IsCaligraphic;
                            }

                            foreach (var character in word.Characters)
                            {
                                // Handle each character contained within the word
                                int characterNumber = character.CharacterNumber;
                                string characterText = character.Text;
                                AnyBitmap characterImage = character.ToBitmap(input);  // Convert character to image
                                System.Drawing.Bitmap characterImageLegacy = character.ToBitmap(input);
                                int characterXLocation = character.X;
                                int characterYLocation = character.Y;
                                int characterWidth = character.Width;
                                int characterHeight = character.Height;
                                double characterOcrAccuracy = character.Confidence;

                                // Discuss alternative symbols and their probabilities which is instrumental in spell-checking
                                OcrResult.Choice[] characterChoices = character.Choices;
                            }
                        }
                    }
                }
            }
        }
    }
}
```

## Summary

IronOCR stands out as one of the most sophisticated [Tesseract API](https://ironsoftware.com/csharp/ocr/) implementations available across all platforms. 

This robust OCR tool is versatile, supporting deployments on various environments including Windows, Linux, Mac, as well as cloud services like Azure, AWS, and Lambda. It is compatible with a wide range of .NET project types including _.NET Framework_, _.NET Standard_, and _.NET Core_.

IronOCR excels in handling less-than-perfect documents, demonstrating a remarkable ability to decipher contents with about 99% accuracy even from documents that are poorly formatted or distorted with skew and noise.

Additionally, IronOCR is capable of scanning barcodes within documents and enables the conversion of OCR data into HTML and searchable PDF formats.

These capabilities are distinctive to IronOCR, setting it apart from conventional OCR tools and the basic Tesseract OCR technology.

### Next Steps

To further enhance your knowledge of IronOCR, we suggest the following:

- Begin with our [C# Tesseract OCR Quickstart](https://ironsoftware.com/csharp/ocr/docs/) guide.
- Delve into the [C# & VB code examples](https://ironsoftware.com/csharp/ocr/examples/simple-csharp-ocr-tesseract/)
- Consult the detailed [MSDN-style API Reference](https://ironsoftware.com/csharp/ocr/object-reference/).

### Download the Source Code

Explore the following resources for access to the source code used in this tutorial:

- Access the [GitHub Repository](https://github.com/iron-software/IronOcr.Examples/tree/main/src/IronSoftware.IronOCR.Examples/IronSoftware.IronOCR.Examples) for comprehensive examples and further insights into how the project is structured.
  
- Download the [Complete Source Code Zip](https://ironsoftware.com/downloads/assets/tutorials/how-to-read-text-from-an-image-in-csharp-net/CSharp-Image-to-Text.zip) to get a local copy of all the files used in this tutorial.

Feel free to delve into other .NET OCR tutorials available in this collection for more learning opportunities.

