FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ../../services/base-service/src/SnyderApps.BaseService.Client ./App
WORKDIR "/src/App"
RUN dotnet restore "SnyderApps.BaseService.Client.csproj"
RUN dotnet build "SnyderApps.BaseService.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SnyderApps.BaseService.Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SnyderApps.BaseService.Client.dll"]