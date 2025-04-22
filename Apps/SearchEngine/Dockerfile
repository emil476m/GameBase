FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Apps/SearchEngine/api/api.csproj", "Apps/SearchEngine/api/"]
COPY ["Apps/SearchEngine/service/service.csproj", "Apps/SearchEngine/service/"]
COPY ["Apps/SearchEngine/infrastructur/infrastructur.csproj", "Apps/SearchEngine/infrastructur/"]

RUN dotnet restore "Apps/SearchEngine/api/api.csproj"

COPY Apps/SearchEngine/api/ Apps/SearchEngine/api/
COPY Apps/SearchEngine/service/ Apps/SearchEngine/service/
COPY  Apps/SearchEngine/infrastructur/ Apps/SearchEngine/infrastructur/

WORKDIR "Apps/SearchEngine/api"
RUN dotnet build "api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api.dll"]
