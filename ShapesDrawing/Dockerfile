FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["2_ShapesDrawing/2_ShapesDrawing.csproj", "2_ShapesDrawing/"]
RUN dotnet restore "2_ShapesDrawing/2_ShapesDrawing.csproj"
COPY . .
WORKDIR "/src/2_ShapesDrawing"
RUN dotnet build "2_ShapesDrawing.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "2_ShapesDrawing.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "2_ShapesDrawing.dll"]
