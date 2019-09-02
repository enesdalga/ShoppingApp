FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5001
ENV ASPNETCORE_URLS http://*:5001

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Source/Services/Cart/Cart.API/Cart.API.csproj", "Source/Services/Cart/Cart.API/"]
COPY ["Source/Services/Cart/Cart.Domain/Cart.Domain.csproj", "Source/Services/Cart/Cart.Domain/"]
COPY ["Source/Services/Cart/Cart.Infrastructure/Cart.Infrastructure.csproj", "Source/Services/Cart/Cart.Infrastructure/"]

RUN dotnet restore "Source/Services/Cart/Cart.API/Cart.API.csproj"

COPY . .
WORKDIR "/src/Source/Services/Cart/Cart.API"
RUN dotnet build "Cart.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Cart.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Cart.API.dll"]