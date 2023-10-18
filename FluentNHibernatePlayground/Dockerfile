FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["FluentNHibernatePlayground/FluentNHibernatePlayground.csproj", "FluentNHibernatePlayground/"]
RUN dotnet restore "FluentNHibernatePlayground/FluentNHibernatePlayground.csproj"
COPY . .
WORKDIR "/src/FluentNHibernatePlayground"
RUN dotnet build "FluentNHibernatePlayground.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FluentNHibernatePlayground.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FluentNHibernatePlayground.dll"]
