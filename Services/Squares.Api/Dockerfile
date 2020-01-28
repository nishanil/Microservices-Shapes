FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

COPY Services/Squares.Api/SquaresApi.csproj Services/Squares.Api/
RUN dotnet restore Services/Squares.Api/SquaresApi.csproj
COPY . .
WORKDIR /src/Services/Squares.Api
RUN dotnet build SquaresApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish SquaresApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SquaresApi.dll"]
