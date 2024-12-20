# How to Implement OCR in Android Using .NET MAUI

***Based on <https://ironsoftware.com/how-to/setup-android/>***


<div class="container-fluid">
    <div class="row">
        <div class="col-md-2">
            <img src="https://ironsoftware.com/img/platforms/h74/android.svg">
        </div>
    </div>
</div>

.NET MAUI (Multi-platform App UI) represents an advancement over Xamarin.Forms, facilitating the development of cross-platform applications for Android, iOS, macOS, and Windows with .NET. The goal of .NET MAUI is to streamline the creation of native interfaces that are deployable across various platforms.

The **IronOcr.Android package** introduces OCR capabilities to Android devices.

## IronOCR Android Package Installation

**IronOcr.Android** allows the integration of OCR technologies into Android applications through .NET cross-platform projects, making the standard IronOCR library unnecessary.

```shell
PM > Install-Package IronOcr.Android
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
            <pre class="install-script">Install-Package IronOcr.Android</pre>
            <div class="copy-button">
                <button class="btn btn-default copy-nuget-script" type="button" data-toggle="popover" data-placement="bottom" data-content="Copied." aria-label="Copy the Package Manager command" data-original-title="" title="">
                <span class="far fa-copy"></span>
                </button>
            </div>
        </div>
    </div>
    <div class="nuget-link">nuget.org/packages/IronOcr.Android/</div>
    </div>
</div>

## Starting a New .NET MAUI Project

Launch Visual Studio and select "Create a new project". Look for MAUI, choose the .NET MAUI App template, and proceed by clicking "Next".

![Set up a .NET MAUI App project](https://ironsoftware.com/static-assets/ocr/how-to/setup-android/create-maui-app.webp)

## Integrating IronOCR.Android

Adding the library is straightforward using NuGet.

1. In Visual Studio, right-click "Dependencies" and choose "Manage NuGet Packages ...".
2. Navigate to the "Browse" tab and look up "IronOcr.Android".
3. Choose the "IronOcr.Android" package and press "Install".

![Install IronOcr.Android library](https://ironsoftware.com/static-assets/ocr/how-to/setup-android/download-package.webp)

To ensure the library only affects Android builds:

1. Right-click on the project and select "Edit Project File".
2. Add a new ItemGroup with a condition for Android platforms:
    ```xml
    <ItemGroup Condition="$(TargetFramework.Contains('android')) == true">
    </ItemGroup>
    ```
3. Transfer the `PackageReference` for "IronOcr.Android" into this newly created ItemGroup.

This strategy prevents the "IronOcr.Android" package from interfering with other platforms' builds, such as iOS, for which you should use [IronOcr.iOS](https://nuget.org/packages/IronOcr.iOS/).

## Modifying "MainActivity.cs"

Open the "MainActivity.cs" by navigating to Platforms -> Android, add the `MainActivity` constructor and call `Initialize` on `IronTesseract`.

```cs
namespace MAUIIronOCRAndroidSample
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        public MainActivity()
        {
            IronTesseract.Initialize(this);
        }
    }
}
```

## Configuring "MainPage.xaml"

Modify the XAML to include a button and a label for displaying OCR results:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="MAUIIronOCRAndroidSample.MainPage">

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

## Updating "MainPage.xaml.cs"

Create and configure `IronTesseract` instance. Use `FilePicker.PickAsync` to select an image file, perform OCR, and display the text:

```cs
using IronOcr;

namespace MAUIIronOCRAndroidSample;

public partial class MainPage : ContentPage
{
    private IronTesseract ocrTesseract = new IronTesseract();

    public MainPage()
    {
        InitializeComponent();
        IronOcr.License.LicenseKey = "IRONOCR.MYLICENSE.KEY.1EF01";
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

#### Execute the Project

Run the project to perform OCR on Android.

<img src="https://ironsoftware.com/static-assets/ocr/how-to/setup-android/mauiProjectRun.gif" alt="Execute .NET MAUI App project" class="img-responsive add-shadow" style="margin-bottom: 30px;"/>

## Download .NET MAUI App Project

Download the full project code available as a zipped file for .NET MAUI App projects from Visual Studio.

[Download the complete project here.](https://ironsoftware.com/static-assets/ocr/how-to/setup-android/MAUIIronOCRAndroidSample.zip)

## Usage in Avalonia

Similar to MAUI, the IronOcr.Android package can be incorporated into Avalonia for OCR functionalities.

For OCR capabilities on iOS, learn more from this detailed guide: "[How to Implement OCR on iOS in .NET MAUI](https://ironsoftware.com/csharp/ocr/how-to/setup-ios/)"