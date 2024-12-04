# Conducting OCR on iOS with .NET MAUI

***Based on <https://ironsoftware.com/how-to/setup-ios/>***


<div class="container-fluid">
    <div class="row">
        <div class="col-md-2">
            <img src="https://ironsoftware.com/img/platforms/h74/ios.svg">
        </div>
    </div>
</div>

.NET MAUI (Multi-platform App UI) represents an advanced iteration of the Xamarin.Forms framework, crafted to develop cross-platform applications for Android, iOS, macOS, and Windows using .NET. It endeavors to streamline the development of native interfaces across various platforms.

The **IronOcr.iOS package** provides powerful OCR capabilities specifically tailored for iOS platforms.

## IronOCR iOS Integration

Utilizing the **IronOcr.iOS package**, iOS devices can leverage OCR features directly through .NET cross-platform development, without the need for the standard IronOCR library.

```shell
PM > Install-Package IronOcr.iOS
```

<div class="products-download-section">
    <div class="js-modal-open product-item nuget" style="width: fit-content; margin-left: auto; margin-right: auto;" data-modal-id="trial-license-after-download">
        <div class="product-image">
            <img class="img-responsive add-shadow" alt="C# NuGet Library for PDF" src="https://ironsoftware.com/img/nuget-logo.svg">
        </div>
        <div class="product-info">
            <h3>Install via <span>NuGet</span></h3>
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

## Starting a .NET MAUI Project

When creating a new project, choose .NET MAUI App under the Multiplatform category.

![Initiate .NET MAUI App project](https://ironsoftware.com/static-assets/ocr/how-to/setup-ios/create-maui-app.webp)

## How to Introduce IronOCR.iOS

Incorporating the IronOCR.iOS library is straightforward, especially through NuGet.

1. Within Visual Studio, navigate to "Dependencies > Nuget" by right-clicking and choosing "Manage NuGet Packages ...".
2. Click on the "Browse" tab, then search for and select "IronOcr.iOS".
3. Hit "Add Package" to incorporate the package into your project.

![Incorporate the IronOcr.iOS package](https://ironsoftware.com/static-assets/ocr/how-to/setup-ios/download-package.webp)

To ensure compatibility only on iOS, adjust the project file accordingly:

1. Right-click on the project file (*.csproj) and pick "Edit Project File".
2. Insert a new `ItemGroup` with a condition to apply only for iOS targets:
    ```xml
    <ItemGroup Condition="$(TargetFramework.Contains('ios')) == true">
    </ItemGroup>
    ```
3. Place the `PackageReference` for **IronOcr.iOS** within this newly created `ItemGroup`.

## Customize "MainPage.xaml"

Design the XAML layout to include a button and label for displaying OCR results:

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

## Modify "MainPage.xaml.cs"

Develop the logic in the code-behind to handle the OCR processes:

```cs
using IronOcr;

namespace MAUIIronOCRiOSSample;

public partial class MainPage : ContentPage
{
    private IronTesseract ocrTesseract = new IronTesseract(); // Ensure IronTesseract is initialized once per class for optimal performance

    public MainPage()
    {
        InitializeComponent();
    }

    private async void ReadFileOnImport(object sender, EventArgs e)
    {
        var file = await FilePicker.PickAsync(new PickOptions { PickerTitle = "Please select a file" });
        if (file != null)
        {
            using var fileStream = await file.OpenReadAsync();
            using var input = new OcrInput(fileStream);  // Prepare the image file for OCR

            var result = ocrTesseract.Read(input);  // Conduct OCR
            OutputText.Text = result.Text;  // Display results
        }
    }
}
```

Switch to the iOS Simulator and deploy your application to see it in action.

#### Deploy the Application

Learn how to run your newly created OCR application on iOS.

<img src="https://ironsoftware.com/static-assets/ocr/how-to/setup-ios/mauiProjectRun.gif" alt="Demonstration of running the .NET MAUI App" class="img-responsive add-shadow" style="margin-bottom: 30px;"/>

## Obtain the Complete .NET MAUI App Project

Download the full example project, packed as a zipfile, to explore in Visual Studio.

[Access the complete codebase here.](https://ironsoftware.com/static-assets/ocr/how-to/setup-ios/MAUIIronOCRiOSSample.zip)

## Setting Up IronOcr.iOS with Avalonia

The setup of IronOcr.iOS in Avalonia mirrors that in MAUI, but with the necessity of having [.NET SDK 8.0.101](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) ready for successful operation. Following these guidelines, you can incorporate IronOcr.iOS into an Avalonia project.

Explore OCR on Android by referring to: "[How to Perform OCR on Android in .NET MAUI](https://ironsoftware.com/csharp/ocr/how-to/setup-android/)"