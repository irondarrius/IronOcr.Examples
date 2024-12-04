# Configuring IronOCR in Docker Environments

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***


Are you looking to [implement OCR with Images or PDFs in C#](https://ironsoftware.com/csharp/ocr/)?

IronOCR is now fully compatible with Docker, supporting environments like Azure Docker Containers across both Linux and Windows platforms.

![](https://img.icons8.com/color/96/000000/docker--v1.png) ![](https://img.icons8.com/color/96/000000/linux--v1.png) ![](https://img.icons8.com/color/96/000000/amazon-web-services--v1.png) ![](https://img.icons8.com/color/96/000000/windows-logo--v1.png)

## Benefits of Using Docker

Docker provides a streamlined framework for developers to package, ship, and run applications within lightweight, portable containers that are capable of operating virtually everywhere.

## Getting Started with IronOCR on Linux

For developers new to Docker in the context of .NET, the following guide on [Docker debugging and integration with Visual Studio](https://docs.microsoft.com/en-us/visualstudio/containers/edit-and-refresh?view=vs-2019) is indispensable.

We further encourage you to explore our detailed [IronOCR Linux Setup and Compatibility Guide](https://ironsoftware.com/csharp/ocr/how-to/tesseract-ocr-setup-linux-ubuntu-debian/).

### Suggested Linux Distributions for Docker

The following 64-bit Linux distributions are recommended for optimal configuration of IronPDF:

- Ubuntu 20
- Ubuntu 18
- Debian 11
- Debian 10 _[The default Linux distribution on Microsoft Azure currently]_

It's advisable to use [Microsoft's Official Docker Images](https://hub.docker.com/_/microsoft-dotnet-runtime/). Although other Linux distributions can be used, they might require additional manual configuration with `apt-get`. Refer to our "[Linux Manual Setup](https://ironsoftware.com/csharp/ocr/how-to/tesseract-ocr-setup-linux-ubuntu-debian/)" guide for more details.

Sample Dockerfiles for both Ubuntu and Debian are provided within this document.

## Installation Essentials for IronOCR on Linux Using Docker

### Integrating via Our NuGet Package

For cross-platform development (Windows, macOS, and Linux), we recommend incorporating the [IronOcr NuGet Package](https://www.nuget.org/packages/IronOcr).

```shell
PM> Install-Package IronOcr
```

## Docker Configurations for Ubuntu Linux

![](https://img.icons8.com/color/96/000000/docker--v1.png) ![](https://img.icons8.com/color/96/000000/linux--v1.png) ![](https://img.icons8.com/color/96/000000/ubuntu--v1.png)

### Setup for Ubuntu 20 with .NET 5

```shell
# Base runtime image (Ubuntu 20 with .NET runtime)

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

FROM mcr.microsoft.com/dotnet/runtime:5.0-focal AS base
WORKDIR /app
# Install necessary packages

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

RUN apt-get update && apt-get install -y apt-utils libgdiplus libc6-dev

# Base development image (Ubuntu 20 with .NET SDK)

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
# Restore NuGet packages

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Build the project

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Publish the project

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Final build stage

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### Setup for Ubuntu 18 with .NET 3.1 LTS

```shell
# Base runtime and development configurations for Ubuntu 18 with .NET 3.1 LTS

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

# Similar steps as Ubuntu 20, substituting with the appropriate images

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

```

## Docker Configurations for Debian Linux

![](https://img.icons8.com/color/96/000000/docker--v1.png) ![](https://img.icons8.com/color/96/000000/linux--v1.png) ![](https://img.icons8.com/color/96/000000/debian--v1.png)

### Setup for Debian 11 with .NET 5

```shell
# Base runtime and development configurations for Debian 11 with .NET 5

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

# Similar steps as Ubuntu setups, substituting with the appropriate Debian images

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

```

### Setup for Debian 11 and Debian 10 with .NET 5 and .NET 3.1 LTS

```shell
# Base runtime and development configurations for Debian 10 and Debian 11 with .NET 5 and .NET 3.1 LTS

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

# Similar steps as above configurations, substituting with the appropriate Debian images

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

```

These configurations provide foundational templates for setting up IronOCR within Docker on Linux environments, accommodating different versions and distributions efficiently.