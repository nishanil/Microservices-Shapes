FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

COPY Web/ShapesWeb/ShapesWeb.csproj Web/ShapesWeb/
RUN dotnet restore Web/ShapesWeb/ShapesWeb.csproj
COPY . .
WORKDIR /src/Web/ShapesWeb
RUN dotnet build ShapesWeb.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ShapesWeb.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ShapesWeb.dll"]
