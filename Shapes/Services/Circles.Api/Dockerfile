FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Services/Circles.Api/CirclesApi.csproj Services/Circles.Api/
RUN dotnet restore Services/Circles.Api/CirclesApi.csproj
COPY . .
WORKDIR /src/Services/Circles.Api
RUN dotnet build CirclesApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CirclesApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CirclesApi.dll"]
