# Implementing OCR in .NET MAUI for iOS Devices

***Based on <https://ironsoftware.com/how-to/setup-ios/>***


<div class="container-fluid">
    <div class="row">
        <div class="col-md-2">
            <img src="https://ironsoftware.com/img/platforms/h74/ios.svg">
        </div>
    </div>
</div>

.NET MAUI, the evolution of Xamarin.Forms, enables developers to build applications for Android, iOS, macOS, and Windows from a single codebase. This framework focuses on streamlining the development of native user interfaces across multiple platforms.

The **IronOcr.iOS package** introduces OCR functionality exclusively for iOS platforms!

## IronOCR iOS Package

The **IronOcr.iOS package** specifically caters to enabling OCR capabilities on iOS devices within .NET multi-platform projects. There's no need to install the standard IronOCR package.

```shell
PM > Install-Package IronOcr.iOS
```

<link rel="stylesheet" type="text/css" href="https://ironsoftware.com/front/css/content__install-components__extended.css" media="print" onload="this.media='all'; this.onload=null;">
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
    <div class="nuget-link">nuget.org/packages/IronOcr.iOS/</div>
    </div>
</div>

## Starting a New .NET MAUI Project

In Visual Studio, choose to create a new .NET MAUI App under the Multiplatform category.

![Initialize a .NET MAUI App project](https://ironsoftware.com/static-assets/ocr/how-to/setup-ios/create-maui-app.webp)

## Adding IronOCR.iOS Library

Incorporate the IronOcr.iOS library in a few steps using NuGet.

1. Right-click on "Dependencies > Nuget" within Visual Studio and choose "Manage NuGet Packages...".
2. Navigate to the "Browse" tab and type "IronOcr.iOS" in the search bar.
3. Click to add the "IronOcr.iOS" package.

![Incorporate IronOcr.iOS package](https://ironsoftware.com/static-assets/ocr/how-to/setup-ios/download-package.webp)

Adjust the csproj file to ensure the package is only included for iOS targets:

1. Right-click the *.csproj file in your project and choose "Edit Project File".
2. Add a conditional statement:
    ```xml
    <ItemGroup Condition="$(TargetFramework.Contains('ios')) == true">
    </ItemGroup>
    ```
3. Insert the "IronOcr.iOS" PackageReference within the newly created ItemGroup.

To avoid conflicting with Android platforms, consider the [IronOcr.Android](https://nuget.org/packages/IronOcr.Android/) specifically for Android.

## Modify "MainPage.xaml"

Update your XAML to include a file import button and a label to display OCR results:

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

## Configure "MainPage.xaml.cs"

Create an `IronTesseract` instance at class level, not within method scope, to ensure stability. Use the `FilePicker.PickAsync` to choose a file and read it:

```cs
using IronOcr;

namespace MAUIIronOCRiOSSample;

public partial class MainPage : ContentPage
{
    // Instantiate IronTesseract at class level
    private IronTesseract ocrTesseract = new IronTesseract();

    public MainPage()
    {
        InitializeComponent();
        IronOcr.License.LicenseKey = "IRONOCR-MYLICENSE-KEY-1EF01";
    }

    private async void ReadFileOnImport(object sender, EventArgs e)
    {
        try
        {
            var options = new PickOptions
            {
                PickerTitle = "Please select a file"
            };

            var result = await FilePicker.PickAsync(options);
            if (result != null)
            {
                using var stream = await result.OpenReadAsync();

                using var ocrInput = new OcrInput();
                ocrInput.LoadImage(stream);

                var ocrResult = ocrTesseract.Read(ocrInput);
                OutputText.Text = ocrResult.Text;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
    }
}
```

The package is currently designed for images only, not PDFs.

### Executing the Project

Prepare and run your project on an iOS Simulator to execute OCR.

<img src="https://ironsoftware.com/static-assets/ocr/how-to/setup-ios/mauiProjectRun.gif" alt="Execute .NET MAUI App project" class="img-responsive add-shadow" style="margin-bottom: 30px;"/>

## Download Complete .NET MAUI App Project

[Download the full project here.](https://ironsoftware.com/static-assets/ocr/how-to/setup-ios/MAUIIronOCRiOSSample.zip)

## Configuring IronOcr.iOS in Avalonia

The integration into Avalonia mirrors the steps for MAUI, requiring the installation of [.NET SDK 8.0.101](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) alongside the latest version.

For OCR capabilities on Android, please refer to the article, "[How to Perform OCR on Android in .NET MAUI](https://ironsoftware.com/csharp/ocr/how-to/setup-android/)"