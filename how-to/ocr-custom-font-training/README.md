# C# Custom Font Training for Tesseract 5 (For Windows Users)

Improve the recognition accuracy of the OCR engine with custom fonts using Tesseract 5. This guide explains how to provide training data to Tesseract, which allows the OCR to familiarize itself with unique font characteristics and patterns not typically covered by its default settings.

## Step 1: Obtain the Latest Version of IronOCR

### Install via DLL

To begin, download the [IronOcr DLL](https://ironsoftware.com/csharp/ocr/packages/IronOcr.zip) to your local system.

### Install via NuGet

Alternatively, you can add IronOcr to your project via NuGet:

```shell
Install-Package IronOcr
```

---

## Step 2: Set Up WSL2 and Ubuntu on Windows

Follow this [guide](https://ubuntu.com/tutorials/install-ubuntu-on-wsl2-on-windows-10) to install WSL2 with Ubuntu. Note that custom font training is only possible on Linux at this time.

## Step 3: Install Tesseract 5 on Ubuntu

Install Tesseract and its development libraries by executing these commands:

```bash
sudo apt install tesseract-ocr
sudo apt install libtesseract-dev
```

## Step 4: Acquire Your Desired Font

For this tutorial, we use the AMGDT font, available in both .ttf and .otf formats.

![Example of downloaded font file](https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-font-training/example_of_downloaded_font_file.png)

## Step 5: Mount Your Working Space Disk Drive

Mount your drive, here Drive `D:`, for use as a working space:

```bash
cd /
cd /mnt/d
```

## Step 6: Relocate the Font File to Ubuntu's Font Folders

Navigate to the font directories in Ubuntu; `Ubuntu/usr/share/fonts` and `Ubuntu/usr/local/share/fonts`.

To access the file on Ubuntu, enter `\\\wsl$` in the file explorer's address bar.

![Ubuntu folder directory](https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-font-training/ubutu_folder_directory.png)

### Common Issue: Access Denied to Destination Folder

If you encounter this, utilize the command line for copying:

```bash
cd /
su root
cd c/Users/Admin/Downloads/'AMGDT Regular'
cp 'AMGDT Regular.ttf' /usr/share/fonts
cp 'AMGDT Regular.ttf' /usr/local/share/fonts
su username
```

![Access Denied Issue](https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-font-training/destination_folder_access_denied.png)

## Step 7: Clone the Tesseract Tutorial Repository

The `tesseract_tutorial` repository is available here:

```bash
git clone https://github.com/astutejoe/tesseract_tutorial.git
```

## Step 8: Clone Additional Required Repositories

Within the `tesseract_tutorial` directory, clone the required repositories:

```bash
cd tesseract_tutorial
git clone https://github.com/tesseract-ocr/tesstrain
git clone https://github.com/tesseract-ocr/tesseract
```

## Step 9: Prepare a Data Folder

Create a `data` folder in `tesseract_tutorial/tesstrain` to store output files.

## Step 10: Execute the Training Split Script

Navigate back to `tesseract_tutorial` and run:

```bash
python split_training_text.py
```

### Font Config Warning: Empty Font Directory Name

If you encounter a font directory issue, update `tesseract_tutorial/fonts.conf` with the correct directories and copy it to the appropriate location:

![Font Config Directory Warning](https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-font-training/fontconfig_dir.png.png)

```bash
cp fonts.conf /etc/fonts
```

Ensure the new script includes the font directory settings:

![Font Config Solution](https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-font-training/fontconfig_sol.png)

And add this line:

```python
fontconf_dir = '/etc/fonts'
```

## Step 11: Enhance Your Custom Font with Training Data

Download superior training data from here and place it in the `tesseract_tutorial/tesseract/tessdata`:

```bash
TESSDATA_PREFIX=../tesseract/tessdata make training MODEL_NAME=AMGDT START_MODEL=eng TESSDATA=../tesseract/tessdata MAX_ITERATIONS=100
```

If errors arise due to script unicharsets, address them as shown in the Makefile adjustments:

![Before and After Makefile Solution](https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-font-training/makefile_issues.png)

### Final Step: Evaluate the Accuracy of Your `.traineddata`

By using a large dataset (1000 `.box` and `.tif` files) and performing 3000 iterations, the resulting `.traineddata` achieves an excellent Base Character Error Rate (BCER) around 5.77%.

![Trained Data Accuracy](https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-font-training/traineddata_accuracy.png)

For more details and guidance, refer to this video tutorial: [YouTube Guide on Tesseract Training](https://www.youtube.com/watch?v=KE4xEzFGSU8ustom).