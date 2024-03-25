FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MultiThreadedDataProcessing/MultiThreadedDataProcessing.csproj", "MultiThreadedDataProcessing/"]
RUN dotnet restore "MultiThreadedDataProcessing/MultiThreadedDataProcessing.csproj"
COPY . .
WORKDIR "/src/MultiThreadedDataProcessing"
RUN dotnet build "MultiThreadedDataProcessing.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MultiThreadedDataProcessing.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MultiThreadedDataProcessing.dll"]
