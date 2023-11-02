FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./FfmpegPlayground.csproj", "FfmpegPlayground/"]
RUN dotnet restore "FfmpegPlayground/FfmpegPlayground.csproj"
COPY . .
WORKDIR "/src/FfmpegPlayground"
RUN dotnet build "FfmpegPlayground.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FfmpegPlayground.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN sudo apt-get install -y ffmpeg libgdiplus
ENTRYPOINT ["dotnet", "FfmpegPlayground.dll"]
