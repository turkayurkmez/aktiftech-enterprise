#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Services/Stock/Stock.API/Stock.API.csproj", "src/Services/Stock/Stock.API/"]
COPY ["shop.Messages/shop.Messages.csproj", "shop.Messages/"]
RUN dotnet restore "src/Services/Stock/Stock.API/Stock.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Stock/Stock.API"
RUN dotnet build "Stock.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Stock.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Stock.API.dll"]