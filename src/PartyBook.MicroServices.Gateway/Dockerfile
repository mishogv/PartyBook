#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PartyBook.MicroServices.Gateway/PartyBook.MicroServices.Gateway.csproj", "PartyBook.MicroServices.Gateway/"]
COPY ["PartyBook.Common/PartyBook.Common.csproj", "PartyBook.Common/"]
COPY ["PartyBook.Services.Mapping/PartyBook.Services.Mapping.csproj", "PartyBook.Services.Mapping/"]
COPY ["PartyBook/Shared/PartyBook.ViewModels.csproj", "PartyBook/Shared/"]
COPY ["PartyBook.Data.Common/PartyBook.Data.Common.csproj", "PartyBook.Data.Common/"]
COPY ["PartyBook.Configurations/PartyBook.Configurations.csproj", "PartyBook.Configurations/"]
RUN dotnet restore "PartyBook.MicroServices.Gateway/PartyBook.MicroServices.Gateway.csproj"
COPY . .
WORKDIR "/src/PartyBook.MicroServices.Gateway"
RUN dotnet build "PartyBook.MicroServices.Gateway.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "PartyBook.MicroServices.Gateway.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PartyBook.MicroServices.Gateway.dll"]