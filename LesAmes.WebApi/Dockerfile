# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build image
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy all csproj files for restore (handles multi-project solutions)
COPY ["LesAmes.WebApi/LesAmes.WebApi.csproj", "LesAmes.WebApi/"]
# If you have other projects, add their csproj files here:
# COPY ["LesAmes.Domain/LesAmes.Domain.csproj", "LesAmes.Domain/"]
# COPY ["LesAmes.Infrastructure/LesAmes.Infrastructure.csproj", "LesAmes.Infrastructure/"]

RUN dotnet restore "LesAmes.WebApi/LesAmes.WebApi.csproj"

# Copy everything else
COPY . .

WORKDIR "/src/LesAmes.WebApi"
RUN dotnet build "LesAmes.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish image
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "LesAmes.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LesAmes.WebApi.dll"]
