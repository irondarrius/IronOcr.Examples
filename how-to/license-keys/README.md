# Utilizing IronOCR License Keys

***Based on <https://ironsoftware.com/how-to/license-keys/>***


## Acquiring a License Key

To deploy your projects live with IronOCR without any limitations or imposed watermarks, obtaining a license key is essential.

Secure a license through [this link](https://ironsoftware.com/csharp/ocr/licensing/) or opt for a [free 30-day trial key](#trial-license).

<hr class="separator">

## Step 1: Obtain the Latest IronOCR Release

### Installation via DLL

Access and download the [IronOcr DLL package](https://ironsoftware.com/csharp/ocr/packages/IronOcr.zip) directly to your computer.

### Installation via NuGet

As an alternative, IronOCR can be installed via NuGet:

```shell
Install-Package IronOcr
```

<hr class="separator">

## Step 2: Implementing Your License Key

### Implement Your License Key Programmatically

To incorporate your IronOCR license key, insert the following line at the beginning of your application, prior to utilizing IronOCR:

```cs
IronOcr.License.LicenseKey = "IRONOCR-MYLICENSE-KEY-1EF01";
```

To confirm that your license is active, use `IronOcr.License.IsValidLicense(string LicenseKey)` or check the `IronOcr.License.IsLicensed` property.

<hr class="separator">

### Setting Your License Key Via Web.Config or App.Config

For a global application-wide key setup via Web.Config or App.Config, integrate the following in your configuration file under appSettings:

```xml
<configuration>
....
  <appSettings>
    <add key="IronOcr.LicenseKey" value="IRONOCR-MYLICENSE-KEY-1EF01"/>
  </appSettings>
....
</configuration>
```

Currently, there is a licensing compatibility issue with IronOcr versions from [2023.4.13](https://www.nuget.org/packages/IronOcr/2023.4.13) to [2024.3.4](https://www.nuget.org/packages/IronOcr/2024.3.4) in:
- **ASP.NET** projects
- **.NET Framework version 4.6.2 and above**

If experiencing issues with license recognition in `Web.config`, please consult the [guide on setting up license in Web.config](https://ironsoftware.com/csharp/ocr/troubleshooting/license-key-web.config/).

<hr class="separator">

### Applying Your Key With a .NET Core appsettings.json File

To globally set your key in a .NET Core application:

- Introduce a JSON file named *appsettings.json* in your project's root directory.
- Add a 'IronOcr.LicenseKey' entry in your JSON configuration. Use your license key as the value.
- Ensure the file property *Copy to Output Directory* is set to *Copy always*.
- Confirm the `IronOcr.License.IsLicensed` property returns `true`.

Example *appsettings.json* file:

```json
{
	"IronOcr.LicenseKey":"IRONOCR-MYLICENSE-KEY-1EF01"
}  
```

<hr class="separator">

## Step 3: Validate Your Key

Check the correct installation of your license key:

```cs
bool result = IronOcr.License.IsValidLicense("IRONOCR-MYLICENSE-KEY-1EF01");
```

<hr class="separator">

## Step 4: Launch Your Project

Jumpstart your project by following our [Getting Started with IronOCR guide](https://ironsoftware.com/csharp/ocr/docs/).

<hr class="separator">

## Need Assistance?

For additional support, contact us at [support@ironsoftware.com](mailto:support@ironsoftware.com).