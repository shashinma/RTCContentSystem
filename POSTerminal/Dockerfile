﻿FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["POSTerminal.csproj", "POSTerminal.csproj"]
RUN dotnet restore "POSTerminal.csproj"
COPY . .

WORKDIR "/src"

RUN dotnet build "POSTerminal.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "POSTerminal.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY ["app.db", "app.db"]
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "POSTerminal.dll"]