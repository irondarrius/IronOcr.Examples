# Configuring IronOCR within Docker Containers

Interested in [OCR capabilities for Images or PDF files in C#](https://ironsoftware.com/csharp/ocr/)?

IronOCR offers comprehensive support for Docker, including environments like Azure Docker Containers, applicable to both Linux and Windows platforms.

![Docker Logo](https://img.icons8.com/color/96/000000/docker--v1.png) ![Azure Logo](https://img.icons8.com/color/96/000000/azure--v1.png) ![Linux Logo](https://img.icons8.com/color/96/000000/linux--v1.png) ![AWS Logo](https://img.icons8.com/color/96/000000/amazon-web-services--v1.png) ![Windows Logo](https://img.icons8.com/color/96/000000/windows-logo--v1.png)

## Benefits of Docker

Docker simplifies the packaging, distribution, and consistent operation of applications across varied environments by encapsulating them into lightweight, portable containers. These containers can operate seamlessly in virtually any system.

## Introduction to IronOCR on Linux using Docker

For newcomers to Docker with .NET, we suggest checking out this thorough guide on [setting up Docker for debugging and integration within Visual Studio projects](https://docs.microsoft.com/en-us/visualstudio/containers/edit-and-refresh?view=vs-2019).

It's also worthwhile to explore our detailed [IronOCR Linux Setup and Compatibility Guide](https://ironsoftware.com/csharp/ocr/how-to/tesseract-ocr-setup-linux-ubuntu-debian/).

### Optimal Linux Distributions for Docker

For simpler setup experiences with IronOCR, we recommend the following contemporary 64-bit Linux distributions:

- Ubuntu 20
- Ubuntu 18
- Debian 11
- Debian 10 (Presently, the default Linux distribution on Microsoft Azure)

Utilizing Microsoft's [Official Docker Images](https://hub.docker.com/_/microsoft-dotnet-runtime/) is advised. While other distributions are supported, they may require manual configurations via `apt-get`. For guidance on these setups, please refer to our [Manual Linux Setup Guide](https://ironsoftware.com/csharp/ocr/how-to/tesseract-ocr-setup-linux-ubuntu-debian/).

Example Docker files for both Ubuntu and Debian are included below:

## Essential Installation Steps for IronOCR in Linux Docker

### Using IronOCR via NuGet

We recommend leveraging the [IronOcr NuGet Package](https://www.nuget.org/packages/IronOcr) for development across Windows, macOS, and Linux.

```shell
PM> Install-Package IronOcr
```

## Dockerfile Examples for Ubuntu with .NET

![Docker Logo](https://img.icons8.com/color/96/000000/docker--v1.png) ![Linux Logo](https://img.icons8.com/color/96/000000/linux--v1.png) ![Ubuntu Logo](https://img.icons8.com/color/96/000000/ubuntu--v1.png)

### Ubuntu 20 with .NET 5 SDK and Runtime

```shell
# Base runtime image for Ubuntu 20 with .NET 5
FROM mcr.microsoft.com/dotnet/runtime:5.0-focal AS base
WORKDIR /app
# Installing critical libraries
RUN apt-get update && apt-get install -y apt-utils libgdiplus libc6-dev

# Base SDK image for development
FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
# Restoring NuGet packages
COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Project build sequence
COPY . .
WORKROOM "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Publishing project
FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Final runtime environment setup
FROM base AS final
WORKROOM /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

[Additional detailed Dockerfile configurations for other Ubuntu and Debian versions are provided further in this document, adapting to different .NET versions.]

## Dockerfile Templates for Debian with .NET

![Docker Logo](https://img.icons8.com/color/96/000000/docker--v1.png) ![Linux Logo](https://img.icons8.com/color/96/000000/linux--v1.png) ![Debian Logo](https://img.icons8.com/color/96/000000/debian--v1.png)

### Debian 11 with .NET 5 SDK and Runtime

```shell
# Base runtime image for Debian 11 with .NET 5
FROM mcr.microsoft.com/dotnet/aspnet:5.0-bullseye-slim AS base
WORKROOM /app
# Installing necessary packages
RUN apt-get update && apt-get install -y apt-utils libgdiplus libc6-dev

# Base SDK image for development
FROM mcr.microsoft.com/dotnet/sdk:5.0-bullseye-slim AS build
WORKROOM /src
# NuGet package restoration
COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Compilation and build instructions
COPY . .
WORKROOM "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Publishing the application
FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Preparing final runtime environment
FROM base AS final
WORKROOM /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

[Steps for additional configurations for other Debian versions are analogously detailed further in this document.]

Through these setups, deploying IronOCR within Docker containers becomes streamlined, ensuring optimal OCR capabilities on a variety of platforms.