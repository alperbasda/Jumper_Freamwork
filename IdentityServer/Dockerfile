#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src


COPY ["Identity/NugetPackages/EsterOfis.EntityBase.3.0.0.3.nupkg","Identity/NugetPackages/"]
COPY ["Identity/NugetPackages/EsterOfis.RabbitMqAdapter.3.0.0.5.nupkg","Identity/NugetPackages/"]
COPY ["Identity/NugetPackages/EsterOfis.UIHelpers.3.0.0.7.nupkg","Identity/NugetPackages/"]
COPY ["Identity/NugetPackages/EsterOfis.JwtHelpers.3.0.0.3.nupkg","Identity/NugetPackages/"]
COPY ["Identity/NugetPackages/EsterOfis.ExpressionBuilder.3.0.0.3.nupkg","Identity/NugetPackages/"]
COPY ["Identity/NugetPackages/EsterOfis.FluentValidationWrapper.3.0.0.3.nupkg","Identity/NugetPackages/"]
COPY ["Identity/NugetPackages/EsterOfis.AutoMapperWrapper.3.0.0.3.nupkg","Identity/NugetPackages/"]
COPY ["Identity/NugetPackages/EsterOfis.DbServerBase.3.0.0.3.nupkg","Identity/NugetPackages/"]
COPY ["Identity/NugetPackages/EsterOfis.MsSqlAdapter.3.0.0.5.nupkg","Identity/NugetPackages/"]
COPY ["Identity/NugetPackages/EsterOfis.Tools.3.0.0.3.nupkg","Identity/NugetPackages/"]

COPY ["nuget.Config", "Identity/"]
COPY ["nuget.Config", ""]

COPY ["Identity/IdentityServer/IdentityServer.csproj", "Identity/IdentityServer/"]

COPY ["Identity/IdentityServer.Business/IdentityServer.Business.csproj", "Identity/IdentityServer.Business/"]

COPY ["Identity/IdentityServer.DataAccess/IdentityServer.DataAccess.csproj", "Identity/IdentityServer.DataAccess/"]

COPY ["Identity/IdentityServer.Entities/IdentityServer.Entities.csproj", "Identity/IdentityServer.Entities/"]

COPY ["Identity/IdentityServer.Events/IdentityServer.Events.csproj", "Identity/IdentityServer.Events/"]

RUN dotnet restore "Identity/IdentityServer/IdentityServer.csproj" --configfile nuget.Config --ignore-failed-sources

COPY . .
WORKDIR "/src/Identity/IdentityServer"
RUN dotnet build "IdentityServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityServer.dll"]