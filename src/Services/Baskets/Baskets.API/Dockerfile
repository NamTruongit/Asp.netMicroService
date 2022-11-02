#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Baskets/Baskets.API/Baskets.API.csproj", "Services/Baskets/Baskets.API/"]
RUN dotnet restore "Services/Baskets/Baskets.API/Baskets.API.csproj"
COPY . .
WORKDIR "/src/Services/Baskets/Baskets.API"
RUN dotnet build "Baskets.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Baskets.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Baskets.API.dll"]