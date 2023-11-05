FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["POSTerminal/POSTerminal.csproj", "POSTerminal/"]
RUN dotnet restore "POSTerminal/POSTerminal.csproj"
COPY . .
WORKDIR "/src/ESPDumpsterWebApp.API"
RUN dotnet build "POSTerminal.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "POSTerminal.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "POSTerminal.dll"]
