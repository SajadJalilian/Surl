FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Surl/Surl.csproj", "Surl/"]
RUN dotnet restore "Surl/Surl.csproj"
COPY . .
WORKDIR "/src/Surl"
RUN dotnet build "Surl.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Surl.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Surl.dll"]
