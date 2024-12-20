# Installing IronOCR Using the Automated Installer

***Based on <https://ironsoftware.com/how-to/ironocr-installer/>***


## Download and Execute the Installation Pack

1. Obtain the installation package **[here](https://ironsoftware.com/csharp/ocr/packages/IronOcrInstaller.zip)** and run the downloaded file.
2. Ensure to read and agree to the license terms:
![license-agreement-image](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/license-agreement.webp)

3. Progress through the installation steps and select `Install`:
![license-install](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/license-install.webp)
4. After reviewing the information page, press `Next` to proceed:
![license information](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/license-information.webp)
5. Hit `Finish` to complete the setup process:
![license complete](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/license-complete.webp)

## Update Environment Variables on Windows 11

Note that changes to Environment Variables only come into effect after a system restart. Normally, these changes are applied automatically by the installer, but manual adjustments may be needed if automatic settings fail:

1. Use the `Windows+R` keys to open the "Run" dialog and input `sysdm.cpl` in the "Open" box:
![run program win11](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/run-program-win11.webp)
2. In the resulting `System Properties` dialog, go to the `Advanced` tab and select the `Environment Variables...` button:
![system properties win11](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/system-properties-win11.webp)
3. You can add or modify variables here. Use `User Variables` for changes specific to your login, and `System Variables` for those that affect the entire system.
![environment variables window](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/environment-variables-window.webp)
4. Create or modify the variable for IronOCR.
5. Set `Variable Name` to `IRONOCR_INSTALL_DIR` and `Variable Value` to `C:\Program Files (x86)\IronSoftware\IronOcr`
![edit user variable win11](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/edit-user-variable.webp)
6. Reboot your computer to apply these changes.

## Update Environment Variables on Windows 10

You must restart your system to apply any changes to Environment Variables. Follow these steps if they are not set automatically by the installer:

1. Right-click the Windows icon on the taskbar and select `System`.
2. In the `Settings` interface that appears, go to `Related Settings`->`Advanced System Settings`
3. Find the `Environment Variables...` button in the `Advanced` tab:
![system properties win10](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/system-properties-win10.webp)
4. Here, you can add or edit variables. `User Variables` adjust settings for individual users, whereas `System Variables` alter settings across the entire system.
![environment variables window](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/environment-variables-window.webp)
5. Adjust or add the IronOCR variable by setting the `Variable Name` to `IRONOCR_INSTALL_DIR` and the `Variable Value` to `C:\Program Files (x86)\IronSoftware\IronOcr`
6. Restart your computer to activate these new settings.