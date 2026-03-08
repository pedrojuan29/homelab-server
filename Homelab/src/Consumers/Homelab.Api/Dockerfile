# Base runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080


# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src


COPY ["Homelab.Api.csproj", "."]
COPY src/Consumers/Homelab.Api/Homelab.Api.csproj src/Consumers/Homelab.Api/
COPY src/Core/Homelab.Application/Homelab.Application.csproj src/Core/Homelab.Application/
COPY src/Core/Homelab.Domain/Homelab.Domain.csproj src/Core/Homelab.Domain/
COPY src/Infrastructure/Homelab.Data/Homelab.Data.csproj src/Infrastructure/Homelab.Data/
RUN dotnet restore "./Homelab.Api.csproj"

COPY . .
RUN dotnet build "./Homelab.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build


# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Homelab.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false


# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Homelab.Api.dll"]



## Base runtime
#FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
#WORKDIR /app
#EXPOSE 8080
#
## Build stage
#FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#
## copiar apenas os csproj para aproveitar cache
#COPY ["Homelab/src/Consumers/Homelab.Api/Homelab.Api.csproj", "src/Consumers/Homelab.Api/"]
#COPY ["Homelab/src/Core/Homelab.Application/Homelab.Application.csproj", "src/Core/Homelab.Application/"]
#COPY ["Homelab/src/Core/Homelab.Domain/Homelab.Domain.csproj", "src/Core/Homelab.Domain/"]
#COPY ["Homelab/src/Infrastructure/Homelab.Data/Homelab.Data.csproj", "src/Infrastructure/Homelab.Data/"]
#
## restore dependências
#RUN dotnet restore "src/Consumers/Homelab.Api/Homelab.Api.csproj"
#
## copiar resto do código
#COPY . .
#
## build
#WORKDIR "/src/src/Consumers/Homelab.Api"
#RUN dotnet build "Homelab.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
## Publish stage
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "Homelab.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
## Final runtime image
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Homelab.Api.dll"]