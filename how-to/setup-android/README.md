***Based on <https://ironsoftware.com/how-to/setup-android/>***

/h74/android.svg">
        </div>
    </div>
</div>

.NET MAUI (Multi-platform App UI) represents an advancement from the Xamarin.Forms framework, enabling developers to craft cross-platform applications for Android, iOS, macOS, and Windows with .NET. It streamlines the creation of native interfaces that are deployable across various platforms.

The **IronOcr.Android package** adds OCR capabilities to Android projects built with .NET MAUI!

## IronOCR Android Package

The **IronOcr.Android package** equips Android devices with OCR functionalities within .NET cross-platform solutions. Importing the standard IronOCR library separately is not required.

```shell
PM > Install-Package IronOcr.Android
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

## Create a .NET MAUI Project

Launch Visual Studio and opt for "Create a new project". Search for MAUI, select .NET MAUI App and proceed with "Next".

![Create .NET MAUI App project](https://ironsoftware.com/static-assets/ocr/how-to/setup-android/create-maui-app.webp)

## Integrate IronOCR.Android Library

You can incorporate this library in various ways, with NuGet being the most straightforward approach.

1. Within Visual Studio, right-click on "Dependencies" and choose "Manage NuGet Packages...".
2. Navigate to the "Browse" tab and enter "IronOcr.Android" in the search bar.
3. Click on the "IronOcr.Android" package, then select "Install".

![Download IronOcr.Android package](https://ironsoftware.com/static-assets/ocr/how-to/setup-android/download-package.webp)

To avoid complications on other platforms, adapt the csproj file to include this package only for the Android platform:

1. Right-click on the project and choose "Edit Project File".
2. Add a new ItemGroup element structured as follows:
    ```xml
    <ItemGroup Condition="$(TargetFramework.Contains('android')) == true">
    </ItemGroup>
    ```
3. Relocate the "IronOcr.Android" PackageReference to the newly formed ItemGroup.

This configuration ensures that the "IronOcr.Android" package is utilized solely for the Android platform and not on platforms like iOS (for iOS, consider installing [IronOcr.iOS](https://nuget.org/packages/IronOcr.iOS/)).

## Modify "MainActivity.cs"

- Access the file "MainActivity.cs" by navigating to Platforms -> Android.
- Incorporate the `MainActivity` constructor and call the `Initialize` method within it.

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

## Update "MainPage.xaml"

Adjust the XAML layout to feature a button and a label that will display the OCR results. Here’s how you might set it up:

```xml
<?xml version="1.0" encoding="utf-8"?>
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

## Revise "MainPage.xaml.cs"

Initially, establish an instance of the IronTesseract class. It's crucial to initiate the IronTesseract instance once per class to avoid inefficiencies and potential execution anomalies.

Next, utilize the `FilePicker.PickAsync` function to choose a file, open a reading stream from the **FileResult**, configure a new OcrInput instance, load the image, perform OCR, and then display the resultant text on a label.

It's important to note that the current implementation exclusively supports image files. The package does not presently accommodate PDF files; therefore, any settings related to PDF should be kept deactivated by default.

```cs
using IronOcr;

namespace MAUIIronOCRAndroidSample;

public partial class MainPage : ContentPage
{
    // Ensure IronTesseract is initialized just once per class
    private IronTesseract ocrTesseract = new IronTesseract();

    public MainPage()
    {
        InitializeComponent();
        IronOcr.License.LicenseKey = "IRONOCR.MYLICENSE.KEY.1EF01";  // Apply License Key
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
                OutputText.Text = ocrResult.Text;  // Display OCR results
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);  // Handle exceptions
        }
    }
}
```

Upon adjusting the .csproj file as previously described, you ensure that the project is solely built for Android, as only the Android package was incorporated.

#### Execute the Project

Follow these steps to run the project and perform OCR operations.

<img src="https://ironsoftware.com/static-assets/ocr/how-to/setup-android/mauiProjectRun.gif" alt="Execute .NET MAUI App project" class="img-responsive add-shadow" style="margin-bottom: 30px;"/>

## Download the Complete .NET MAUI App Project

Access the complete source code for this guide. It comes as a zipped file, ready to be opened in Visual Studio as a .NET MAUI App project.

[Download the project here.](https://ironsoftware.com/static-assets/ocr/how-to/setup-android/MAUIIronOCRAndroidSample.zip)

## Utilizing IronOcr.Android in Avalonia

Just like in MAUI, you can implement IronOcr.Android in an Avalonia project following the instructions outlined above.

For details on integrating OCR functionalities on iOS with .NET MAUI, refer to the article: "[How to Perform OCR on iOS in .NET MAUI](https://ironsoftware.com/csharp/ocr/how-to/setup-ios/)"