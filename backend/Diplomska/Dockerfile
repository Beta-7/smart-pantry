FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Diplomska/Diplomska.csproj", "Diplomska/"]
RUN dotnet restore "Diplomska/Diplomska.csproj"
COPY . .
WORKDIR "/src/Diplomska"
RUN dotnet build "Diplomska.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Diplomska.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Diplomska.dll"]
