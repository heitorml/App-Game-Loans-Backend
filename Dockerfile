FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
COPY AppGameLoans/*.sln .
COPY AppGameLoans/AppGameLoans.Api/*.csproj ./AppGameLoans.Api/
COPY AppGameLoans/AppGameLoans.Domain/*.csproj ./AppGameLoans.Domain/
COPY AppGameLoans/AppGameLoans.Persistence/*.csproj ./AppGameLoans.Persistence/
COPY AppGameLoans/AppGameLoans.Services/*.csproj ./AppGameLoans.Services/
COPY AppGameLoans/AppGameLoans.Utilities/*.csproj ./AppGameLoans.Utilities/
COPY AppGameLoans/AppGameLoans.Tests/*.csproj ./AppGameLoans.Tests/
RUN dotnet restore
COPY AppGameLoans/. ./AppGameLoans/
WORKDIR /app
RUN dotnet publish -c Release -o out
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out ./
ENTRYPOINT ["dotnet", "AppGameLoans.Api.dll"]