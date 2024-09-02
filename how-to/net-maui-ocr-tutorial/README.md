# .NET MAUI OCR Utilizing IronOCR

## Introduction

Microsoft has developed .NET MAUI (Multi-platform App UI), a multi-platform framework designed to create applications across several operating systems including Android, iOS, and Windows. It leverages a shared codebase to enhance developer efficiency and resource utilization. .NET MAUI is distributed under an open-source license, allowing developers access to its source code and several sample projects available on [GitHub](https://github.com/dotnet/maui).

This tutorial will demonstrate how to develop OCR applications for .NET MAUI using the IronOCR library, complete with examples.

## IronOCR: .NET OCR Library

[IronOCR](https://ironsoftware.com/csharp/ocr/) is a robust .NET library that supports Optical Character Recognition (OCR), simplifying the integration of OCR into your projects. It allows for the scanning of PDFs into searchable and modifiable text without compromising on data quality. This seamless process is particularly useful for extracting necessary information from documents and permitting adjustments or corrections.

IronOCR stands out, providing an optimal version of the Tesseract engine which is the most advanced on any platform. It delivers better speed, accuracy, and includes a native DLL/API that caters to every version of Tesseract from 3 to 5, simplifying the installation process.

Additionally, IronOCR supports an impressive array of 125 international languages, installing English as the default. Additional languages can be easily acquired via NuGet or direct DLL downloads.

## Comparison with Tesseract

Designed primarily for C# developers, IronOCR integrates flawlessly with .NET applications, in contrast with Tesseract, a generic OCR library that necessitates custom wrappers for C# usage. Beyond integration, IronOCR provides higher accuracy and efficiency through advanced AI algorithms.

IronOCR also comes with extensive documentation and dedicated technical support which assists developers in quickly leveraging its capabilities.

Notably, IronOCR achieves accuracy rates exceeding 99%, significantly higher than Tesseract, which generally scores between 70.2% and 92.9%. Learn more about IronOCR and Tesseract from this [YouTube video](https://www.youtube.com/watch?v=2QTEb6x8NJ4).

## Steps to Create an OCR MAUI App

Here's how to create an OCR app using the .NET MAUI framework with IronOCR.

### Prerequisites

Ensure you have the following before starting:

1. Visual Studio 2022 (Latest version)
2. .NET 6 or 7
3. MAUI packages installed within Visual Studio
4. A .NET MAUI project setup in Visual Studio

### Install IronOCR

Begin by installing the IronOCR library via the NuGet Packages Manager Console. Access the console by right-clicking on the solution explorer and execute the command below:

```shell
Install-Package IronOcr
```

### Frontend Design

Navigate to and open the *MainPage.xaml* file.

<div class="content-img-align-center">
    <img src="https://ironsoftware.com/static-assets/ocr/how-to/net-maui-ocr-tutorial/net-maui-ocr-tutorial-1.webp" alt=".NET MAUI OCR Tutorial Using IronOCR - Figure 1: MainPage.xaml" class="img-responsive add-shadow">
    <p class="content__image-caption content-align">MainPage.xaml</p>
</div>

Place a button in the interface to trigger image or PDF selection for OCR processing. Assign the `IOCR` function to the button's `clicked` property, which you will define later.

```xml
<Button
    x:Name="OCR"
    Text="Click to OCR"
    Clicked="IOCR"
    HorizontalOptions="Center" />
```

Include an `Image` control, named `OCRImage`, to display the chosen file.

```xml
<Image
    x:Name="OCRImage"
    SemanticProperties.Description="Selected Image"
    HeightRequest="300"
    HorizontalOptions="Center" />
```

Add an `Editor` control that will display the OCR extracted text.

```xml
<Editor
    x:Name="outputText"
    HorizontalOptions="Center"
    WidthRequest="600"
    HeightRequest="300"
    />
```

Below is the complete XAML markup for the User Interface.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="IronOCR_MAUI_Test.MainPage">

    <ScrollView>
        <VerticalStackLayout
            Spacing="25"
            Padding="30,0"
            VerticalOptions="Center">
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
        </VerticalStackLayout>
    </ScrollView>

</ContentPage>
```

### OCR Functionality Code

Proceed to the "MainPage.xaml.cs" class file and implement the `IOCR` function as illustrated.

<div class—"content-img-align-center">
    <img src="https://ironsoftware.com/static-assets/ocr/how-to/net-maui-ocr-tutorial/net-maui-ocr-tutorial-2.webp" alt=".NET MAUI OCR Tutorial Using IronOCR - Figure 2: MainPage.xaml.cs" class="img-responsive add-shadow">
    <p class="content__image-caption content-align">MainPage.xaml.cs</p>
</div>

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
    using (var input = new OcrInput())
    {
        input.AddImage(path);
        OcrResult result = ocr.Read(input);
        string text = result.Text;
        outputText.Text = text; 
    }
}
```

## Output

Upon launching the app and selecting an image or PDF, the UI prompts for a file selection.

<div class="content-img-align-center">
    <img src="https://ironsoftware.com/static-assets/ocr/how-to/net-maui-ocr-tutorial/net-maui-ocr-tutorial-3.webp" alt=".NET MAUI OCR Tutorial Using IronOCR - Figure 3: OCR Output" class="img-responsive add-shadow">
    <p class="content__image-caption content-align">OCR Output</p>
</div>

IronOCR then processes the selected image or PDF, rendering the recognized text within the `Editor` control for further actions.

<div class="content-img-align-center">
    <img src="https://ironsoftware.com/static-assets/ocr/how-to/net-maui-ocr-tutorial/net-maui-ocr-tutorial-4.webp" alt=".NET MAUI OCR Tutorial Using IronOCR - Figure 4: OCR Image" class="img-responsive add-shadow">
    <p class="content__image-caption content-align">OCR Image</p>
</div>

IronOCR is capable of accurately processing complex images with significant precision using its sophisticated pre-trained models.

## Conclusion

For more detailed information on utilizing IronOCR to extract text from images, refer to this [tutorial](https://ironsoftware.com/csharp/ocr/tutorials/how-to-read-text-from-an-image-in-csharp-net/) which provides additional guidance.

IronOCR provides a free license for development, with commercial licenses starting at an affordable rate. Review the available plans [here](https://ironsoftware.com/csharp/ocr/licensing/).