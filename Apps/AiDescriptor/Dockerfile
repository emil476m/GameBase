FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Apps/AiDescriptor/Api/Api.csproj", "Apps/AiDescriptor/Api/"]
COPY ["Apps/AiDescriptor/Service/Service.csproj", "Apps/AiDescriptor/Service/"]
COPY ["Apps/AiDescriptor/Externalities/Externalities.csproj", "Apps/AiDescriptor/Externalities/"]
RUN dotnet restore "Apps/AiDescriptor/Api/Api.csproj"
COPY Apps/AiDescriptor/Api/ Apps/AiDescriptor/Api/
COPY Apps/AiDescriptor/Service/ Apps/AiDescriptor/Service/
COPY Apps/AiDescriptor/Externalities/ Apps/AiDescriptor/Externalities/

WORKDIR "Apps/AiDescriptor/Api/"
RUN dotnet build "./Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]
