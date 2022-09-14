#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/nightly/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/nightly/sdk:6.0 AS build
WORKDIR /src
COPY ["JNGV.TALKDESK.TESTS/JNGV.TALKDESK.TESTS.csproj", "JNGV.TALKDESK.TESTS/"]
COPY ["JNGV.TALKDESK.API/JNGV.TALKDESK.API.csproj", "JNGV.TALKDESK.API/"]
COPY ["JNGV.TALKDESK.DOMAIN/JNGV.TALKDESK.DOMAIN.csproj", "JNGV.TALKDESK.DOMAIN/"]
RUN dotnet restore "JNGV.TALKDESK.TESTS/JNGV.TALKDESK.TESTS.csproj"
COPY . .
WORKDIR "/src/JNGV.TALKDESK.TESTS"
RUN dotnet build "JNGV.TALKDESK.TESTS.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JNGV.TALKDESK.TESTS.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JNGV.TALKDESK.TESTS.dll"]