# Implementing OCR in iOS Using .NET MAUI

## Introduction to .NET MAUI for iOS

![iOS logo](https://ironsoftware.com/img/platforms/h74/ios.svg)

.NET MAUI, which stands for Multi-platform App UI, is the successor to Xamarin.Forms and is engineered to facilitate the development of cross-platform applications for Android, iOS, macOS, and Windows with .NET. It streamlines the creation of native user interfaces deployable across various platforms.

The **IronOcr.iOS library** is specifically tailored to add OCR capabilities to iOS devices within .NET cross-platform projects, without necessitating the general IronOCR library.

## Installing IronOCR for iOS

You can easily incorporate OCR functionalities into your iOS devices by integrating the **IronOcr.iOS library**. This package can be installed directly via NuGet, negating the need for the standard IronOCR package:

```shell
PM > Install-Package IronOcr.iOS
```

<div class="products-download-section">
    <div class="js-modal-open product-item nuget" style="width: fit-content; margin-left: auto; margin-right: auto;" data-modal-id="trial-license-after-download">
        <div class="product-image">
            <img class="img-responsive add-shadow" alt="C# NuGet Library for PDF" src="https://ironsoftware.com/img/nuget-logo.svg">
        </div>
        <div class="product-info">
            <h3>Install with <span>NuGet</span></h3>
        </div>
        <div class="js-open-modal-ignore copy-nuget-section" data-toggle="tooltip" data-placement="bottom" title="" data-original-title="Click to copy">
            <div class="copy-nuget-row">
                <pre class="install-script">Install-Package IronOcr.iOS</pre>
                <div class="copy-button">
                    <button class="btn btn-default copy-nuget-script" type="button" data-toggle="popover" data-placement="bottom" data-content="Copied." aria-label="Copy the Package Manager command" data-original-title="" title="">
                        <span class="far fa-copy"></span>
                    </button>
                </div>
            </div>
        </div>
    </div>
    <div class="nuget-link">nuget.org/packages/IronOcr.iOS/</div>
</div>

## Starting a New .NET MAUI Project

Select .NET MAUI App under the Multiplatform section to kickstart your project.

![Create a new .NET MAUI App project](https://ironsoftware.com/static-assets/ocr/how-to/setup-ios/create-maui-app.webp)

## Integrating IronOCR.iOS into Your Project

Integration via NuGet is straightforward and can be accomplished as follows:

1. Right-click "Dependencies > Nuget" in Visual Studio and choose "Manage NuGet Packages ...".
2. Navigate to the "Browse" tab and search for "IronOcr.iOS".
3. Select and install the "IronOcr.iOS" package.

![Integrate IronOcr.iOS package into your project](https://ironsoftware.com/static-assets/ocr/how-to/setup-ios/download-package.webp)

Ensure that the IronOcr.iOS package is included only for iOS builds using this approach in your project's csproj file:

```xml
<ItemGroup Condition="$(TargetFramework.Contains('ios')) == true">
    <PackageReference Include="IronOcr.iOS" Version="x.x.x" />
</ItemGroup>
```

## Editing MainPage.xaml

Include a button and a label in your MainPage.xaml to handle file import and display OCR results:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="MAUIIronOCRiOSSample.MainPage">

    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <Button
            Text="Import File"
            Clicked="ReadFileOnImport"
            Grid.Row="0"
            HorizontalOptions="Center"
            Margin="20, 20, 20, 10"/>

        <ScrollView
            Grid.Row="1"
            BackgroundColor="LightGray"
            Padding="10"
            Margin="10, 10, 10, 30">
            <Label x:Name="OutputText"/>
        </ScrollView>
    </Grid>

</ContentPage>
```

## Editing MainPage.xaml.cs for OCR Functionality

Define OCR operations within the MainPage.xaml.cs file effectively, using the IronTesseract class for OCR tasks after picking a file through a user interface:

```cs
using IronOcr;

namespace MAUIIronOCRiOSSample;

public partial class MainPage : ContentPage
{
    private IronTesseract ocrTesseract = new IronTesseract();

    public MainPage()
    {
        InitializeComponent();
        IronOcr.License.LicenseKey = "IRONOCR-MYLICENSE-KEY-1EF01";
    }

    private async void ReadFileOnImport(object sender, EventArgs e)
    {
        var options = new PickOptions { PickerTitle = "Please select a file" };
        var result = await FilePicker.PickAsync(options);
        if (result != null)
        {
            using var stream = await result.OpenReadAsync();
            using var ocrInput = new OcrInput();
            ocrInput.LoadImage(stream);
            var ocrResult = ocrTesseract.Read(ocrInput);
            OutputText.Text = ocrResult.Text;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
    }
}
```

Subsequently, configure your project's build target to the iOS Simulator and execute your app.

#### Visualizing OCR in Action

Running the project on iOS would visually resemble the following:

![Run the project and see OCR in action](https://ironsoftware.com/static-assets/ocr/how-to/setup-ios/mauiProjectRun.gif)

## Downloadable .NET MAUI Project Example

For hands-on practice, download the complete guide's project as a zipped file, directly openable in Visual Studio as a .NET MAUI App project:

[Download .NET MAUI App project](https://ironsoftware.com/static-assets/ocr/how-to/setup-ios/MAUIIronOCRiOSSample.zip)

## Configuring IronOcr.iOS with Avalonia

To employ IronOcr.iOS within an Avalonia project, ensure you have .NET SDK version 8.0.101 installed. Setup steps mirror those in MAUI. 

For insights into applying OCR on Android using .NET MAUI, refer to this article: ["How to Perform OCR on Android in .NET MAUI"](https://ironsoftware.com/csharp/ocr/how-to/setup-android/)