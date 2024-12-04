# OCR Processing in .NET MAUI with IronOCR

***Based on <https://ironsoftware.com/how-to/net-maui-ocr-tutorial/>***


## Overview

Microsoft's .NET MAUI (Multi-platform App UI) is a powerful framework designed to build cross-platform applications using a single codebase for Android, iOS, and Windows. This open-source framework enhances development efficiency by cutting down on time, resources, and effort. The source code and examples of .NET MAUI can be found on its [GitHub page](https://github.com/dotnet/maui).

This guide will introduce how to leverage IronOCR, a .NET OCR library, to create OCR applications in .NET MAUI with practical examples.

## About IronOCR: A .NET OCR Solution

[IronOCR](https://ironsoftware.com/csharp/ocr/) is a .NET optical character recognition library available as a NuGet package. It allows developers to implement OCR capabilities in their applications efficiently. With IronOCR, you can scan PDFs and transform them into searchable, editable texts while maintaining high data fidelity. This simplifies accessing and manipulating PDF content.

IronOCR stands out as the most sophisticated version of the Tesseract engine, supporting all Tesseract versions from Tesseract 3 to Tesseract 5, and it is operational after a straightforward installation. It offers robust performance enhancements and language support for over 125 international languages. Additional languages can be added via NuGet or by downloading the relevant DLLs.

## IronOCR against Tesseract

Intending specifically for C# development, IronOCR integrates seamlessly into .NET applications, unlike Tesseract, which is more general and requires custom wrappers for C#. IronOCR outshines other OCR tools with superior speed and accuracy, facilitated by advanced AI algorithms. Additionally, IronOCR delivers superior accuracy with a 99% rate, far outstripping Tesseract's 70.2% to 92.9%. An informative [YouTube video](https://www.youtube.com/watch?v=2QTEb6x8NJ4) offers further insight into the comparison between IronOCR and Tesseract.

## Developing an OCR App in .NET MAUI

### Necessary Setup

Before starting, ensure you have:

1. Visual Studio 2022 (latest version)
2. .NET 6 or 7
3. MAUI packages integrated within Visual Studio
4. An active .NET MAUI project environment in Visual Studio

### Installing IronOCR

Begin by adding the IronOCR library to your project via the NuGet Package Manager Console in Visual Studio:

```shell
Install-Package IronOcr
```

### UI Layout Creation

Open the *MainPage.xaml* file to start the design:

```xml
<Button
    x:Name="OCR"
    Text="Click to OCR"
    Clicked="IOCR"
    HorizontalOptions="Center" />

<Image
    x:Name="OCRImage"
    SemanticProperties.Description="Selected Image"
    HeightRequest="300"
    HorizontalOptions="Center" />

<Editor
    x:Name="outputText"
    HorizontalOptions="Center"
    WidthRequest="600"
    HeightRequest="300"
    />
```

### OCR Function Implementation

Navigate to the "MainPage.xaml.cs" class file to implement the OCR functionality:

```cs
private async void IOCR(object sender, EventArgs e)
{
    var images = await FilePicker.Default.PickAsync(new PickOptions
    {
        PickerTitle = "Pick image",
        FileTypes = FilePickerFileType.Images
    });
    var path = images.FullPath.ToString();
    OCRImage.Source = path;

    var ocr = new IronTesseract();
    using (var input = new OcrInput(path))
    {
        var result = ocr.Read(input);
        outputText.Text = result.Text;
    }
}
```

## Execution and Output

Upon execution, the interface will prompt selection of an image or PDF. Once a file is selected and processed, the recognized text will appear in the `Editor` control.

IronOCR shows exceptional ability in recognizing complex patterns in images, drawing on its sophisticated, pre-trained models.

## Conclusion and Further Reading

For a deeper understanding of IronOCR's capabilities, especially for reading text from images, visit this detailed [tutorial](https://ironsoftware.com/csharp/ocr/tutorials/how-to-read-text-from-an-image-in-csharp-net/).

IronOCR is free for development and offers affordable licensing options starting from the basic light license. Explore the pricing details [here](https://ironsoftware.com/csharp/ocr/licensing/).