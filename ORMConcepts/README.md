# ORM Concepts

## Requirements
- InSTALL .NET Runtime
- Install `Microsoft.EntityFrameworkCore.Sqlite` using NuGet
- Install `dotnet-ef` using this command `dotnet tool install --global dotnet-ef`
## Steps
- Create First Migration: `dotnet ef migrations add Initial --project ORMConcepts/ORMConcepts.csproj`
- Update Database: `dotnet ef database update --project ORMConcepts/ORMConcepts.csproj`
  `

