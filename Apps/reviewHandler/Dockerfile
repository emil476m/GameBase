FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Apps/reviewHandler/api/api.csproj", "Apps/reviewHandler/api/"]
COPY ["Apps/reviewHandler/service/service.csproj", "Apps/reviewHandler/service/"]
COPY ["Apps/reviewHandler/infrastructur/infrastructur.csproj", "Apps/reviewHandler/infrastructur/"]
RUN dotnet restore "Apps/reviewHandler/api/api.csproj"

COPY Apps/reviewHandler/api/ Apps/reviewHandler/api/
COPY Apps/reviewHandler/service/ Apps/reviewHandler/service/
COPY Apps/reviewHandler/infrastructur/ Apps/reviewHandler/infrastructur/

WORKDIR "Apps/reviewHandler/api"
RUN dotnet build "api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api.dll"]
