FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["DockerBooksAPI.csproj", "./"]
RUN dotnet restore "./DockerBooksAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "DockerBooksAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DockerBooksAPI.csproj" -c Release -o /app/publish
RUN ls /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "DockerBooksAPI.dll"]
