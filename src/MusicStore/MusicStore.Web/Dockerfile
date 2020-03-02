FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MusicStore.Web/MusicStore.Web.csproj", "MusicStore.Web/"]
COPY ["MusicStore.Services/MusicStore.Services.csproj", "MusicStore.Services/"]
COPY ["MusicStore.Data/MusicStore.Data.csproj", "MusicStore.Data/"]
COPY ["MusicStore.Shared/MusicStore.Shared.csproj", "MusicStore.Shared/"]
RUN dotnet restore "MusicStore.Web/MusicStore.Web.csproj"
COPY . .
WORKDIR "/src/MusicStore.Web"
RUN dotnet build "MusicStore.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MusicStore.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MusicStore.Web.dll"]