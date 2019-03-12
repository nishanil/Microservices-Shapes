FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ApiGateway/Shapes.ApiGateway/ShapesApiGateway.csproj ApiGateway/Shapes.ApiGateway/
RUN dotnet restore ApiGateway/Shapes.ApiGateway/ShapesApiGateway.csproj
COPY . .
WORKDIR /src/ApiGateway/Shapes.ApiGateway
RUN dotnet build ShapesApiGateway.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ShapesApiGateway.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ShapesApiGateway.dll"]
