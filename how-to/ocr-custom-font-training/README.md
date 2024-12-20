# C# Custom Font Training for Tesseract 5 (For Windows Users)

***Based on <https://ironsoftware.com/how-to/ocr-custom-font-training/>***


Enhance the precision of your OCR engine using custom font training with Tesseract 5. This is particularly useful for fonts or styles not typically well-supported. The technique requires feeding Tesseract with samples of fonts and their respective texts, allowing it to recognize and adapt to these unique features.

### Getting Started with IronOCR

---

## Step 1: Obtain the Latest IronOCR Release

### Install via DLL

Secure a copy of the [IronOcr DLL](https://ironsoftware.com/csharp/ocr/packages/IronOcr.zip) straight to your local system.

### Install via NuGet

You can also choose to install it through [NuGet](https://www.nuget.org/packages/IronOcr/).

```shell
Install-Package IronOcr
```

---

## Step 2: Configure WSL2 and Ubuntu

Follow this [guide to set up WSL2 and Ubuntu](https://ubuntu.com/tutorials/install-ubuntu-on-wsl2-on-windows-10).
**Note:** Custom font training is only feasible on Linux environments.

## Step 3: Install Tesseract 5 in Ubuntu

```bash
sudo apt install tesseract-ocr
sudo apt install libtesseract-dev
```

## Step 4: Select and Download Your Font

For this tutorial, we have chosen the AMGDT font. Font files can be either .ttf or .otf.

![Example of downloaded font file](https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-font-training/example_of_downloaded_font_file.png)

## Step 5: Prepare the Disk Drive for Training

Mount your `D:` drive as the working directory with these commands:

```bash
cd /
cd /mnt/d
```

## Step 6: Transfer the Font File to the Ubuntu Font Directory

Access Ubuntu’s font directories here: `Ubuntu/usr/share/fonts` and `Ubuntu/usr/local/share/fonts`.

**Hint:** Use `\\\wsl$` to explore Ubuntu files from Windows.

![Ubuntu folder directory](https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-font-training/ubutu_folder_directory.png)

### Troubleshooting: Access Denied to Destination Folder

![Access Denied Error](https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-font-training/destination_folder_access_denied.png)

Resolve this by using command-line operations:

```bash
cd /
su root
cd c/Users/Admin/Downloads/’AMGDT Regular’
cp ‘AMGDT Regular.ttf’ /usr/share/fonts
cp ‘AMGDT Regular.ttf’ /usr/local/share/fonts
su username
```

## Step 7: Download Repositories from GitHub

Clone `tesseract_tutorial` with this command:

```bash
git clone https://github.com/astutejoe/tesseract_tutorial.git
```

## Step 8: Additional GitHub Clones

Inside the `tesseract_tutorial` directory, clone the additional necessary repositories:

```bash
git clone https://github.com/tesseract-ocr/tesstrain
git clone https://github.com/tesseract-ocr/tesseract
```

## Step 9: Organize Output Data

Create a `data` directory in `tesseract_tutorial/tesstrain` to store output files.

## Step 10: Execute Training Script

Navigate back to the `tesseract_tutorial` and run:

```bash
python split_training_text.py
```

This script generates `.box` and `.tif` files in the `data` directory.

### Troubleshooting: Fontconfig Warning

![Fontconfig issue](https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-font-training/fontconfig_warning.png)

Fix missing font directories with configuration changes:

![Solution for font directory](https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-font-training/fontconfig_dir.png.png)

```bash
cp fonts.conf /etc/fonts
```

Add directory paths in `split_training_text.py`:

```
fontconf_dir = '/etc/fonts`
```

## Step 11: Obtain Updated Language Data

Download the enhanced `eng.traineddata` from [here](https://github.com/tesseract-ocr/tessdata_best) and place it in `tesseract_tutorial/tesseract/tessdata`.

## Step 12: Generate Your Custom Font `.traineddata`

Execute the training process with these commands in the `tesstrain` directory:

```
TESSDATA_PREFIX=../tesseract/tessdata make training MODEL_NAME=AMGDT START_MODEL=eng TESSDATA=../tesseract/tessdata MAX_ITERATIONS=100
```

### Error Handling in the Training Process

Before and after corrections related to Makefile configurations:

![Before correction](https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-font-training/makefile_sol_before.png)

![After correction](https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-font-training/makefile_sol_after.png)

Ensure `Latin.unicharset` is present in `tesstrain/data/langdata` directory:

```
make - Makefile
WORDLIST_FILE := $(OUTPUT_DIR2)/$(MODEL_NAME).lstm-word-dawg
NUMBERS_FILE := $(OUTPUT_DIR2)/$(MODEL_NAME).lstm-number-dawg
PUNC_FILE := $(OUTPUT_DIR2)/$(MODEL_NAME).lstm-punc-dawg
```

## Step 13: Evaluate Your `.traineddata` Accuracy

After processing 1000 `.box` and `.tif` files through 3000 iterations, the final `.traineddata` (AMGDT.traineddata) exhibits a minimal error rate (BCER) of about 5.77%.

![Trained Data Accuracy](https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-font-training/traineddata_accuracy.png)

For more information and resources, see this helpful [video tutorial](https://www.youtube.com/watch?v=KE4xEzFGSU8ustom).