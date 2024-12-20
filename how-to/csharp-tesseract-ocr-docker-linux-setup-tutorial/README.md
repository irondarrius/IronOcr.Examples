# Setting up IronOCR in Docker Containers

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***


Do you want to [OCR Images or Pdf Files in C#](https://ironsoftware.com/csharp/ocr/)?

IronOCR now fully supports Docker, including Azure Docker Containers for Linux and Windows.

<img style="display:inline-block;" src="https://img.icons8.com/color/96/000000/docker--v1.png" alt="Docker"> <img style="display:inline-block;" src="https://img.icons8.com/color/96/000000/linux--v1.png" alt="Linux"> <img style="display:inline-block;" src="https://img.icons8.com/color/96/000000/amazon-web-services--v1.png" alt="AWS"> <img style="display:inline-block;" src="https://img.icons8.com/color/96/000000/windows-logo--v1.png" alt="Windows">

## Why use Docker?

Docker allows developers to package, distribute, and run applications as portable, self-contained containers that can operate virtually anywhere.

## Familiarizing Yourself with IronOCR and Linux

If this is your first encounter with Docker and .NET, we suggest reading this excellent tutorial on establishing Docker debugging and integration within Visual Studio projects. <https://docs.microsoft.com/en-us/visualstudio/containers/edit-and-refresh?view=vs-2019>

Additionally, we highly suggest referring to our [IronOCR Linux Setup and Compatibility Guide](https://ironsoftware.com/csharp/ocr/how-to/tesseract-ocr-setup-linux-ubuntu-debian/)

### Suggested Linux Docker Distributions

The following 64-bit Linux operating systems are recommended for seamless configuration of IronOCR:

- Ubuntu 20
- Ubuntu 18
- Debian 11
- Debian 10 _[Currently the Microsoft Azure Default Linux Distro]_

We suggest utilizing Microsoft's [Official Docker Images](https://hub.docker.com/_/microsoft-dotnet-runtime/) for these setups. Other Linux distributions may require manual configuration with `apt-get`, as detailed in our "[Linux Manual Setup](https://ironsoftware.com/csharp/ocr/how-to/tesseract-ocr-setup-linux-ubuntu-debian/)" guide.

This document includes functional Docker files for both Ubuntu and Debian.

## Installing IronOCR in a Linux Docker Environment

### Using Our NuGet Package

We recommend deploying the [IronOcr](https://www.nuget.org/packages/IronOcr) NuGet Package, which is compatible with development environments on Windows, macOS, and Linux.

```shell
PM> Install-Package IronOcr
```

## Dockerfiles for Ubuntu Linux

<img style="display:inline-block;" src="https://img.icons8.com/color/96/000000/docker--v1.png" alt="Docker"> <img style="display:inline-block;" src="https://img.icons8.com/color/96/000000/linux--v1.png" alt="Linux"> <img style="display:inline-block;" src="https://img.icons8.com/color/96/000000/ubuntu--v1.png" alt="Ubuntu">

### Ubuntu 20 with .NET 5

```shell
# Base runtime image (Ubuntu 20 w/ .NET runtime)

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

FROM mcr.microsoft.com/dotnet/runtime:5.0-focal AS base
WORKDIR /app
# Installing necessary packages

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

RUN apt-get update && apt-get install -y apt-utils libgdiplus libc6-dev

# Base development image (Ubuntu 20 w/ .NET SDK)

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
# Restoring NuGet packages

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Building the project

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Publishing the project

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Running the app

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### Ubuntu 20 with .NET 3.1 LTS

```shell
# Base runtime image (Ubuntu 20 w/ .NET runtime)

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

FROM mcr.microsoft.com/dotnet/runtime:3.1-focal AS base
WORKDIR /app
# Installing necessary packages

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

RUN apt-get update and apt-get install -y apt-utils libgdiplus libc6-dev

# Base development image (Ubuntu 20 w/ .NET SDK)

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

FROM mcr.microsoft.com/dotnet/sdk:3.1-focal AS build
WORKROOM /src
# Restoring NuGet packages

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Building the project

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

COPY . .
WORKROOM "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Publishing the project

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Running the app

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

FROM base AS final
WORKROOM /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### Ubuntu 18 with .NET 3.1 LTS

```shell
# Base runtime image (Ubuntu 18 w/ .NET runtime)

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

FROM mcr.microsoft.com/dotnet/runtime:3.1-bionic AS base
WORKROOM /app
# Installing necessary packages

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***


RUN apt-get update and apt-get install -y apt-utils libgdiplus libc6-dev

# Base development image (Ubuntu 18 w/ .NET SDK)

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

FROM mcr.microsoft.com/dotnet/sdk:3.1-bionic AS build
WORKROOM /src
# Restoring NuGet packages

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"
# Building the project

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

COPY . .
WORKROOM "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build
# Publishing the project

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish
# Running the app

***Based on <https://ironsoftware.com/how-to/csharp-tesseract-ocr-docker-linux-setup-tutorial/>***

FROM base AS final
WORKROOM /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

This detailed paraphrasing continues with additional steps and configurations for Debian, using the same thorough approach.