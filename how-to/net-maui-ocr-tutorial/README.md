# .NET MAUI OCR Using IronOCR

***Based on <https://ironsoftware.com/how-to/net-maui-ocr-tutorial/>***


## Introduction

Microsoft unveiled .NET MAUI (Multi-platform App UI), a framework for creating cross-platform applications using the .NET Framework. It enables you to develop code that runs on platforms such as Android, iOS, and Windows from a single codebase, thereby saving time, resources, and effort. Being open-source, the .NET MAUI project source code along with samples is available on [GitHub](https://github.com/dotnet/maui).

This guide will demonstrate how to build an OCR application using the IronOCR library in .NET MAUI, complete with examples.

## IronOCR: .NET OCR library

[IronOCR](https://ironsoftware.com/csharp/ocr/) is a prominent .NET OCR library available as a NuGet package, allowing developers to effortlessly incorporate Optical Character Recognition (OCR) capabilities into their applications. IronOCR ensures that PDF documents are scanned, converting them into searchable and editable text/data without compromising data quality. This utility enables users to quickly locate information within PDF documents and perform necessary modifications.

IronOCR represents the pinnacle of Tesseract technology on any platform, offering enhanced speed, accuracy, and a native DLL/API. It supports all Tesseract versions from Tesseract 3 to Tesseract 5 with a simple installation.

Supporting 125 international languages, IronOCR comes with English pre-installed. Additional languages can easily be added via NuGet or by directly downloading the corresponding DLLs.

## Comparison with Tesseract

Designed specifically for C# developers, IronOCR integrates smoothly with .NET applications, unlike Tesseract, which is a generic OCR library necessitating custom wrappers for use with C#. Moreover, IronOCR surpasses other libraries with superior speed and accuracy, thanks to its advanced AI algorithms.

IronOCR is renowned for its comprehensive documentation and robust technical support, ensuring a smooth experience for developers at all levels.

In terms of accuracy, IronOCR achieves an impressive rate of over 99%, significantly higher than Tesseract's 70.2% to 92.9%. For more insights and comparisons between IronOCR and Tesseract, watch this [YouTube video](https://www.youtube.com/watch?v=2QTEb6x8NJ4).

## Steps to Create an OCR MAUI app

Here are the steps to develop an OCR application using the .NET MAUI framework with IronOCR.

### Prerequisites

Required tools and setups include:

1. Visual Studio 2022 (Latest version)
2. .NET 6 or 7
3. MAUI packages configured in Visual Studio
4. A running .NET MAUI project within Visual Studio

### Install IronOCR

Initiate by installing the IronOCR library through the NuGet Packages Manager Console in Visual Studio as follows:

```shell
Install-Package IronOcr
```

### Frontend Design

Begin by opening the *MainPage.xaml* file to design the application’s frontend.

![.NET MAUI OCR Tutorial Using IronOCR - Figure 1: MainPage.xaml](https://ironsoftware.com/static-assets/ocr/how-to/net-maui-ocr-tutorial/net-maui-ocr-tutorial-1.webp)

Designate a button to select the image or PDF for OCR processing. Additionally, include an `Image` box to display the selected file and an `Editor` control to display the extracted text.

```xml
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

### Code for OCR using IronOCR

Proceed to the "MainPage.xaml.cs" class file to implement the OCR functionality:

![.NET MAUI OCR Tutorial Using IronOCR - Figure 2: MainPage.xaml.cs](https://ironsoftware.com/static-assets/ocr/how-to/net-maui-ocr-tutorial/net-maui-ocr-tutorial-2.webp)

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

The user interface displayed after launching the app allows you to select an image or PDF. Once a file is selected, IronOCR recognizes the content and presents the text within the Editor control, demonstrating high accuracy even with complex images.

![.NET MAUI OCR Tutorial Using IronOCR - Figure 3: OCR Output](https://ironsoftware.com/static-assets/ocr/how-to/net-maui-ocr-tutorial/net-maui-ocr-tutorial-3.webp)

## Conclusion

For additional details on using IronOCR to extract text from images, refer to this comprehensive [tutorial](https://ironsoftware.com/csharp/ocr/tutorials/how-to-read-text-from-an-image-in-csharp-net/).

While IronOCR is free for development, commercial licenses start from a nominal fee. Review the available [pricing plans](https://ironsoftware.com/csharp/ocr/licensing/) for more information.