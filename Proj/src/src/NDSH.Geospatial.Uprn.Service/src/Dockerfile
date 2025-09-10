# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Common/OgcApi.Net/OgcApi.Net.csproj", "./Common/OgcApi.Net/"]
COPY ["Common/OgcApi.Net/OgcApi.Net.Features.csproj", "./Common/OgcApi.Net/"]
COPY ["Common/Standards/OgcApi.Net.Schemas/OgcApi.Net.Schemas.csproj", "./Common/Standards/OgcApi.Net.Schemas/"]
COPY ["Providers/OgcApi.Net.MbTiles/OgcApi.Net.MbTiles.csproj", "./Providers/OgcApi.Net.MbTiles/"]
COPY ["Providers/OgcApi.Net.PostGis/OgcApi.Net.PostGis.csproj", "./Providers/OgcApi.Net.PostGis/"]
COPY ["Providers/OgcApi.Net.SpatiaLite/OgcApi.Net.SpatiaLite.csproj", "./Providers/OgcApi.Net.SpatiaLite/"]
COPY ["Providers/OgcApi.Net.SqlServer/OgcApi.Net.SqlServer.csproj", "./Providers/OgcApi.Net.SqlServer/"]
COPY ["NDSH.Geospatial.Uprn.Service/src/NDSH.Geospatial.Uprn.Service.csproj", "./NDSH.Geospatial.Uprn.Service/src/"]
WORKDIR "/src/NDSH.Geospatial.Uprn.Service/src"
RUN apt-get update && apt-get install -y tree && tree /src
RUN dotnet restore ./NDSH.Geospatial.Uprn.Service.csproj

WORKDIR /src
COPY Common ./Common
COPY Providers ./Providers
COPY NDSH.Geospatial.Uprn.Service/src ./NDSH.Geospatial.Uprn.Service/src
WORKDIR /src/NDSH.Geospatial.Uprn.Service/src
RUN tree /src
RUN dotnet build "./NDSH.Geospatial.Uprn.Service.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN tree /app
RUN dotnet publish "./NDSH.Geospatial.Uprn.Service.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NDSH.Geospatial.Uprn.Service.dll"]