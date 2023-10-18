#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CodeGenerator/Jumper.CodeGenerator.Api/Jumper.CodeGenerator.Api.csproj", "CodeGenerator/Jumper.CodeGenerator.Api/"]
RUN dotnet restore "CodeGenerator/Jumper.CodeGenerator.Api/Jumper.CodeGenerator.Api.csproj"
COPY . .
WORKDIR "/src/CodeGenerator/Jumper.CodeGenerator.Api"
RUN dotnet build "Jumper.CodeGenerator.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Jumper.CodeGenerator.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Jumper.CodeGenerator.Api.dll"]