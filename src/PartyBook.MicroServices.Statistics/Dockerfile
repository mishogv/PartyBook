FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PartyBook.MicroServices.Statistics/PartyBook.MicroServices.Statistics.csproj", "PartyBook.MicroServices.Statistics/"]
COPY ["PartyBook.Common/PartyBook.Common.csproj", "PartyBook.Common/"]
COPY ["PartyBook.Services.Mapping/PartyBook.Services.Mapping.csproj", "PartyBook.Services.Mapping/"]
COPY ["PartyBook/Shared/PartyBook.ViewModels.csproj", "PartyBook/Shared/"]
COPY ["PartyBook.Data.Common/PartyBook.Data.Common.csproj", "PartyBook.Data.Common/"]
RUN dotnet restore "PartyBook.MicroServices.Statistics/PartyBook.MicroServices.Statistics.csproj"
COPY . .
WORKDIR "/src/PartyBook.MicroServices.Statistics"
RUN dotnet build "PartyBook.MicroServices.Statistics.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "PartyBook.MicroServices.Statistics.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PartyBook.MicroServices.Statistics.dll"]