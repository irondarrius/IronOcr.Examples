# Installing IronOCR Using the Provided Installer

***Based on <https://ironsoftware.com/how-to/ironocr-installer/>***


## Download and Execute the Installer

1. Obtain the installer by clicking **[here](https://ironsoftware.com/csharp/ocr/packages/IronOcrInstaller.zip)**, then execute the downloaded file.
2. Review and agree to the license terms:
![license-agreement-image](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/license-agreement.webp)

3. Proceed with the installation steps and select `Install`:
![license-install](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/license-install.webp)
4. After reviewing the Information page, press `Next` to proceed:
![license information](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/license-information.webp)
5. Conclude the installation by clicking `Finish`:
![license complete](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/license-complete.webp)

## Updating Environment Variables on Windows 11

It's important to note that modifications to Environment Variables become effective only after a system restart. Although the installer typically handles these updates, you might need to make them manually if necessary:

1. Open the "Run" dialog by pressing `Windows+R`, and type `sysdm.cpl` in the "Open" field:
![run program win11](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/run-program-win11.webp)
2. In the `System Properties` window that pops up, go to the `Advanced` tab and click the `Environment Variables...` button:
![system properties win11](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/system-properties-win11.webp)
3. This window allows you to create new or modify existing `User Variables` and `System Variables`.
![environment variables window](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/environment-variables-window.webp)
4. Next, define or update the variable for IronOCR.
5. Set `Variable Name` to `IRONOCR_INSTALL_DIR` and `Variable Value` to `C:\Program Files (x86)\IronSoftware\IronOcr`:
![edit user variable win11](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/edit-user-variable.webp)
6. Restart your computer to apply these changes.

## Updating Environment Variables on Windows 10

Changes to Environment Variables require a restart to take effect. Follow these instructions if the installer doesn’t automatically update these settings:

1. Right-click the Windows icon on the taskbar and choose `System`.
2. Navigate to `Related Settings` -> `Advanced System Settings` in the `Settings` window.
3. In the `Advanced` tab, locate the `Environment Variables...` button:
![system properties win10](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/system-properties-win10.webp)
4. This section allows for the addition or editing of `User Variables` and `System Variables`.
![environment variables window](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/environment-variables-window.webp)
5. Define or update the IronOCR variable. Set `Variable Name` to `IRONOCR_INSTALL_DIR` and `Variable Value` to `C:\Program Files (x86)\IronSoftware\IronOcr`
6. Reboot your system to enact these changes.