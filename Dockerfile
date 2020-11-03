FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
COPY *.sln .
COPY AppGameLoans/AppGameLoans.Api/*.csproj ./AppGameLoans/AppGameLoans.Api/
COPY AppGameLoans/AppGameLoans.Domain/*.csproj ./AppGameLoans/AppGameLoans.Domain/
COPY AppGameLoans/AppGameLoans.Persistence/*.csproj ./AppGameLoans/AppGameLoans.Persistence/
COPY AppGameLoans/AppGameLoans.Services/*.csproj ./AppGameLoans/AppGameLoans.Services/
COPY AppGameLoans/AppGameLoans.Utilities/*.csproj ./AppGameLoans/AppGameLoans.Utilities/
COPY AppGameLoans/AppGameLoans.Tests/*.csproj ./AppGameLoans/AppGameLoans.Tests/
RUN dotnet restore
COPY AppGameLoans/. ./AppGameLoans/
WORKDIR /app
RUN dotnet publish -c Release -o out
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out ./
ENTRYPOINT ["dotnet", "AppGameLoans.Api.dll"]