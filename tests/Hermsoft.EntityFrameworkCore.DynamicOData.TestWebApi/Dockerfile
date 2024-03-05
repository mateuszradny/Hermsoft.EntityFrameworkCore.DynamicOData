#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Packages.props", "."]
COPY ["Directory.Build.props", "."]
COPY ["Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi/Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.csproj", "Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi/"]
RUN dotnet restore "./Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi/Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.csproj"
COPY . .
WORKDIR "/src/Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi"
RUN dotnet build "./Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.dll"]