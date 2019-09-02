FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS http://*:5000

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Source/ApiGateway/ApiGatewayApp/ApiGatewayApp.csproj", "Source/ApiGateway/ApiGatewayApp/"]
RUN dotnet restore "Source/ApiGateway/ApiGatewayApp/ApiGatewayApp.csproj"
COPY . .
WORKDIR "/src/Source/ApiGateway/ApiGatewayApp"
RUN dotnet build "ApiGatewayApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ApiGatewayApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ApiGatewayApp.dll"]