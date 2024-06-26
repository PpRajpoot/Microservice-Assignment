#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5002

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ProductDetailService/ProductDetailService.csproj", "ProductDetailService/"]
COPY ["JwtAuthenticationManager/JwtAuthenticationManager.csproj", "JwtAuthenticationManager/"]
COPY ["ProductDetailBuisnessLayer/ProductDetailBuisnessLayer.csproj", "ProductDetailBuisnessLayer/"]
COPY ["Shared/Shared.csproj", "Shared/"]
COPY ["ProductDetailDataLayer/ProductDetailDataLayer.csproj", "ProductDetailDataLayer/"]
RUN dotnet restore "./ProductDetailService/./ProductDetailService.csproj"
COPY . .
WORKDIR "/src/ProductDetailService"
RUN dotnet build "./ProductDetailService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ProductDetailService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductDetailService.dll"]