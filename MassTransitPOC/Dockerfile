FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MassTransitPOC/MassTransitPOC.csproj", "MassTransitPOC/"]
RUN dotnet restore "MassTransitPOC/MassTransitPOC.csproj"
COPY . .
WORKDIR "/src/MassTransitPOC"
RUN dotnet build "MassTransitPOC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MassTransitPOC.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MassTransitPOC.dll"]
