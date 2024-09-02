# IronOCR Linux Compatibility & Installation Guide

IronOCR is fully supported on Linux for **.NET Core** and **.NET 5** projects, with additional compatibility for platforms like [Docker](https://ironsoftware.com/csharp/ocr/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/), Azure, macOS, and Windows, ensuring a flexible integration across various environments.

![Linux](https://img.icons8.com/color/96/000000/linux--v1.png) ![Docker](https://img.icons8.com/color/96/000000/docker.png) ![Azure](https://img.icons8.com/fluency/96/000000/azure-1.png) ![AWS](https://img.icons8.com/color/96/000000/amazon-web-services.png) ![Ubuntu](https://img.icons8.com/color/96/000000/ubuntu--v1.png) ![Debain](https://img.icons8.com/color/96/000000/debian--v1.png)

For best results, we advocate using .NET Core 3.1 or any other [Microsoft LTS-supported runtimes](https://dotnet.microsoft.com/platform/support/policy), as they provide reliable, long-term support and have proven stability on Linux systems.

IronOCR delivers a seamless experience on Linux platforms right out of the box, benefiting from numerous hours of meticulous testing and optimization by our dedicated engineering team.

The significance of Linux compatibility cannot be overstated, particularly for cloud-based services such as Azure Web Apps, Azure Functions, AWS EC2, AWS Lambda, and Docker containers in Azure DevOps, which predominantly run on Linux. At Iron Software, our extensive use of these technologies ensures a profound understanding of the requirements and challenges faced by our Enterprise and SAAS clientele.

## Officially Supported Linux Distributions

IronOCR offers **official support** for the latest **64-bit** versions of Linux listed below, designed for effortless, "zero configuration" setup:

- Ubuntu 20
- Ubuntu 18
- Debian 11
- Debian 10 _[Currently the default Linux Distro in Microsoft Azure]_

For guidance on setups involving Linux distributions not **officially supported**, please see the "Other Linux Distros" section below.

## IronOCR NuGet Packages

```
PM > Install-Package IronOCR
```

## Ubuntu Compatibility

Ubuntu ranks as our most scrutinized Linux OS due to its significant role in the Azure ecosystem that we leverage for continuous integration and production deployments. This platform benefits from both official Microsoft .NET support and established Docker images.

### Ubuntu 20

![](https://img.icons8.com/color/48/000000/microsoft.png) ![](https://img.icons8.com/color/48/000000/ubuntu--v1.png) ![](https://img.icons8.com/color/48/000000/chrome--v1.png) ![](https://img.icons8.com/color/48/000000/safari--v1.png) ![](https://img.icons8.com/color/48/000000/docker.png) ![](https://img.icons8.com/fluency/48/000000/azure-1.png)

**Manual Ubuntu 20 Installation** - For manual setups or where your application cannot utilize _sudo_ privileges:

```sh
sudo apt update
sudo apt install -y apt-utils libgdiplus libc6-dev
```

### Ubuntu 18

![](https://img.icons8.com/color/48/000000/microsoft.png) ![](https://img.icons8.com/color/48/000000/ubuntu--v1.png) ![](https://img.icons8.com/color/48/000000/chrome--v1.png) ![](https://img.icons8.com/color/48/000000/safari--v1.png) ![](https://img.icons8.com/color/48/000000/docker.png) ![](https://img.icons8.com/fluency/48/000000/azure-1.png)

**Manual Ubuntu 18 Installation** - For setups requiring manual intervention or when admin privileges are unavailable:

```sh
sudo apt update
sudo apt install -y apt-utils libgdiplus libc6-dev
```

### Debian 11

![](https://img.icons8.com/color/48/000000/debian.png) ![](https://img.icons8.com/color/48/000000/microsoft.png) ![](https://img.icons8.com/color/48/000000/chrome--v1.png) ![](https://img.icons8.com/color/48/000000/safari--v1.png) ![](https://img.icons8.com/color/48/000000/docker.png) ![](https://img.icons8.com/fluency/48/000000/azure-1.png)

**Manual Debian 11 Installation** - Appropriate for direct installation or cases where _sudo_ privileges are restricted:

```sh
sudo apt update
sudo apt install -y apt-utils libgdiplus libc6-dev
```

### Debian 10

![](https://img.icons8.com/color/48/000000/debian.png) ![](https://img.icons8.com/color/48/000000/microsoft.png) ![](https://img.icons8.com/color/48/000000/chrome--v1.png) ![](https://img.icons8.com/color/48/000000/safari--v1.png) ![](https://img.icons8.com/color/48/000000/docker.png) ![](https://img.icons8.com/fluency/48/000000/azure-1.png)

_Developing .NET projects in Visual Studio typically defaults to Debian 10 as the Linux distribution when adding Docker compatibility._

**Manual Debian 10 Installation** - To manually configure or where application usage does not permit _sudo_ commands:

```sh
sudo apt update
sudo apt install -y apt-utils libgdiplus libc6-dev
```

### Other Linux Distros

Regardless of whether you utilize `HFS`, `yum`, `apt`, or `apt-get` as your package manager, software requirements remain consistent across distributions.

```sh
sudo apt update
sudo apt install -y apt-utils libgdiplus libc6-dev tessseract-ocr libtesseract-dev
```

<style>article.main-article.main-content img  { display:inline-block !important ;}</style>