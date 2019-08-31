FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Source/Services/Card/Card.API/Card.API.csproj", "Source/Services/Card/Card.API/"]
RUN dotnet restore "Source/Services/Card/Card.API/Card.API.csproj"
COPY . .
WORKDIR "/src/Source/Services/Card/Card.API"
RUN dotnet build "Card.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Card.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Card.API.dll"]