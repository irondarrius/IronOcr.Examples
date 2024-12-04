# IronOCR Compatibility & Setup on Linux

***Based on <https://ironsoftware.com/how-to/tesseract-ocr-setup-linux-ubuntu-debian/>***


IronOCR offers robust support for **.NET Core** and **.NET 5** on various platforms, including Linux, [Docker](https://ironsoftware.com/csharp/ocr/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/), Azure, macOS, and Windows.

![Linux](https://img.icons8.com/color/96/000000/linux--v1.png) ![Docker](https://img.icons8.com/color/96/000000/docker.png) ![Azure](https://img.icons8.com/fluency/96/000000/azure-1.png) ![AWS](https://img.icons8.com/color/96/000000/amazon-web-services.png) ![Ubuntu](https://img.icons8.com/color/96/000000/ubuntu--v1.png) ![Debain](https://img.icons8.com/color/96/000000/debian--v1.png)

We advise using .NET Core 3.1 and other runtimes that are [endorsed as LTS by Microsoft](https://dotnet.microsoft.com/platform/support/policy) for their extended support and stable performance on Linux.

IronOCR typically requires no additional code modifications to function on Linux, performing optimally right away due to extensive testing and fine-tuning by our team.

Support for Linux is crucial as it underpins many cloud solutions like Azure Web Apps, Azure Functions, AWS EC2, AWS Lambda, and Azure Devops Docker, which are integral to many of our Enterprise and SaaS customers at Iron Software.

## Supported Linux Distributions

We **officially support** these 64-bit Linux distributions for seamless IronOCR integration:

- Ubuntu 20
- Ubuntu 18
- Debian 11
- Debian 10 _[Currently the Microsoft Azure Default Linux Distro]_

For guidance on installing IronOCR on other Linux distributions, see "Other Linux Distros" section below.

## IronOCR NuGet Packages

To install, use:

```bash
PM > Install-Package IronOCR
```

## Compatibility with Ubuntu

Ubuntu is thoroughly tested as it is widely used in Azure, where we conduct ongoing testing and deployments. It enjoys robust support from Microsoft for .NET and official Docker images.

### Setup for Ubuntu 20

![Icons](https://img.icons8.com/color/48/000000/microsoft.png) ![Ubuntu](https://img.icons8.com/color/48/000000/ubuntu--v1.png) ![Chrome](https://img.icons8.com/color/48/000000/chrome--v1.png) ![Safari](https://img.icons8.com/color/48/000000/safari--v1.png) ![Docker](https://img.icons8.com/color/48/000000/docker.png) ![Azure](https://img.icons8.com/fluency/48/000000/azure-1.png)

**Manual Ubuntu 20 Installation** - For situations where administrative permissions are unavailable:

```sh
sudo apt update
sudo apt install -y apt-utils libgdiplus libc6-dev
```

### Setup for Ubuntu 18

![Icons](https://img.icons8.com/color/48/000000/microsoft.png) ![Ubuntu](https://img.icons8.com/color/48/000000/ubuntu--v1.png) ![Chrome](https://img.icons8.com/color/48/000000/chrome--v1.png) ![Safari](https://img.icons8.com/color/48/000000/safari--v1.png) ![Docker](https://img.icons8.com/color/48/000000/docker.png) ![Azure](https://img.icons8.com/fluency/48/000000/azure-1.png)

**Manual Ubuntu 18 Installation** - If installing manually without _sudo_ permissions:

```sh
sudo apt update
sudo apt install -y apt-utils libgdiplus libc6-dev
```

### Setup for Debian 11 and Debian 10

Both setups are identical due to their requirements.

**Manual Debian Setup** - Suitable when administrative rights are restricted.

```sh
sudo apt update
sudo apt install -y apt-utils libgdiplus libc6-dev
```

### Additional Linux Distributions

Regardless of which package manager you use (`HFS`, `yum`, `apt`, or `apt-get`), the requirements generally remain the same:

```sh
sudo apt update
sudo apt install -y apt-utils libgdiplus libc6-dev tesseract-ocr libtesseract-dev
```

<style>article.main-article.main-content img  { display:inline-block !important ;}</style>