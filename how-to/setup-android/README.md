# Implementing OCR on Android using .NET MAUI

![Android Platform](https://ironsoftware.com/img/platforms/h74/android.svg)

.NET MAUI, which stands for Multi-platform App UI, is a continuation and enhancement of Xamarin.Forms. It enables developers to build apps for Android, iOS, macOS, and Windows from a single .NET-based codebase. One of the goals of .NET MAUI is to ease the creation of scalable and maintainable native user interfaces across multiple platforms.
The **IronOcr.Android package** extends OCR capabilities to Android applications specifically.

## Integration of IronOCR into Android Projects

The **IronOcr.Android package** facilitates the implementation of OCR in Android environments through .NET MAUI, eliminating the need for the standard IronOCR package.

```shell
PM > Install-Package IronOcr.Android
```

<div class="products-download-section">
    <div class="js-modal-open product-item nuget" style="width: fit-content; margin-left: auto; margin-right: auto;" data-modal-id="trial-license-after-download">
        <div class="product-image">
            <img class="img-responsive add-shadow" alt="C# NuGet Library for PDF" src="https://ironsoftware.com/img/nuget-logo.svg">
        </div>
        <div class="product-info">
            <h3>Install using <span>NuGet</span></h3>
        </div>
        <div class="copy-nuget-section">
            <div class="copy-nuget-row">
            <pre class="install-script">Install-Package IronOcr.Android</pre>
            <div class="copy-button">
                <button class="btn btn-default copy-nuget-script" type="button" aria-label="Copy the Package Manager command">
                <span class="far fa-copy"></span>
                </button>
            </div>
        </div>
    </div>
    <div class="nuget-link">nuget.org/packages/IronOcr.Android/</div>
    </div>
</div>

## Initiating a New .NET MAUI Project

Start by launching Visual Studio and selecting "Create a new project". In the project type field, search for MAUI, select ".NET MAUI App" and proceed by clicking "Next".

![Create .NET MAUI App project](https://ironsoftware.com/static-assets/ocr/how-to/setup-android/create-maui-app.webp)

## Adding IronOCR.Android Library

You can add the library in different ways, with the simplest being through NuGet management:

1. Within Visual Studio, navigate to "Dependencies" via right-click and choose "Manage NuGet Packages...".
2. Click on the "Browse" tab and enter "IronOcr.Android".
3. Locate and select "IronOcr.Android" from results, then press "Install".

![Download IronOcr.Android package](https://ironsoftware.com/static-assets/ocr/how-to/setup-android/download-package.webp)

Adjust the `.csproj` file to ensure the package only targets Android platforms:

1. Right-click the project and choose "Edit Project File".
2. Insert this line into a new `ItemGroup` with condition:
    ```xml
    <ItemGroup Condition="$(TargetFramework.Contains('android')) == true">
    </ItemGroup>
    ```
3. Encapsulate the `IronOcr.Android` package reference within the newly created `ItemGroup`.

This strategy prevents unintended use on non-Android platforms, such as iOS. For iOS, use the [IronOcr.iOS](https://nuget.org/packages/IronOcr.iOS/) package.

## Setting Up the Activity Classes

### Main Activity Configuration

Open the `MainActivity.cs` file under Platforms -> Android and include the initialization method for OCR:

```cs
namespace MAUIIronOCRAndroidSample
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true)]
    public class MainActivity : MauiAppCompatActivity
    {
        public MainActivity()
        {
            IronTesseract.Initialize(this);
        }
    }
}
```

### Editing the Main Page Layout

Modify the `MainPage.xaml` to include interactive elements like a button and a label for displaying OCR results:

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
            Margin="20, 20, 20, 10" />

        <ScrollView
            Grid.Row="1"
            BackgroundColor="LightGray"
            Padding="10"
            Margin="10">
            <Label x:Name="OutputText"/>
        </ScrollView>
    </Grid>
</ContentPage>
```

### Implementing OCR Logic in MainPage.xaml.cs

Implement the reading and OCR process in the `MainPage.xaml.cs`. Ensure the `IronTesseract` is instantiated once to avoid redundancy and errors:

```cs
using IronOcr;

namespace MAUIIronOCRAndroidSample;

public partial class MainPage : ContentPage
{
    private IronTesseract ocrTesseract = new IronTesseract();

    public MainPage()
    {
        InitializeComponent();
        IronOcr.License.LicenseKey = "IRONOCR.MYLICENSE.KEY";
    }

    private async void ReadFileOnImport(object sender, EventArgs e)
    {
        var options = new PickOptions { PickerTitle = "Please select a file" };
        var result = await FilePicker.PickAsync(options);
        if (result != null)
        {
            using var stream = await result.OpenReadAsync();
            using var ocrInput = new OcrInput(stream);
            var ocrResult = ocrTesseract.Read(ocrInput);
            OutputText.Text = ocrResult.Text;
        }
    }
}
```

### Project Execution

Deploy the project to conduct OCR tasks specifically on Android devices:

![Execute .NET MAUI App project](https://ironsoftware.com/static-assets/ocr/how-to/setup-android/mauiProjectRun.gif)

### Download the Complete .NET MAUI App Project

Download the complete configured project, ready to open in Visual Studio as a .NET MAUI App project.

[Download here](https://ironsoftware.com/static-assets/ocr/how-to/setup-android/MAUIIronOCRAndroidSample.zip)

For using IronOcr.Android in other frameworks such as Avalonia, or to extend OCR functionality to iOS, reference other relevant guides available on Iron Software's website.