#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["JNGV.TALKDESK.API/JNGV.TALKDESK.API.csproj", "JNGV.TALKDESK.API/"]
COPY ["JNGV.TALKDESK.DOMAIN/JNGV.TALKDESK.DOMAIN.csproj", "JNGV.TALKDESK.DOMAIN/"]
RUN dotnet restore "JNGV.TALKDESK.API/JNGV.TALKDESK.API.csproj"
COPY . .
WORKDIR "/src/JNGV.TALKDESK.API"
COPY ["JNGV.TALKDESK.API/Resources/Files/prefixes.txt", "Resources/Files/"]
RUN dotnet build "JNGV.TALKDESK.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JNGV.TALKDESK.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY ["JNGV.TALKDESK.API/Resources/Files/prefixes.txt", "Resources/Files/"]
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JNGV.TALKDESK.API.dll"]