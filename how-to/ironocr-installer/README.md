# Installation Guide for IronOCR

## How to Install IronOCR with the Provided Installer

1. Initiate the installation by downloading the installer from **[this link](https://ironsoftware.com/csharp/ocr/packages/IronOcrInstaller.zip)** and then execute it.
2. Make sure to read and agree to the license terms:
   ![View License Agreement](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/license-agreement.webp)

3. Proceed following the displayed instructions and select `Install`:
   ![Install](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/license-install.webp)
4. Go through the Information page, then click on `Next` to proceed:
   ![License Information](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/license-information.webp)
5. Tap `Finish` to conclude the setup process:
   ![Installation Complete](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/license-complete.webp)

## Updating Environment Variables on Windows 11

For the modifications to environment variables to fully integrate, a system restart is necessary. Although the installer typically handles this, manual steps might be required if the automatic setup fails:

1. Hit the `Windows+R` keys to trigger the "Run" dialog box and type `sysdm.cpl` into the "Open" field:
   ![Run Dialog](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/run-program-win11.webp)
2. In the `System Properties` dialog that pops up, switch to the `Advanced` tab and click on `Environment Variables...`:
   ![System Properties](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/system-properties-win11.webp)
3. Utilize this interface to either add or modify variables. You can update `User Variables` for individual user adjustments or `System Variables` for changes affecting the entire system.
   ![Environment Variables Setup](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/environment-variables-window.webp)
4. Add or modify the IronOCR variable.
5. Specify the `Variable Name` as `IRONOCR_INSTALL_DIR` and the `Variable Value` as `C:\Program Files (x86)\IronSoftware\IronOcr`:
   ![Edit Variable](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/edit-user-variable.webp)
6. Restart your computer to apply the environmental changes.

## Configuring Environment Variables on Windows 10

Adjusting environment variables also requires a system restart to take effect. Follow these steps if the installer does not set them automatically:

1. Right click on the Windows icon on the taskbar and select `System`.
2. From the `Settings` window, go to `Related Settings`->`Advanced System Settings`
3. In the `Advanced` tab, locate and click on `Environment Variables...`:
   ![Windows 10 System Properties](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/system-properties-win10.webp)
4. This window allows the addition or modification of `User Variables` (specific to your profile) and `System Variables` (affecting the entire system).
   ![Environment Variables Interface](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/environment-variables-window.webp)
5. Create or update the IronOCR variable as needed, setting the `Variable Name` as `IRONOCR_INSTALL_DIR` and the `Variable Value` as `C:\Program Files (x86)\IronSoftware\IronOcr`
6. Restart the computer to ensure the changes to environment variables are activated.