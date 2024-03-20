FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BootcampCalculator/BootcampCalculator.csproj", "BootcampCalculator/"]
RUN dotnet restore "BootcampCalculator/BootcampCalculator.csproj"
COPY . .
WORKDIR "/src/BootcampCalculator"
RUN dotnet build "BootcampCalculator.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "BootcampCalculator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BootcampCalculator.dll"]
