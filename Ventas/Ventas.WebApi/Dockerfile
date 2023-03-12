#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Ventas.WebApi/Ventas.WebApi.csproj", "Ventas.WebApi/"]
RUN dotnet restore "Ventas.WebApi/Ventas.WebApi.csproj"
COPY . .
WORKDIR "/src/Ventas.WebApi"
RUN dotnet build "Ventas.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ventas.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ventas.WebApi.dll"]