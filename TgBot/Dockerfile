﻿FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TgBot/TgBot.csproj", "TgBot/"]
RUN dotnet restore "TgBot/TgBot.csproj"
COPY . .
WORKDIR "/src/TgBot"
RUN dotnet build "TgBot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TgBot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TgBot.dll"]
