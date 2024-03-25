FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TransactionsLINQ/TransactionsLINQ.csproj", "TransactionsLINQ/"]
RUN dotnet restore "TransactionsLINQ/TransactionsLINQ.csproj"
COPY . .
WORKDIR "/src/TransactionsLINQ"
RUN dotnet build "TransactionsLINQ.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TransactionsLINQ.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TransactionsLINQ.dll"]
