# IronOCR Linux Compatibility & Setup Guide

***Based on <https://ironsoftware.com/how-to/tesseract-ocr-setup-linux-ubuntu-debian/>***


IronOCR is fully compatible with Linux environments for **.NET Core** and **.NET 5** applications, including deployments using [Docker](https://ironsoftware.com/csharp/ocr/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/), as well as other platforms like Azure, macOS, and Windows.

![Linux](https://img.icons8.com/color/96/000000/linux--v1.png) ![Docker](https://img.icons8.com/color/96/000000/docker.png) ![Azure](https://img.icons8.com/fluency/96/000000/azure-1.png) ![AWS](https://img.icons8.com/color/96/000000/amazon-web-services.png) ![Ubuntu](https://img.icons8.com/color/96/000000/ubuntu--v1.png) ![Debain](https://img.icons8.com/color/96/000000/debian--v1.png)

For optimal stability and support, we suggest using .NET Core 3.1 or other [LTS versions maintained by Microsoft](https://dotnet.microsoft.com/platform/support/policy). These versions offer long-term support and have been thoroughly tested on Linux systems.

IronOCR requires no modifications to run on Linux systems. It is designed to work seamlessly 'out of the box', following extensive testing and optimization by our development team.

Linux is a critical environment for many cloud services, including Azure Web Apps, Azure Functions, AWS EC2, AWS Lambda, and Docker operations in Azure DevOps. At Iron Software, we utilize these cloud solutions frequently and recognize their importance to our Enterprise and SAAS client base.

## Officially Supported Linux Distributions

IronOCR is **officially supported** with a "zero-configuration" setup on the latest **64-bit** versions of the Linux operating systems listed below:

- Ubuntu 20
- Ubuntu 18
- Debian 11
- Debian 10 _[The Default Linux Distro in Microsoft Azure]_

For Linux versions not **officially supported**, please see the "Other Linux Distros" section for further guidance on setting up IronOCR.

## IronOCR NuGet Packages

```
PM > Install-Package IronOCR
```

## Compatibility with Ubuntu

Ubuntu receives the most testing because of its significant use in continuous testing and deployment processes, particularly within Azure's infrastructure. Ubuntu boasts official support from Microsoft for .NET and has official Docker images available.

### Ubuntu 20

![](https://img.icons8.com/color/48/000000/microsoft.png) ![](https://img.icons8.com/color/48/000000/ubuntu--v1.png) ![](https://img.icons8.com/color/48/000000/chrome--v1.png) ![](https://img.icons8.com/color/48/000000/safari--v1.png) ![](https://img.icons8.com/color/48/000000/docker.png) ![](https://img.icons8.com/fluency/48/000000/azure-1.png)

**Manual Setup for Ubuntu 20** - If manual installation is required or if running applications with _sudo_ privileges is not possible:

```sh
sudo apt update
sudo apt install -y apt-utils libgdiplus libc6-dev
```

### Ubuntu 18

![](https://img.icons8.com/color/48/000000/microsoft.png) ![](https://img.icons8.com/color/48/000000/ubuntu--v1.png) ![](https://img.icons8.com/color/48/000000/chrome--v1.png) ![](https://img.icons8.com/color/48/000000/safari--v1.png) ![](https://img.icons8.com/color/48/000000/docker.png) ![](https://img.icons8.com/fluency/48/000000/azure-1.png)

**Manual Setup for Ubuntu 18** - This setup is also applicable when administrative privileges are restricted:

```sh
sudo apt update
sudo apt install -y apt-utils libgdiplus libc6-dev
```

### Debian 11 and Debian 10

![](https://img.icons8.com/color/48/000000/debian.png) ![](https://img.icons8.com/color/48/000000/microsoft.png) ![](https://img.icons8.com/color/48/000000/chrome--v1.png) ![](https://img.icons8.com/color/48/000000/safari--v1.png) ![](https://img.icons8.com/color/48/000000/docker.png) ![](https://img.icons8.com/fluency/48/000000/azure-1.png)

**Manual Setup for Debian 11 and Debian 10** - For those opting to manually install IronOCR or when administrative access is constrained:

```sh
sudo apt update
sudo apt install -y apt-utils libgdiplus libc6-dev
```

Both versions follow the same setup process.

### Other Linux Distros

Regardless of whether you utilize `HFS`, `yum`, `apt`, or `apt-get` as your package manager, the installation requirements are virtually identical.

```sh
sudo apt update
sudo apt install -y apt-utils libgdiplus libc6-dev tesseract-ocr libtesseract-dev
```

<style>article.main-article.main-content img  { display:inline-block !important ;}</style>