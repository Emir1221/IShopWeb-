#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["IShopWeb.Api/IShopWeb.Api.csproj", "IShopWeb.Api/"]
COPY ["IShopWeb.Application/IShopWeb.Application.csproj", "IShopWeb.Application/"]
COPY ["IShopWeb.Domain/IShopWeb.Domain.csproj", "IShopWeb.Domain/"]
COPY ["Mfc.Health.Corner.Common/Mfc.Health.Corner.Common.csproj", "Mfc.Health.Corner.Common/"]
COPY ["IShopWeb.Persistence/IShopWeb.Persistence.csproj", "IShopWeb.Persistence/"]
RUN dotnet restore "IShopWeb.Api/IShopWeb.Api.csproj"
COPY . .
WORKDIR "/src/IShopWeb.Api"
RUN dotnet build "IShopWeb.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IShopWeb.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IShopWeb.Api.dll"]
