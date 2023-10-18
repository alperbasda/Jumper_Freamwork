#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Jumper.Creator.UI/Jumper.Creator.UI.csproj", "Jumper.Creator.UI/"]
RUN dotnet restore "Jumper.Creator.UI/Jumper.Creator.UI.csproj"
COPY . .
WORKDIR "/src/Jumper.Creator.UI"
RUN dotnet build "Jumper.Creator.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Jumper.Creator.UI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Jumper.Creator.UI.dll"]