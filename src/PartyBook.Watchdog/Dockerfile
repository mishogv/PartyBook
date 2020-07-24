FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PartyBook.Watchdog/PartyBook.Watchdog.csproj", "PartyBook.Watchdog/"]
RUN dotnet restore "PartyBook.Watchdog/PartyBook.Watchdog.csproj"
COPY . .
WORKDIR "/src/PartyBook.Watchdog"
RUN dotnet build "PartyBook.Watchdog.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "PartyBook.Watchdog.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PartyBook.Watchdog.dll"]