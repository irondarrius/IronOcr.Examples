# Utilizing IronOCR License Keys

***Based on <https://ironsoftware.com/how-to/license-keys/>***


## Acquiring a License Key

Incorporating an IronOCR license key into your project allows for watermark-free deployment and unlimited operation.

You may [purchase a license here](https://ironsoftware.com/csharp/ocr/licensing/) or obtain a [free 30-day trial key](https://ironsoftware.com/csharp/ocr/licensing/).

<hr class="separator">

## Step 1: Acquire the Latest IronOCR Version

### Installation via DLL

Directly download the [IronOcr DLL](https://ironsoftware.com/csharp/ocr/packages/IronOcr.zip) to your system.

### Installation via NuGet

As an alternative, IronOCR can be installed using [NuGet](https://www.nuget.org/packages/IronOcr/).

```shell
Install-Package IronOcr
```

<hr class="separator">

## Step 2: Implement Your License Key

### Coding Your License Key

Inject this snippet early in your application's startup sequence, before utilizing IronOCR.

```cs
IronOcr.Licensing.LicenseKey = "IRONOCR-MYLICENSE-KEY-1EF01";
```

Confirm your software's licensing status with `IronOcr.Licensing.IsValidLicense(string LicenseKey)` or check the `IronOcr.Licensing.IsLicensed` attribute.

<hr class="separator">

### Integrating License Key via Web.Config or App.Config

To assign a key across your entire application via Web.Config or App.Config, embed the following entry in your config file under appSettings.

```xml
<configuration>
....
  <appSettings>
    <add key="IronOcr.LicenseKey" value="IRONOCR-MYLICENSE-KEY-1EF01"/>
  </appSettings>
....
</configuration>
```

Current compatibility issues exist between IronOCR versions [2023.4.13](https://www.nuget.org/packages/IronOcr/2023.4.13) and [2024.3.4](https://www.nuget.org/packages/IronOcr/2024.3.4) for projects using:
- **ASP.NET**
- **.NET Framework versions 4.6.2 or newer**

If the key is not recognized from a Web.config file, please consult the [Web.config licensing troubleshooting guide](https://ironsoftware.com/csharp/ocr/troubleshooting/license-key-web.config/).

<hr class="separator">

### Settings for .NET Core in appsettings.json File

Globally set your license key in your .NET Core application:

- Add a JSON file named `appsettings.json`
- Insert an `IronOcr.LicenseKey`
- Confirm through file properties with *Copy to Output Directory: Copy always*
- Verify with `IronOcr.License.IsLicensed`.

Example file: *appsettings.json*
```json
{
	"IronOcr.LicenseKey":"IRONOCR-MYLICENSE-KEY-1EF01"
}
```

<hr class="separator">

## Step 3: Verifying Your License Key

Ensure that the licensing key was successfully implemented.

```cs
bool result = IronOcr.License.IsValidLicense("IRONOCR-MYLICENSE-KEY-1EF01");
```

<hr class="separator">

## Step 4: Kick Off Your Project

Explore our guide on how to [Begin with IronOCR](https://ironsoftware.com/csharp/ocr/docs/).

<hr class="separator">

## Need Help?

Don't hesitate to contact [support@ironsoftware.com](mailto:support@ironsoftware.com) for support or inquiries.