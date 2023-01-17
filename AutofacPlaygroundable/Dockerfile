FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AutofacPlaygroundable/AutofacPlaygroundable.csproj", "AutofacPlaygroundable/"]
RUN dotnet restore "AutofacPlaygroundable/AutofacPlaygroundable.csproj"
COPY . .
WORKDIR "/src/AutofacPlaygroundable"
RUN dotnet build "AutofacPlaygroundable.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AutofacPlaygroundable.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AutofacPlaygroundable.dll"]
