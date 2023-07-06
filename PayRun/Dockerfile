FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PayRunService/PayRunService.csproj", "PayRunService/"]
RUN dotnet restore "PayRunService/PayRunService.csproj"
COPY . .
WORKDIR "/src/PayRunService"
RUN dotnet build "PayRunService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PayRunService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PayRunService.dll"]
