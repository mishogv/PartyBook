FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 8000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PartyBook/Server/PartyBook.Server.csproj", "PartyBook/Server/"]
COPY ["PartyBook.Common/PartyBook.Common.csproj", "PartyBook.Common/"]
COPY ["PartyBook.Services.Mapping/PartyBook.Services.Mapping.csproj", "PartyBook.Services.Mapping/"]
COPY ["PartyBook/Shared/PartyBook.ViewModels.csproj", "PartyBook/Shared/"]
COPY ["PartyBook.Data.Common/PartyBook.Data.Common.csproj", "PartyBook.Data.Common/"]
COPY ["PartyBook/Client/PartyBook.Client.csproj", "PartyBook/Client/"]
RUN dotnet restore "PartyBook/Server/PartyBook.Server.csproj"
COPY . .
WORKDIR "/src/PartyBook/Server"
RUN dotnet build "PartyBook.Server.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "PartyBook.Server.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PartyBook.Server.dll"]