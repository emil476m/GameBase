FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 6000

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Apps/CreateService/api/api.csproj", "Apps/CreateService/api/"]
COPY ["Apps/CreateService/service/service.csproj", "Apps/CreateService/service/"]
COPY ["Apps/CreateService/infrastructure/infrastructure.csproj", "Apps/CreateService/infrastructure/"]
RUN dotnet restore "Apps/CreateService/api/api.csproj"

COPY Apps/CreateService/api/ Apps/CreateService/api/
COPY Apps/CreateService/service/ Apps/CreateService/service/
COPY Apps/CreateService/infrastructure/ Apps/CreateService/infrastructure/

WORKDIR "Apps/CreateService/api"
RUN dotnet build "api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api.dll"]
