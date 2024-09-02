# Utilizing IronOCR License Keys

## Acquiring a License Key

Integrating an IronOCR license key into your project enables live deployment without any limitations or watermark impositions.

You can [purchase a license here](https://ironsoftware.com/csharp/ocr/licensing/) or obtain a [free 30-day trial key here](https://ironsoftware.com/csharp/ocr/licensing/).

---

## Step 1: Acquire the Latest Version of IronOCR

### Installation via DLL

Obtain the [IronOcr DLL file](https://ironsoftware.com/csharp/ocr/packages/IronOcr.zip) directly onto your local system.

### Installation via NuGet

As an alternative, the IronOCR library can be installed using [NuGet](https://www.nuget.org/packages/IronOcr/).

```shell
Install-Package IronOcr
```

---

## Step 2: Implement Your License Key

### Coding the License Key

Insert the following code snippet at the start of your application, prior to utilizing IronOCR.

```cs
IronOcr.License.LicenseKey = "IRONOCR-MYLICENSE-KEY-1EF01";
```

Verify the licensing status using `IronOcr.License.IsValidLicense(string LicenseKey)` or by accessing the `IronOcr.License.IsLicensed` property.

---

### Configuring the License Key through Web.Config or App.Config

For a global application key configuration, include this setting in your Web.Config or App.Config's appSettings section.

```xml
<configuration>
....
  <appSettings>
    <add key="IronOcr.LicenseKey" value="IRONOCR-MYLICENSE-KEY-1EF01"/>
  </appSettings>
....
</configuration>
```

Note a licensing compatibility issue between IronOCR versions [2023.4.13](https://www.nuget.org/packages/IronOcr/2023.4.13) and [2024.3.4](https://www.nuget.org/packages/IronOcr/2024.3.4) concerning:
- **ASP.NET** projects
- **.NET Framework version >= 4.6.2**

Licenses set in a `Web.config` file may not be recognized. For further details, visit '[Setting License Key in Web.config](https://ironsoftware.com/csharp/ocr/troubleshooting/license-key-web.config/)'.

---

### Configuring the License Key in a .NET Core appsettings.json file

To globally set your key in a .NET Core environment:

- Create an `appsettings.json` file in your project's root directory.
- Add the `IronOcr.LicenseKey` entry with your license key value.
- Set *Copy to Output Directory: Copy always* in the file properties.
- Confirm the licensing status with `IronOcr.License.IsLicensed` returning `true`.

Example `appsettings.json` configuration:
```json
{
  "IronOcr.LicenseKey": "IRONOCR-MYLICENSE-KEY-1EF01"
}
```

---

## Step 3: Validate Your Key

Ensure your license key is functioning correctly.

```cs
bool result = IronOcr.License.IsValidLicense("IRONOCR-MYLICENSE-KEY-1EF01");
```

---

## Step 4: Begin Your Project

Kick-start your project by following our [IronOCR Getting Started Tutorial](https://ironsoftware.com/csharp/ocr/docs/).

---

## Need Assistance?

Should you have any inquiries, feel free to contact [support@ironsoftware.com](mailto:support@ironsoftware.com).