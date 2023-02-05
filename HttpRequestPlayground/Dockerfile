FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ConsolePlaygrouns/ConsolePlaygrouns.csproj", "ConsolePlaygrouns/"]
RUN dotnet restore "ConsolePlaygrouns/ConsolePlaygrouns.csproj"
COPY . .
WORKDIR "/src/ConsolePlaygrouns"
RUN dotnet build "ConsolePlaygrouns.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConsolePlaygrouns.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsolePlaygrouns.dll"]
