FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /
COPY ../../gateways/web/src/SnyderApps.WebGateway ./gateways/web/src/SnyderApps.WebGateway
COPY ../../shared ./shared

WORKDIR "/gateways/web/src/SnyderApps.WebGateway"
RUN dotnet restore "SnyderApps.WebGateway.csproj"
RUN dotnet build "SnyderApps.WebGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SnyderApps.WebGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SnyderApps.WebGateway.dll"]