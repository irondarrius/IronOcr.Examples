# C# Custom Font Training for Tesseract 5 (For Windows Users)

***Based on <https://ironsoftware.com/how-to/ocr-custom-font-training/>***


Custom font training in Tesseract 5 is a fantastic way to enhance OCR accuracy, particularly for fonts or styles that are not recognized effectively by default. This entails providing Tesseract with samples of the specific fonts and their corresponding text entries, enabling it to learn and adapt to these unique typefaces.

## Step 1: Acquire the Latest IronOCR Version

### Install via DLL

Obtain the IronOcr DLL directly at [IronOcr DLL](https://ironsoftware.com/csharp/ocr/packages/IronOcr.zip) for your system.

### Install via NuGet

For those who prefer NuGet installation, it is available at [NuGet IronOcr Package](https://www.nuget.org/packages/IronOcr/).

```shell
Install-Package IronOcr
```

## Step 2: Configure WSL2 and Ubuntu 
Refer to [this guide](https://ubuntu.com/tutorials/install-ubuntu-on-wsl2-on-windows-10) to set up WSL2 and Ubuntu. Note that custom font training is currently only supported on Linux.

## Step 3: Install Tesseract 5 on Ubuntu 
Install Tesseract and its development libraries using:
```bash
sudo apt install tesseract-ocr
sudo apt install libtesseract-dev
```

## Step 4: Obtain the Desired Font 
For this tutorial, we use the AMGDT font, available in both .ttf and .otf formats.
![Example of Downloaded Font File](https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-font-training/example_of_downloaded_font_file.png)

## Step 5: Mount Your Work Drive 
Use the following commands to mount Drive `D:`:
```bash
cd /
cd /mnt/d
```

## Step 6: Transfer Font File to Ubuntu Font Folder
The directories for fonts in Ubuntu are `Ubuntu/usr/share/fonts` and `Ubuntu/usr/local/share/fonts`.

**To access files on Ubuntu, enter `\\\wsl$` in your file explorer address bar.**

![Ubuntu Folder Directory](https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-font-training/ubutu_folder_directory.png)

### Troubleshooting: Access Denied to Destination Folder

![Access Denied](https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-font-training/destination_folder_access_denied.png)

This can be resolved using the command line:
```bash
cd /
su root
cd c/Users/Admin/Downloads/’AMGDT Regular’
cp ‘AMGDT Regular.ttf’ /usr/share/fonts
cp ‘AMGDT Regular.ttf’ /usr/local/share/fonts
su username
```

## Step 7: Clone tesseract_tutorial Repository
Clone the `tesseract_tutorial` from GitHub using:
```bash
git clone https://github.com/astutejoe/tesseract_tutorial.git
```

## Step 8: Obtain Additional GitHub Repositories
Navigate to the `tesseract_tutorial` directory and clone additional needed repositories:
```bash
git clone https://github.com/tesseract-ocr/tesstrain
git clone https://github.com/tesseract-ocr/tesseract
```
- `tesstrain` includes the Makefile used to create `.traineddata` file.
- `tesseract` includes the `tessdata` folder for referencing in training.

## Step 9: Set Up the `data` Folder
Create a `data` folder within `tesseract_tutorial/tesstrain` to store output.

## Step 10: Execute the Training Split Script
From the `tesseract_tutorial` directory, run:
```bash
python split_training_text.py
```
This script splits the training text, creating `.box` and `.tif` files in the "data" folder.

### Troubleshooting: Fontconfig Warning

![Fontconfig Warning](https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-font-training/fontconfig_warning.png)

Fix this by modifying `tesseract_tutorial/fonts.conf` and copying it to `/etc/fonts`:
```bash
cp fonts.conf /etc/fonts
```
Update `split_training_text.py` with the proper directory settings:
```python
fontconf_dir = '/etc/fonts'
```

### Note: Managing Training Files
Modify the `split_training_text.py` to adjust the number of training files as needed.

![Number of Training Files](https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-font-training/number_of_trainfile.png)

## Step 11: Acquire `eng.traineddata`
Download this enhanced training data from [tessdata_best GitHub](https://github.com/tesseract-ocr/tessdata_best).

## Step 12: Generate Custom Font `.traineddata`
Navigate to the `tesstrain` directory and initiate the training process with specified configurations:
```bash
TESSDATA_PREFIX=../tesseract/tessdata make training MODEL_NAME=AMGDT START_MODEL=eng TESSDATA=../tesseract/tessdata MAX_ITERATIONS=100
```

![Makefile Issues](https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-font-training/makefile_issues.png)
- Edit the Makefile as necessary to ensure correct file paths and settings.

### Resolution for Common Issues

After editing, your Makefile should resemble:
```make
make - Makefile
WORDLIST_FILE := $(OUTPUT_DIR2)/$(MODEL_NAME).lstm-word-dawg
NUMBERS_FILE := $(OUTPUT_DIR2)/$(MODEL_NAME).lstm-number-dawg
PUNC_FILE := $(OUTPUT_DIR2)/$(MODEL_NAME).lstm-punc-dawg
```

Insert `Latin.unicharset` into the `tesstrain/data/langdata` directory to resolve script unicharset load failures.

## Step 13: Evaluate the Accuracy of Your `.traineddata`
With 1000 `.box` and `.tif` files and 3000 iterations, the BCER of the generated `.traineddata` (AMGDT.traineddata) is approximately 5.77%.

![Traineddata Accuracy](https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-font-training/traineddata_accuracy.png)

For additional information and guidance, refer to **this resource**: [YouTube Tutorial](https://www.youtube.com/watch?v=KE4xEzFGSU8ustom).